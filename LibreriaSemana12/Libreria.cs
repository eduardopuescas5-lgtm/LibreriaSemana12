using System;

namespace LibreriaSemana12
{
    class Libreria
    {
        // Arreglos fijos
        string[] nombres = new string[100];
        double[] precios = new double[100];
        int cantidad = 0;

        public void Registrar()
        {
            if (cantidad >= 100)
            {
                Console.WriteLine("No se pueden registrar más libros (límite 100).");
                return;
            }

            Console.Write("Ingrese el nombre del libro: ");
            string nombre = Console.ReadLine();

            if (nombre == "")
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            // Validar duplicado
            for (int i = 0; i < cantidad; i++)
            {
                if (nombres[i] == nombre)
                {
                    Console.WriteLine("Ese libro ya está registrado.");
                    return;
                }
            }

            Console.Write("Ingrese el precio del libro: ");
            double precio;
            if (!double.TryParse(Console.ReadLine(), out precio))
            {
                Console.WriteLine("El precio debe ser numérico.");
                return;
            }

            if (precio <= 0 || precio > 1000)
            {
                Console.WriteLine("El precio debe ser mayor que 0 y menor o igual a 1000.");
                return;
            }

            // Guardar en los arreglos
            nombres[cantidad] = nombre;
            precios[cantidad] = precio;
            cantidad++;

            Console.WriteLine("Libro registrado correctamente.");
        }

        public void Mostrar()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("\nLISTA DE LIBROS:");
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - S/. {precios[i]:0.00}");
            }
        }

        public void Modificar()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay libros para modificar.");
                return;
            }

            Console.Write("Ingrese el nombre del libro a modificar: ");
            string nombre = Console.ReadLine();

            int pos = -1;
            for (int i = 0; i < cantidad; i++)
            {
                if (nombres[i] == nombre)
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("No se encontró ese libro.");
                return;
            }

            Console.Write("Ingrese el nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            if (nuevoNombre == "")
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            // Validar duplicado en el nuevo nombre
            for (int i = 0; i < cantidad; i++)
            {
                if (nombres[i] == nuevoNombre && i != pos)
                {
                    Console.WriteLine("Ya existe un libro con ese nombre.");
                    return;
                }
            }

            Console.Write("Ingrese el nuevo precio: ");
            double nuevoPrecio;
            if (!double.TryParse(Console.ReadLine(), out nuevoPrecio))
            {
                Console.WriteLine("El precio debe ser numérico.");
                return;
            }

            if (nuevoPrecio <= 0 || nuevoPrecio > 1000)
            {
                Console.WriteLine("El precio debe ser mayor que 0 y menor o igual a 1000.");
                return;
            }

            // Actualizar
            nombres[pos] = nuevoNombre;
            precios[pos] = nuevoPrecio;

            Console.WriteLine("Libro modificado correctamente.");
        }

        public void Eliminar()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay libros para eliminar.");
                return;
            }

            Console.Write("Ingrese el nombre del libro a eliminar: ");
            string nombre = Console.ReadLine();

            int pos = -1;
            for (int i = 0; i < cantidad; i++)
            {
                if (nombres[i] == nombre)
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("No se encontró ese libro.");
                return;
            }

            // Mover los elementos siguientes una posición hacia atrás
            for (int i = pos; i < cantidad - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                precios[i] = precios[i + 1];
            }

            cantidad--;
            Console.WriteLine("Libro eliminado correctamente.");
        }
    }
}
