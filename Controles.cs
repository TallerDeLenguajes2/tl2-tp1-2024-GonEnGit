using System.Diagnostics.Contracts;
using EspacioEmpresa;

namespace EspacioTextos;

public static class Controles
{
    public static string ControlarTipoDeArchivo(string tipo)
    {
        int valor;
        string respuesta;
        bool opcionCorrecta;

        opcionCorrecta = int.TryParse(tipo, out valor);
        if (!opcionCorrecta || valor < 1 || valor > 7)
        {
            respuesta = "error";
        }
        else
        {
            if (valor == 1)
            {
                respuesta = "csv";
            }
            else
            {
                respuesta = "json";
            }
        }

        return respuesta;
    }
    public static int ControlarOpcionMenu(string entrada)
    {
        int valor;
        bool opcionCorrecta;

        opcionCorrecta = int.TryParse(entrada, out valor);
        if (!opcionCorrecta || valor < 1 || valor > 7)
        {
            valor = 99999;
        }

        return valor;
    }

    public static int ControlarCadeteExistente(string entrada, Cadeteria local)
    {
        int valor, aux;
        bool opcionCorrecta;

        opcionCorrecta = int.TryParse(entrada, out valor);
        aux = valor;
        if (!opcionCorrecta || valor < 1 || valor > 999)
        {
            valor = 99999;
        }
        else
        {
            foreach (Cadete cadete in local.ListaCadetes)
            {
                if (cadete.Id == aux)
                {
                    valor = cadete.Id;
                    break;              // este break, corta el foreach no el if
                }
                else
                {
                    valor = 99999;
                }
            }
        }

        return valor;
    }

    public static int ControlarPedidoExistente(string entrada, Cadeteria local)
    {
        int valor, aux;
        bool opcionCorrecta;

        opcionCorrecta = int.TryParse(entrada, out valor);
        aux = valor;
        if (!opcionCorrecta || valor < 1 || valor > 999)
        {
            valor = 99999;
        }
        else
        {
            foreach (Pedido pedido in local.ListaPedidos)
            {
                if (pedido.Numero == aux)
                {
                    valor = pedido.Numero;
                    break;
                }
                else
                {
                    valor = 99999;
                }
            }
        }

        return valor;
    }

    public static int ControlarPedidoPendiente(string entrada, Cadeteria local)
    {
        int valor, aux;
        bool opcionCorrecta;

        opcionCorrecta = int.TryParse(entrada, out valor);
        aux = valor;
        if (!opcionCorrecta || valor < 1 || valor > 999)
        {
            valor = 99999;
        }
        else
        {
            foreach (Pedido pedido in local.ListaPedidos)
            {
                if (pedido.EstadoActual == Pedido.Estados.Pendiente && pedido.Numero == aux)
                {
                    valor = pedido.Numero;
                    break;
                }
                else
                {
                    valor = 99999;
                }
            }
        }

        return valor;
    }
}