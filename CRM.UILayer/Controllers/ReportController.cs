using ClosedXML.Excel;
using CRM.DAL.Concrete;
using CRM.UILayer.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.UILayer.Controllers
{
    [AllowAnonymous]
    public class ReportController : Controller
    {
        //Static Excel Listesi

        public IActionResult ReportList()
        {
            return View();
        }
        public IActionResult ExcelStatic()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Personel ID";
            workSheet.Cells[1, 2].Value = "Personel Adı";
            workSheet.Cells[1, 3].Value = "Personel Soyadı";

            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "Merve";
            workSheet.Cells[2, 3].Value = "Öz";

            workSheet.Cells[3, 1].Value = "0002";
            workSheet.Cells[3, 2].Value = "Güneş";
            workSheet.Cells[3, 3].Value = "Yılmaz";//excelPackage üzerinden gelen veriyi bir byte dizisine dönüştürdük
            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "personeller.xlsx");//fileContents,contentType ve dosya ismi parametrelerini file olarak döndürdük         
        }

        public List<CustomerViewModel> CustomerList()
        {
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            using(var context=new Context())
            {
                customerViewModels = context.Customers.Select(x => new CustomerViewModel
                {
                    Email=x.Email,//CustomerViewModel den gelen propertylere Customer entity'sinden gelen propertyleri atadık
                    Name =x.Name,
                    Surname=x.Surname,
                    Phone=x.Phone
                }).ToList();
            }
            return customerViewModels;
        }
        public IActionResult DynamicExcel()
        {
            using(var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Müşteri Listesi");
                workSheet.Cell(1, 1).Value = "Mail Adresi";
                workSheet.Cell(1, 2).Value = "Müşteri Adı";
                workSheet.Cell(1, 3).Value = "Müşteri Soyadı";
                workSheet.Cell(1, 4).Value = "Müşteri Telefon";

                int rowCount = 2;//İlk satırda başlıkları aldık
                foreach(var item in CustomerList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Email;
                    workSheet.Cell(rowCount, 2).Value = item.Name;
                    workSheet.Cell(rowCount, 3).Value = item.Surname;
                    workSheet.Cell(rowCount, 4).Value = item.Phone;
                    rowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Musteri_Listesi.xlsx");
                }
            }
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "Musteri.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Akbank & Up School Asp.Net Full Stack .Net Core Backend Proje");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReports/" + "Musteri.pdf", "application/pdf", "Musteri.pdf");
        }
        
    }
}
