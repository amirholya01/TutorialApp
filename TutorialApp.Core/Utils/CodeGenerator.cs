using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Core.Utils
{
    public class CodeGenerator
    {
        public static string stringCodeGenerator()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
