using System;

namespace ExportDocHandles
{
    public class PurchaseReportModel
    {
        public string ProductCode { get; set; }
        public string QuantityPurchased { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SupplierName { get; set; }
        public string PurchaseInvoiceNumber { get; set; }
    }
}
