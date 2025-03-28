using apiTurnoMatico.GenericResponses;
using Kurama.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;

namespace apiTurnoMatico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploALVController : ControllerBase
    {
       
        [HttpGet]
        public ActionResult Obtener()
        {
            string cnnStrinSql = "Data Source=172.31.9.63;Initial Catalog=db_Citas;Integrated Security=False;User ID=sa;Password=12345678a$";
            string query = "SELECT FolioInternet  FROM [db_Citas].[dbo].[Cita]";

            List<dynamic> data = new List<dynamic>();

            // Ejecutamos la consulta con el SqlDataReader
            using (var dr = SqlHelper.ExecuteReader(cnnStrinSql, System.Data.CommandType.Text, query))
            {
                // Iteramos sobre cada registro del reader
                while (dr.Read())
                {
                    // Leemos el valor de FolioInternet y lo agregamos a la lista
                    var folioInternet = dr.GetString(0);
                    Console.WriteLine("FolioInternet: " + folioInternet + "\n");

                    // Creamos un objeto dinámico para cada folio y lo agregamos a la lista
                    data.Add(new { FolioInternet = folioInternet });
                }
            }

            // Respondemos con los datos en formato de éxito
            var apiResponse = ApiResponse<dynamic>.Success(data);
            return Ok(apiResponse);
        }

    }
}
