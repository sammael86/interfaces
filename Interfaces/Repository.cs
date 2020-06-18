using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Interfaces
{
    public class Repository : IRepository<Account>
    {
        string repositoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "repository.xml");
        List<Account> accounts;
        MyXmlSerializer serializer;

        public Repository()
        {
            serializer = new MyXmlSerializer();
            accounts = new List<Account>();

            if (!File.Exists(repositoryPath))
            {
                var fs = File.Create(repositoryPath);
                fs.Close();
            }

            string fileData = File.ReadAllText(repositoryPath);
            if (string.IsNullOrEmpty(fileData))
                return;

            foreach (var account in new MyStreamReader<Person>(fileData, serializer))
            {
                if (account is Account a)
                    accounts.Add(a);
            }
        }

        public void Add(Account item)
        {
            accounts.Add(item);
            string contents = serializer.Serialize(accounts);
            File.WriteAllText(repositoryPath, contents);
        }

        public IEnumerable<Account> GetAll()
        {
            return accounts;
        }

        public Account GetOne(Func<Account, bool> predicate)
        {
            return accounts.FirstOrDefault(predicate);
        }
    }
}
