using System;

namespace Interfaces
{
    public class AccountService : IAccountService
    {
        public IRepository<Account> repository;

        public AccountService(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        public void AddAccount(Account account)
        {
            if (!string.IsNullOrEmpty(account.FirstName) &&
                !string.IsNullOrEmpty(account.LastName) &&
                account.BirthDate.AddYears(18).Date < DateTime.Today)
            {
                repository.Add(account);
            }
        }
    }
}
