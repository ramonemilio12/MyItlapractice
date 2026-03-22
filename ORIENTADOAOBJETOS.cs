Console.WriteLine("Mi Agenda Perrón");
Console.WriteLine("Bienvenido a tu lista de contactes");

Agenda agenda = new Agenda();
bool running = true;

while (running)
{
    Console.Write("1. Agregar Contacto      ");
    Console.Write("2. Ver Contactos     ");
    Console.Write("3. Buscar Contactos      ");
    Console.Write("4. Modificar Contacto        ");
    Console.Write("5. Eliminar Contacto     ");
    Console.WriteLine("6. Salir");
    Console.Write("Elige una opción: ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1: agenda.Agregar(); break;
        case 2: agenda.Ver(); break;
        case 3: agenda.Buscar(); break;
        case 4: agenda.Modificar(); break;
        case 5: agenda.Eliminar(); break;
        case 6: running = false; break;
        default: Console.WriteLine("Opción no válida"); break;
    }
}

class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public void Mostrar()
    {
        Console.WriteLine($"{Id}    {Nombre}    {Telefono}    {Email}    {Direccion}");
    }
}

class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();

    public void Agregar()
    {
        int id = contactos.Count + 1;
        Console.Write("Digite el Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Digite el Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Digite el Email: ");
        string email = Console.ReadLine();
        Console.Write("Digite la Dirección: ");
        string direccion = Console.ReadLine();

        contactos.Add(new Contacto { Id = id, Nombre = nombre, Telefono = telefono, Email = email, Direccion = direccion });
        Console.WriteLine("Contacto agregado correctamente.");
    }

    public void Ver()
    {
        Console.WriteLine("Id           Nombre          Telefono            Email           Dirección");
        Console.WriteLine("___________________________________________________________________________");
        foreach (var c in contactos)
        {
            c.Mostrar();
        }
    }

    public void Buscar()
    {
        Console.WriteLine("Digite un Id de Contacto Para Mostrar");
        int idSeleccionado = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.FirstOrDefault(c => c.Id == idSeleccionado);
        if (contacto != null) contacto.Mostrar();
        else Console.WriteLine("Contacto no encontrado.");
    }

    public void Modificar()
    {
        Ver();
        Console.WriteLine("Digite un Id de Contacto Para Editar");
        int idSeleccionado = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.FirstOrDefault(c => c.Id == idSeleccionado);

        if (contacto != null)
        {
            Console.Write($"El nombre es: {contacto.Nombre}, Digite el Nuevo Nombre: ");
            contacto.Nombre = Console.ReadLine();

            Console.Write($"El Teléfono es: {contacto.Telefono}, Digite el Nuevo Teléfono: ");
            contacto.Telefono = Console.ReadLine();

            Console.Write($"El Email es: {contacto.Email}, Digite el Nuevo Email: ");
            contacto.Email = Console.ReadLine();

            Console.Write($"La dirección es: {contacto.Direccion}, Digite la nueva dirección: ");
            contacto.Direccion = Console.ReadLine();

            Console.WriteLine("Contacto modificado correctamente.");
        }
        else Console.WriteLine("Contacto no encontrado.");
    }

    public void Eliminar()
    {
        Ver();
        Console.WriteLine("Digite un Id de Contacto Para Eliminar");
        int idSeleccionado = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
        int opcion = Convert.ToInt32(Console.ReadLine());

        if (opcion == 1)
        {
            var contacto = contactos.FirstOrDefault(c => c.Id == idSeleccionado);
            if (contacto != null)
            {
                contactos.Remove(contacto);
                Console.WriteLine("Contacto eliminado correctamente.");
            }
            else Console.WriteLine("Contacto no encontrado.");
        }
    }
}

