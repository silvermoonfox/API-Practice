using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataApi.ViewModel
{
    public class TestVModel
    {
        public class JSONObject<T>
        {
            private bool _success;
            /// <summary>
            /// 是否成功
            /// </summary>
            public bool success
            {
                get { return _success; }
                set { _success = value; }
            }

            private T _Object;
            /// <summary>
            /// 业务实体对象
            /// </summary>
            public T Object
            {
                get { return _Object; }
                set { _Object = value; }
            }

            private string _msg;
            /// <summary>
            /// 消息
            /// </summary>
            public string msg
            {
                get { return _msg; }
                set { _msg = value; }
            }
        }

        /// <summary>
        /// MoveInfo 调拨单
        /// </summary>
        public class MoveInfo<T>
        {
            private int _ID;
            public int ID
            {
                get { return _ID; }
                set { _ID = value; }
            }

            private string _MoveID;
            public string MoveID
            {
                get { return _MoveID; }
                set { _MoveID = value; }
            }

            private int _EX_Unit;
            public int EX_Unit
            {
                get { return _EX_Unit; }
                set { _EX_Unit = value; }
            }

            private int _In_Unit;
            public int In_Unit
            {
                get { return _In_Unit; }
                set { _In_Unit = value; }
            }

            private List<MoveDetailInfo> _Detail;
            public List<MoveDetailInfo> Detail
            {
                get { return _Detail; }
                set { _Detail = value; }
            }
        }

        /// <summary>
        /// 调拨明细信息
        /// </summary>
        public class MoveDetailInfo
        {
            private int _ID;
            public int ID
            {
                get { return _ID; }
                set { _ID = value; }
            }

            private string _M_ID;
            public string M_ID
            {
                get { return _M_ID; }
                set { _M_ID = value; }
            }

            private string _DVID;
            public string DVID
            {
                get { return _DVID; }
                set { _DVID = value; }
            }

            private string _DVName;
            public string DVName
            {
                get { return _DVName; }
                set { _DVName = value; }
            }

            private string _DVType;
            public string DVType
            {
                get { return _DVType; }
                set { _DVType = value; }
            }
        }


    }
}