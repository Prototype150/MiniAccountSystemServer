using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Managers.Interfaces
{
    public interface IAccountManager
    {
        AccountModel GetByUsername(string username);
        bool Add(AccountModel account);
    }
}
