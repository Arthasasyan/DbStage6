using System;
using System.Collections.Generic;

namespace DbProject.Service
{
    public interface IService
    {
        IList<Article> GetArticles();
        IList<Contract> GetContracts();
        IList<Contact> GetContacts();
        IList<Employee> GetEmployees();
        IList<Tuple<string,int>> GetSubscribtions();
    }
}