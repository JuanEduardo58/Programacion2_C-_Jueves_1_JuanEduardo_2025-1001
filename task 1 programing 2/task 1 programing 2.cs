using System;
using System.Collections.Generic;

namespace SistemaComunidadEducativa
{
    // Clase abstracta base - Abstracción
    public abstract class MiembroDeLaComunidad
    {
        // Encapsulamiento - Propiedades
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Constructor
        protected MiembroDeLaComunidad(int id, string nombre, string apellido, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            FechaRegistro = DateTime.Now;
        }

        // Método abstracto - Polimorfismo
        public abstract void MostrarInformacion();
        
        // Método virtual que puede ser sobrescrito
        public virtual string ObtenerRol()
        {
            return "Miembro de la Comunidad";
        }
    }

    // Clase Estudiante - Herencia
    public class Estudiante : MiembroDeLaComunidad
    {
        public string Carrera { get; set; }
        public int Semestre { get; set; }
        public double Promedio { get; set; }

        public Estudiante(int id, string nombre, string apellido, string email, 
                         string carrera, int semestre, double promedio)
            : base(id, nombre, apellido, email)
        {
            Carrera = carrera;
            Semestre = semestre;
            Promedio = promedio;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- ESTUDIANTE ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Carrera: {Carrera}");
            Console.WriteLine($"Semestre: {Semestre}");
            Console.WriteLine($"Promedio: {Promedio:F2}");
        }

        public override string ObtenerRol()
        {
            return "Estudiante";
        }
    }

    // Clase ExAlumno - Herencia
    public class ExAlumno : MiembroDeLaComunidad
    {
        public string CarreraGraduado { get; set; }
        public int AñoGraduacion { get; set; }
        public string EmpresaActual { get; set; }

        public ExAlumno(int id, string nombre, string apellido, string email,
                       string carreraGraduado, int añoGraduacion, string empresaActual)
            : base(id, nombre, apellido, email)
        {
            CarreraGraduado = carreraGraduado;
            AñoGraduacion = añoGraduacion;
            EmpresaActual = empresaActual;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- EX-ALUMNO ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Carrera: {CarreraGraduado}");
            Console.WriteLine($"Año de Graduación: {AñoGraduacion}");
            Console.WriteLine($"Empresa Actual: {EmpresaActual}");
        }

        public override string ObtenerRol()
        {
            return "Ex-Alumno";
        }
    }

    // Clase Empleado - Herencia
    public class Empleado : MiembroDeLaComunidad
    {
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaContratacion { get; set; }

        public Empleado(int id, string nombre, string apellido, string email,
                       string departamento, decimal salario)
            : base(id, nombre, apellido, email)
        {
            Departamento = departamento;
            Salario = salario;
            FechaContratacion = DateTime.Now;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- EMPLEADO ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Salario: ${Salario:N2}");
            Console.WriteLine($"Fecha de Contratación: {FechaContratacion:dd/MM/yyyy}");
        }

        public override string ObtenerRol()
        {
            return "Empleado";
        }

        public virtual decimal CalcularBonoAnual()
        {
            return Salario * 0.1m; // 10% del salario
        }
    }

    // Clase Administrativo - Herencia de Empleado
    public class Administrativo : Empleado
    {
        public string Area { get; set; }
        public string Cargo { get; set; }

        public Administrativo(int id, string nombre, string apellido, string email,
                            string departamento, decimal salario, string area, string cargo)
            : base(id, nombre, apellido, email, departamento, salario)
        {
            Area = area;
            Cargo = cargo;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- ADMINISTRATIVO ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Área: {Area}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salario: ${Salario:N2}");
        }

        public override string ObtenerRol()
        {
            return "Administrativo";
        }
    }

    // Clase Docente - Herencia de Empleado
    public class Docente : Empleado
    {
        public string Especialidad { get; set; }
        public List<string> MateriasImpartidas { get; set; }

        public Docente(int id, string nombre, string apellido, string email,
                      string departamento, decimal salario, string especialidad)
            : base(id, nombre, apellido, email, departamento, salario)
        {
            Especialidad = especialidad;
            MateriasImpartidas = new List<string>();
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- DOCENTE ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Especialidad: {Especialidad}");
            Console.WriteLine($"Salario: ${Salario:N2}");
            
            if (MateriasImpartidas.Count > 0)
            {
                Console.WriteLine("Materias que imparte:");
                foreach (var materia in MateriasImpartidas)
                {
                    Console.WriteLine($"  - {materia}");
                }
            }
        }

        public override string ObtenerRol()
        {
            return "Docente";
        }

        public void AgregarMateria(string materia)
        {
            MateriasImpartidas.Add(materia);
        }

        public override decimal CalcularBonoAnual()
        {
            // Los docentes reciben 15% más bono por investigación
            return Salario * 0.15m;
        }
    }

    // Clase Maestro - Herencia de Docente
    public class Maestro : Docente
    {
        public string GradoAcademico { get; set; }
        public int AñosExperiencia { get; set; }

        public Maestro(int id, string nombre, string apellido, string email,
                      string departamento, decimal salario, string especialidad,
                      string gradoAcademico, int añosExperiencia)
            : base(id, nombre, apellido, email, departamento, salario, especialidad)
        {
            GradoAcademico = gradoAcademico;
            AñosExperiencia = añosExperiencia;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- MAESTRO ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Especialidad: {Especialidad}");
            Console.WriteLine($"Grado Académico: {GradoAcademico}");
            Console.WriteLine($"Años de Experiencia: {AñosExperiencia}");
            Console.WriteLine($"Salario: ${Salario:N2}");
            
            if (MateriasImpartidas.Count > 0)
            {
                Console.WriteLine("Materias que imparte:");
                foreach (var materia in MateriasImpartidas)
                {
                    Console.WriteLine($"  - {materia}");
                }
            }
        }

        public override string ObtenerRol()
        {
            return "Maestro";
        }

        public override decimal CalcularBonoAnual()
        {
            // Maestros reciben bono adicional por experiencia
            decimal bonoBase = base.CalcularBonoAnual();
            decimal bonoExperiencia = AñosExperiencia * 500m;
            return bonoBase + bonoExperiencia;
        }
    }

    // Clase Administrador - Herencia de Docente
    public class Administrador : Docente
    {
        public string CargoAdministrativo { get; set; }
        public int NumeroEmpleadosACargo { get; set; }

        public Administrador(int id, string nombre, string apellido, string email,
                           string departamento, decimal salario, string especialidad,
                           string cargoAdministrativo, int numeroEmpleadosACargo)
            : base(id, nombre, apellido, email, departamento, salario, especialidad)
        {
            CargoAdministrativo = cargoAdministrativo;
            NumeroEmpleadosACargo = numeroEmpleadosACargo;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- ADMINISTRADOR ACADÉMICO ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Especialidad: {Especialidad}");
            Console.WriteLine($"Cargo Administrativo: {CargoAdministrativo}");
            Console.WriteLine($"Empleados a Cargo: {NumeroEmpleadosACargo}");
            Console.WriteLine($"Salario: ${Salario:N2}");
        }

        public override string ObtenerRol()
        {
            return "Administrador Académico";
        }

        public override decimal CalcularBonoAnual()
        {
            // Administradores reciben bono por gestión
            decimal bonoBase = base.CalcularBonoAnual();
            decimal bonoGestion = NumeroEmpleadosACargo * 200m;
            return bonoBase + bonoGestion;
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE GESTIÓN DE COMUNIDAD EDUCATIVA          ║");
            Console.WriteLine("║   Demostrando Conceptos de POO en C#                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

            // Lista polimórfica - puede contener cualquier MiembroDeLaComunidad
            List<MiembroDeLaComunidad> comunidad = new List<MiembroDeLaComunidad>();

            // Creando instancias de diferentes tipos
            
            // Estudiantes
            var estudiante1 = new Estudiante(1001, "Carlos", "Rodríguez", "carlos.r@universidad.edu",
                                            "Ingeniería en Sistemas", 6, 8.5);
            var estudiante2 = new Estudiante(1002, "María", "González", "maria.g@universidad.edu",
                                            "Administración de Empresas", 4, 9.2);

            // Ex-Alumnos
            var exAlumno1 = new ExAlumno(2001, "Roberto", "Pérez", "roberto.p@email.com",
                                        "Ingeniería Industrial", 2020, "Tech Solutions Inc.");

            // Administrativo
            var admin1 = new Administrativo(3001, "Ana", "Martínez", "ana.m@universidad.edu",
                                           "Recursos Humanos", 45000m, "Gestión de Personal", "Coordinadora");

            // Maestros
            var maestro1 = new Maestro(4001, "Dr. José", "Hernández", "jose.h@universidad.edu",
                                      "Ciencias de la Computación", 65000m, "Inteligencia Artificial",
                                      "Doctorado en Ciencias Computacionales", 15);
            maestro1.AgregarMateria("Programación Orientada a Objetos");
            maestro1.AgregarMateria("Estructuras de Datos");
            maestro1.AgregarMateria("Algoritmos Avanzados");

            var maestro2 = new Maestro(4002, "Mtra. Laura", "Sánchez", "laura.s@universidad.edu",
                                      "Matemáticas", 58000m, "Matemáticas Aplicadas",
                                      "Maestría en Matemáticas", 10);
            maestro2.AgregarMateria("Cálculo Diferencial");
            maestro2.AgregarMateria("Álgebra Lineal");

            // Administrador Académico
            var administrador1 = new Administrador(5001, "Dr. Miguel", "Torres", "miguel.t@universidad.edu",
                                                  "Dirección Académica", 80000m, "Gestión Educativa",
                                                  "Director de Ingeniería", 25);
            administrador1.AgregarMateria("Seminario de Liderazgo");

            // Agregar a la comunidad
            comunidad.Add(estudiante1);
            comunidad.Add(estudiante2);
            comunidad.Add(exAlumno1);
            comunidad.Add(admin1);
            comunidad.Add(maestro1);
            comunidad.Add(maestro2);
            comunidad.Add(administrador1);

            // Demostración de Polimorfismo
            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("  LISTADO COMPLETO DE LA COMUNIDAD (Polimorfismo)");
            Console.WriteLine("══════════════════════════════════════════════════════");
            
            foreach (var miembro in comunidad)
            {
                miembro.MostrarInformacion();
            }

            // Demostración de Encapsulamiento y tipos específicos
            Console.WriteLine("\n\n══════════════════════════════════════════════════════");
            Console.WriteLine("  DEMOSTRACIÓN DE FUNCIONALIDADES ESPECÍFICAS");
            Console.WriteLine("══════════════════════════════════════════════════════");

            Console.WriteLine("\n--- Cálculo de Bonos Anuales (Empleados) ---");
            foreach (var miembro in comunidad)
            {
                if (miembro is Empleado empleado)
                {
                    Console.WriteLine($"{empleado.Nombre} {empleado.Apellido} ({empleado.ObtenerRol()}): " +
                                    $"Bono Anual = ${empleado.CalcularBonoAnual():N2}");
                }
            }

            // Estadísticas
            Console.WriteLine("\n\n══════════════════════════════════════════════════════");
            Console.WriteLine("  ESTADÍSTICAS DE LA COMUNIDAD");
            Console.WriteLine("══════════════════════════════════════════════════════");

            int totalEstudiantes = 0, totalEmpleados = 0, totalExAlumnos = 0;
            int totalDocentes = 0, totalAdministrativos = 0;
            decimal nominaTotal = 0;

            foreach (var miembro in comunidad)
            {
                if (miembro is Estudiante) totalEstudiantes++;
                else if (miembro is ExAlumno) totalExAlumnos++;
                else if (miembro is Administrativo) totalAdministrativos++;
                else if (miembro is Docente) totalDocentes++;
                
                if (miembro is Empleado emp)
                {
                    totalEmpleados++;
                    nominaTotal += emp.Salario;
                }
            }

            Console.WriteLine($"\nTotal de Miembros: {comunidad.Count}");
            Console.WriteLine($"  - Estudiantes: {totalEstudiantes}");
            Console.WriteLine($"  - Ex-Alumnos: {totalExAlumnos}");
            Console.WriteLine($"  - Empleados: {totalEmpleados}");
            Console.WriteLine($"    • Docentes (Maestros/Administradores): {totalDocentes}");
            Console.WriteLine($"    • Administrativos: {totalAdministrativos}");
            Console.WriteLine($"\nNómina Total Mensual: ${nominaTotal:N2}");

            // Resumen de conceptos POO
            Console.WriteLine("\n\n╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║        CONCEPTOS DE POO IMPLEMENTADOS                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.WriteLine("\n✓ ENCAPSULAMIENTO:");
            Console.WriteLine("  - Propiedades públicas con get/set");
            Console.WriteLine("  - Constructor protegido en clase base");
            Console.WriteLine("\n✓ HERENCIA:");
            Console.WriteLine("  - MiembroDeLaComunidad (base abstracta)");
            Console.WriteLine("    ├─ Estudiante");
            Console.WriteLine("    ├─ ExAlumno");
            Console.WriteLine("    └─ Empleado");
            Console.WriteLine("       ├─ Administrativo");
            Console.WriteLine("       └─ Docente");
            Console.WriteLine("          ├─ Maestro");
            Console.WriteLine("          └─ Administrador");
            Console.WriteLine("\n✓ POLIMORFISMO:");
            Console.WriteLine("  - Método abstracto MostrarInformacion()");
            Console.WriteLine("  - Método virtual ObtenerRol()");
            Console.WriteLine("  - Método virtual CalcularBonoAnual() con override");
            Console.WriteLine("\n✓ ABSTRACCIÓN:");
            Console.WriteLine("  - Clase abstracta MiembroDeLaComunidad");
            Console.WriteLine("  - Define comportamiento común para todos");

            Console.WriteLine("\n\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
