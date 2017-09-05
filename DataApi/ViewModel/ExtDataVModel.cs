using System;
using System.Collections.Generic;
using System.Web;

namespace DataApi.ViewModel
{
    public class ExtDataVModel
    {

        public class Item
        {
            public string id { get; set; }
            public string external_id { get; set; }
            public string setting_external_id { get; set; }
            public string name { get; set; }
        }

        public class Tag
        {
            public string id { get; set; }
            public string external_id { get; set; }
            public string setting_external_id { get; set; }
            public string name { get; set; }
            public List<Item> items { get; set; }
        }

        public class RootObject
        {
            public string store_id { get; set; }
            public string data_generated_dtime { get; set; }
            public string data_start_dtime { get; set; }
            public string data_end_dtime { get; set; }
            public List<Tag> tags { get; set; }
        }

    }
}
