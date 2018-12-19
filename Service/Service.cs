using System;
using System.Collections.Generic;
using DbProject.DAO;

namespace DbProject.Service
{
    public class Service : IService
    {
        private IDAO _dao;

        public Service()
        {
            _dao = new DatabaseDAO("ARTHASASYAN\\SQLEXPRESS01", "InformationalEdition", "Kost", "localadmin");
        }

        public IList<Article> GetArticles()
        {
            string query =
                "Select Name, Email, PhoneNumber, Title, PubDate  from ArticleAuthor Inner Join Contact on ContactID=AuthorID Inner Join Article on Article.ArticleID=ArticleAuthor.ArticleID";
            var resultSet = _dao.ExecuteQuery(query);
            IList<Article> articles = new List<Article>();
            foreach (var list in resultSet)
            {
                if (list.Count == 0)
                {
                    continue;
                }
                Article article = new Article
                {
                    Author = new Contact
                    {
                     Name = list[0],
                        EMail = list[1],
                        PhoneNumber = list[2]

                    },
                    Title=list[3],
                    PubDate = list[4]
                };
                articles.Add(article);
            }

            return articles;
        }

        public IList<Contract> GetContracts()
        {
            string query = "Select ContactNumber, MoneyForContract FROM Contract";
            IList<Contract> contracts = new List<Contract>();
            var resultSet = _dao.ExecuteQuery(query);
            foreach (var list in resultSet)
            {
                if (list.Count == 0)
                {
                    continue;
                }
                Contract contract = new Contract
                {
                    ContractNumber = list[0],
                    Money = int.Parse(list[1])
                };
                contracts.Add(contract);
            }

            return contracts;
        }

        public IList<Contact> GetContacts()
        {
            string query = "Select Name, Email, PhoneNumber FROM Contact";
            IList<Contact> contacts = new List<Contact>();
            var resultSet = _dao.ExecuteQuery(query);
            foreach (var list in resultSet)
            {
                if (list.Count == 0)
                {
                    continue;
                }
                Contact contact = new Contact
                {
                    Name = list[0],
                    EMail = list[1],
                    PhoneNumber = list[2]
                };
                contacts.Add(contact);
            }

            return contacts;
        }

        public IList<Employee> GetEmployees()
        {
            string query =
                "Select Name, Email, PhoneNumber, Salary, Position  from Employee Inner Join Contact on Contact.ContactID = Employee.EmployeeID";
            IList<Employee> employees = new List<Employee>();
            var resultSet = _dao.ExecuteQuery(query);
            foreach (var list in resultSet)
            {
                if (list.Count == 0)
                {
                    continue;
                }
                Employee employee = new Employee
                {
                    Contact = new Contact
                    {
                        Name = list[0],
                        EMail = list[1],
                        PhoneNumber = list[2]
                    },
                    Salary = int.Parse(list[3]),
                    Position = list[4]
                };
                employees.Add(employee);
            }

            return employees;
        }

        public IList<Tuple<string, int>> GetSubscribtions()
        {
            string query =
                "Select RubricName, Count(Subscribtion.RubricID) from Subscribtion Inner Join Rubric on Subscribtion.RubricID=Rubric.RubricID Group by RubricName";
            var resultSet = _dao.ExecuteQuery(query);
            IList<Tuple<string,int>> tuples = new List<Tuple<string, int>>();
            foreach (var list in resultSet)
            {
                if (list.Count == 0)
                {
                    continue;
                }
                tuples.Add(new Tuple<string, int>(list[0],int.Parse(list[1])));
            }

            return tuples;
        }
    }
}