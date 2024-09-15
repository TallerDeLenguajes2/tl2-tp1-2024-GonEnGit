using EspacioEmpresa;

namespace EspacioTextos;

public static class Textos
{
    public static string CentrarRenglon(string linea, int espacios)
    {
        espacios = (espacios -  linea.Length) /2;
        while (espacios >= 0)
        {
            linea = " " + linea;
            espacios--;
        }

        return linea;
    }

    public static string ArmarPedido(Pedido pedido)
    {
        return  $"Pedido N°: {pedido.Numero};Cliente: {pedido.Cliente.Nombre};" +
                $"-   Telefono: {pedido.Cliente.Telefono};Direccion: {pedido.Cliente.Direccion}, {pedido.Cliente.DatosDir};" +
                $"Observacion: {pedido.Observacion}\n;Estado: {pedido.EstadoActual}";
    }

    public static string CadeteEncargado(Cadeteria local, int idCadete)
    {
        string nombre = "";
        foreach (Cadete cadete in local.ListaCadetes)
        {
            if (cadete.Id == idCadete)
            {
                nombre = cadete.Nombre;
                break;
            }
            else
            {
                nombre = "Sin Cadete";
            }
        }
        return nombre;
    }
}