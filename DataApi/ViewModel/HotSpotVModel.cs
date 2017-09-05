using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;

namespace DataApi.ViewModel
{
   

        public class HotSpot 
        {

            [Display(Name = "熱點代碼")]
            public string id { get; set; }

            [Display(Name = "熱點名稱")]
            public string spot_name { get; set; }

            [Display(Name = "熱點分類")]
            public string type { get; set; }

            [Display(Name = "業者")]
            public string company { get; set; }

            [Display(Name = "鄉鎮市區")]
            public string district { get; set; }

            [Display(Name = "地址")]
            public string address { get; set; }

            [Display(Name = "機關名稱")]
            public string apparatus_name { get; set; }

            [Display(Name = "緯度")]
            public string latitude { get; set; }

            [Display(Name = "經度")]
            public string longitude { get; set; }

        }
       
}