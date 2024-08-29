namespace EspacioEmpresa;


public class Pedido
{
    public enum Estados
    {
        Pendiente,
        Completado
    }

    private int numero;
    private string observacion;
    private Cliente cliente;
    private Estados estadoActual;

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estados EstadoActual { get => estadoActual; set => estadoActual = value; }

// esto parece estar bien así, pasar el cliente por referencia
// como trataste de hacer al principio, no sirve, se puede
// pero eso significaria que al borrar el pedido el cliente no desaparece
    public Pedido(int num, string obs, string nombreCli, string dirCli, string telCli, string datosDir)
    {
        numero = num;
        observacion = obs;
        cliente = new Cliente(nombreCli, dirCli, telCli, datosDir);
        EstadoActual = Estados.Pendiente;
    }
}

// otra forma de crear el objeto cliente

/*
    cliente = new Cliente(){
        Nombre = nombreCli, 
        Direccion = dirCli, 
        Telefono = telCli, 
        DatosDir = datosDir
    };
*/

// la cosa es que si usas esta forma, tendrias que borrar este constructor

/*
    public Cliente(string nom, string dir, string tel, string datos)
    {
        nombre = nom;
        direccion = dir;
        telefono = tel;
        datosDir = datos;
    }
*/