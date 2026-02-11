using System;
using System.Collections.Generic;
using System.Linq;

// Clase abstracta porque no queremos crear "Estudiante" directamente,
// sino solo sus tipos específicos (Presencial o A Distancia)
public abstract class Estudiante
{
    // Propiedades básicas del estudiante (encapsulamiento automático)
    public string Nombre { get; set; }
    public int Id { get; set; }

    // Lista para almacenar todas las calificaciones del estudiante
    public List<double> Calificaciones { get; set; } = new List<double>();

    // Constructor: obliga a que todo estudiante tenga ID y Nombre
    public Estudiante(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    // Método virtual: puede ser sobrescrito en clases hijas
    // Calcula el promedio de las calificaciones
    public virtual double CalcularPromedio()
    {
        // Si no hay calificaciones, retorna 0 para evitar error
        if (Calificaciones.Count == 0) return 0;

        // Usa LINQ para calcular el promedio
        return Calificaciones.Average();
    }

    // Método virtual para mostrar datos del estudiante
    public virtual string MostrarDatos()
    {
        return $"ID: {Id} | Nombre: {Nombre} | Promedio: {CalcularPromedio():F2}";
    }
}
