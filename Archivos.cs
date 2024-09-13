using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

using EspacioEmpresa;

namespace Archivos;

public abstract class Lector
{
    public abstract Cadeteria LeerArchivoCadeteria();
    public abstract List<Cadete> LeerArchivoCadetes();
    public abstract List<Pedido> LeerArchivoPedidos();
}

public class LectorCSV() : Lector
{
    // lo unico que sobreescribis es el cuerpo de la funcion
    // no podes cambiar la firma de los metodos con el override
    public override Cadeteria LeerArchivoCadeteria()
    {
        string[] renglon;
        renglon = File.ReadAllLines("csv/DatosCadeteria.csv");
        renglon = renglon[0].Split(",");
        Cadeteria local = new Cadeteria(renglon[0], renglon[1]);

        return local;
    }
    public override List<Cadete> LeerArchivoCadetes()
    {
        int idCadete;
        string[] renglones, partes;
        List<Cadete> listaTemp = new List<Cadete>();

        renglones = File.ReadAllLines("csv/DatosDeCadetes.csv");
        foreach (string linea in renglones)
        {
            partes = linea.Split(",");
            int.TryParse(partes[0], out idCadete);
            Cadete nuevo = new Cadete(idCadete, partes[1], partes[2], partes[3]);
            listaTemp.Add(nuevo);
        }
        return listaTemp;
    }

    public override List<Pedido> LeerArchivoPedidos()
    {

    }
}

public class LectorJSON() : Lector
{
    // lo unico que sobreescribis es el cuerpo de la funcion
    // no podes cambiar la firma de los metodos con el override
    public override Cadeteria LeerArchivoCadeteria()
    {

    }
    public override List<Cadete> LeerArchivoCadetes()
    {
        string datosDeArchivo;

        using (FileStream arch = new FileStream("json", FileMode.Open))
        {
            using (StreamReader lector = new StreamReader(arch))
            {
                datosDeArchivo = lector.ReadToEnd();
                lector.Close();
            }
        }

        return datosDeArchivo;
    }
}