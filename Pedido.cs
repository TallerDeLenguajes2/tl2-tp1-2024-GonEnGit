namespace Empresa;


public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private enum estados
    {
        Pendiente,
        Completado
    }

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }

    public Pedido(int num, string obs, Cliente cli)
    {
        numero = num;
        observacion = obs;
        Cliente = cli;
    }
}