using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CorpAppLab1.DataAccessLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;

namespace CorpAppLab1.Forms
{
    public partial class DatePromptReportForm : Form
    {

        private string _connectionString;

        public DatePromptReportForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (fromDatePicker.Value.Date > toDatePicker.Value.Date)
            {
                MessageBox.Show("\"Дата от\" должна быть раньше чем \"Дата до\"", "", MessageBoxButtons.OK);
            }
            else
            {
                var xlApp = new Microsoft.Office.Interop.Excel.Application();

                object misValue = System.Reflection.Missing.Value;

                Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Item[1];

                xlWorkSheet.Cells[1, 1] = "ID заказа";
                xlWorkSheet.Cells[1, 2] = "Дата заказа";
                xlWorkSheet.Cells[1, 3] = "Сумма заказа";
                xlWorkSheet.Cells[1, 4] = "Содержимое заказа";

                var orders = new OrderRepository(_connectionString).GetReport(fromDatePicker.Value, toDatePicker.Value);
                var dishesRepo = new DishRepository(_connectionString);


                for (int i = 0; i < orders.Count; i++)
                {
                    xlWorkSheet.Cells[2 + i, 1] = orders[i].OrderID;
                    xlWorkSheet.Cells[2 + i, 2] = orders[i].OrderDate.ToString("dd-MM-yyyy");
                    xlWorkSheet.Cells[2 + i, 3] = orders[i].Total;

                    var orderDetailsString = string.Empty;

                    foreach (var pair in orders[i].DishesAndCounts)
                    {
                        orderDetailsString += dishesRepo.GetById(pair.Key).DishName + " " + pair.Value + " порции(-й) , ";
                    }
                    xlWorkSheet.Cells[2 + i, 4] = orderDetailsString;
                }

                xlWorkBook.SaveAs($"{AppDomain.CurrentDomain.BaseDirectory}Отчет-с-{fromDatePicker.Value:dd-MM-yyyy}-по-{toDatePicker.Value:dd-MM-yyyy}.xlsx", XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue,
                    XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                MessageBox.Show("Отчет успешно экспортирован", "", MessageBoxButtons.OK);
                Close();
            }
        }

        private void btnExportToPdf_Click(object sender, EventArgs e)
        {
            if (fromDatePicker.Value.Date > toDatePicker.Value.Date)
            {
                MessageBox.Show("\"Дата от\" должна быть раньше чем \"Дата до\"", "", MessageBoxButtons.OK);
            }
            else
            {
                const int COLUMN_COUNT = 4;

                var orders = new OrderRepository(_connectionString).GetReport(fromDatePicker.Value, toDatePicker.Value);
                
                PdfPTable pdfTable = new PdfPTable(COLUMN_COUNT);
                pdfTable.DefaultCell.Padding = 5;
                pdfTable.WidthPercentage = 100;

                var cell = new PdfPCell(new Phrase("OrderID"));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#cfc6c6"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(cell);

                cell = new PdfPCell(new Phrase("Date of order"));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#cfc6c6"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(cell);

                cell = new PdfPCell(new Phrase("Total"));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#cfc6c6"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(cell);

                cell = new PdfPCell(new Phrase("Details"));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#cfc6c6"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(cell);

                var dishesRepo = new DishRepository(_connectionString);
                //creating table data (actual result)   
                foreach (var order in orders)
                {
                    pdfTable.AddCell(order.OrderID.ToString());

                    pdfTable.AddCell(order.OrderDate.ToString("dd-MM-yyyy"));

                    pdfTable.AddCell(order.Total.ToString());

                    var orderDetailsString = string.Empty;

                    foreach (var pair in order.DishesAndCounts)
                    {
                        orderDetailsString += dishesRepo.GetById(pair.Key).DishName + " " + pair.Value + " порции(-й) , ";
                    }
                    pdfTable.AddCell(orderDetailsString);
                }

               
                using (var fileStream = new FileStream($"{ AppDomain.CurrentDomain.BaseDirectory }Отчет -с-{ fromDatePicker.Value:dd-MM-yyyy}-по-{ toDatePicker.Value:dd-MM-yyyy}.pdf", FileMode.OpenOrCreate))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, fileStream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    fileStream.Close();
                }

                MessageBox.Show("Отчет успешно экспортирован", "", MessageBoxButtons.OK);
                Close();
            }
        }
    }
}
