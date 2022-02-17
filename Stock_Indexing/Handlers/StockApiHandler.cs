using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Script.Serialization;

namespace Stock_Indexing.Handlers
{
    public class StockApiHandler
    {      
        public decimal GetStockDataByTicker(string ticker, IList<string> cachKeys)
        {
            decimal stockPrice = 0;
            try
            {
                var cachedValue = GetCacheValue(ticker);
                if (cachedValue != null)
                {
                    stockPrice = decimal.Parse(cachedValue);
                    return stockPrice;
                }
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ConfigurationManager.AppSettings["StockAPIBaseUri"] + ticker),
                    Headers =
                        {
                            { "x-rapidapi-host", "yh-finance.p.rapidapi.com" },
                            { "x-rapidapi-key", ConfigurationManager.AppSettings["StockAPIKey"] },
                        },
                };
             /*   using (var response = await client.SendAsync(request))
                {
                    //response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var serializer = new JavaScriptSerializer();
                    dynamic usr = serializer.DeserializeObject(body);

                    try
                    {
                        stockPrice = decimal.Parse(usr["price"]["postMarketPrice"]["fmt"]);
                    }
                    catch (Exception e)
                    {
                        stockPrice = 0;
                    }
                }*/
                using (var response = client.SendAsync(request))
                {
                    var body = response.Result.Content.ReadAsStringAsync();
                    //Console.WriteLine(body);
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var serializer = new JavaScriptSerializer();
                        dynamic usr = serializer.DeserializeObject(body.Result);

                        try
                        {
                            stockPrice = decimal.Parse(usr["price"]["postMarketPrice"]["fmt"]);
                        }
                        catch(Exception e)
                        {
                            stockPrice = 0;
                        }
                    }
                }
                if(cachKeys.Contains(ticker))
                {
                    SetCacheValue(ticker, stockPrice.ToString());
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                String errorText;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    errorText = reader.ReadToEnd();
                    // Log errorText
                }
                throw new Exception(errorText);
            }
            return stockPrice;
           
        }

        private static string GetCacheValue(string key)
        {
            string value = null;

            var objCache = HttpContext.Current.Cache.Get(key);
            if (objCache != null)
            {
                value = HttpContext.Current.Cache.Get(key).ToString();
                return value;
            }
            return value;
        }

        private static void SetCacheValue(string key, string value)
        {
            int mins = int.Parse(ConfigurationManager.AppSettings["MAXCacheTime"]);
            HttpContext.Current.Cache.Insert(key, value, null,
             Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(mins));            
        }
    }
}