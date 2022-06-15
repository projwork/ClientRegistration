using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegistration.Contract.ServiceContract
{
    public class AuthSetting
    {
        public string BaseUrl { get; set; }
        public string Uri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonalN { get; set; }
    }
}
