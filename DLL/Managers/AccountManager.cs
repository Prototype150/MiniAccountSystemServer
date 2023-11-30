using DLL.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Managers
{
    public class AccountManager : IAccountManager
    {
        public string Get()
        {
            return "Hello";
        }
    }
}
