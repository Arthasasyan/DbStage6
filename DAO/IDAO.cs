using System;
using System.Collections.Generic;

namespace DbProject.DAO
{
    public interface IDAO
    {
        ISet<IList<string>> GetData(string table);
        ISet<IList<string>> ExecuteQuery(string query);
    }
}