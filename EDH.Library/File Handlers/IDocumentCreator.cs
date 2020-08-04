using System.Collections.Generic;

namespace ExportDocHandles
{
    public interface IDocumentCreator
    {
        void CreateExcelDocument(List<InvoiceProductModel> _salesInvoiceContent, string vendorName, string vendorInfo, string vendorExtraInfo, string buyerName, 
            string buyerInfo, string buyerExtraInfo, string palletsNumber, string boxesNumber, string totalWeight, string filePath);
        void CreateExporterStatement(string companyInformation, string exporterStatementTitle, string exporterStatementContent1, string exporterPurchaseDocuments, 
            string exporterStatementContent2, string salesAgentName, string stampSignatureFilePath, string folderPath);
        void CreatePackingList(List<InvoiceProductModel> salesInvoiceContent, string VendorInfo, string BuyerInfo, string PalletsNumber, string BoxesNumber,
            string TotalWeight, string FilePath);
        void CreateWordDocument(string header1, string header2, string docTitle, string docContent1, string docContent2, string docContent3, string salesAgentName, 
            string stampSignaturePath, string folderPath);
        bool ValidateFields(params string[] fields);
    }
}