using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Modles
{
    public class AuthConstants
    {
        public const string Issuer= "https://localhost:7007";
        public const string Audience = "https://localhost:7007";
        public const string Secret = "THIS_KEY_IS_GENERATED_TO_AUTHENTICATE_USER_LOGINS";
    }
}
