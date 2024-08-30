namespace EspacioEmpresa;

public class Cadete
{
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;
    // podes inicializarla aquí, tambien vale para la composición
    private List<Pedido> listaPedidos = new List<Pedido>();

    public string Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public Cadete(string id, string nombreCadete, string direccionCadete, string telefonoCadete)
    {
        Id = id;
        Nombre = nombreCadete;
        Direccion = direccionCadete;
        Telefono = telefonoCadete;
    }
}

/* // esta forma la necesitarias si no instanciaras la lista en la linea 10
    public Cadete() // si pasas la lista de pedidos ya no se crea con new
    {
        listaPedidos = new List<Pedido>();
    }

    public Cadete(Pedido nuevo) : this()
    {
        listaPedidos.Add(nuevo);
    }
*/