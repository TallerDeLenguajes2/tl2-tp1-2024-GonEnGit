namespace EspacioEmpresa;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public Cadete(int id, string nombreCadete, string direccionCadete, string telefonoCadete)
    {
        Id = id;
        Nombre = nombreCadete;
        Direccion = direccionCadete;
        Telefono = telefonoCadete;
    }
}