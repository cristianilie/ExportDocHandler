using System.Collections.Generic;
using System.Data;

namespace ExportDocHandles
{
    public interface IExcelReader
    {
        List<InvoiceProductModel> ConvertToInvoiceModel(DataTable excelInvoiceContent, Dictionary<string, string> docColumnHeaders_List);
        List<PurchaseReportModel> ConvertToPurchaseReportModel(DataTable excelReportContent, Dictionary<string, string> docColumnHeaders_List);
        DataTableCollection GetExcelContent();
    }
}