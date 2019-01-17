using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using Stackoverflow_popular_tags.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Stackoverflow_popular_tags.Controllers
{
    public class TagsDownloadController : Controller
    {
        // GET: TagsDownload
        public ActionResult Index()
        {
            
            //Init first 100 tags download
            string result_data = "";
            int max_count = 0;
            int sum_count = 0;
            result_data = Helper.Get_Json_tags();
            JObject o = JObject.Parse(result_data);
            max_count = Helper.max_count_(o);
            
            //Rest tags download
            for (int i = 9; i > 0; i--)
            {
                result_data = Helper.Get_Json_tags(max_count);
                JObject new_json = JObject.Parse(result_data);                   
                max_count = Helper.max_count_(new_json);
                o.Merge(new_json);
   
            }
            result_data = o.ToString();
            Tags tags = JsonConvert.DeserializeObject<Tags>(result_data);
            sum_count = Helper.get_sum_count(tags);
            for(int i = 0; i < tags.Items.Count(); i++)
            {
                double percent = (Convert.ToDouble(tags.Items[i].Count)/Convert.ToDouble(sum_count)) * 100;
                tags.Items[i].Percent = Math.Round(percent, 2);
            }
           

            return View(tags.Items);
        }

        
        
    }
}