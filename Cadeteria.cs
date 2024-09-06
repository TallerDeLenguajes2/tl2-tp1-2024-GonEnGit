using System.Runtime.CompilerServices;

namespace EspacioEmpresa;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

    public Cadeteria(string nombreLocal, string telefonoLocal)
    {
        Nombre = nombreLocal;
        Telefono = telefonoLocal;
        listaCadetes = nuevaLista();
    }

    public List<Cadete> nuevaLista()
    {
        int idCadete;
        List<Cadete> listaTemp = new List<Cadete>();
        string[] partes, renglonesArchivo = File.ReadAllLines("csv/DatosCadetes.csv");

        foreach (string renglon in renglonesArchivo)
        {
            partes = renglon.Split(",");
            int.TryParse(partes[0], out idCadete);
            Cadete nuevoCadete = new Cadete(idCadete, partes[1], partes[2], partes[3]);
            listaTemp.Add(nuevoCadete);
        }

        return listaTemp;
    }

    public void PrimerosPedidos()
    {
        Random rnd = new Random();
        int numero;
        string[] datosPedido, datosCliente;
        string[] renglonesPedidos = File.ReadAllLines("csv/DatosPedidos.csv");
        string[] renglonesClientes = File.ReadAllLines("csv/DatosClientes.csv");

        for (int indice = 0; indice < renglonesPedidos.Length; indice++)
        {
            datosPedido = renglonesPedidos[indice].Split(",");
            datosCliente = renglonesClientes[indice].Split(",");
            int.TryParse(datosPedido[0], out numero);
            Pedido nuevoPedido = new Pedido(numero, datosPedido[1], datosCliente[0], datosCliente[1], datosCliente[2], datosCliente[3]);
            numero = rnd.Next(0,2);
            listaCadetes[numero].ListaPedidos.Add(nuevoPedido);
        }
    }
}