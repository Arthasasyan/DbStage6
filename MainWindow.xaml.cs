using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DbProject.Client;
using DbProject.DAO;

namespace DbProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class A
    {
        public string Aa { get; set; }
        public int Ii { get; set; }
    }
    public partial class MainWindow
    {
        private IGraphicDrawer _graphicDrawer;
        private ITableDrawer _tableDrawer;
        public MainWindow()
        {
            InitializeComponent();
           // IDAO dao = new DatabaseDAO("ARTHASASYAN\\SQLEXPRESS01", "InformationalEdition", "Kost", "localadmin");
            _tableDrawer = new DataGridDrawer();
            _graphicDrawer = new HistogramDrawer();
        }


        private void Articles_OnClick(object sender, RoutedEventArgs e)
        {
            _tableDrawer.DrawArticles();
        }

        private void Contacts_OnClick(object sender, RoutedEventArgs e)
        {
            _tableDrawer.DrawContacts();
        }

        private void Employees_OnClick(object sender, RoutedEventArgs e)
        {
            _tableDrawer.DrawEmployees();
        }

        private void Contracts_OnClick(object sender, RoutedEventArgs e)
        {
            _graphicDrawer.DrawContracts();
        }

        private void Salaries_OnClick(object sender, RoutedEventArgs e)
        {
            _graphicDrawer.DrawSalaries();
        }

        private void Subscribers_OnClick(object sender, RoutedEventArgs e)
        {
            _graphicDrawer.DrawSubscribers();
        }
    }
}