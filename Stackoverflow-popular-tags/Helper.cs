using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stackoverflow_popular_tags.Models;

namespace Stackoverflow_popular_tags
{
    public static class Helper
    {
        public static string Get_Json_tags(int max_count)
        {
            string result_data = "";
            var ExchangeApi = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            ExchangeApi.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
            HttpResponseMessage data = ExchangeApi.GetAsync("tags?pagesize=100&order=desc&max=" + max_count.ToString() + "&sort=popular&site=stackoverflow&filter=!*MPoAL(KAgsdNw0T&key=ml1p7EkT5p0baRDMX01VYw((").Result;
            data.EnsureSuccessStatusCode();
            result_data = data.Content.ReadAsStringAsync().Result;

            return result_data;
        }

        public static string Get_Json_tags()
        {
            string result_data = "";
            var ExchangeApi = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            ExchangeApi.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
            HttpResponseMessage data = ExchangeApi.GetAsync("tags?pagesize=100&order=desc&sort=popular&site=stackoverflow&filter=!*MPoAL(KAgsdNw0T&key=ml1p7EkT5p0baRDMX01VYw((").Result;
            data.EnsureSuccessStatusCode();
            result_data = data.Content.ReadAsStringAsync().Result;

            return result_data;
        }

        public static int max_count_(JObject to_array)
        {
            JArray list_counts = (JArray)to_array["items"];
            return Int32.Parse((string)list_counts.Last["count"]) - 1;
        }

        public static int get_sum_count(Tags tags_list)
        {
            int sum = 0;
            for(int i = 0; i < tags_list.Items.Count(); i++)
            {
                sum += tags_list.Items[i].Count;
            }

            return sum;
        }

    }
}