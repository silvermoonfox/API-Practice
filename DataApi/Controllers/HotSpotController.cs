using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataApi.ViewModel;
using DataApi.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Net;

namespace DataApi.Controllers
{
    public class HotSpotController : Controller
    {
        // GET: HotSpot
        public async Task<ActionResult> Index()
        {




            string targetURI = "http://data.ntpc.gov.tw/od/data/api/04958686-1B92-4B74-889D-9F34409B272B?$format=json";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var response = await client.GetStringAsync(targetURI);
            var collection = JsonConvert.DeserializeObject<IEnumerable<HotSpot>>(response);

            {
                using (var db = new APIEntities())
                {
                    List<HotSpotDB> hdb = new List<HotSpotDB>();

                    foreach (var item in collection)
                    {
                        db.HotSpotDB.Add(new HotSpotDB()
                        {
                            id = item.id,
                            spot_name = item.spot_name,
                            type = item.type,
                            company = item.company,
                            district = item.district,
                            address = item.address,
                            apparatus_name = item.apparatus_name,
                            latitude = item.latitude,
                            longitude = item.longitude

                        });
                    }
                    //hdb.ToList();

                    db.SaveChanges();

                }
            }

            //ViewBag.Result = response;
            return View();
        }


    }
}