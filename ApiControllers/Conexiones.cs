using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MongoDB.Driver; 
using System.Data;

[ApiController]
[Route("conexion")]
public class Conexion : Controller {
    [HttpGet("sql")]
    public IActionResult ListarCarrerasSql(){
        List<CarreraSQL> lista = new List<CarreraSQL>()
       
     sqlConnection conn = new sqlConnection (CadenasConexion.SQL_SERVER);
     sqlcommand cmd = new sqlcommand ("select IdCarrera,Carrera from Carreras");
     cmd.Connection = conn;
     cmd.CommandType = System.Data.CommandType.Text;
     cmd.Connection.Open();
       
     sqlDataReader reader = cmd.Executereader();

     while (reader.Read()){
        CarreraSQL Carrera = new Carrera();
        carrera.IdCarrera = reader.GetInt16("IdCarrera");
        carrera.Carrera = reader.GetString("Carrera");

        lista.Add(carrera);

    }

    reader.Close();
    conn.Close();

    return Ok(lista);
 }

    [HttpGet("mongo")]

    public IActionResult ListarSalonesMongoDb(){
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Practica2_Ivan");
        var collection = db.GetCollection<SalonMongo>("Salones");

        var lista = collection.Find(FilterDefinition<SalonMongo>.empty).ToList();
        
        return Ok(lista);
    }
}
