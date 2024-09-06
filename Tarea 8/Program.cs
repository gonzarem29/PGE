using System;
using System.IO;

public class FileManager
{
    public void EscribirArchivo(string ruta, string contenido)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                writer.Write(contenido);
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Error: No tienes permisos para acceder al archivo.");
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error: Ocurrió un problema de I/O durante la escritura del archivo.");
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: Ocurrió un error inesperado.");
            Console.WriteLine(e.Message);
        }
    }

    public string LeerArchivo(string ruta)
    {
        try
        {
            using (StreamReader reader = new StreamReader(ruta))
            {
                return reader.ReadToEnd();
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("Error: No se encontró el archivo especificado.");
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Error: No tienes permisos para acceder al archivo.");
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error: Ocurrió un problema de I/O durante la lectura del archivo.");
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: Ocurrió un error inesperado.");
            Console.WriteLine(e.Message);
        }
        return string.Empty;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Obtener el directorio donde se ejecuta el programa
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(currentDirectory, "archivo.txt");

            FileManager fileManager = new FileManager();

            // Escribir en el archivo
            Console.WriteLine("Escribe el contenido del archivo: (Apretar 2 veces Enter para salir)");
            string contenido = string.Empty;
            string line;
            do
            {
                line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    contenido += line + Environment.NewLine;
                }
            } while (!string.IsNullOrEmpty(line));

            fileManager.EscribirArchivo(filePath, contenido);
            Console.WriteLine("Puedes encontrar el archivo en la siguiente ruta: {0}", filePath);

            // Leer el archivo
            string contenidoLeido = fileManager.LeerArchivo(filePath);
            Console.WriteLine("Contenido del archivo:");
            Console.WriteLine(contenidoLeido);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: Ocurrió un problema durante la ejecución del programa.");
            Console.WriteLine(e.Message);
        }
        finally
        {
            // Espera una entrada del usuario antes de cerrar la consola
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
