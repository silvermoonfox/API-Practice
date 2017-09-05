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
using static DataApi.ViewModel.iChefData;

namespace DataApi.Controllers
{
    public class iChefController : Controller
    {
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            iChefData obj = JsonConvert.DeserializeObject<iChefData>(jsonString);
            //using (var db = new APIEntities())
            //{
                

            //    foreach (var item in obj.invoice)
            //    {
            //       List
            //    }


            //    db.SaveChanges();

            //}
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}