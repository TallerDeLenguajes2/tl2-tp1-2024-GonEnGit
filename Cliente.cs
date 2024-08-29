namespace EspacioEmpresa;

public class Cliente
{
    private string nombre;      // campos
    private string direccion;
    private string telefono; 
    private string datosDir;

    public string Nombre { get => nombre; set => nombre = value; }          // propiedades
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosDir { get => datosDir; set => datosDir = value; }

    public Cliente(string nom, string dir, string tel, string datos)
    {
        nombre = nom;
        direccion = dir;
        telefono = tel;
        datosDir = datos;
    }
}