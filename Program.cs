using System.Text.RegularExpressions;

class Program
{
    // Lista global para almacenar todas las asignaturas en memoria
    static List<Asignatura> asignaturas = new List<Asignatura>();

    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n===== SISTEMA DE CONTROL ACADÉMICO =====");
            Console.WriteLine("1. Crear Asignatura");
            Console.WriteLine("2. Crear Grupo en Asignatura");
            Console.WriteLine("3. Agregar Estudiante a Grupo");
            Console.WriteLine("4. Registrar Calificación");
            Console.WriteLine("5. Mostrar Reporte por Grupo");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearAsignatura();
                    break;
                case 2:
                    CrearGrupo();
                    break;
                case 3:
                    AgregarEstudiante();
                    break;
                case 4:
                    RegistrarCalificacion();
                    break;
                case 5:
                    MostrarReporte();
                    break;
                case 6:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    // Método para crear una nueva asignatura
    static void CrearAsignatura()
    {
        Console.Write("Nombre de la asignatura: ");
        string nombre = Console.ReadLine();

        asignaturas.Add(new Asignatura(nombre));

        Console.WriteLine("Asignatura creada correctamente.");
    }

    // Método para crear un grupo dentro de una asignatura
    static void CrearGrupo()
    {
        Console.Write("Nombre de la asignatura: ");
        string nombreAsig = Console.ReadLine();

        // Busca la asignatura por nombre
        Asignatura asig = asignaturas.FirstOrDefault(a => a.Nombre == nombreAsig);

        if (asig == null)
        {
            Console.WriteLine("Asignatura no encontrada.");
            return;
        }

        Console.Write("Nombre del grupo: ");
        string nombreGrupo = Console.ReadLine();

        asig.AgregarGrupo(new Grupo(nombreGrupo));
        Console.WriteLine("Grupo creado correctamente.");
    }

    // Método para agregar un estudiante a un grupo
    static void AgregarEstudiante()
    {
        Console.Write("Asignatura: ");
        string nombreAsig = Console.ReadLine();

        Asignatura asig = asignaturas.FirstOrDefault(a => a.Nombre == nombreAsig);

        if (asig == null)
        {
            Console.WriteLine("Asignatura no encontrada.");
            return;
        }

        Console.Write("Grupo: ");
        string nombreGrupo = Console.ReadLine();

        Grupo grupo = asig.Grupos.FirstOrDefault(g => g.NombreGrupo == nombreGrupo);

        if (grupo == null)
        {
            Console.WriteLine("Grupo no encontrado.");
            return;
        }

        Console.Write("ID Estudiante: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Tipo (1=Presencial, 2=Distancia): ");
        int tipo = int.Parse(Console.ReadLine());

        Estudiante estudiante;

        if (tipo == 1)
        {
            Console.Write("Aula: ");
            string aula = Console.ReadLine();
            estudiante = new EstudiantePresencial(id, nombre, aula);
        }
        else
        {
            Console.Write("Plataforma: ");
            string plataforma = Console.ReadLine();
            estudiante = new EstudianteADistancia(id, nombre, plataforma);
        }

        grupo.AgregarEstudiante(estudiante);
        Console.WriteLine("Estudiante agregado correctamente.");
    }

    // Método para registrar una calificación a un estudiante
    static void RegistrarCalificacion()
    {
        Console.Write("Asignatura: ");
        string nombreAsig = Console.ReadLine();

        Asignatura asig = asignaturas.FirstOrDefault(a => a.Nombre == nombreAsig);

        if (asig == null)
        {
            Console.WriteLine("Asignatura no encontrada.");
            return;
        }

        Console.Write("Grupo: ");
        string nombreGrupo = Console.ReadLine();

        Grupo grupo = asig.Grupos.FirstOrDefault(g => g.NombreGrupo == nombreGrupo);

        if (grupo == null)
        {
            Console.WriteLine("Grupo no encontrado.");
            return;
        }

        Console.Write("ID Estudiante: ");
        int id = int.Parse(Console.ReadLine());

        Estudiante estudiante = grupo.Estudiantes.FirstOrDefault(e => e.Id == id);

        if (estudiante == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
            return;
        }

        Console.Write("Ingrese calificación: ");
        double nota = double.Parse(Console.ReadLine());

        estudiante.Calificaciones.Add(nota);
        Console.WriteLine("Calificación registrada.");
    }

    // Método para mostrar el reporte de un grupo
    static void MostrarReporte()
    {
        Console.Write("Asignatura: ");
        string nombreAsig = Console.ReadLine();

        Asignatura asig = asignaturas.FirstOrDefault(a => a.Nombre == nombreAsig);

        if (asig == null)
        {
            Console.WriteLine("Asignatura no encontrada.");
            return;
        }

        Console.Write("Grupo: ");
        string nombreGrupo = Console.ReadLine();

        Grupo grupo = asig.Grupos.FirstOrDefault(g => g.NombreGrupo == nombreGrupo);

        if (grupo == null)
        {
            Console.WriteLine("Grupo no encontrado.");
            return;
        }

        grupo.MostrarListado();
    }
}
