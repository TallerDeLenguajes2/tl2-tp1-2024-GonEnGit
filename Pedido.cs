namespace EspacioEmpresa;


public class Pedido
{
    public enum Estados
    {
        Pendiente,
        Completado
    }

    private int numero;
    private int numeroCadete;
    private string observacion;
    private Cliente cliente;
    private Estados estadoActual;

    public int Numero { get => numero; set => numero = value; }
    public int NumeroCadete { get => numeroCadete; set => numeroCadete = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estados EstadoActual { get => estadoActual; set => estadoActual = value; }

    public Pedido (){}
    public Pedido(int num, string obs, string nombreCli, string dirCli, string telCli, string datosDir)
    {
        numero = num;
        numeroCadete = 99999;
        observacion = obs;
        cliente = new Cliente(nombreCli, dirCli, telCli, datosDir);
        EstadoActual = Estados.Pendiente;
    }

    public void CambiarEstado()
    {
        estadoActual = Estados.Completado;
    }
}