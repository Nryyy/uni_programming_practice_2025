using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HromadaWEB.Models.Models
{
    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
        public string ErorMessage { get; set; }
        public object Data { get; set; }
    }
}
