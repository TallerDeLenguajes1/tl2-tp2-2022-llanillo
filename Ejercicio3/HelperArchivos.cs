namespace Ejercicio3;

public static class HelperArchivos
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    private const string SeparadorCsv = ";";
    private const string ExtensionCsv = ".csv";
    
    /*
     * Devuelve el path del proyecto
     */
    public static string VerPathDelProyecto()
    {
        string directorioEnv = Environment.CurrentDirectory;
        DirectoryInfo? pathProyecto = Directory.GetParent(directorioEnv)?.Parent;
        
        if (pathProyecto?.Parent != null)
            return pathProyecto?.Parent.FullName ?? string.Empty;
        
        return string.Empty;
    }
    
    /*
     * Retorna verdadero si la escritura fue exitosa
     */
    public static void EscribirLinea(string ruta, string? texto)
    {
        if (!File.Exists(ruta))
        {
            Logger.Info("El archivo: " + ruta + " no existe, se procederá a crear");  
        }
        
        try
        {
            using TextWriter streamWriter = File.AppendText(ruta + ExtensionCsv);
            streamWriter.WriteLine(texto + SeparadorCsv);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Excepción al tratar de escribir en el archivo");
        }
        
        Logger.Debug("Se escribió correctamente en el archivo: " + ruta);
    }

    /*
     * Lee el archivo ubicado en el path y muestra por pantalla su contenido
     */
    public static void LeerArchivo(string ruta)
    {
        if (!File.Exists(ruta))
        {
            Logger.Info("El archivo que se desea leer no existe");
        }

        try
        {
            using TextReader streamReader = new StreamReader(ruta + ExtensionCsv);
            var textoEnArchivo = streamReader.ReadToEnd();
            textoEnArchivo = textoEnArchivo.Replace(";", " ");
            Console.WriteLine(textoEnArchivo);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Excepción al tratar de escribir en el archivo");
        }
        
        Logger.Debug("Se leyó correctamente el archivo: " + ruta);
    }
}