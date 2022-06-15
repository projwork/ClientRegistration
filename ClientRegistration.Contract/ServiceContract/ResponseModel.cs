using ClientRegistration.Contract.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegistration.Contract.ServiceContract
{
    public class ResponseModel
    {
        public UserResponseModel Result { get; set; }
        public bool HasValue { get; set; }
    }
}
