using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Model
{
    public class ResultVM
    {
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static ResultVM Success(object data = null, string message = "成功")
        {
            return new ResultVM() { code = 0, data = data, message = message };
        }

        public static ResultVM Fail(string message = "失败", int code = -1)
        {
            return new ResultVM() { code = code, data = null, message = message };
        }
    }

    public class PageResultVM
    {
        public int page_index { get; set; }
        public int page_size { get; set; }
        public int total_count { get; set; }
        public object list { get; set; }
    }

    public class LayuiResultVM
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public object data { get; set; }
    }
}
