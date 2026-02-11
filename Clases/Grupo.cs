public class Grupo
{
    // Nombre del grupo (ejemplo: "Grupo A", "Grupo B")
    public string NombreGrupo { get; set; }

    // Lista de estudiantes del grupo
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public Grupo(string nombre)
    {
        NombreGrupo = nombre;
    }

    // Método para agregar un estudiante al grupo
    public void AgregarEstudiante(Estudiante estudiante)
    {
        Estudiantes.Add(estudiante);
    }

    // Calcula el porcentaje de estudiantes aprobados (nota >= 70)
    public double CalcularPorcentajeAprobados()
    {
        // Si no hay estudiantes, retorna 0
        if (Estudiantes.Count == 0) return 0;

        // Cuenta cuántos estudiantes tienen promedio >= 70
        int aprobados = Estudiantes.Count(e => e.CalcularPromedio() >= 70);

        // Calcula el porcentaje
        return (aprobados * 100.0) / Estudiantes.Count;
    }

    // Muestra el listado completo del grupo
    public void MostrarListado()
    {
        Console.WriteLine($"\nGrupo: {NombreGrupo}");

        foreach (var e in Estudiantes)
        {
            Console.WriteLine(e.MostrarDatos());
        }

        Console.WriteLine($"Porcentaje aprobados: {CalcularPorcentajeAprobados():F2}%");
    }
}
