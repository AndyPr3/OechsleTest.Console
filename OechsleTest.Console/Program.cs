using System.Linq;
using OechsleTest.Console.Apis;
using OechsleTest.Console.Utils;

try
{
    string StartYear = Environment.GetEnvironmentVariable("START_YEAR");
    string EndYear = Environment.GetEnvironmentVariable("END_YEAR");

    if (!String.IsNullOrEmpty(StartYear) && !String.IsNullOrEmpty(EndYear))
    {
        var data = await EmployeeApi.GetEmployees();
        var filter = data.Where(c => c.admission_date.Year > int.Parse(StartYear) && c.admission_date.Year <= int.Parse(EndYear));

        var file = ExcelGenerator.GenerateStreamExcel(filter);

        SendMail.Send("Reporte Empleados - Examen Técnico Oechsle", "andy.r3@gmail.com", "andy.r3@gmail.com", "", file, "Reporte.xlsx");

        Console.WriteLine("Reporte Empleados enviado");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("No se encuentra las variables de entorno");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}