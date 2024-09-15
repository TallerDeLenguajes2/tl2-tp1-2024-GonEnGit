
using EspacioArchivos;
using EspacioEmpresa;
using EspacioTextos;

Random rnd = new Random();
int tamanioPantalla = Console.WindowWidth;

int pedidoSeleccionado, cadeteSeleccionado, entradaUsuario;
int promedio = 0, enviosPorCadete, nuevoPedidoNum, contador;
double jornal, dineroGanado = 0;
char continuar = 'S';
string nuevoCliNombre, nuevoClidireccion, nuevoCliDatosDir, nuevoCliTelefono, nuevoPedidoObs;
string linea, tipoDeArchivo = "error";
string[] datosArchivo, renglones;
Lector lector; 
Cadeteria local;

/* tenes que cargar los primeros datos segun lo que se elija */
Console.Write("Que tipo de Archivo quiere usar? (1. CSV / 2. JSON): ");
while (tipoDeArchivo == "error")
{
    tipoDeArchivo = Controles.ControlarTipoDeArchivo(Console.ReadLine());
    if (tipoDeArchivo == "error")
    {
        Console.WriteLine("Ingrese un tipo de archivo valido.");
    }
}

if (tipoDeArchivo == "csv")
{
    lector = new LectorCSV();
    local = lector.LeerArchivoCadeteria();
    local.CargarCadetes(tipoDeArchivo);
    local.CargarPedidos(tipoDeArchivo);
}
else
{
    lector = new LectorJSON();
    local = lector.LeerArchivoCadeteria();
}

Console.WriteLine("\n" + Textos.CentrarRenglon($"Bienvenido a {local.Nombre}, Telefono: {local.Telefono}", tamanioPantalla));
while (continuar == 'S')
{
    contador = 0; pedidoSeleccionado = 99999; cadeteSeleccionado = 99999; entradaUsuario = 99999;
    Console.WriteLine("\n" + Textos.CentrarRenglon("1. Alta de pedidos.", tamanioPantalla));
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
            if (local.ContarPedidosIncompletos() != 0)
            {
                Console.WriteLine("\nPedidos sin asignar:");
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
                                Console.WriteLine($"\n{contador}. {renglones[0]}");
                            }
                            else if (indice != renglones.Length - 1) // el estado es evidente, no hace falta aquí
                            {
                                Console.WriteLine($"   {renglones[indice]}");
                            }
                        }
                    }
                }

                foreach (Cadete cadete in local.ListaCadetes)
                {
                    Console.WriteLine($"\nPedidos de {cadete.Nombre} - ID: {cadete.Id}:");
                    foreach (Pedido pedido in local.ListaPedidos)
                    {
                        if (pedido.NumeroCadete == cadete.Id && pedido.EstadoActual == Pedido.Estados.Pendiente)
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
                                else if (indice != renglones.Length)
                                {
                                    Console.WriteLine($"   {renglones[indice]}");
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
            }
            else
            {
                Console.WriteLine("No quedan pedidos sin completar.");
            }
            break;
        case 3:
            if (local.ContarPedidosIncompletos() != 0)
            {
                Console.WriteLine("\nPedidos en curso:");
                foreach (Pedido pedido in local.ListaPedidos)
                {
                    if (pedido.EstadoActual == Pedido.Estados.Pendiente && pedido.NumeroCadete != 99999)
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
                            else if (indice != renglones.Length)
                            {
                                Console.WriteLine($"   {renglones[indice]}");
                            }
                        }
                    }
                }
                Console.Write("\nIngrese el numero de pedido a completar: ");
                while (pedidoSeleccionado == 99999)
                {
                    pedidoSeleccionado = Controles.ControlarPedidoPendiente(Console.ReadLine(), local);
                    if (pedidoSeleccionado == 99999)
                    {
                        Console.Write("Ingrese el ID de un pedido existente: ");
                    }
                }
                foreach (Pedido pedido in local.ListaPedidos)
                {
                    if (pedido.Numero == pedidoSeleccionado)
                    {
                        pedido.CambiarEstado();
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No quedan pedidos por completar.");
            }
            break;
        case 4:
            Console.WriteLine("\nPedidos registrados: ");
            foreach (Pedido pedido in local.ListaPedidos)
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
                    else if (indice == 1)
                    {
                        Console.Write($"   {renglones[indice]}");
                    }
                    else
                    {
                        Console.WriteLine($"   {renglones[indice]}");
                    }
                }
                Console.WriteLine("   Encargado: " + Textos.CadeteEncargado(local, pedido.NumeroCadete) + $" - ID: {pedido.NumeroCadete}");
            }
            break;
        case 5:
            Console.WriteLine("\nResumen del dia: ");
            foreach (Cadete cadete in local.ListaCadetes)
            {
                contador += 1;
                enviosPorCadete = local.CantPedidosPorCadete(cadete.Id);
                jornal = local.JornalACobrar(cadete.Id);
                promedio += enviosPorCadete;
                dineroGanado += jornal;
                Console.WriteLine($"\n{cadete.Nombre} completó " + enviosPorCadete + " pedidos.");
                Console.WriteLine("Le corresponde cobrar: $" + jornal);
            }
            promedio /= contador;
            Console.WriteLine("\nNo se completaron: " + local.ContarPedidosIncompletos() + " pedidos.");
            Console.WriteLine($"Envios realizados: {promedio}.");
            Console.WriteLine($"Ganancia del dia: ${dineroGanado}.");
            Console.WriteLine($"Promedio de pedidos completados por cadete: {promedio}.");
            break;
        case 6:
            continuar = 'N';
            break;
    }
}
// en honor a lo que te dijeron en el proyecto, se guarda siempre
Escritor.GuardarCadeteriaJSON(local);
Console.WriteLine("Nos vemos!");
