public class Asignatura
{
    // Nombre de la asignatura (ejemplo: Programación I)
    public string Nombre { get; set; }

    // Lista de grupos de la asignatura
    public List<Grupo> Grupos { get; set; } = new List<Grupo>();

    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }

    // Método para agregar un nuevo grupo a la asignatura
    public void AgregarGrupo(Grupo grupo)
    {
        Grupos.Add(grupo);
    }
}
