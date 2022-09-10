using NLog.Fluent;

namespace Ejercicio3;

public static class Program
{
    private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    private static readonly string[] Nombres = { "Pedro", "Jose", "Pepe" };
    private static readonly string[] Apellidos = { "Ramirez", "Perez", "Suarez" };
    private static readonly Random Random = new Random();

    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la cantidad de alumnos");
        var cantidadAlumnos = Convert.ToInt32(Console.ReadLine());
        
        var alumnos = new List<Alumno>();
        List<Alumno> listaAtletismo;
        List<Alumno> listaVoley;
        List<Alumno> listaFutbol;

        try
        {
            Logger.Info("Los alumnos se crean automáticamente de manera aleatoria porque paja");
            for (var i = 0; i < cantidadAlumnos; i++)
            {
                var numeroAleatorio = Random.Next(0, Nombres.Length);
                var cursos = Enum.GetValues(typeof(Curso));
                var cursoAleatorio = (Curso)cursos.GetValue(Random.Next(cursos.Length));
                var nuevoAlumno = new Alumno(i, Nombres[numeroAleatorio], Apellidos[numeroAleatorio], 9000 + i,
                    cursoAleatorio);

                alumnos.Add(nuevoAlumno);
            }

            Logger.Debug("Se crearon exitosamente los alumnos");
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error al crear los alumnos");
        }

        listaAtletismo = alumnos.Where(x => x.Curso == Curso.Atletismo).ToList();
        listaFutbol = alumnos.Where(x => x.Curso == Curso.Futbol).ToList();
        listaVoley = alumnos.Where((x => x.Curso == Curso.Voley)).ToList();

        Logger.Debug("Se crearon exitosamente las listas de los cursos");
        
        ImprimirLista(alumnos);
    }

    public static void ImprimirLista(List<Alumno> lista)
    {
        foreach (Alumno alumno in lista)
        {
            Console.WriteLine(alumno.ToString());
        }
    }
}