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

    // en alguna clase te mencionarons que si coinciden los nombres de los
    // parametros con los de los atributos, usas this. en el nombre del parametro
    public Cliente(string nombre, string direccion, string telefono, string datosDir)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosDir = datosDir;
    }
}