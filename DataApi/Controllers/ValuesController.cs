using DataApi.Models;
using DataApi.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using JwtAuthWebApi;
using Jose;
using Newtonsoft.Json.Linq;

namespace DataApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        //[JwtAuthActionFilter]
        // POST api/values
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            var jsonString = await request.Content.ReadAsStringAsync();

            JObject jObj = JObject.Parse(jsonString);
            var ConvertIV = jObj["invoices"];
            var ConvertStore = jObj["storeID"];


            iChefData chef = new iChefData();

            
            List<Invoice> ListIV = new List<Invoice>();
            foreach (var item in ConvertIV)
            {
                Invoice invoice = new Invoice();
                invoice.buyer_tax_info_company_address = item["buyer_tax_info_company_address"].ToString();
                invoice.buyer_tax_info_tax_id = item["buyer_tax_info_tax_id"].ToString();
                ListIV.Add(invoice);
            }

            chef.invoice = ListIV;

            //var collection = JsonConvert.DeserializeObject<IEnumerable<iChefData>>(jsonString);

            return new HttpResponseMessage(HttpStatusCode.OK);

            //foreach (var item in collection)
            //{

            //}
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
//using (var db = new APIEntities())
//{
//    List<HotSpotDB> hdb = new List<HotSpotDB>();

//    foreach (var item in collection)
//    {
//        db.HotSpotDB.Add(new HotSpotDB()
//        {
//            id = item.id,
//            spot_name = item.spot_name,
//            type = item.type,
//            company = item.company,
//            district = item.district,
//            address = item.address,
//            apparatus_name = item.apparatus_name,
//            latitude = item.latitude,
//            longitude = item.longitude

//        });
//    }


//    db.SaveChanges();

//}