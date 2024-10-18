using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.ViewModels
{
    public class APIResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public Object data { get; set; }
    }
}
