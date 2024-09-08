
using EspacioEmpresa;
using EspacioTextos;

Random rnd = new Random();
int tamanioPantalla = Console.WindowWidth, pedidoSeleccionado = 99999, cadeteSeleccionado = 99999;
int entradaUsuario = 99999, nuevoPedidoNum, contador, segundoCadeteSeleccionado;
int dineroGanado = 0, jornal, promedio, enviosPorCadete = 0, totalDeEnvios = 0;
char continuar = 'S';
string linea, nuevoCliNombre, nuevoClidireccion;
string nuevoCliDatosDir, nuevoCliTelefono, nuevoPedidoObs;
string[] datosArchivo, renglones;
Pedido pedidoTemp = new Pedido();

datosArchivo = File.ReadAllLines("csv/DatosCadeteria.csv");
linea = datosArchivo[0];
datosArchivo = linea.Split(",");

Cadeteria local = new Cadeteria(datosArchivo[0], datosArchivo[1]);
local.PrimerosPedidos();

Console.WriteLine("\n" + Textos.CentrarRenglon($"Bienvenido a {local.Nombre}, Telefono: {local.Telefono}", tamanioPantalla));
while (continuar == 'S')
{
    Console.WriteLine(Textos.CentrarRenglon("\n1. Alta de pedidos.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("2. Asignar o reasignar un pedido.", tamanioPantalla)); // desde el TP2 son lo mismo basicamente
    Console.WriteLine(Textos.CentrarRenglon("3. Completar pedido.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("4. Listar pedidos.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("5. Informe del día.", tamanioPantalla));
    Console.WriteLine(Textos.CentrarRenglon("6. Salir.", tamanioPantalla));
    Console.Write(Textos.CentrarRenglon("Que tarea quiere realizar? ", tamanioPantalla));
    while (entradaUsuario == 99999)
    {
        entradaUsuario = Controles.ControlarOpcionMenu(Console.ReadLine());
        if (entradaUsuario == 99999)
        {
            Console.WriteLine("Ingrese una de las opciones disponibles.");
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
            nuevoPedidoNum = rnd.Next(1,1000);      // tendrias que controlar que no se repitan
            local.CrearNuevoPedido(nuevoPedidoNum, nuevoPedidoObs, nuevoCliNombre, nuevoClidireccion, nuevoCliTelefono, nuevoCliDatosDir);
            break;

        case 2:
            Console.WriteLine("\nPedidos sin asignar: \n");
            contador = 0;
            foreach (Pedido pedido in local.ListaPedidos)
            {
                if (pedido.NumeroCadete == 99999)
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
                }
            }
            Console.WriteLine(" ");


            foreach (Cadete cadete in local.ListaCadetes)
            {
                contador = 0;
                Console.WriteLine($"\nPedidos de {cadete.Nombre} - ID: {cadete.Id}:");
                foreach (Pedido pedido in local.ListaPedidos)
                {
                    if (pedido.NumeroCadete == cadete.Id)
                    {
                        linea = Textos.ArmarPedido(pedido);
                        renglones = linea.Split(";");
                        contador += 1;
                        for (int indice = 0; indice < renglones.Length; indice++)
                        {
                            if (indice == 0)
                            {
                                Console.WriteLine($"\n{contador}. {renglones[0]}");
                            }
                            else if (indice != renglones.Length - 1) // el estado es evidente, no hace falta aquí
                            {
                                Console.WriteLine($"{renglones[indice]}");
                            }
                        }
                    }
                }
            }
            Console.WriteLine(" ");
            Console.Write("Ingrese el numero del pedido: ");
            while (pedidoSeleccionado == 99999)
            {
                pedidoSeleccionado = Controles.ControlarPedidoExistente(Console.ReadLine(), local);
                if (pedidoSeleccionado == 99999)
                {
                    Console.Write("Ingrese el ID de un pedido existente: ");
                }
            }
            Console.Write("\nIngrese el numero del cadete que se encargará del pedido: ");
            while (cadeteSeleccionado == 99999)
            {
                cadeteSeleccionado = Controles.ControlarCadeteExistente(Console.ReadLine(), local);
                if (cadeteSeleccionado == 99999)
                {
                    Console.Write("Ingrese el ID de un cadete registrado: ");
                }
            }
            local.AsignarCadeteAPedido(cadeteSeleccionado, pedidoSeleccionado);
            pedidoSeleccionado = 99999; cadeteSeleccionado = 99999;
            break;

        /*case 3:
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
        /*case 4:
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
        /*case 5:
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
        /*case 6:
            continuar = 'N';
            break;*/
    }
    entradaUsuario = 99999;
}
Console.WriteLine("Nos vemos!");
