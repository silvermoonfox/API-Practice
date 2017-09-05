using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataApi.ViewModel;
using static DataApi.ViewModel.RealDataVModel;
using DataApi.Models;
using NLog;
using DataApi.Tools;

namespace DataApi.Controllers
{
    public class RealDataController : ApiController
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
                {   //直接第一層讀取
                    foreach (var item in obj.items)
                    {
                        db.RealData.Add(new RealData()
                        {
                            store_id = obj.store_id,
                            data_generated_dtime = obj.data_generated_dtime,
                            data_start_dtime = obj.data_start_dtime,
                            data_end_dtime = obj.data_end_dtime,
                            item_id = item.id,
                            item_external_id = item.external_id,
                            item_setting_external_id = item.setting_external_id,
                            item_name = item.name,
                            item_category_id = item.category_id,
                            item_category_name = item.category_name,
                            quantity = Convert.ToDecimal(item.quantity)
                        });

                        db.SaveChanges();
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Fatal(LogUtility.BuildExceptionMessage(ex));
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
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
