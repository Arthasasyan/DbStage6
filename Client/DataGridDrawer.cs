using System.Windows;
using System.Windows.Controls;
using DbProject.Service;

namespace DbProject.Client
{
    public class DataGridDrawer :ITableDrawer
    {
        private IService _service;

        public DataGridDrawer()
        {
            _service=new Service.Service();
        }

        public void DrawArticles()
        {
            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = _service.GetArticles();
            new CLientWindow().Show(dataGrid);
        }

        public void DrawContacts()
        {
            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = _service.GetContacts();
            new CLientWindow().Show(dataGrid);
        }

        public void DrawEmployees()
        {
            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = _service.GetEmployees();
            new CLientWindow().Show(dataGrid);
        }
    }
}