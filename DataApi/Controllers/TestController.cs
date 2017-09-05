using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataApi.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static DataApi.ViewModel.TestVModel;

namespace DataApi.Controllers
{
    public class TestController : ApiController
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
            var jsonString = await request.Content.ReadAsStringAsync();

            ///大{}内 JSONObject 数据, 最外层
            JSONObject<MoveInfo<MoveDetailInfo>> obj = JsonConvert.DeserializeObject<JSONObject<MoveInfo<MoveDetailInfo>>>(jsonString);
            string msg = obj.msg;
            string success = obj.success.ToString();

            ///'Object'是实体对象类"MoveInfo"的实体类的数据
            MoveInfo<MoveDetailInfo> info = obj.Object;
            int Mv_id1 = info.ID;   //可以直接赋值给MoveInfo的对象获取到值
            int Mv_id2 = obj.Object.ID; //还可以用上层的Object.ID获取到值

            ///info.Detail 或 obj.Object.Detail 都是实体对象类"MoveDetailInfo"的实体类的数据
            string DVName1 = "";
            string DVName2 = "";
            string DVName3 = "";

            DVName1 = obj.Object.Detail[0].DVName;      //方法1: 从最上次对象实体中取子属性

            foreach (MoveDetailInfo mvinfo in info.Detail)
                DVName2 += mvinfo.DVName;       //方法2: 迭代上层 info.Detail 对象"MoveDetailInfo"获取属性

            MoveDetailInfo dvinfo = info.Detail[0];
            DVName3 = dvinfo.DVName;        //方法3: 再赋值给MoveDetailInfo对象类后获取

            //context.Response.ContentType = "text/plain";
            //context.Response.Write(string.Format("0;{0}\r1:{1};\r2:{2};", DVName1, DVName2, DVName3));
        

        //public bool IsReusable
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}


            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}