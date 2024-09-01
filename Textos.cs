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

    public static int ControlEntrada(string entrada)
    {
        bool pruebaOpciones;
        int valor;
        pruebaOpciones = int.TryParse(entrada, out valor);
        if (pruebaOpciones == false || valor <= 0 || valor >= 8)
        {
            valor = 99999;
        }

        return valor;
    }

    public static string ArmarPedido(Pedido pedido)
    {
        return  $"Pedido N°: {pedido.Numero};Nobre del cliente: {pedido.Cliente.Nombre};" +
                $"Direccion: {pedido.Cliente.Direccion}, {pedido.Cliente.DatosDir};Telefono: {pedido.Cliente.Telefono}" +
                $"Observacion: {pedido.Observacion};Estado: {pedido.EstadoActual}";
    }
}