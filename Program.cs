
using EspacioEmpresa;
using EspacioTextos;

Random rnd = new Random();
int tamanioPantalla = Console.WindowWidth, pedidoSeleccionado = 0, cadeteSeleccionado = 0;
int entradaUsuario = 99999, nuevoPedidoNum, contador = 0;
char continuar = 'S';
string linea, nuevoCliNombre, nuevoClidireccion;
string nuevoCliDatosDir, nuevoCliTelefono, nuevoPedidoObs;
string[] datosArchivo, renglones;
List<Pedido> pedidosSinAsignar = new List<Pedido>();

datosArchivo = File.ReadAllLines("csv/DatosCadeteria.csv");
linea = datosArchivo[0];
datosArchivo = linea.Split(",");

Cadeteria local = new Cadeteria(datosArchivo[0], datosArchivo[1]);
local.PrimerosPedidos();

Console.WriteLine("\n" + Textos.CentrarRenglon($"Bienvenido a {local.Nombre}, Telefono: {local.Telefono}", tamanioPantalla) + "\n");
while (continuar == 'S')
{
    Console.WriteLine(Textos.CentrarRenglon("1. Alta de pedidos.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("2. Asignar nuevo pedido.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("3. Reasignar un pedido.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("4. Completar pedido.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("5. Listar pedidos.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("6. Informe del día.", tamanioPantalla));
    Console.Write(Textos.CentrarRenglon("Que tarea quiere realizar? ", tamanioPantalla));
    linea = Console.ReadLine();
    while (entradaUsuario == 99999)
    {
        entradaUsuario = Textos.ControlEntrada(linea);
        if (entradaUsuario == 99999)
        {
            Console.WriteLine(Textos.CentrarRenglon("Ingrese una opcion valida.",tamanioPantalla));
        }
    }
    switch (entradaUsuario)
    {
        case 1:
            Console.Write("Ingrese el nombre del cliente: ");
            nuevoCliNombre = Console.ReadLine();
            Console.Write("Ingrese la direccion del cliente: ");
            nuevoClidireccion = Console.ReadLine();
            Console.Write("Ingrese el numero de la direccion: ");
            nuevoCliDatosDir = Console.ReadLine();
            Console.Write("Ingrese el telefono del cliente: ");
            nuevoCliTelefono = Console.ReadLine();
            Console.Write("Ingrese el pedido: ");
            nuevoPedidoObs = Console.ReadLine();
            nuevoPedidoNum = rnd.Next(1,1000);
            Pedido pedidoNuevo = new Pedido(nuevoPedidoNum, nuevoPedidoObs, nuevoCliNombre, nuevoClidireccion, nuevoCliTelefono, nuevoCliDatosDir);
            pedidosSinAsignar.Add(pedidoNuevo);
            break;
        case 2:
            Console.WriteLine("\nPedidos sin asignar: \n");
            foreach (Pedido pedido in pedidosSinAsignar)
            {
                linea = Textos.ArmarPedido(pedido);
                renglones = linea.Split(";");
                contador += 1;
                for (int indice = 0; indice < renglones.Length; indice++)
                {
                    if (indice == 0)
                    {
                        Console.WriteLine($"{contador}. {renglones[0]}");
                    }
                    else if (indice != renglones.Length - 1) // el estado es evidente, no hace falta aquí
                    {
                        Console.WriteLine($"{renglones[indice]}");
                    }
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine(" ");
            Console.Write("Ingrese el numero de pedido a asignar: ");
            int.TryParse(Console.ReadLine(), out pedidoSeleccionado);   // esto no tiene control, cuidado
            Console.Write("Ingrese el numero del cadete que se encargará del pedido: ");
            int.TryParse(Console.ReadLine(), out cadeteSeleccionado);   // esto no tiene control, cuidado
            foreach (Cadete cadete in local.ListaCadetes)
            {
                if (cadete.Id == cadeteSeleccionado)
                {
                    foreach (Pedido pedido in pedidosSinAsignar)
                    {
                        if (pedido.Numero == pedidoSeleccionado)
                        {
                            cadete.ListaPedidos.Add(pedido);
                            // es valido encadenar metodos así
                            pedidosSinAsignar.RemoveAt(pedidosSinAsignar.IndexOf(pedido));
                            break;
                        }
                    }
                }
            }
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
            break;
    }
    entradaUsuario = 99999;
}
