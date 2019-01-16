using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using Stackoverflow_popular_tags.Models;
using Newtonsoft.Json;


namespace Stackoverflow_popular_tags.Controllers
{
    public class TagsDownloadController : Controller
    {
        // GET: TagsDownload
        public ActionResult Index()
        {
            var ExchangeApi = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            ExchangeApi.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
            HttpResponseMessage data = ExchangeApi.GetAsync("tags?pagesize=100&order=desc&max=2000000&sort=popular&site=stackoverflow&filter=!*MPoAL(KAgsdNw0T&key=ml1p7EkT5p0baRDMX01VYw((").Result;
            data.EnsureSuccessStatusCode();
            string result_data = data.Content.ReadAsStringAsync().Result;
            Tags tags = JsonConvert.DeserializeObject<Tags>(result_data);
            
            return View(tags);
        }
    }
}