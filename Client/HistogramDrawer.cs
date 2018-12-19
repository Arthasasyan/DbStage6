using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DbProject.Service;

namespace DbProject.Client
{
    public class HistogramDrawer :IGraphicDrawer
    {
        private IService _service = new Service.Service();



        public void DrawContracts()
        {
            var list = _service.GetContracts();
            CLientWindow window = new CLientWindow();
            List<string> labels = new List<string>();
            Random random = new Random();
            Grid grid = new Grid();
            for(int i=0;i<list.Count;i++)
            {
                Contract contract = list[i];
                labels.Add(contract.ContractNumber);
                ColumnDefinition colDef = new ColumnDefinition();
                grid.ColumnDefinitions.Add(colDef);

                RowDefinition rowDef = new RowDefinition();
                grid.RowDefinitions.Add(rowDef);

                Color color = i % 2 == 0 ? Colors.Red : Colors.Blue;

                _placeSingleColorColumn(grid, color, contract.Money, i, 100000000);
            }
            _createLabels(window.ClientGrid,labels.ToArray());
            window.Show(grid);
        }

        public void DrawSalaries()
        {
            var list = _service.GetEmployees();
            Grid myGrid = new Grid();
            List<string> labels = new List<string>();
            Random random = new Random();
            for (int i=0; i<list.Count; i++)
            {
                Employee employee = list[i];
                labels.Add(employee.Contact.Name);
                ColumnDefinition colDef = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef);

                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);

                Color color = i % 2 == 0 ? Colors.Red : Colors.Blue;

                _placeSingleColorColumn(myGrid, color, employee.Salary, i, 10);
            }

            _createLabels(myGrid, labels.ToArray());
            new CLientWindow().Show(myGrid);
        }

        public void DrawSubscribers()
        {
            var list = _service.GetSubscribtions();
            Grid myGrid = new Grid();
            List<string> labels = new List<string>();
            Random random = new Random();
            for (int i=0; i<list.Count; i++)
            {
                labels.Add(list[i].Item1);
                ColumnDefinition colDef = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef);

                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);

                Color color = i % 2 == 0 ? Colors.Red : Colors.Blue;

                _placeSingleColorColumn(myGrid, color, list[i].Item2, i, 10);
            }

            _createLabels(myGrid, labels.ToArray());
            new CLientWindow().Show(myGrid);
        }

        private void _placeSingleColorColumn(Grid grid, Color color, int height, int colNum, int maxHeight)
        {
        Brush brush = new SolidColorBrush(color);

        Rectangle rect = new Rectangle();
        rect.Fill = brush;
        Grid.SetColumn(rect, colNum);
        Grid.SetRow(rect, maxHeight - height);
        Grid.SetRowSpan(rect, height);

        grid.Children.Add(rect);
        }

        private void _createLabels(Grid grid, string[] labels)
        {
        RowDefinition rowDefnLabels = new RowDefinition();
        grid.RowDefinitions.Add(rowDefnLabels);

        for (int i = 0; i < labels.Length; i++)
        {
        TextBlock block = new TextBlock();
        block.Text = labels[i];
        block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
        Grid.SetColumn(block, i);
        Grid.SetRow(block, grid.RowDefinitions.Count);
        grid.Children.Add(block);
        }
        }

    }
}