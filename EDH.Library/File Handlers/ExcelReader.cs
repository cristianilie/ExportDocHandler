using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExportDocHandles
{
    /// <summary>
    /// Reads From Microsoft Excel Files and converts content to Invoice/Purchase Report Model
    /// </summary>
    public class ExcelReader : IExcelReader
    {
        /// <summary>
        /// Opens and retrieves an excel document content
        /// </summary>
        /// <returns>The excel document content as DataTableCollection</returns>
        public DataTableCollection GetExcelContent()
        {
            List<InvoiceProductModel> output = new List<InvoiceProductModel>();

            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            return result.Tables;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Converts the excel content data table to a list of InvoiceProductModel
        /// </summary>
        /// <param name="excelInvoiceContent">The excel content data table</param>
        /// <param name="docColumnHeaders_List">The Invoice column headers used to filter the invoice</param>
        /// <returns>The loaded excel document content/a list of InvoiceProductModel</returns>
        public List<InvoiceProductModel> ConvertToInvoiceModel(DataTable excelInvoiceContent, Dictionary<string, string> docColumnHeaders_List)
        {

            List<InvoiceProductModel> output = new List<InvoiceProductModel>();
            FilterExcelContentColumns(excelInvoiceContent, docColumnHeaders_List);

            for (int i = 0; i < excelInvoiceContent.Rows.Count; i++)
            {
                var row = excelInvoiceContent.Rows[i].ItemArray;

                output.Add(new InvoiceProductModel()
                {
                    Code = row[excelInvoiceContent.Columns.IndexOf(docColumnHeaders_List["Code"])].ToString(),
                    Quantity = row[excelInvoiceContent.Columns.IndexOf(docColumnHeaders_List["Quantity"])].ToString(),
                    Name = row[excelInvoiceContent.Columns.IndexOf(docColumnHeaders_List["Name"])].ToString(),
                    CountryOfOrigin = row[excelInvoiceContent.Columns.IndexOf(docColumnHeaders_List["CountryOfOrigin"])].ToString(),
                }); ;
            }

            return output.ToList(); ;
        }

        /// <summary>
        /// Removes the datatable content that is no associated with the column headers in docColumnHeaders_List
        /// </summary>
        /// <param name="excelDocContent">The data table we are filtering</param>
        /// <param name="docColumnHeaders_List">the document headers list we are filtering by</param>
        private  void FilterExcelContentColumns(DataTable excelDocContent, Dictionary<string, string> docColumnHeaders_List)
        {
            for (int i = excelDocContent.Columns.Count - 1; i >= 0; i--)
            {
                if (!docColumnHeaders_List.ContainsValue(excelDocContent.Columns[i].ColumnName))
                    excelDocContent.Columns.Remove(excelDocContent.Columns[i]);
            }
        }

        /// <summary>
        /// Converts the excel content data table to a list of PurchaseReportModel
        /// </summary>
        /// <param name="excelReportContent">The excel content data table</param>
        /// <param name="docColumnHeaders_List">The PurchaseReportModel column headers used to filter the report</param>
        /// <returns>The loaded excel document content/a list of PurchaseReportModel</returns>
        public List<PurchaseReportModel> ConvertToPurchaseReportModel(DataTable excelReportContent, Dictionary<string, string> docColumnHeaders_List)
        {
            List<PurchaseReportModel> output = new List<PurchaseReportModel>();
            FilterExcelContentColumns(excelReportContent, docColumnHeaders_List);


            for (int i = 0; i < excelReportContent.Rows.Count; i++)
            {
                var row = excelReportContent.Rows[i].ItemArray;

                string purchaseDateStr = row[excelReportContent.Columns.IndexOf(docColumnHeaders_List["PurchaseDate"])].ToString();

                DateTime purchaseDate;
                bool isValidDate = DateTime.TryParse(purchaseDateStr, out purchaseDate);

                output.Add(new PurchaseReportModel()
                {
                    ProductCode = row[excelReportContent.Columns.IndexOf(docColumnHeaders_List["ProductCode"])].ToString(),
                    QuantityPurchased = row[excelReportContent.Columns.IndexOf(docColumnHeaders_List["QuantityPurchased"])].ToString(),
                    PurchaseDate = isValidDate ? purchaseDate : DateTime.MinValue,
                    SupplierName = row[excelReportContent.Columns.IndexOf(docColumnHeaders_List["SupplierName"])].ToString(),
                    PurchaseInvoiceNumber = row[excelReportContent.Columns.IndexOf(docColumnHeaders_List["PurchaseInvoiceNumber"])].ToString()
                }); ;
            }

            return output.OrderBy(a => a.ProductCode).ThenByDescending(a => a.QuantityPurchased).ThenByDescending(x => x.PurchaseDate).ToList(); ;
        }
    }
}
