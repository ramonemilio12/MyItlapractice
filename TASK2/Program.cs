// See https://aka.ms/new-console-template for more information

bool valido = false;

while (!valido)
{
    try
    {
        Console.WriteLine("Ingrese un número:");
        int numero = int.Parse(Console.ReadLine());

        if (numero % 2 == 0)
        {
            Console.WriteLine($"El número {numero} es par.");
        }
        else
        {
            Console.WriteLine($"El número {numero} es impar.");
        }

        valido = true; 
    }
    catch
    {
        Console.WriteLine("Error: debe ingresar un número válido.");
    }
}


