using System.Collections.Generic;
using System.Data.SqlClient;

namespace DbProject.DAO
{
    public class DatabaseDAO : IDAO
    {
        private SqlConnection Connection;

        public DatabaseDAO(string connectionString)
        {
            Connection= new SqlConnection(connectionString);
        }

        public DatabaseDAO(string dataSource, string initialCatalog, string userID, string password)
        {
            string connectionString =
                $"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={userID};Password={password}";
            Connection = new SqlConnection(connectionString);
        }

        public ISet<IList<string>> ExecuteQuery(string query)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand(query, Connection);
            SqlDataReader dataReader = command.ExecuteReader();
            HashSet<IList<string>> result = new HashSet<IList<string>>();
            List<string> columnNames = new List<string>();
           /* for (int i = 0; i < dataReader.FieldCount; i++)
            {
                columnNames.Add(dataReader.GetName(i));
            }
            */
            result.Add(columnNames);
            while (dataReader.Read())
            {
                List<string> list = new List<string>();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    list.Add(dataReader.GetValue(i).ToString());
                }

                result.Add(list);
            }
            Connection.Close();
            return result;
        }

        public ISet<IList<string>> GetData(string table)
        {
            return ExecuteQuery("SELECT * FROM " + table);
        }
    }
}