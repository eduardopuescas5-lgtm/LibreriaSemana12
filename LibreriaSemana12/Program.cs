using System;

namespace LibreriaSemana12
{
    class Program
    {
        static void Main(string[] args)
        {
            Libreria libreria = new Libreria();
            int opcion;

            do
            {
                Console.WriteLine("\n======= MENÚ LIBRERÍA =======");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Mostrar libros");
                Console.WriteLine("3. Modificar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida.");
                    continue;
                }

                if (opcion == 1) libreria.Registrar();
                else if (opcion == 2) libreria.Mostrar();
                else if (opcion == 3) libreria.Modificar();
                else if (opcion == 4) libreria.Eliminar();
                else if (opcion == 5) Console.WriteLine("Saliendo del sistema...");
                else Console.WriteLine("Opción fuera de rango.");

            } while (opcion != 5);
        }
    }
}
