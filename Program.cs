
using EspacioEmpresa;
using EspacioTextos;

int tamanioPantalla = Console.WindowWidth;
int entradaUsuario = 99999;
int idPedido;
double jornal;
string idCadete;
char continuar = 'S';
string linea;
string[] datosArchivo;

datosArchivo = File.ReadAllLines("csv/DatosCadeteria.csv");
linea = datosArchivo[0];
datosArchivo = linea.Split(",");

Cadeteria local = new Cadeteria(datosArchivo[0], datosArchivo[1]);
local.PrimerosPedidos();

Console.WriteLine("\n" + Textos.CentrarRenglon($"Bienvenido a {local.Nombre}, Telefono: {local.Telefono}", tamanioPantalla));
Console.WriteLine(Textos.CentrarRenglon("1. Asignar nuevo pedido.", tamanioPantalla));
Console.WriteLine(Textos.CentrarRenglon("2. Reasignar un pedido.", tamanioPantalla));
Console.WriteLine(Textos.CentrarRenglon("3. Alta de pedidos.", tamanioPantalla));
Console.WriteLine(Textos.CentrarRenglon("4. Calcular jornal.", tamanioPantalla));
Console.WriteLine(Textos.CentrarRenglon("5. Cerrar programa.", tamanioPantalla));

while (continuar == 'S')
{
    Console.WriteLine(Textos.CentrarRenglon("Que tarea quiere realizar?", tamanioPantalla));
    while (entradaUsuario == 99999)
    {
        entradaUsuario = Textos.ControlEntrada(Console.ReadLine());
        if (entradaUsuario == 99999)
        {
            Console.WriteLine(Textos.CentrarRenglon("Ingrese una opcion valida.",tamanioPantalla));
        }
    }
    switch (entradaUsuario)
    {
        case 1:
            Console.Write("Ingrese el ID del cadete: ");
            idCadete = Console.ReadLine();
            Console.Write("Ingrese el ID del pedido a asignar: ");
            int.TryParse(Console.ReadLine(), out idPedido);

            foreach (Pedido pedido in local.ListaPedidos)
            {
                if (pedido.Numero == idPedido)
                {
                    pedido.NumeroDeCadete = idCadete;
                }
            }
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            Console.WriteLine("Ingrese el id del cadete:");
            idCadete = Console.ReadLine();
            jornal = local.JornalACobrar(idCadete);
            foreach (Cadete persona in local.ListaCadetes)
            {
                if (persona.Id == idCadete)
                {
                    Console.WriteLine($"{persona.Nombre} debe cobrar: ${jornal}");
                }
            }
            break;
        case 5:
        continuar = 'N';
            break;
    }
    entradaUsuario = 99999;
}
