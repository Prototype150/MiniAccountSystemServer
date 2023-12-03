using DLL.Managers.Interfaces;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Managers
{
    public class AccountManager : IAccountManager
    {
        private List<AccountModel> _accounts;
        private int _counter;

        public AccountManager()
        {
            _accounts = new List<AccountModel>();
            _counter = 0;
        }

        public AccountModel GetByUsername(string username)
        {
            return _accounts.FirstOrDefault(x => x.Username == username);
        }

        public bool Add(AccountModel account)
        {
            if (string.IsNullOrWhiteSpace(account.Username) || string.IsNullOrWhiteSpace(account.Email) || _accounts.FirstOrDefault(x => x.Username == account.Username) != null)
                return false;

            account.Id = _counter++;
            _accounts.Add(account);

            return true;
        }
    }
}
