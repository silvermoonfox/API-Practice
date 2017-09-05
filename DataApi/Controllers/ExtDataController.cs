using DataApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static DataApi.ViewModel.ExtDataVModel;
using DataApi.Models;
using NLog;
using DataApi.Tools;

namespace DataApi.Controllers
{
    public class ExtDataController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            try
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                var jsonString = await request.Content.ReadAsStringAsync();
                RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsonString);
                //備份進來的json string
                logger.Info((jsonString));

                using (var db = new APIEntities())
                {

                    //抓取第一層tag
                    foreach (var tag in obj.tags)
                    {
                        //抓取tag下的item list物件
                        List<Item> oItem = new List<Item>(tag.items);

                        foreach (var tItem in oItem)
                        {
                            db.ExtData.Add(new ExtData()

                            {
                                store_id = obj.store_id,
                                data_generated_dtime = obj.data_generated_dtime,
                                data_start_dtime = obj.data_start_dtime,
                                data_end_dtime = obj.data_end_dtime,
                                tag_id = tag.id,
                                tag_external_id = tag.external_id,
                                tag_setting_external_id = tag.setting_external_id,
                                tag_name = tag.name,
                                item_id = tItem.id,
                                item_external_id = tItem.external_id,
                                item_setting_external_id = tItem.setting_external_id,
                                item_name = tItem.name

                            });
                        }
                    }
                    db.SaveChanges();
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Fatal(LogUtility.BuildExceptionMessage(ex));
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}

//using (var db = new APIEntities())
//{
//    List<Item> item2 = new List<Item>();
//    foreach (var ggg in obj.tags)
//    {
//        Item obj2 = new Item();
//        db.HotSpotDB.Add(new HotSpotDB()
//        {
//            id = ggg.id,
//            spot_name = ggg.name
//            });

//        db.SaveChanges();
//    }
//    return new HttpResponseMessage(HttpStatusCode.OK);
//}