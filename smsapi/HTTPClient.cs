using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SMSApi.Api
{

    public class HTTPClient
    {

        public String BaseUrl { get; }

        Credentials basicAuthentication;

        public HTTPClient(String baseUrl) 
        {
            this.BaseUrl = baseUrl;
        }

        protected Stream PrepareContent(NameValueCollection data)
        {

            var stream     = new MemoryStream();
            var enumerator = data.GetEnumerator();
            enumerator.Reset();

            int count = data.Keys.Count;

            foreach (string key in data.Keys)
            {
                var param = Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(data[key]) + "&";
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

        protected Stream PrepareMultipartContent(string boundary, NameValueCollection data, Dictionary<string, Stream> files)
        {

            var stream     = new MemoryStream();
            var enumerator = data.GetEnumerator();
            enumerator.Reset();

            var template = Environment.NewLine + "--" + boundary + Environment.NewLine + "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}";

            foreach (string key in data.Keys)
            {
                var param = string.Format(template, key, data[key]);
                var bytes = System.Text.Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);
            }

            template = Environment.NewLine + "--" + boundary + Environment.NewLine +
                           "Content-Disposition: form-data; name=\"{0}\"; filename=\"{0}\"" + Environment.NewLine +
                           "Content-Type: application/octet-stream" + Environment.NewLine + Environment.NewLine;

            foreach(var file in files)
            {

                var param = String.Format(template, file.Key);
                var bytes = System.Text.Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);

                var fileStream = file.Value;
                fileStream.Position = 0;
                var buffer    = new byte[1024];
                var bytesRead = 0;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    stream.Write(buffer, 0, bytesRead);

            }

            var footBytes = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + "--");
            stream.Write(footBytes, 0, footBytes.Length);

            stream.Position = 0;

            return stream;

        }

        public Stream Execute(String uri, NameValueCollection data, RequestMethods method = RequestMethods.POST)
            => Execute(uri,
                       data,
                       new Dictionary<String, Stream>(),
                       method);

        public Stream Execute(String uri, NameValueCollection data, Stream file, RequestMethods method = RequestMethods.POST)
            => Execute(uri,
                       data,
                       new Dictionary<String, Stream> {
                           { "file", file }
                       },
                       method);

        public Stream Execute(String uri, NameValueCollection data, Dictionary<String, Stream> files, RequestMethods method = RequestMethods.POST)
        {

            var boundary = "SMSAPI-" + DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + (new Random()).Next(int.MinValue, int.MaxValue).ToString() + "-boundary";

            var webRequest = WebRequest.Create(BaseUrl + uri);
            webRequest.Method = RequestMethodToString(method);

            if (basicAuthentication != null)
                webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(basicAuthentication.Username + ":" + basicAuthentication.Password)));

            if (RequestMethods.POST.Equals(method) || RequestMethods.PUT.Equals(method))
            {

                Stream stream;

                if (files != null && files.Count > 0)
                {
                    webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
                    stream = PrepareMultipartContent(boundary, data, files);
                }

                else
                {
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    stream = PrepareContent(data);
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
                    throw new ProxyException(e.Message, e);
                }

            }

            var response = new MemoryStream();

            try
            {
                CopyStream(webRequest.GetResponse().GetResponseStream(), response);
            }
            catch (WebException e)
            {
                throw new ProxyException("Failed to get response from " + webRequest.RequestUri.ToString(), e);
            }

            response.Position = 0;
            return response;

        }

        private void CopyStream(Stream input, Stream output)
        {

            var buffer = new byte[2048];
            int read;

            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                output.Write(buffer, 0, read);

        }

        public void BasicAuthentication(Credentials client)
        {
            basicAuthentication = client;
        }

        public static string RequestMethodToString(RequestMethods method)
        {
            switch(method)
            {
                case RequestMethods.GET:
                    return "GET";
                case RequestMethods.PUT:
                    return "PUT";
                case RequestMethods.POST:
                    return "POST";
                case RequestMethods.DELETE:
                    return "DELETE";
                default:
                    throw new ProxyException("Invalid request method");
            }
        }

    }

}
