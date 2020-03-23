using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class VersionViewModel
    {
        public string Version { 
            get
            {
                return Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
        }
    }
}
