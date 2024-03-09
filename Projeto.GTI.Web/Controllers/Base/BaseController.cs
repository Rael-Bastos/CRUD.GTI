using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Projeto.GTI.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;

        public IConfiguration GetConfiguration
        {
            get { return _configuration; }
        }
        public BaseController() { }
        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<T> GetApi<T>(string requestUri)
        {
            using (var handler = new HttpClientHandler())
            {

                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var httpClient = new HttpClient(handler))
                {

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(requestUri))
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                        var responseMessage = await response.Content.ReadAsStringAsync();

                        throw new Exception(responseMessage);
                    }
                }
            }
        }

        public async Task<T> DeleteApi<T>(string requestUri)
        {
            using (var handler = new HttpClientHandler())
            {

                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var httpClient = new HttpClient(handler))
                {

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.DeleteAsync(requestUri))
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                        var responseMessage = await response.Content.ReadAsStringAsync();

                        throw new Exception(responseMessage);
                    }
                }
            }
        }
        public async Task<TReturn> PostApi<TReturn, TInput>(string requestUri, TInput parameters)
        {
            using (var handler = new HttpClientHandler())
            {

                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    using (var response = await httpClient.PostAsJsonAsync(requestUri, parameters))
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<TReturn>(response.Content.ReadAsStringAsync().Result);

                        var responseMessage = await response.Content.ReadAsStringAsync();

                        throw new Exception(responseMessage);
                    }
                }
            }
        }

        public async Task<TReturn> PutApi<TReturn, TInput>(string requestUri, TInput parameters)
        {
            using (var handler = new HttpClientHandler())
            {

                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    using (var response = await httpClient.PutAsJsonAsync(requestUri, parameters))
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<TReturn>(response.Content.ReadAsStringAsync().Result);

                        var responseMessage = await response.Content.ReadAsStringAsync();

                        throw new Exception(responseMessage);
                    }
                }
            }
        }

    }
}
