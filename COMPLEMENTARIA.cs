class Program
{
    static void Main()
    {
        Console.WriteLine("Sistema de Registro de Pacientes");
        Hospital hospital = new Hospital();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Agregar   2. Ver   3. Buscar   4. Modificar   5. Eliminar   6. Salir");
            Console.Write("Opción: ");
            int op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1: hospital.Agregar(); break;
                case 2: hospital.Ver(); break;
                case 3: hospital.Buscar(); break;
                case 4: hospital.Modificar(); break;
                case 5: hospital.Eliminar(); break;
                case 6: running = false; break;
                default: Console.WriteLine("Opción inválida"); break;
            }
        }
    }
}

class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Diagnostico { get; set; }

    public void Mostrar()
    {
        Console.WriteLine($"{Id} - {Nombre}, {Edad} años, Diagnóstico: {Diagnostico}");
    }
}

class Hospital
{
    private List<Paciente> pacientes = new List<Paciente>();

    public void Agregar()
    {
        int id = pacientes.Count + 1;
        Console.Write("Nombre: "); string nombre = Console.ReadLine();
        Console.Write("Edad: "); int edad = Convert.ToInt32(Console.ReadLine());
        Console.Write("Diagnóstico: "); string diag = Console.ReadLine();

        pacientes.Add(new Paciente { Id = id, Nombre = nombre, Edad = edad, Diagnostico = diag });
        Console.WriteLine("Paciente agregado.");
    }

    public void Ver()
    {
        if (pacientes.Count == 0) Console.WriteLine("No hay pacientes.");
        else foreach (var p in pacientes) p.Mostrar();
    }

    public void Buscar()
    {
        Console.Write("Id a buscar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var p = pacientes.Find(x => x.Id == id);
        if (p != null) p.Mostrar(); else Console.WriteLine("No encontrado.");
    }

    public void Modificar()
    {
        Console.Write("Id a modificar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var p = pacientes.Find(x => x.Id == id);
        if (p != null)
        {
            Console.Write("Nuevo nombre: "); p.Nombre = Console.ReadLine();
            Console.Write("Nueva edad: "); p.Edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nuevo diagnóstico: "); p.Diagnostico = Console.ReadLine();
            Console.WriteLine("Paciente modificado.");
        }
        else Console.WriteLine("No encontrado.");
    }

    public void Eliminar()
    {
        Console.Write("Id a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var p = pacientes.Find(x => x.Id == id);
        if (p != null) { pacientes.Remove(p); Console.WriteLine("Paciente eliminado."); }
        else Console.WriteLine("No encontrado.");
    }
}
