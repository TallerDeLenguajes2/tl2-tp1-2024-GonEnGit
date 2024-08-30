using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Archivos;

public class Lector
{
    public virtual string[] LeerArchivo(string archivo)
    {
        string[] lineas = {};
        return lineas;
    }
}

public class LectorCSV() : Lector
{
    // lo unico que sobreescribis es el cuerpo de la funcion
    // no podes cambiar la firma de los metodos con el override
    public override string[] LeerArchivo(string archivo)
    {
        string ruta = "csv/";
        string[] datosDeArchivo = {};

        datosDeArchivo = File.ReadAllLines(ruta + archivo + ".csv");

        return datosDeArchivo;
    }
}

public class LectorJSON() : Lector
{
    // lo unico que sobreescribis es el cuerpo de la funcion
    // no podes cambiar la firma de los metodos con el override
    public override string[] LeerArchivo(string archivo)
    {
        string ruta = "json/";
        string[] datosDeArchivo = {};

        datosDeArchivo = File.ReadAllLines(ruta + archivo + ".json");

        return datosDeArchivo;
    }
}