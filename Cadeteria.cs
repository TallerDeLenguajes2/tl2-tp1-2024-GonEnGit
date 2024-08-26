using System.Runtime.CompilerServices;

namespace Empresa;

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
        List<Cadete> listaTemp = new List<Cadete>();
        string[] partes, renglonesArchivo = File.ReadAllLines("csv/DatosCadetes.csv");

        foreach (string renglon in renglonesArchivo)
        {
            partes = renglon.Split(",");
            Cadete nuevoCadete = new Cadete(partes[0], partes[1], partes[2], partes[3]);
            listaTemp.Add(nuevoCadete);
        }

        return listaTemp;
    }
}