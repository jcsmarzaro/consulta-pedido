using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.Serialization.Json;
using System.Net.Http.Headers;
using System.Xml;

namespace ConsultaPedidoOperacao.ClassesUtil
{
    public static class HttpHelper
    {
        //private static readonly string apiBasicUri = ConfigurationManager.AppSettings["apiBasicUri"];
        private static readonly string apiBasicUri = "http://millennium.selia.com.br:6017/api/login";

        public static async Task<String> Post<T>(string url, T contentValue, string formato = "Json")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");

                var byteArray = Encoding.ASCII.GetBytes("selia:selia@3213");
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var result = await client.PostAsync(url, content);
                result.EnsureSuccessStatusCode();

                string resultContentString = await result.Content.ReadAsStringAsync();

                //Converter o json em xml
                if (formato == "xml")
                {
                    XmlDocument doc = JsonConvert.DeserializeXmlNode(resultContentString);

                    resultContentString = doc.InnerText;
                }
                //try
                //{
                //    resultContentString = resultContentString.Remove(resultContentString.Length - 1).Replace("{" + '\u0022' + "order" + '\u0022' + ":", "");
                //}
                //catch { }


                return resultContentString;
            }
        }
        public static async Task Put<T>(string url, T stringValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(stringValue), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(url, content);
                result.EnsureSuccessStatusCode();
            }
        }
        public static async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                //header
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("wts-authorization", "INTERNO/!@INT");
                client.DefaultRequestHeaders.Add("wts-licencetype", "API");
                //fim header

                client.BaseAddress = new Uri(apiBasicUri);
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();

                try
                {
                    T resul = JsonConvert.DeserializeObject<T>(resultContentString);
                    return resul;
                }
                catch
                {

                }
                T res = JsonConvert.DeserializeObject<T>(resultContentString);
                return res;
            }
        }

        public static async Task<String> GetMillennium<T>(string url, string pedido, string formato, string token)
        {
            using (var client = new HttpClient())
            {
                //header
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("wts-session", token.ToString());
                client.DefaultRequestHeaders.Add("wts-licensetype", "API");
                //fim header
                //Parametros

                //
                client.BaseAddress = new Uri(apiBasicUri);
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();

                try
                {
                    String resul = resultContentString.ToString();
                    //T resul = JsonConvert.DeserializeObject<T>(resultContentString);
                    return resul;
                }
                catch
                {

                }
                String res = "";
                return res;
            }
        }

        public static async Task Delete(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var result = await client.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
            }
        }
    }
}
