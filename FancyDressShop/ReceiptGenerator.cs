using System;
using System.IO;
using System.Windows.Forms;
using FancyDressShop.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Drawing;
using PdfiumViewer;
using iTextFont = iTextSharp.text.Font;
using iTextRectangle = iTextSharp.text.Rectangle;

namespace FancyDressShop
{
    public class ReceiptGenerator
    {
        private readonly CustomerRepository _customerRepo = new CustomerRepository();

        public void GenerateReceipt(Rental rentalData)
        {
            Customer customerData = _customerRepo.GetCustomerById(rentalData.CustomerId);
            if (customerData == null)
            {
                MessageBox.Show("ไม่พบข้อมูลลูกค้าสำหรับบิลนี้", "ข้อผิดพลาด");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                FileName = $"ใบเสร็จ_บิล-{rentalData.RentalId}_{customerData.FullName}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                        PdfWriter.GetInstance(document, fs);

                        document.Open();

                        BuildPdfContent(document, rentalData, customerData);

                        document.Close();
                    }

                    MessageBox.Show("สร้างใบเสร็จ PDF สำเร็จ!", "สำเร็จ");
                    System.Diagnostics.Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการสร้าง PDF: " + ex.Message, "ข้อผิดพลาด");
                }
            }
        }

        public System.Drawing.Image GenerateReceiptImage(Rental rentalData)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Customer customerData = _customerRepo.GetCustomerById(rentalData.CustomerId);
                    if (customerData == null) return null;

                    Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                    PdfWriter.GetInstance(document, ms);

                    document.Open();

                    BuildPdfContentForPreview(document, rentalData, customerData);

                    document.Close();

                    byte[] pdfBytes = ms.ToArray();
                    using (var pdfDocument = PdfiumViewer.PdfDocument.Load(new MemoryStream(pdfBytes)))
                    {
                        return pdfDocument.Render(0, 300, 300, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการสร้างตัวอย่างใบเสร็จ: " + ex.Message);
                return null;
            }
        }

        private void BuildPdfContent(Document document, Rental rentalData, Customer customerData)
        {
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "THSarabunNew.ttf");
            if (!File.Exists(fontPath)) throw new FileNotFoundException("ไม่พบไฟล์ฟอนต์ THSarabunNew.ttf");

            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextFont headerFont = new iTextFont(bf, 16, iTextFont.BOLD);
            iTextFont subHeaderFont = new iTextFont(bf, 14, iTextFont.BOLD);
            iTextFont normalFont = new iTextFont(bf, 12);
            iTextFont boldFont = new iTextFont(bf, 12, iTextFont.BOLD);

            document.Add(new Paragraph("ร้านเช่าชุดแฟนซี Fancy Dress", headerFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("123/4 ถ.แฟนซี ต.สุขใจ อ.ตังอยู่ จ.ครบ 10234", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("เลขประจำตัวผู้เสียภาษี: 0123456789012", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("โทร: 08x-xxx-xxxx", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(Chunk.NEWLINE);

            document.Add(new Paragraph("ใบเสร็จรับเงิน / ใบกำกับภาษีอย่างย่อ", subHeaderFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(Chunk.NEWLINE);

            PdfPTable infoTable = new PdfPTable(2) { WidthPercentage = 100 };
            infoTable.DefaultCell.Border = iTextRectangle.NO_BORDER;

            PdfPCell customerCell = new PdfPCell { Border = iTextRectangle.NO_BORDER, PaddingLeft = 0 };
            customerCell.AddElement(new Paragraph($"เลขที่เอกสาร: {rentalData.RentalId}", normalFont));
            customerCell.AddElement(new Paragraph($"ลูกค้า: {customerData.FullName}", normalFont));
            customerCell.AddElement(new Paragraph($"โทร: {customerData.PhoneNumber ?? "-"}", normalFont));
            infoTable.AddCell(customerCell);

            int rentalDays = (int)Math.Ceiling((rentalData.DueDate.Date - rentalData.RentalDate.Date).TotalDays);
            PdfPCell docCell = new PdfPCell { Border = iTextRectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT };
            docCell.AddElement(new Paragraph($"วันที่รับชุด: {rentalData.RentalDate:dd/MM/yyyy}", normalFont));
            docCell.AddElement(new Paragraph($"กำหนดคืน: {rentalData.DueDate:dd/MM/yyyy}", normalFont));
            docCell.AddElement(new Paragraph($"ระยะเวลาเช่า: {rentalDays} วัน", normalFont));

            infoTable.AddCell(docCell);
            document.Add(infoTable);
            document.Add(Chunk.NEWLINE);

            PdfPTable itemsTable = new PdfPTable(6) { WidthPercentage = 100 };

            itemsTable.SetWidths(new float[] { 8f, 32f, 10f, 15f, 15f, 20f });

            itemsTable.HeaderRows = 1;

            BaseColor headerBgColor = new BaseColor(240, 240, 240);

            itemsTable.AddCell(new PdfPCell(new Phrase("ลำดับ", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = headerBgColor, Padding = 5 });
            itemsTable.AddCell(new PdfPCell(new Phrase("รายการ", boldFont)) { BackgroundColor = headerBgColor, Padding = 5 });
            itemsTable.AddCell(new PdfPCell(new Phrase("จำนวน", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = headerBgColor, Padding = 5 });
            itemsTable.AddCell(new PdfPCell(new Phrase("ราคา/วัน", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = headerBgColor, Padding = 5 });

            itemsTable.AddCell(new PdfPCell(new Phrase("มัดจำ/ตัว", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = headerBgColor, Padding = 5 });

            itemsTable.AddCell(new PdfPCell(new Phrase("รวมค่าเช่า", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = headerBgColor, Padding = 5 });

            int itemNumber = 1;
            foreach (var detail in rentalData.Details)
            {
                decimal lineTotalRental = detail.RentalQuantity * detail.PriceAtRental * rentalDays;

                Phrase itemDescription = new Phrase();
                itemDescription.Add(new Chunk($"{detail.DressName} ", normalFont));
                itemDescription.Add(new Chunk($"\n(ไซส์: {detail.DressSize}, เช่า: {rentalDays} วัน)", new iTextFont(bf, 10, iTextFont.ITALIC, BaseColor.GRAY)));

                itemsTable.AddCell(new PdfPCell(new Phrase(itemNumber.ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(itemDescription) { Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(detail.RentalQuantity.ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(detail.PriceAtRental.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(detail.DepositPrice.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(lineTotalRental.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

                itemNumber++;
            }

            document.Add(itemsTable);

            decimal totalRentalFeeWithVat = rentalData.TotalPrice - rentalData.DepositAmount;
            decimal subtotal = totalRentalFeeWithVat / 1.07m;
            decimal vatAmount = totalRentalFeeWithVat - subtotal;
            PdfPTable summarySubTable = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_RIGHT, SpacingBefore = 5f };
            summarySubTable.SetWidths(new float[] { 3, 2 });
            summarySubTable.DefaultCell.Border = iTextRectangle.NO_BORDER;
            summarySubTable.AddCell(new PdfPCell(new Phrase("รวมเงินค่าเช่า (ก่อน VAT)", normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase(subtotal.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase("ภาษีมูลค่าเพิ่ม 7%", normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase(vatAmount.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase("ค่ามัดจำ", normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase(rentalData.DepositAmount.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            document.Add(summarySubTable);

            LineSeparator line = new LineSeparator(1f, 50f, BaseColor.BLACK, Element.ALIGN_RIGHT, -5f);
            document.Add(new Chunk(line));

            PdfPTable grandTotalTable = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_RIGHT, SpacingBefore = 5f };
            grandTotalTable.SetWidths(new float[] { 3, 2 });
            grandTotalTable.DefaultCell.Border = iTextRectangle.NO_BORDER;
            grandTotalTable.AddCell(new PdfPCell(new Phrase("ยอดรวมที่ต้องชำระ", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            grandTotalTable.AddCell(new PdfPCell(new Phrase(rentalData.TotalPrice.ToString("N2"), boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = new BaseColor(240, 240, 240) });
            document.Add(grandTotalTable);

            document.Add(new Paragraph("ขอบคุณที่ใช้บริการ", normalFont) { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20f });
        }

        private void BuildPdfContentForPreview(Document document, Rental rentalData, Customer customerData)
        {
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "THSarabunNew.ttf");
            if (!File.Exists(fontPath)) throw new FileNotFoundException("ไม่พบไฟล์ฟอนต์ THSarabunNew.ttf");

            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextFont headerFont = new iTextFont(bf, 16, iTextFont.NORMAL);
            iTextFont subHeaderFont = new iTextFont(bf, 14, iTextFont.NORMAL);
            iTextFont normalFont = new iTextFont(bf, 12);
            iTextFont boldFont = new iTextFont(bf, 12, iTextFont.NORMAL);

            document.Add(new Paragraph("ร้านเช่าชุดแฟนซี Fancy Dress", headerFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("123/4 ถ.แฟนซี ต.สุขใจ อ.ตังอยู่ จ.ครบ 10234", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("เลขประจำตัวผู้เสียภาษี: 0123456789012", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("โทร: 08x-xxx-xxxx", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(Chunk.NEWLINE);

            document.Add(new Paragraph("ใบเสร็จรับเงิน / ใบกำกับภาษีอย่างย่อ", subHeaderFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(Chunk.NEWLINE);

            PdfPTable infoTable = new PdfPTable(2) { WidthPercentage = 100 };
            infoTable.DefaultCell.Border = iTextRectangle.NO_BORDER;

            PdfPCell customerCell = new PdfPCell { Border = iTextRectangle.NO_BORDER, PaddingLeft = 0 };
            customerCell.AddElement(new Paragraph($"เลขที่เอกสาร: {rentalData.RentalId}", normalFont));
            customerCell.AddElement(new Paragraph($"ลูกค้า: {customerData.FullName}", boldFont));
            customerCell.AddElement(new Paragraph($"โทร: {customerData.PhoneNumber ?? "-"}", normalFont));
            infoTable.AddCell(customerCell);

            int rentalDays = (int)Math.Ceiling((rentalData.DueDate.Date - rentalData.RentalDate.Date).TotalDays);

            PdfPCell docCell = new PdfPCell { Border = iTextRectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT };
            docCell.AddElement(new Paragraph($"วันที่รับชุด: {rentalData.RentalDate:dd/MM/yyyy}", normalFont));
            docCell.AddElement(new Paragraph($"กำหนดคืน: {rentalData.DueDate:dd/MM/yyyy}", normalFont));
            docCell.AddElement(new Paragraph($"ระยะเวลาเช่า: {rentalDays} วัน", normalFont));

            infoTable.AddCell(docCell);
            document.Add(infoTable);
            document.Add(Chunk.NEWLINE);

            PdfPTable itemsTable = new PdfPTable(6) { WidthPercentage = 100 };

            itemsTable.SetWidths(new float[] { 8f, 32f, 10f, 15f, 15f, 20f });

            itemsTable.HeaderRows = 1;

            BaseColor headerBgColor = new BaseColor(240, 240, 240);

            itemsTable.AddCell(new PdfPCell(new Phrase("ลำดับ", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = headerBgColor, Padding = 5 });
            itemsTable.AddCell(new PdfPCell(new Phrase("รายการ", boldFont)) { BackgroundColor = headerBgColor, Padding = 5 });
            itemsTable.AddCell(new PdfPCell(new Phrase("จำนวน", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = headerBgColor, Padding = 5 });
            itemsTable.AddCell(new PdfPCell(new Phrase("ราคา/วัน", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = headerBgColor, Padding = 5 });

            itemsTable.AddCell(new PdfPCell(new Phrase("มัดจำ/ตัว", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = headerBgColor, Padding = 5 });

            itemsTable.AddCell(new PdfPCell(new Phrase("รวมค่าเช่า", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = headerBgColor, Padding = 5 });

            int itemNumber = 1;
            foreach (var detail in rentalData.Details)
            {
                decimal lineTotalRental = detail.RentalQuantity * detail.PriceAtRental * rentalDays;

                Phrase itemDescription = new Phrase();
                itemDescription.Add(new Chunk($"{detail.DressName} ", normalFont));
                itemDescription.Add(new Chunk($"\n(ไซส์: {detail.DressSize}, เช่า: {rentalDays} วัน)", new iTextFont(bf, 10, iTextFont.ITALIC, BaseColor.GRAY)));

                itemsTable.AddCell(new PdfPCell(new Phrase(itemNumber.ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(itemDescription) { Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(detail.RentalQuantity.ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(detail.PriceAtRental.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(detail.DepositPrice.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

                itemsTable.AddCell(new PdfPCell(new Phrase(lineTotalRental.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

                itemNumber++;
            }

            document.Add(itemsTable);

            decimal totalRentalFeeWithVat = rentalData.TotalPrice - rentalData.DepositAmount;
            decimal subtotal = totalRentalFeeWithVat / 1.07m;
            decimal vatAmount = totalRentalFeeWithVat - subtotal;

            PdfPTable summarySubTable = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_RIGHT, SpacingBefore = 5f };
            summarySubTable.SetWidths(new float[] { 3, 2 });
            summarySubTable.DefaultCell.Border = iTextRectangle.NO_BORDER;
            summarySubTable.DefaultCell.Padding = 2;

            summarySubTable.AddCell(new PdfPCell(new Phrase("รวมเงินค่าเช่า (ก่อน VAT)", normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase(subtotal.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });

            summarySubTable.AddCell(new PdfPCell(new Phrase("ภาษีมูลค่าเพิ่ม 7%", normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase(vatAmount.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });

            summarySubTable.AddCell(new PdfPCell(new Phrase("ค่ามัดจำ", normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            summarySubTable.AddCell(new PdfPCell(new Phrase(rentalData.DepositAmount.ToString("N2"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });

            document.Add(summarySubTable);

            LineSeparator line = new LineSeparator(1f, 50f, BaseColor.BLACK, Element.ALIGN_RIGHT, -5f);
            document.Add(new Chunk(line));

            PdfPTable grandTotalTable = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_RIGHT, SpacingBefore = 5f };
            grandTotalTable.SetWidths(new float[] { 3, 2 });
            grandTotalTable.DefaultCell.Border = iTextRectangle.NO_BORDER;
            grandTotalTable.DefaultCell.Padding = 4;

            grandTotalTable.AddCell(new PdfPCell(new Phrase("ยอดรวมที่ต้องชำระ", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = iTextRectangle.NO_BORDER });
            grandTotalTable.AddCell(new PdfPCell(new Phrase(rentalData.TotalPrice.ToString("N2"), boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = new BaseColor(240, 240, 240) });
            document.Add(grandTotalTable);

            document.Add(new Paragraph("ขอบคุณที่ใช้บริการ", normalFont) { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20f });
        }

    }
}