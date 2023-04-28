class Program
{
    static void Main(string[] args)
    {
        int[,] tablero = new int[5, 5];
        int cantidad_barcos = 3;
        int intentos = 0;

        paso1_crear_tablero(tablero);
        paso2_colocar_barcos(tablero, cantidad_barcos);

        while (cantidad_barcos > 0)
        {
            Console.Clear();
            Console.Write(" Bienvenido al juego de batalla naval\n");
            Console.WriteLine("Intentos: " + intentos);
            paso3_colocar_tablero(tablero, true);

            int fila, columna;
            do
            {
                Console.Write("Ingresa la fila: ");
                fila = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingresa la columna: ");
                columna = Convert.ToInt32(Console.ReadLine());
                if (fila >= 0 && fila < 5 && columna >= 0 && columna < 5)
                {
                    break;
                }
                Console.WriteLine("Coordenadas inválidas. Intenta de nuevo.");
            } while (true);

            if (tablero[fila, columna] == 1)
            {
                Console.WriteLine("¡Golpeaste un barco!");
                Console.Beep(700, 400);
                tablero[fila, columna] = 2;
                cantidad_barcos--;
            }
            else
            {
                Console.WriteLine("Fallaste.");
                Console.Beep(330, 400);
                tablero[fila, columna] = -1;
            }
            intentos++;
        }

        Console.Clear();
        Console.WriteLine("¡Felicitaciones, has ganado! Te tomó " + intentos + " intentos.");
        paso3_colocar_tablero(tablero, false);
        Console.ReadLine();
    }

    static void paso1_crear_tablero(int[,] tablero)
    {
        for (int f = 0; f < tablero.GetLength(0); f++)
        {
            for (int c = 0; c < tablero.GetLength(1); c++)
            {
                tablero[f, c] = 0;
            }
        }
    }

    static void paso2_colocar_barcos(int[,] tablero, int cantidad_barcos)
    {
        Random rnd = new Random();
        for (int i = 0; i < cantidad_barcos; i++)
        {
            int fila = rnd.Next(0, 5);
            int columna = rnd.Next(0, 5);
            while (tablero[fila, columna] == 1)
            {
                fila = rnd.Next(0, 5);
                columna = rnd.Next(0, 5);
            }
            tablero[fila, columna] = 1;
        }
    }

    static void paso3_colocar_tablero(int[,] tablero, bool mostrar_barcos)
    {
        Console.WriteLine("   0  1  2  3  4");
        for (int f = 0; f < tablero.GetLength(0); f++)
        {
            Console.Write(f + " ");
            for (int c = 0; c < tablero.GetLength(1); c++)
            {
                if (!mostrar_barcos && tablero[f, c] == 1)
                {
                    Console.Write("-  ");
                }
                else if (tablero[f, c] == 0 || tablero[f, c] == 1)
                {
                    Console.Write("~  ");
                }
                else if (tablero[f, c] == -1)
                {
                    Console.Write("-1 ");
                }
                else if (tablero[f, c] == 2)
                {
                    Console.Write("2 ");
                }
            }
            Console.WriteLine();
        }
    }
}