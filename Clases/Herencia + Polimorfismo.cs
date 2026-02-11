// Clase hija de Estudiante para modalidad presencial
public class EstudiantePresencial : Estudiante
{
    // Propiedad específica de esta modalidad
    public string Aula { get; set; }

    // Constructor que reutiliza el constructor de la clase base (Estudiante)
    public EstudiantePresencial(int id, string nombre, string aula)
        : base(id, nombre)
    {
        Aula = aula;
    }

    // Sobrescribimos el método para agregar información adicional
    public override string MostrarDatos()
    {
        return base.MostrarDatos() + $" | Modalidad: Presencial | Aula: {Aula}";
    }
}

// Clase hija de Estudiante para modalidad a distancia
public class EstudianteADistancia : Estudiante
{
    // Propiedad específica de esta modalidad
    public string Plataforma { get; set; }

    public EstudianteADistancia(int id, string nombre, string plataforma)
        : base(id, nombre)
    {
        Plataforma = plataforma;
    }

    // Sobrescritura del método para mostrar datos personalizados
    public override string MostrarDatos()
    {
        return base.MostrarDatos() + $" | Modalidad: A Distancia | Plataforma: {Plataforma}";
    }
}
