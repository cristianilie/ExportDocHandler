using ExportDocHandles;
using System.Collections.Generic;

namespace EDH.Library
{
    public interface IDocHandler
    {
        Dictionary<string, List<string>> GetAllProductsPurchaseInvoices(List<InvoiceProductModel> salesInvoice, List<string> wordsToExclude, List<PurchaseReportModel> purchaseReportContent);
        string GetPurchaseDocumentsAs_SupplierPurchaseInvoicesGrouping(List<InvoiceProductModel> purchaseDocuments);
        Dictionary<string, string> InitializeInvoiceModelMapping(List<string> selectedHeadersList);
        Dictionary<string, string> InitializeReportModelMapping(List<string> selectedHeadersList);
        void SetInvoiceModel_ProductSupplier(List<InvoiceProductModel> salesInvoice, List<PurchaseReportModel> purchaseReportContent);
        void SetInvoiceModel_PurchaseInvoice(List<InvoiceProductModel> salesInvoice, Dictionary<string, List<string>> productInvoices);
    }
}