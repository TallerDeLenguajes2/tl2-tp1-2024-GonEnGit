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
}