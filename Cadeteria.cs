using System.Runtime.CompilerServices;
using Archivos;

namespace EspacioEmpresa;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;
    private List<Pedido> listaPedidos;

    //private List<Cadete> listaCadetesTemp;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public Cadeteria(string nombreLocal, string telefonoLocal)
    {
        Nombre = nombreLocal;
        Telefono = telefonoLocal;
        listaCadetes = new List<Cadete>();
        listaPedidos = new List<Pedido>();
    }

    public void CargarCadetes(string tipoDeArchivo)
    {
        int idCadete;
        string datosArchivo;
        List<Cadete> listaTemp;

        if (tipoDeArchivo == "csv")
        {
            LectorCSV lector = new LectorCSV();
            listaTemp = lector.LeerArchivoCadetes();
            foreach (Cadete registro in listaTemp)
            {
                listaCadetes.Add(registro);
            }
        }
        else
        {
            LectorJSON lector = new LectorJSON();
        }

    }

    public void CargarPedidos(string tipoArchivo)
    {
        Random rnd = new Random();
        int numero;
        listaPedidos = new List<Pedido>();
        string[] datosPedido, datosCliente;
        string[] renglonesPedidos = File.ReadAllLines(tipoArchivo + "/DatosPedidos." + tipoArchivo);
        string[] renglonesClientes = File.ReadAllLines(tipoArchivo + "/DatosClientes." + tipoArchivo);

        for (int indice = 0; indice < renglonesPedidos.Length; indice++)
        {
            datosPedido = renglonesPedidos[indice].Split(",");
            datosCliente = renglonesClientes[indice].Split(",");
            int.TryParse(datosPedido[0], out numero);
            Pedido nuevoPedido = new Pedido(numero, datosPedido[1], datosCliente[0], datosCliente[1], datosCliente[2], datosCliente[3]);
            listaPedidos.Add(nuevoPedido);
        }
        for (int i = 0; i < 4; i++) // asigna cadetes a los pedidos
        {
            numero = rnd.Next(1,3);
            if (numero == 1)
            {
                listaPedidos[i].NumeroCadete = 123;
            }
            else
            {
                listaPedidos[i].NumeroCadete = 456;
            }
        }
    }

    public void CrearNuevoPedido(int pedidoNum, string pedidoObs, string cliNombre, string clidireccion, string cliTelefono, string cliDatosDir)
    {
        Pedido pedido = new Pedido(pedidoNum, pedidoObs, cliNombre, clidireccion, cliTelefono, cliDatosDir);
        listaPedidos.Add(pedido);
    }

    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        foreach (Pedido pedido in listaPedidos)
        {
            if (pedido.Numero == idPedido)
            {
                pedido.NumeroCadete = idCadete;
            }
        }
    }

    public int CantPedidosPorCadete(int idCadete)
    {
        int total = 0;
        foreach (Pedido pedido in listaPedidos)
        {
            if (pedido.NumeroCadete == idCadete && pedido.EstadoActual == Pedido.Estados.Completado)
            {
                total += 1;
            }
        }
        return total;
    }

    public int ContarPedidosIncompletos()
    {
        int total = 0;
        foreach (Pedido pedido in listaPedidos)
        {
            if (pedido.EstadoActual == Pedido.Estados.Pendiente)
            {
                total += 1;
            }
        }
        return total;
    }

    public double JornalACobrar(int idCadete)
    {
        double total = 0;
        foreach (Pedido pedido in listaPedidos)
        {
            if (pedido.NumeroCadete == idCadete && pedido.EstadoActual == Pedido.Estados.Completado)
            {
                total += 500;
            }
        }
        return total;
    }
}