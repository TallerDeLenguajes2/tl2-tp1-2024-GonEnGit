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

    public Cadeteria()
    {
        listaCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete nuevo)
    {
        ListaCadetes.Add(nuevo);
    }
}