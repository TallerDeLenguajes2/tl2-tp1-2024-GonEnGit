namespace EspacioEmpresa;


public class Pedido
{
    public enum Estados
    {
        Pendiente,
        Completado
    }

    private int numero;
    private string numeroDeCadete;
    private string observacion;
    private Cliente cliente;
    private Estados estadoActual;

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estados EstadoActual { get => estadoActual; set => estadoActual = value; }
    public string NumeroDeCadete { get => numeroDeCadete; set => numeroDeCadete = value; }
    public Pedido(int num, string obs, string nombreCli, string dirCli, string telCli, string datosDir)
    {
        numeroDeCadete = "g";
        numero = num;
        observacion = obs;
        cliente = new Cliente(nombreCli, dirCli, telCli, datosDir);
        EstadoActual = Estados.Pendiente;
    }
}