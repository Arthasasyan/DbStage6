using System;
using System.Collections.Generic;

namespace DbProject.DAO
{
    public interface IDAO
    {
        ISet<IList<string>> GetData(string table);
        /// <summary>
        /// Returns result set after executing query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ISet<IList<string>> ExecuteQuery(string query);
    }
}