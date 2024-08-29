namespace EspacioTextos;

public static class Textos
{
    public static string CentrarRenglon(string linea, int espacios)
    {
        espacios = (espacios -  linea.Length) /2;
        while (espacios >= 0)
        {
            linea = " " + linea + " ";
            espacios--;
        }

        return linea;
    }

    public static int ControlEntrada(string entrada)
    {
        bool pruebaOpciones;
        int valor;
        pruebaOpciones = int.TryParse(entrada, out valor);
        valor -= 1;
        if (pruebaOpciones == false || valor <= 0 || valor >= 5)
        {
            valor = 99999;
        }

        return valor;
    }
}