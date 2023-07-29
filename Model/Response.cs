using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saaya.Wrapper.Model
{
    public class Response : SystemException
    {
        public int? ResponseCode { get; set; }
        public string? ResponseContent { get; set; }
    }
}