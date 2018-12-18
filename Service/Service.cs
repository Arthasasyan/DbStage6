using System;
using System.Collections.Generic;
using DbProject.DAO;

namespace DbProject.Service
{
    public class Service : IService
    {
        private IDAO Dao;

        public Service()
        {
            Dao = new DatabaseDAO("ARTHASASYAN\\SQLEXPRESS01", "InformationalEdition", "Kost", "localadmin");;
        }

        public IList<Article> GetArticles()
        {
            throw new System.NotImplementedException();
        }

        public IList<Contract> GetContracts()
        {
            throw new System.NotImplementedException();
        }

        public IList<Contact> GetContacts()
        {
            throw new System.NotImplementedException();
        }

        public IList<Employee> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public IList<Tuple<string, int>> GetSubscribtions()
        {
            throw new NotImplementedException();
        }
    }
}