using OechsleTest.Console.Dtos;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OechsleTest.Console.Utils
{
    public class ExcelGenerator
    {
        public static MemoryStream GenerateStreamExcel(IEnumerable<Employee> data)
        {
            var stream = new MemoryStream();
            //required using OfficeOpenXml;

            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(data, true);
                package.Save();
            }
            stream.Position = 0;

            return stream;
        }
    }
}