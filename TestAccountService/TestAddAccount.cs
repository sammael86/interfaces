using NUnit.Framework;
using Interfaces;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TestAccountService
{
    public class TestAddAccount
    {
        [Test]
        public void TestAddAccountFailed()
        {
            var repository = new Mock<IRepository<Account>>();
            IAccountService accountService = new AccountService(repository.Object);

            foreach (var account in GetAccounts(false))
            {
                accountService.AddAccount(account);
            }
            repository.Verify(x => x.Add(It.IsAny<Account>()), Times.Never);
        }

        [Test]
        public void TestAddAccountSuccessful()
        {
            var repository = new Mock<IRepository<Account>>();
            IAccountService accountService = new AccountService(repository.Object);

            foreach (var account in GetAccounts(true))
            {
                accountService.AddAccount(account);
            }
            repository.Verify(x => x.Add(It.IsAny<Account>()), Times.Exactly(accounts.Count(x => x.Value == true)));
        }

        Dictionary<Account, bool> accounts = new Dictionary<Account, bool>
            {
                { new Account { FirstName = "", LastName = "", BirthDate = Convert.ToDateTime("10.04.2005") }, false },
                { new Account { FirstName = "Alexey", LastName = "Moskovkin", BirthDate = Convert.ToDateTime("20.07.1986") }, true },
                { new Account { FirstName = "Alexey", LastName = "", BirthDate = Convert.ToDateTime("20.07.1986") }, false },
                { new Account { FirstName = "", LastName = "Moskovkin", BirthDate = Convert.ToDateTime("20.07.1986") }, false },
                { new Account { FirstName = "Alexey", LastName = "Moskovkin", BirthDate = Convert.ToDateTime("20.07.2016") }, false },
                { new Account { FirstName = "Alexey", LastName = "Moskovkin", BirthDate = DateTime.Now.AddYears(-18).AddDays(-1) }, true },
                { new Account { FirstName = "Alexey", LastName = "Moskovkin", BirthDate = DateTime.Now.AddYears(-18).AddDays(1) }, false },
            };

        private IEnumerable<Account> GetAccounts(bool onlyCorrect)
        {
            foreach (var account in accounts.Where(x => x.Value == onlyCorrect))
            {
                yield return account.Key;
            }
        }
    }
}