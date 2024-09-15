using System.Text.Json;
using EspacioEmpresa;

namespace EspacioArchivos;

public static class Escritor
{
    public static void GuardarCadeteriaJSON(Cadeteria local)
    {
        string datosAGuardar = JsonSerializer.Serialize(local);

        // FileMode.OpenOrCreate, si el archivo existe lo usa, si no crea uno nuevo... conveniente
        using (FileStream archivo = new FileStream("json/DatosCadeteria.json", FileMode.OpenOrCreate))
        {
            using (StreamWriter escritor = new StreamWriter(archivo))
            {
                escritor.WriteLine(datosAGuardar);
                escritor.Close();
            }
        }
    }
}