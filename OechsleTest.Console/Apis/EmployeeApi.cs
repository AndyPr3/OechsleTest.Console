using Newtonsoft.Json;
using OechsleTest.Console.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OechsleTest.Console.Apis
{
    public class EmployeeApi
    {
        public static async Task<List<Employee>> GetEmployees()
        {
            using var httpClient = new HttpClient();
            var data = new List<Employee>();
            try
            {
                var response = await httpClient.GetAsync("https://localhost:44370/api/Employees");

                response.EnsureSuccessStatusCode();

                data = await response.Content.ReadFromJsonAsync<List<Employee>>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al consultar la api (Configurar la url del endpoint): {ex.Message}");
            }
            return data;
        }

        public static async Task<DataTable> GetEmployeesTable()
        {
            using var httpClient = new HttpClient();
            DataTable data = new DataTable();
            try
            {
                var response = await httpClient.GetAsync("https://localhost:44370/api/Employees");

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                data = (DataTable)JsonConvert.DeserializeObject(result.ToString(), (typeof(DataTable)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }
    }
}