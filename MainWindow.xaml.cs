using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public MainWindow()
        {
            InitializeComponent();
           // IDAO dao = new DatabaseDAO("ARTHASASYAN\\SQLEXPRESS01", "InformationalEdition", "Kost", "localadmin");

        }
    }
}