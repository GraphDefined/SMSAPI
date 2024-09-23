/*
 * Copyright (c) 2017-2024 GraphDefined GmbH <achim.friedland@graphdefined.com>
 * This file is part of GraphDefined SMSAPI <https://github.com/GraphDefined/SMSAPI>
 *   based on original work of SMSAPI!
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System.Net;
using System.Net.Security;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization.Json;
using System.Security.Authentication;

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;
using org.GraphDefined.Vanaheimr.Illias;
using com.GraphDefined.SMSApi.API.Response;

#endregion

namespace com.GraphDefined.SMSApi.API
{

    public delegate Task OnSendSMSAPIRequestDelegate (DateTime                        LogTimestamp,
                                                      SMSAPIClient                    Sender,
                                                      EventTracking_Id                EventTrackingId,
                                                      String                          Command,
                                                      JObject                         Data,
                                                      TimeSpan?                       RequestTimeout);

    public delegate Task OnSendSMSAPIResponseDelegate(DateTime                        LogTimestamp,
                                                      SMSAPIClient                    Sender,
                                                      EventTracking_Id                EventTrackingId,
                                                      String                          Command,
                                                      JObject                         Data,
                                                      TimeSpan?                       RequestTimeout,
                                                      SMSAPIResponseStatus            Result,
                                                      TimeSpan                        Runtime);


    /// <summary>
    /// A SMSAPI HTTP client.
    /// </summary>
    public class SMSAPIClient : AHTTPClient
    {

        #region Data

        /// <summary>
        /// The default HTTP user agent.
        /// </summary>
        public new const String  DefaultHTTPUserAgent  = "GraphDefined SMSAPI Client v0.3";

        #endregion

        #region Properties

        /// <summary>
        /// API authentication (send within the payload).
        /// </summary>
        public Credentials?  Credentials            { get; }

        /// <summary>
        /// API credentials for HTTP basic authentication.
        /// </summary>
        public Credentials?  BasicAuthentication    { get; }

        #endregion

        #region Events

        public event OnSendSMSAPIRequestDelegate?   OnSendSMSAPIRequest;

        public event OnSendSMSAPIResponseDelegate?  OnSendSMSAPIResponse;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new SMSAPI HTTP client.
        /// </summary>
        /// <param name="RemoteURL">The remote URL of the OICP HTTP endpoint to connect to.</param>
        /// <param name="VirtualHostname">An optional HTTP virtual hostname.</param>
        /// <param name="Description">An optional description of this CPO client.</param>
        /// <param name="RemoteCertificateValidator">The remote TLS certificate validator.</param>
        /// <param name="HTTPUserAgent">The HTTP user agent identification.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        /// <param name="RequestTimeout">An optional request timeout.</param>
        /// <param name="TransmissionRetryDelay">The delay between transmission retries.</param>
        /// <param name="MaxNumberOfRetries">The maximum number of transmission retries for HTTP request.</param>
        /// <param name="DNSClient">The DNS client to use.</param>
        public SMSAPIClient(URL?                                  RemoteURL                    = null,
                            HTTPHostname?                         VirtualHostname              = null,
                            I18NString?                           Description                  = null,
                            Boolean?                              PreferIPv4                   = null,
                            RemoteCertificateValidationCallback?  RemoteCertificateValidator   = null,
                            SslProtocols?                         TLSProtocol                  = null,
                            String                                HTTPUserAgent                = DefaultHTTPUserAgent,
                            Credentials?                          BasicAuthentication          = null,
                            Credentials?                          Credentials                  = null,
                            TimeSpan?                             RequestTimeout               = null,
                            TransmissionRetryDelayDelegate?       TransmissionRetryDelay       = null,
                            UInt16?                               MaxNumberOfRetries           = null,
                            UInt32?                               InternalBufferSize           = null,
                            Boolean?                              DisableLogging               = false,
                            DNSClient?                            DNSClient                    = null)

            : base(RemoteURL     ?? URL.Parse("https://api.smsapi.com/api/"),
                   VirtualHostname,
                   Description,
                   PreferIPv4,
                   RemoteCertificateValidator is null
                       ? null
                       : (sender,
                          certificate,
                          chain,
                          server,
                          policyErrors) => (RemoteCertificateValidator(sender,
                                                                       certificate,
                                                                       chain,
                                                                       policyErrors),
                                            Array.Empty<String>()),
                   null,
                   null,
                   TLSProtocol,
                   null,
                   null,
                   null,
                   HTTPUserAgent ?? DefaultHTTPUserAgent,
                   ConnectionType.Close,
                   RequestTimeout,
                   TransmissionRetryDelay,
                   MaxNumberOfRetries,
                   InternalBufferSize,
                   false,
                   DisableLogging,
                   null,
                   DNSClient)

        {

            this.BasicAuthentication  = BasicAuthentication;
            this.Credentials          = Credentials;

        }

        #endregion


        #region (protected) PrepareContent(Data)

        protected Stream PrepareContent(NameValueCollection Data)
        {

            var stream     = new MemoryStream();
            var enumerator = Data.GetEnumerator();
            enumerator.Reset();

            int count = Data.Keys.Count;

            foreach (string key in Data.Keys)
            {
                var param = Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(Data[key]) + "&";
                var bytes = System.Text.Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);
            }

            if (stream.Length > 0)
            {
                //remove the "&" at the end
                stream.SetLength(stream.Length - 1);
            }

            stream.Position = 0;

            return stream;

        }

        #endregion

        #region (protected) PrepareMultipartContent(MIMEBoundary, Data, Files = null)

        protected Stream PrepareMultipartContent(String                      MIMEBoundary,
                                                 NameValueCollection         Data,
                                                 Dictionary<String, Stream>  Files  = null)
        {

            var stream     = new MemoryStream();
            var enumerator = Data.GetEnumerator();
            enumerator.Reset();

            var template = Environment.NewLine + "--" + MIMEBoundary + Environment.NewLine + "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}";

            foreach (string key in Data.Keys)
            {
                var param = string.Format(template, key, Data[key]);
                var bytes = System.Text.Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);
            }

            template = Environment.NewLine + "--" + MIMEBoundary + Environment.NewLine +
                           "Content-Disposition: form-data; name=\"{0}\"; filename=\"{0}\"" + Environment.NewLine +
                           "Content-Type: application/octet-stream" + Environment.NewLine + Environment.NewLine;

            if (Files != null)
            {
                foreach (var file in Files)
                {

                    var param = String.Format(template, file.Key);
                    var bytes = System.Text.Encoding.UTF8.GetBytes(param);
                    stream.Write(bytes, 0, bytes.Length);

                    var fileStream = file.Value;
                    fileStream.Position = 0;
                    var buffer = new byte[1024];
                    var bytesRead = 0;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        stream.Write(buffer, 0, bytesRead);

                }
            }

            var footBytes = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine + "--" + MIMEBoundary + "--");
            stream.Write(footBytes, 0, footBytes.Length);

            stream.Position = 0;

            return stream;

        }

        #endregion


        #region (private) ResponseToObject<TT>(ResultStream)

        private TT ResponseToObject<TT>(Stream ResultStream)
        {

            TT result;

            var uu = (ResultStream as MemoryStream).ToArray();
            var aa = Encoding.UTF8.GetString(uu, 0, uu.Length);


            if (ResultStream.Length > 0)
            {
                ResultStream.Position = 0;
                var serializer = new DataContractJsonSerializer(typeof(TT));
                result = (TT) serializer.ReadObject(ResultStream);
                ResultStream.Position = 0;
            }

            else
                result = Activator.CreateInstance<TT>();

            return result;

        }

        #endregion

        #region (private) HandleError(ResultStream)

        private Tuple<Int32, String> HandleError(Stream ResultStream)
        {

            var result = new Tuple<Int32, String>(-1, "DeSerializationException");

            ResultStream.Position = 0;

            try
            {

                var error = ResponseToObject<Error>(ResultStream);

                if (error.Code != 0)
                    result = new Tuple<Int32, String>(error.Code, error.Message);

            }
            catch
            { }

            ResultStream.Position = 0;

            return result;

        }

        #endregion

        #region IsClientError(Code)

        /// <summary>
        /// Whether the result code is a client error.
        /// </summary>
        /// <param name="Code">The result code.</param>
        public Boolean IsClientError(Int32 Code)

            => Code ==  101 ||  // Niepoprawne lub brak danych autoryzacji.
               Code ==  102 ||  // Nieprawidłowy login lub hasło
               Code ==  103 ||  // Brak punków dla tego użytkownika
               Code ==  105 ||  // Błędny adres IP
               Code ==  110 ||  // Usługa nie jest dostępna na danym koncie
               Code == 1000 ||  // Akcja dostępna tylko dla użytkownika głównego
               Code == 1001;    // Nieprawidłowa akcja

        #endregion

        #region IsServerError(Code)

        /// <summary>
        /// Whether the result code is a server error.
        /// </summary>
        /// <param name="Code">The result code.</param>
        public Boolean IsServerError(Int32 Code)

            => Code ==   8 ||  // Błąd w odwołaniu
               Code == 201 ||  // Wewnętrzny błąd systemu
               Code == 666 ||  // Wewnętrzny błąd systemu
               Code == 999;    // Wewnętrzny błąd systemu

        #endregion


        #region Execute(Command, Data, ...)

        /// <summary>
        /// Exceute the given SMSAPI command.
        /// </summary>
        /// <param name="Command">The SMSAPI command.</param>
        /// <param name="Data">The data of the SMSAPI command.</param>
        /// <param name="File">An optional file to send.</param>
        /// <param name="HTTPMethod">The HTTP method to use.</param>
        public Task<Stream> Execute(String               Command,
                                    NameValueCollection  Data,
                                    Stream               File,
                                    RequestMethods       HTTPMethod = RequestMethods.POST)

            => Execute(Command,
                       Data,
                       new Dictionary<String, Stream> {
                           { "file", File }
                       },
                       HTTPMethod);


        /// <summary>
        /// Exceute the given SMSAPI command.
        /// </summary>
        /// <param name="Command">The SMSAPI command.</param>
        /// <param name="Data">The data of the SMSAPI command.</param>
        /// <param name="Files">Optional files to send.</param>
        /// <param name="HTTPMethod">The HTTP method to use.</param>
        public async Task<Stream> Execute(String                       Command,
                                          NameValueCollection          Data,
                                          Dictionary<String, Stream>?  Files       = null,
                                          RequestMethods               HTTPMethod  = RequestMethods.POST)
        {

            #region Init

            var EventTrackingId  = EventTracking_Id.New;
            var RequestTimeout   = TimeSpan.FromSeconds(60);
            var JSONData         = new JObject();
            var values           = new String[0];

            foreach (var key in Data.AllKeys)
            {

                values = Data.GetValues(key);

                if (values.Length == 1)
                    JSONData[key] = values[0];

                if (values.Length > 1)
                    JSONData[key] = new JArray(values);

            }

            MemoryStream         response        = new MemoryStream();
            SMSAPIResponseStatus responseStatus  = null;

            #endregion

            #region Send OnSendSMSAPIRequest event

            var StartTime = org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            try
            {

                if (OnSendSMSAPIRequest != null)
                    await Task.WhenAll(OnSendSMSAPIRequest.GetInvocationList().
                                        Cast<OnSendSMSAPIRequestDelegate>().
                                        Select(e => e(StartTime,
                                                      this,
                                                      EventTrackingId,
                                                      Command,
                                                      JSONData,
                                                      RequestTimeout))).
                                        ConfigureAwait(false);

            }
            catch (Exception e)
            {
                DebugX.Log(e, nameof(SMSAPIClient) + "." + nameof(OnSendSMSAPIRequest));
            }

            #endregion


            try
            {

                var boundary = "SMSAPI-" + DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + new Random().Next(int.MinValue, int.MaxValue).ToString() + "-boundary";

                var webRequest = WebRequest.Create(RemoteURL.ToString() + Command);
                webRequest.Method = HTTPMethod.RequestMethodToString();

                if (BasicAuthentication != null)
                    webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(BasicAuthentication.Username + ":" + BasicAuthentication.Password)));

                #region POST | PUT

                if (RequestMethods.POST.Equals(HTTPMethod) || RequestMethods.PUT.Equals(HTTPMethod))
                {

                    Stream stream;

                    if (Files != null && Files.Count > 0)
                    {
                        webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
                        stream = PrepareMultipartContent(boundary, Data, Files);
                    }

                    else
                    {
                        webRequest.ContentType = "application/x-www-form-urlencoded";
                        stream = PrepareContent(Data);
                    }

                    webRequest.ContentLength = stream.Length;

                    try
                    {
                        stream.Position = 0;
                        CopyStream(stream, webRequest.GetRequestStream());
                        stream.Close();
                    }
                    catch (WebException e)
                    {
                        throw new HTTPClientException(e.Message, e);
                    }

                }

                #endregion

                try
                {
                    CopyStream((await webRequest.GetResponseAsync()).GetResponseStream(), response);
                }
                catch (WebException e)
                {
                    throw new HTTPClientException("Failed to get response from " + webRequest.RequestUri.ToString(), e);
                }

                response.Position = 0;

                responseStatus = ResponseToObject<SMSAPIResponseStatus>(response);

            }
            catch (Exception e)
            {
                responseStatus = SMSAPIResponseStatus.Failed(e);
            }


            #region Send OnSendSMSAPIResponse event

            var Endtime = org.GraphDefined.Vanaheimr.Illias.Timestamp.Now;

            try
            {

                if (OnSendSMSAPIResponse != null)
                    await Task.WhenAll(OnSendSMSAPIResponse.GetInvocationList().
                                       Cast<OnSendSMSAPIResponseDelegate>().
                                       Select(e => e(Endtime,
                                                     this,
                                                     EventTrackingId,
                                                     Command,
                                                     JSONData,
                                                     RequestTimeout,
                                                     responseStatus,
                                                     Endtime - StartTime))).
                                       ConfigureAwait(false);

            }
            catch (Exception e)
            {
                DebugX.Log(e, nameof(SMSAPIClient) + "." + nameof(OnSendSMSAPIResponse));
            }

            #endregion

            return response;

        }

        #endregion


        #region (private) CopyStream(Input, Output, BufferSize = 2048)

        private void CopyStream(Stream  Input,
                                Stream  Output,
                                UInt32  BufferSize = 2048)
        {

            var buffer = new Byte[BufferSize];
            int read;

            while ((read = Input.Read(buffer, 0, buffer.Length)) > 0)
                Output.Write(buffer, 0, read);

        }

        #endregion


        #region Dispose()

        /// <summary>
        /// Dispose this object.
        /// </summary>
        public void Dispose()
        { }

        #endregion

    }

}
