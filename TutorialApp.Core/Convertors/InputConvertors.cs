using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Core.Convertors
{
    public class InputConvertors
    {
        public static string EmailValidator(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
