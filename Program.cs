csharp Listas Edades\Program.cs
using System;
using System.IO;

namespace Listas_Edades
{
    internal class Program
    {
        private enum Menu
        {
            Salir = 0,
            Agregar = 1,
            EliminarPorValor = 2,
            Actualizar = 3,
            ConsultarTodas = 4,
            Ordenar = 5,
            Sumar = 6,
            Promedio = 7,
            Exportar = 8
        }

        static void Main(string[] args)
        {
            var acciones = new Acciones();

            // Llamada a la clase Constructor (instancia antes del bucle)
            var constructor = new Constructor("Aldo", "ISC");
            Console.WriteLine("Datos del constructor: " + constructor);

            int opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=== Men� de operaciones sobre la lista de edades ===");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Agregar edad");
                Console.WriteLine("2 - Eliminar edad por valor");
                Console.WriteLine("3 - Actualizar edad");
                Console.WriteLine("4 - Consultar todas las edades");
                Console.WriteLine("5 - Ordenar lista (menor a mayor)");
                Console.WriteLine("6 - Calcular suma de edades");
                Console.WriteLine("7 - Calcular promedio de edades");
                Console.WriteLine("8 - Exportar XML (edades.xml)");
                Console.Write("Seleccione una opci�n: ");

                var entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Entrada no v�lida. Introduzca el n�mero de la opci�n.");
                    continue;
                }

                switch ((Menu)opcion)
                {
                    case Menu.Agregar:
                        Console.Write("Edad a agregar: ");
                        if (int.TryParse(Console.ReadLine(), out int edadAgregar))
                        {
                            acciones.AgregarEdad(edadAgregar);
                            Console.WriteLine("Edad agregada.");
                        }
                        else
                        {
                            Console.WriteLine("Edad no v�lida.");
                        }
                        break;

                    case Menu.EliminarPorValor:
                        Console.Write("Valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                        {
                            if (acciones.EliminarPorValor(valorEliminar))
                                Console.WriteLine("Se elimin� la primera ocurrencia del valor.");
                            else
                                Console.WriteLine("Valor no encontrado en la lista.");
                        }
                        else
                        {
                            Console.WriteLine("Valor no v�lido.");
                        }
                        break;

                    case Menu.Actualizar:
                        Console.Write("�ndice a actualizar (0-based): ");
                        if (!int.TryParse(Console.ReadLine(), out int indiceActualizar))
                        {
                            Console.WriteLine("�ndice no v�lido.");
                            break;
                        }
                        Console.Write("Nueva edad: ");
                        if (!int.TryParse(Console.ReadLine(), out int nuevaEdad))
                        {
                            Console.WriteLine("Edad no v�lida.");
                            break;
                        }
                        if (acciones.ActualizarEdad(indiceActualizar, nuevaEdad))
                            Console.WriteLine("Edad actualizada.");
                        else
                            Console.WriteLine("�ndice fuera de rango.");
                        break;

                    case Menu.ConsultarTodas:
                        var todas = acciones.ObtenerTodas();
                        if (todas.Count == 0)
                        {
                            Console.WriteLine("No hay edades registradas.");
                        }
                        else
                        {
                            Console.WriteLine("Edades registradas:");
                            for (int i = 0; i < todas.Count; i++)
                                Console.WriteLine($"[{i}] {todas[i]}");
                        }
                        break;

                    case Menu.Ordenar:
                        acciones.Ordenar();
                        Console.WriteLine("Lista ordenada (menor a mayor).");
                        break;

                    case Menu.Sumar:
                        Console.WriteLine("Suma de edades: " + acciones.Sumar());
                        break;

                    case Menu.Promedio:
                        Console.WriteLine("Promedio de edades: " + acciones.Promedio().ToString("F2"));
                        break;

                    case Menu.Exportar:
                        var ruta = Path.Combine(Environment.CurrentDirectory, "edades.xml");
                        try
                        {
                            acciones.ExportarAArchivo(ruta);
                            Console.WriteLine("Lista exportada a: " + ruta);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al exportar: " + ex.Message);
                        }
                        break;

                    case Menu.Salir:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opci�n no reconocida.");
                        break;
                }

            } while (opcion != (int)Menu.Salir);
        }
    }
}   