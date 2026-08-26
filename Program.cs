namespace RegistroGastos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> descripciones = new List<string>();
            List<decimal> montos = new List<decimal>();

            string opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=== REGISTRO DE GASTOS ===");
                Console.WriteLine("1. Agregar gasto");
                Console.WriteLine("2. Listar gastos");
                Console.WriteLine("3. Buscar gasto");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                        Console.WriteLine();
                        Console.WriteLine("=== Agregar gasto ===");

                        Console.Write("Descripción del gasto: ");
                        string descripcion = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(descripcion))
                        {
                            Console.WriteLine("Datos inválidos.");
                            break;
                        }

                        Console.Write("Monto del gasto: ");
                        bool montoOk = decimal.TryParse(
                            Console.ReadLine(),
                            out decimal monto);

                        if (!montoOk || monto <= 0)
                        {
                            Console.WriteLine("Datos inválidos.");
                            break;
                        }

                        descripciones.Add(descripcion);
                        montos.Add(monto);

                        Console.WriteLine("Gasto agregado.");

                        break;

                    case "2":

                        Console.WriteLine();
                        Console.WriteLine("Lista de gastos:");

                        if (descripciones.Count == 0)
                        {
                            Console.WriteLine("No hay gastos.");
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("# Descripción Monto");

                        decimal total = 0;

                        for (int i = 0; i < descripciones.Count; i++)
                        {
                            Console.WriteLine(
                                (i + 1) + " " +
                                descripciones[i] +
                                " Q " +
                                montos[i].ToString("N2"));

                            total = total + montos[i];
                        }

                        Console.WriteLine();
                        Console.WriteLine("Total gastado: Q " + total.ToString("N2"));

                        break;

                    case "3":

                        Console.WriteLine();
                        Console.Write("Texto a buscar: ");
                        string texto = Console.ReadLine();

                        string textoBusqueda = texto.ToUpper();
                        bool encontrado = false;

                        for (int i = 0; i < descripciones.Count; i++)
                        {
                            if (descripciones[i].ToUpper().Contains(textoBusqueda))
                            {
                                Console.WriteLine(
                                    "- " +
                                    descripciones[i] +
                                    " (Q " +
                                    montos[i].ToString("N2") +
                                    ")");

                                encontrado = true;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine("Sin coincidencias.");
                        }

                        break;

                    case "4":

                        Console.WriteLine("Saliendo...");

                        break;

                    default:

                        Console.WriteLine("Opción no válida.");

                        break;
                }

            } while (opcion != "4");
        }
    }
}