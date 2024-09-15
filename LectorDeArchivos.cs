
using System.Text.Json;
using EspacioEmpresa;

namespace EspacioArchivos;

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

        renglones = File.ReadAllLines("csv/DatosCadetes.csv");
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
        Random rnd = new Random();
        int numero;
        List<Pedido> lista = new List<Pedido>();
        string[] datosPedido, datosCliente;
        string[] renglonesPedidos = File.ReadAllLines("csv/DatosPedidos.csv");
        string[] renglonesClientes = File.ReadAllLines("csv/DatosClientes.csv");
        for (int indice = 0; indice < renglonesPedidos.Length; indice++)

        {
            datosPedido = renglonesPedidos[indice].Split(",");
            datosCliente = renglonesClientes[indice].Split(",");
            int.TryParse(datosPedido[0], out numero);
            Pedido nuevoPedido = new Pedido(numero, datosPedido[1], datosCliente[0], datosCliente[1], datosCliente[2], datosCliente[3]);
            lista.Add(nuevoPedido);
        }
        for (int i = 0; i < 4; i++) // asigna cadetes a los pedidos
        {
            numero = rnd.Next(1,3);
            if (numero == 1)
            {
                lista[i].NumeroCadete = 123;
            }
            else
            {
                lista[i].NumeroCadete = 456;
            }
        }

        return lista;
    }
}

public class LectorJSON() : Lector
{
// si lo pensas, cuando guardas datos en un json, todas las clases
// se serializan gracias dentro de cadeteria... lo otros 2 metodos,
// para json, quedan redundantes
    public override Cadeteria LeerArchivoCadeteria()
    {
        string datosDeArchivo;
        Cadeteria local = new Cadeteria();

        using (FileStream archivo = new FileStream("json/DatosCadeteria.json", FileMode.Open))
        {
            using (StreamReader lector = new StreamReader(archivo))
            {
                datosDeArchivo = lector.ReadToEnd();
                local = JsonSerializer.Deserialize<Cadeteria>(datosDeArchivo);
                lector.Close();
            }
        }

        return local;
    }

    public override List<Cadete> LeerArchivoCadetes()
    {
        string datosDeArchivo;
        List<Cadete> lista = new List<Cadete>();

        using (FileStream archivo = new FileStream("json/DatosCadetes.json", FileMode.Open))
        {
            using (StreamReader lector = new StreamReader(archivo))
            {
                datosDeArchivo = lector.ReadToEnd();
                lista = JsonSerializer.Deserialize<List<Cadete>>(datosDeArchivo);
                lector.Close();
            }
        }

        return lista;
    }

    public override List<Pedido> LeerArchivoPedidos()
    {
        string datosPedidos, DatosClientes;
        List<Pedido> lista = new List<Pedido>();
        /*using (FileStream archivo = new FileStream("json/DatosCadetes.json", FileMode.Open))
        {
            using (StreamReader lector = new StreamReader(archivo))
            {
                datosDeArchivo = lector.ReadToEnd();
                lista = JsonSerializer.Deserialize<List<Cadete>>(datosDeArchivo);
                lector.Close();
            }
        }*/
        return lista;
    }
}