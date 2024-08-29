
using EspacioEmpresa;
using EspacioTextos;

int tamanioPantalla = Console.WindowWidth;
int entradaUsuario = 99999;
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
Console.WriteLine(Textos.CentrarRenglon("4. Informe del día.", tamanioPantalla));

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
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
    }
}
