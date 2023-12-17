using System.Data;

namespace AYweb.Core.Serializer;
public interface IExcelSerializer
{
    byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result");
    DataTable ExcelToDataTable(byte[] bytes);
    List<T> ExcelToList<T>(byte[] bytes);
}

