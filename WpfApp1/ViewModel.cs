using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1
{
  public class ViewModel
  {
    public ViewModel()
    {
      GetData();
      GetColumns();
    }
    private CollectionViewSource cvs = new CollectionViewSource();
    ObservableCollection<Data> col;
    public ICollectionView View1 { get => cvs.View; }

    public ObservableCollection<DataGridColumn> ColumnCollection { get; set; } = new ObservableCollection<DataGridColumn>();
    private int colCount = 20;

    private void GetData()
    {
      col = new ObservableCollection<Data>();
      Random rnd = new Random();
      for (int i = 1; i < 100; i++)
      {
        Data d = new Data(colCount) { ID = i };
        for (int k = 0; k < colCount; k++)
        {
          int value = rnd.Next(1, 10000);
          if (rnd.NextDouble() > .5) d.C[k] = (rnd.NextDouble() > .5) ? value : -value;
        }
        col.Add(d);
      }
      cvs.Source = col;
    }

    private void GetColumns()
    {
      ColumnCollection.Add(new DataGridTextColumn() { Header = "ID", Binding = new Binding("ID") });
      Style dgCellStyle = (Style)Application.Current.Resources["dgcellStyle"];
      for (int i = 0; i < colCount; i++)
      {
        ColumnCollection.Add(new DataGridTextColumn()
        {
          Header = $"C{i}",
          Binding = new Binding() { Path = new PropertyPath($"C[{i}]") },
          Width = new DataGridLength(70),
          CellStyle = dgCellStyle
        });
      }
    }
  }
}
