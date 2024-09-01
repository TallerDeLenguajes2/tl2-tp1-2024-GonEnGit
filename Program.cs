
using EspacioEmpresa;
using EspacioTextos;

Random rnd = new Random();
int tamanioPantalla = Console.WindowWidth, pedidoSeleccionado, cadeteSeleccionado;
int entradaUsuario = 99999, nuevoPedidoNum, contador = 0, segundoCadeteSeleccionado;
int dineroGanado = 0, jornal, promedio, enviosPorCadete = 0, totalDeEnvios = 0;
char continuar = 'S';
string linea, nuevoCliNombre, nuevoClidireccion;
string nuevoCliDatosDir, nuevoCliTelefono, nuevoPedidoObs;
string[] datosArchivo, renglones;
Pedido pedidoTemp = new Pedido();
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
    Console.WriteLine(Textos.CentrarRenglon("7. Salir.", tamanioPantalla));
    Console.Write(Textos.CentrarRenglon("Que tarea quiere realizar? ", tamanioPantalla));
    while (entradaUsuario == 99999)
    {
        linea = Console.ReadLine();
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
                }
                Console.WriteLine(" ");
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
                            pedidoTemp = pedido;
                        }
                    }
                    cadete.ListaPedidos.Add(pedidoTemp);
                    // es valido encadenar metodos así
                    pedidosSinAsignar.RemoveAt(pedidosSinAsignar.IndexOf(pedidoTemp));
                }
            }
            contador = 0;
            break;
        case 3:
            Console.Write("\nIngrese el numero del cadete que tiene el pedido actualmente: ");
            int.TryParse(Console.ReadLine(), out cadeteSeleccionado);
            Console.Write("Ingrese el numero del pedido a reasignar: ");
            int.TryParse(Console.ReadLine(), out pedidoSeleccionado);
            foreach (Cadete cadete in local.ListaCadetes)  // buscas el cadete que tiene el pedido
            {
                if (cadete.Id == cadeteSeleccionado)
                {  
                    foreach (Pedido pedido in cadete.ListaPedidos)
                    {
                        if (pedido.Numero == pedidoSeleccionado)
                        {
                            pedidoTemp = pedido;
                            cadete.ListaPedidos.RemoveAt(cadete.ListaPedidos.IndexOf(pedido));
                        }
                    }
                }
            }
            Console.Write("Ingrese el numero del cadete que se encargará del pedido: ");
            int.TryParse(Console.ReadLine(), out cadeteSeleccionado);
            foreach (Cadete cadete in local.ListaCadetes)
            {
                if (cadete.Id == cadeteSeleccionado)
                {
                    cadete.ListaPedidos.Add(pedidoTemp);
                }
            }
            break;
        case 4:
            Console.Write("Ingrese el numero de pedido a completar: ");
            int.TryParse(Console.ReadLine(), out entradaUsuario);
            foreach (Cadete cadete in local.ListaCadetes)
            {
                Console.WriteLine($"Pedidos de {cadete.Nombre}");
                foreach (Pedido pedido in cadete.ListaPedidos)
                {
                    if (pedido.Numero == entradaUsuario)
                    {
                        pedido.CambiarEstado();
                    }
                }
            }
            break;
        case 5:
            foreach (Cadete cadete in local.ListaCadetes)
            {
                Console.WriteLine($"Pedidos de {cadete.Nombre}");
                foreach (Pedido pedido in cadete.ListaPedidos)
                {
                    contador += 1;
                    linea = Textos.ArmarPedido(pedido);
                    renglones = linea.Split(";");
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
                    }
                    Console.WriteLine(" ");
                }
                Console.WriteLine(" ");
            }
            break;
        case 6:
            // en teoria al final del dia todos los pedidos estan como "Completados"
            // supongo que podes obviar ese control
            Console.WriteLine("\nResumen del dia: ");
            foreach (Cadete cadete in local.ListaCadetes)
            {
                foreach (Pedido pedido in cadete.ListaPedidos)
                {
                    enviosPorCadete += 1;
                }
                totalDeEnvios += enviosPorCadete;
                jornal = enviosPorCadete * 500;
                dineroGanado += jornal;
                Console.WriteLine($"\n{cadete.Nombre}, realizó {enviosPorCadete} envios.");
                Console.WriteLine($"Jornal: ${jornal}.");
                enviosPorCadete = 0;
                jornal = 0;
            }
            promedio = totalDeEnvios / local.ListaCadetes.Count;
            Console.WriteLine($"\nEnvios realizados: {totalDeEnvios}.");
            Console.WriteLine($"Ganancia del dia: ${dineroGanado}.");
            Console.WriteLine($"Promedio de pedidos por cadete: {promedio}.");
            break;
        case 7:
            continuar = 'N';
            break;
    }
    entradaUsuario = 99999;
}
Console.WriteLine("Nos vemos!");
