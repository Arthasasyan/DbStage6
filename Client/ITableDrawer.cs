using System.Windows;

namespace DbProject.Client
{
    public interface ITableDrawer
    {
        void DrawArticles();
        void DrawContacts();
        void DrawEmployees();
    }
}