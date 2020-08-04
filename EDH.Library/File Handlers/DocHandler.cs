using ExportDocHandles;
using System.Collections.Generic;
using System.Linq;

namespace EDH.Library
{
    /// <summary>
    /// Handles the Sales invoice and Purchasing report from where we extract the needed information
    /// </summary>
    public class DocHandler : IDocHandler
    {
        /// <summary>
        /// Retrieves a dictionary containing  Keys representing the invoiced product's code, and Values representing lists with
        /// the purchase invoices associated with the Key/product
        /// </summary>
        /// <param name="salesInvoice">List with all the products sold on the current Sales Invoice</param>
        /// <param name="wordsToExclude">List of words to filter purchase invoices in the purchase report</param>
        /// <param name="purchaseReportContent">The Purchase Report</param>
        /// <returns>Dictionary of product codes and list of related purchase invoices</returns>
        public Dictionary<string, List<string>> GetAllProductsPurchaseInvoices(List<InvoiceProductModel> salesInvoice, List<string> wordsToExclude, List<PurchaseReportModel> purchaseReportContent)
        {
            Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();

            if (purchaseReportContent != null)
            {
                foreach (InvoiceProductModel item in salesInvoice)
                {
                    if (!output.Keys.Contains(item.Code))
                    {
                        if (wordsToExclude != null)
                        {
                            output.Add(item.Code,
                                       purchaseReportContent.Where(c => c.ProductCode == item.Code && wordsToExclude.Any(s => !c.PurchaseInvoiceNumber.ToLower().Contains(s.ToLower())))
                                                            .Select(a => a.PurchaseInvoiceNumber).ToList());
                        }
                        else
                        {
                            output.Add(item.Code,
                                       purchaseReportContent.Where(c => c.ProductCode == item.Code).Select(a => a.PurchaseInvoiceNumber).ToList());
                        }
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Sets the purchase invoice number in the Sales invoice, according to the product/invoices dictionary
        /// </summary>
        /// <param name="salesInvoice">Sales invoice</param>
        /// <param name="productInvoices">Dictionary of product codes and list of related purchase invoices</param>
        public void SetInvoiceModel_PurchaseInvoice(List<InvoiceProductModel> salesInvoice, Dictionary<string, List<string>> productInvoices)
        {
            if (salesInvoice != null && productInvoices != null)
            {
                foreach (InvoiceProductModel item in salesInvoice)
                {
                    item.PurchaseInvoice = productInvoices[item.Code].FirstOrDefault();
                }
            }
        }

        /// <summary>
        /// Sets the purchase product supplier in the Sales invoice, according to the purchaseReportContent list
        /// </summary>
        /// <param name="salesInvoice">Sales invoice</param>
        /// <param name="purchaseReportContent">The Purchase Report</param>
        public void SetInvoiceModel_ProductSupplier(List<InvoiceProductModel> salesInvoice, List<PurchaseReportModel> purchaseReportContent)
        {
            if (salesInvoice != null && purchaseReportContent != null)
            {
                foreach (InvoiceProductModel item in salesInvoice)
                {
                    PurchaseReportModel reportRow = purchaseReportContent.Where(p => p.ProductCode == item.Code).FirstOrDefault();
                    item.SupplierName = reportRow == null ? "Supplier Name Not Found" : reportRow.SupplierName;
                }
            }
        }

        /// <summary>
        /// Retrieves a Dictionary that maps the required columns from the purchase report with the
        /// ReportHeaders list bellow(represents the list of the required property names from our report model)
        /// </summary>
        /// <param name="selectedHeadersList">List with the selected column headers from the purchase report</param>
        /// <returns>Dictionary of report column/report model property mapping</returns>
        public Dictionary<string, string> InitializeReportModelMapping(List<string> selectedHeadersList)
        {
            Dictionary<string, string> documentModel_ColumnHeaders_List = new Dictionary<string, string>();
            string[] ReportHeaders = { "ProductCode", "QuantityPurchased", "PurchaseDate", "SupplierName", "PurchaseInvoiceNumber" };

            if (ValidateHeaderLists(ReportHeaders, selectedHeadersList))
            {
                for (int i = 0; i < ReportHeaders.Length; i++)
                {
                    documentModel_ColumnHeaders_List.Add(ReportHeaders[i], selectedHeadersList[i]);
                }
            }
            return documentModel_ColumnHeaders_List;
        }

        /// <summary>
        /// Retrieves a Dictionary that maps the required columns from the Sales Invoice  with the
        /// ReportHeaders list bellow(represents the list of the required property names from our InvoiceProductModel)
        /// </summary>
        /// <param name="selectedHeadersList">List with the selected column headers from the Sales Invoice</param>
        /// <returns>Dictionary of Sales Invoice column/InvoiceProductModel property mapping</returns>
        public Dictionary<string, string> InitializeInvoiceModelMapping(List<string> selectedHeadersList)
        {
            Dictionary<string, string> documentModel_ColumnHeaders_List = new Dictionary<string, string>();
            string[] InvoiceHeaders = { "Code", "Quantity", "Name", "CountryOfOrigin" };

            if (ValidateHeaderLists(InvoiceHeaders, selectedHeadersList))
            {
                for (int i = 0; i < InvoiceHeaders.Length; i++)
                {
                    documentModel_ColumnHeaders_List.Add(InvoiceHeaders[i], selectedHeadersList[i]);
                }
            }

            return documentModel_ColumnHeaders_List;
        }

        /// <summary>
        /// Validates the document headers to not be null and match by count
        /// </summary>
        /// <param name="docHeaderList">Document header list</param>
        /// <param name="selectedHeadersList">Selected header list</param>
        /// <returns>True if valid / False otherwise</returns>
        private bool ValidateHeaderLists(string[] docHeaderList, List<string> selectedHeadersList)
        {
            return docHeaderList != null && selectedHeadersList != null
                && docHeaderList.Distinct().Count() == docHeaderList.Count()
                && docHeaderList.Count() == selectedHeadersList.Count();
        }

        /// <summary>
        /// Retrieves a list of purchase invoices and their associated suppliers
        /// </summary>
        /// <param name="purchaseDocuments">Sales invoice content</param>
        /// <returns>A string of purchase documents and their associated suppliers</returns>
        public string GetPurchaseDocumentsAs_SupplierPurchaseInvoicesGrouping(List<InvoiceProductModel> purchaseDocuments)
        {
            string missingDocs = "";
            string[] suppliers = purchaseDocuments.Select(s => s.SupplierName).Distinct().ToArray();

            foreach (string supplier in suppliers)
            {
                    missingDocs +=
                  $"{supplier}: {string.Join(", ", (purchaseDocuments.Where(d => d.SupplierName == supplier).Select(d => d.PurchaseInvoice).Distinct().ToArray()))} \r\n";
            }

            return missingDocs;
        }
    }
}
