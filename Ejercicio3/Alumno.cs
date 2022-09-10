namespace Ejercicio3;

public class Alumno
{
    public int Id { get; private set; }
    
    public string Nombre { get; private set; }
    
    public string Apellido { get; private set; }
    
    public int Dni { get; private set; }
    
    public Curso Curso { get; private set; }

    public Alumno(int id, string nombre, string apellido, int dni, Curso curso)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        Curso = curso;
    }

    public override string ToString()
    {
        return "--- Alumno " + Id + " ---\n" +
               Nombre + ", " + Apellido + "\n" +
               Dni + ", " + Curso + "\n";
    }
}