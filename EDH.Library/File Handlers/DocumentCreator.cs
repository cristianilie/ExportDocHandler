using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ExportDocHandles
{
    /// <summary>
    /// Creates Microsoft Word & Excel Documents according to the export documents we need
    /// </summary>
    public class DocumentCreator : IDocumentCreator
    {
        /// <summary>
        /// Creates a Microsoft Word document using the DocX library
        /// </summary>
        public void CreateWordDocument(string header1, string header2, string docTitle, string docContent1, string docContent2, string docContent3,
                                        string salesAgentName, string stampSignaturePath, string folderPath)
        {
            using (var document = DocX.Create($"{folderPath}\\{docTitle.Replace("\r\n", string.Empty)}.docx"))
            {
                document.PageWidth = 700f;
                document.InsertParagraph(docTitle).FontSize(20d).SpacingAfter(30d).Alignment = Alignment.center;

                document.AddHeaders();
                document.Headers.First.InsertParagraph(header1).Append(Environment.NewLine)
                                      .Append(header2).Append(Environment.NewLine).SpacingAfter(30d);
                document.DifferentFirstPage = true;


                document.InsertParagraph(docContent1).FontSize(14d).SpacingBefore(10d).SpacingAfter(10d).Append(Environment.NewLine)
                                 .Append(Environment.NewLine).Append(docContent2).FontSize(14d).SpacingAfter(10d)
                                 .Append(Environment.NewLine).Append(Environment.NewLine).Append(docContent3).FontSize(14d).SpacingAfter(10d).Alignment = Alignment.center;

                document.Paragraphs[1].LineSpacing = 10;
                var image = document.AddImage(stampSignaturePath.Replace("\r\n", string.Empty));
                Picture picture = image.CreatePicture(120f, 150f);

                Paragraph paragraph = document.InsertParagraph(salesAgentName);
                paragraph.Append(Environment.NewLine);
                paragraph.AppendPicture(picture);
                paragraph.Alignment = Alignment.right;

                document.Save();
            }
        }

        /// <summary>
        /// Creates a Microsoft Excel document using the NPOI Library
        /// </summary>
        public void CreateExcelDocument(List<InvoiceProductModel> _salesInvoiceContent, string vendorName, string vendorInfo, string vendorExtraInfo,
            string buyerName, string buyerInfo, string buyerExtraInfo, string palletsNumber, string boxesNumber, string totalWeight, string folderPath)
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = $"Packing List {vendorInfo}";
            hssfworkbook.DocumentSummaryInformation = dsi;

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = $"Packing List for goods sold by {vendorInfo}";
            hssfworkbook.SummaryInformation = si;

            ISheet mainSheet = hssfworkbook.CreateSheet("Packing List");

            //Create border style
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BottomBorderColor = HSSFColor.Black.Index;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.LeftBorderColor = HSSFColor.Black.Index;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.RightBorderColor = HSSFColor.Black.Index;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.TopBorderColor = HSSFColor.Black.Index;

            //Create company information header
            mainSheet.CreateRow(0).CreateCell(0).SetCellValue("Vendor Name:");
            mainSheet.GetRow(0).CreateCell(1).SetCellValue(vendorName);

            mainSheet.CreateRow(1).CreateCell(0).SetCellValue("Vendor Info");
            mainSheet.GetRow(1).CreateCell(1).SetCellValue(vendorInfo);

            mainSheet.CreateRow(2).CreateCell(0).SetCellValue("Vendor Info2");
            mainSheet.GetRow(2).CreateCell(1).SetCellValue(vendorExtraInfo);

            mainSheet.CreateRow(3).CreateCell(0).SetCellValue("Buyer Name");
            mainSheet.GetRow(3).CreateCell(1).SetCellValue(buyerName);

            mainSheet.CreateRow(4).CreateCell(0).SetCellValue("Buyer Info");
            mainSheet.GetRow(4).CreateCell(1).SetCellValue(buyerInfo);

            mainSheet.CreateRow(5).CreateCell(0).SetCellValue("Buyer Info2");
            mainSheet.GetRow(5).CreateCell(1).SetCellValue(buyerExtraInfo);

            //Set Border Style
            mainSheet.GetRow(0).GetCell(0).CellStyle = style;
            mainSheet.GetRow(0).GetCell(1).CellStyle = style;
            mainSheet.GetRow(1).GetCell(0).CellStyle = style;
            mainSheet.GetRow(1).GetCell(1).CellStyle = style;
            mainSheet.GetRow(2).GetCell(0).CellStyle = style;
            mainSheet.GetRow(2).GetCell(1).CellStyle = style;
            mainSheet.GetRow(3).GetCell(0).CellStyle = style;
            mainSheet.GetRow(3).GetCell(1).CellStyle = style;
            mainSheet.GetRow(4).GetCell(0).CellStyle = style;
            mainSheet.GetRow(4).GetCell(1).CellStyle = style;
            mainSheet.GetRow(5).GetCell(0).CellStyle = style;
            mainSheet.GetRow(5).GetCell(1).CellStyle = style;

            //Create columns
            mainSheet.CreateRow(6).CreateCell(0).SetCellValue("#");
            mainSheet.GetRow(6).CreateCell(1).SetCellValue("Denumire");
            mainSheet.GetRow(6).CreateCell(2).SetCellValue("Cantitate");
            mainSheet.GetRow(6).CreateCell(3).SetCellValue("Tara de origine");

            //Set Border Style
            mainSheet.GetRow(6).GetCell(0).CellStyle = style;
            mainSheet.GetRow(6).GetCell(1).CellStyle = style;
            mainSheet.GetRow(6).GetCell(2).CellStyle = style;
            mainSheet.GetRow(6).GetCell(3).CellStyle = style;

            //Add invoice content(product names+quantity+Country of origin
            int invoiceContentIndex = 7;
            foreach (InvoiceProductModel product in _salesInvoiceContent)
            {
                mainSheet.CreateRow(invoiceContentIndex).CreateCell(0).SetCellValue(invoiceContentIndex - 6);
                mainSheet.GetRow(invoiceContentIndex).CreateCell(1).SetCellValue(product.Name);
                mainSheet.GetRow(invoiceContentIndex).CreateCell(2).SetCellValue(product.Quantity);
                mainSheet.GetRow(invoiceContentIndex).CreateCell(3).SetCellValue(product.CountryOfOrigin);

                mainSheet.GetRow(invoiceContentIndex).GetCell(0).CellStyle = style;
                mainSheet.GetRow(invoiceContentIndex).GetCell(1).CellStyle = style;
                mainSheet.GetRow(invoiceContentIndex).GetCell(2).CellStyle = style;
                mainSheet.GetRow(invoiceContentIndex).GetCell(3).CellStyle = style;

                invoiceContentIndex++;
            }

            //Add Footer with Pallets/Boxes + weight
            mainSheet.CreateRow(invoiceContentIndex).CreateCell(1).SetCellValue("Pallets:");
            mainSheet.GetRow(invoiceContentIndex).CreateCell(2).SetCellValue(palletsNumber);
            mainSheet.CreateRow(invoiceContentIndex + 1).CreateCell(1).SetCellValue("Boxes:");
            mainSheet.GetRow(invoiceContentIndex + 1).CreateCell(2).SetCellValue(boxesNumber);
            mainSheet.CreateRow(invoiceContentIndex + 2).CreateCell(1).SetCellValue("Total Weight:");
            mainSheet.GetRow(invoiceContentIndex + 2).CreateCell(2).SetCellValue(totalWeight);
            mainSheet.GetRow(invoiceContentIndex + 2).CreateCell(3).SetCellValue("Kg");

            //Set Border Style
            mainSheet.GetRow(invoiceContentIndex).GetCell(1).CellStyle = style;
            mainSheet.GetRow(invoiceContentIndex).GetCell(2).CellStyle = style;
            mainSheet.GetRow(invoiceContentIndex + 1).GetCell(1).CellStyle = style;
            mainSheet.GetRow(invoiceContentIndex + 1).GetCell(2).CellStyle = style;
            mainSheet.GetRow(invoiceContentIndex + 2).GetCell(1).CellStyle = style;
            mainSheet.GetRow(invoiceContentIndex + 2).GetCell(2).CellStyle = style;
            mainSheet.GetRow(invoiceContentIndex + 2).GetCell(3).CellStyle = style;

            ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeFormula = false;
            ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeExpression = false;
                            
            //Save File 
            FileStream file = new FileStream($"{folderPath}\\PackingList.xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }

        /// <summary>
        /// Creates Exporter Statement(In Microsoft Word)
        /// </summary>
        public void CreateExporterStatement(string companyInformation, string exporterStatementTitle, string exporterStatementContent1, string exporterPurchaseDocuments,
                                            string exporterStatementContent2, string salesAgentName, string stampSignatureFilePath, string folderPath)
        {
            string[] companyInfo = companyInformation.Split('\r', '\n');
            string header1 = companyInfo.Count() > 0 ? companyInfo[0] : "";
            string header2 = companyInfo.Count() > 1 ? companyInfo[1] : "";

            CreateWordDocument(header1, header2, exporterStatementTitle, exporterStatementContent1, exporterPurchaseDocuments,
                exporterStatementContent2, salesAgentName, stampSignatureFilePath, folderPath);
        }

        /// <summary>
        /// Creates Packing List(In Microsoft Excel)
        /// </summary>
        public void CreatePackingList(List<InvoiceProductModel> salesInvoiceContent, string VendorInfo, string BuyerInfo, string PalletsNumber, string BoxesNumber, string TotalWeight, string FilePath)
        {
            string[] vendorData = VendorInfo.Split('\r', '\n');
            string vendorName = vendorData.Count() > 0 ? vendorData[0] : "";
            string vendorInfo = vendorData.Count() > 1 ? vendorData[1] : "";
            string vendorInfo2 = vendorData.Count() > 2 ? vendorData[2] : "";

            string[] buyerData = BuyerInfo.Split('\r', '\n');
            string buyerName = buyerData.Count() > 0 ? buyerData[0] : "";
            string buyerInfo = buyerData.Count() > 1 ? buyerData[1] : "";
            string buyerInfo2 = buyerData.Count() > 2 ? buyerData[2] : "";

            CreateExcelDocument(salesInvoiceContent, vendorName, vendorInfo, vendorInfo2, buyerName, buyerInfo, buyerInfo2, PalletsNumber, BoxesNumber, TotalWeight, FilePath);
        }

        /// <summary>
        /// Validates that the entered fields are not empty
        /// </summary>
        /// <param name="fields">fields required to create the word/excel documents</param>
        /// <returns>True if valid/False otherwise</returns>
        public bool ValidateFields(params string[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == string.Empty)
                    return false;
            }

            return true;
        }
    }
}
