namespace WpfApp1
{
  public class Data
  {
    public Data(int colCount) => C.SetColCount(colCount);
    public int ID { get; set; }
    public CellValue<int> C { get; set; } = new CellValue<int>();
  }

  public class CellValue<T>
  {
    public void SetColCount(int colCount) => arr = new T[colCount];

    // Declare an array to store the data elements.
    private T[] arr;

    // Define the indexer to allow client code to use [] notation.
    public T this[int i]
    {
      get { return arr[i]; }
      set { arr[i] = value; }
    }
  }
}
