using SistemaComunidad;

// Creamos un Maestro (que es Docente, que es Empleado, que es Miembro)
Docente miProfe = new Docente
{
    Nombre = "Ing. Perez",
    Especialidad = "Programación",
    Salario = 5000
};

miProfe.Presentarse();
Console.WriteLine($"Especialidad: {miProfe.Especialidad}, Salario: ${miProfe.Salario}");

Console.WriteLine("\nPresiona cualquier tecla para salir...");
Console.ReadKey();