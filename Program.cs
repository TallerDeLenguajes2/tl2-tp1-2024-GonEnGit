
using Empresa;

string linea;
string[] datosArchivo;

datosArchivo = File.ReadAllLines("csv/DatosCadeteria.csv");
linea = datosArchivo[0];
datosArchivo = linea.Split(",");

Cadeteria datosLocal = new Cadeteria(datosArchivo[0], datosArchivo[1]);

Console.WriteLine($"Bienvenido a {datosLocal.Nombre}, Telefono: {datosLocal.Telefono}");
Console.WriteLine("Seleccione una tarea:");
Console.WriteLine("1. Asignar nuevo pedido.");
Console.WriteLine("2. Reasignar un pedido.");
Console.WriteLine("3. Alta de pedidos.");
Console.WriteLine("4. Informe del día.");

// faltan pedidos y asignaciones a cadetes
//datosArchivo = File.ReadAllLines("csv/DatosPedidos.csv");