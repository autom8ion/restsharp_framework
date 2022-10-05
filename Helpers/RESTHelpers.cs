using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Configuration;
using System.Net;

namespace RESTSharpFW.Helpers
{
    public class RESTHelpers
    {
        public static IRestResponse Request(Method method, string url, string resource, List<HttpHeader> headers = null,
            CookieCollection cookieCollection = null, JObject body = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(url);

            var request = new RestRequest(resource, method);

            //Add Headers if they exist
            if (headers != null)
            {
                foreach (HttpHeader header in headers)
                {
                    request.AddHeader(header.Name, header.Value);
                }
            }

            //Add Cookies if they exist
            if (cookieCollection != null)
            {
                foreach (Cookie cookie in cookieCollection)
                {
                    request.AddCookie(cookie.Name, cookie.Value);
                }
            }

            //Add the body if it Exists
            if (body != null)
            {
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            // execute the request
            var response = client.Execute(request);

            return response;

        }

        public static IRestResponse Request(Method method, string url, string resource, string userName, string password,
            List<HttpHeader> headers = null, CookieCollection cookieCollection = null, JObject body = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var request = new RestRequest(resource, method);

            //Add Headers if they exist
            if (headers != null)
            {
                foreach (HttpHeader header in headers)
                {
                    request.AddHeader(header.Name, header.Value);
                }
            }

            //Add Cookies if they exist
            if (cookieCollection != null)
            {
                foreach (Cookie cookie in cookieCollection)
                {
                    request.AddCookie(cookie.Name, cookie.Value);
                }
            }

            //Add the body if it Exists
            if (body != null)
            {
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            // execute the request
            var response = client.Execute(request);

            return response;

        }

        public static IRestResponse Request(Method method, string url, string resource, string token,
            List<HttpHeader> headers = null, CookieCollection cookieCollection = null, JObject body = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(url);

            var request = new RestRequest(resource, method);

            request.AddQueryParameter("token", token);

            //Add Headers if they exist
            if (headers != null)
            {
                foreach (HttpHeader header in headers)
                {
                    request.AddHeader(header.Name, header.Value);
                }
            }

            //Add Cookies if they exist
            if (cookieCollection != null)
            {
                foreach (Cookie cookie in cookieCollection)
                {
                    request.AddCookie(cookie.Name, cookie.Value);
                }
            }

            //Add the body if it Exists
            if (body != null)
            {
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            // execute the request
            var response = client.Execute(request);

            return response;

        }

        public static IRestResponse RequestOAUTH(Method method, string url, string resource, string client_ID,
            string redirect_URI, string response_type, string scope, List<HttpHeader> headers = null, 
            CookieCollection cookieCollection = null, JObject body = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(url);

            var request = new RestRequest(resource, method);

            //Pass OAUTH params from app.config
            request.AddQueryParameter("client_id", client_ID);
            request.AddQueryParameter("redirect_uri", redirect_URI);
            request.AddQueryParameter("response_type", response_type);
            request.AddQueryParameter("scope", scope);

            //Add Headers if they exist
            if (headers != null)
            {
                foreach (HttpHeader header in headers)
                {
                    request.AddHeader(header.Name, header.Value);
                }
            }

            //Add Cookies if they exist
            if (cookieCollection != null)
            {
                foreach (Cookie cookie in cookieCollection)
                {
                    request.AddCookie(cookie.Name, cookie.Value);
                }
            }

            //Add the body if it Exists
            if (body != null)
            {
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            // execute the request
            var response = client.Execute(request);

            return response;

        }

        public static void ValidatiteStatusCode(IRestResponse response, HttpStatusCode statusCode)
        {
            response.StatusCode.Should().Be(statusCode);
        }



    }
}
