class Program
{
	static string usuarioCorrecto = "admin";
	static string contraseñaCorrecta = "Admin123!";

	static string usuarioIngresado;
	static string contraseñaIngresada;

	static int opcion;

	static void Main()
	{
		Console.WriteLine("================================");
		Console.WriteLine("   SISTEMA DE AJEDREZ");
		Console.WriteLine("================================");

		Console.WriteLine("\nBienvenido al sistema");

		Login();

		Console.ReadLine();
	}

	static void Login()
	{
		Console.Write("\nIngrese el usuario: ");
		usuarioIngresado = Console.ReadLine();

		Console.Write("Ingrese la contraseña: ");
		contraseñaIngresada = Console.ReadLine();

		if (usuarioIngresado == usuarioCorrecto &&
			contraseñaIngresada == contraseñaCorrecta)
		{
			Console.WriteLine("\nAcceso permitido");

			MostrarMenu();
		}
		else
		{
			Console.WriteLine("\nUsuario o contraseña incorrectos");
		}
	}

	static void MostrarMenu()
	{
		do
		{
			Console.WriteLine("\n===== MENU PRINCIPAL =====");
			Console.WriteLine("1. Iniciar juego");
			Console.WriteLine("2. Ver reglas");
			Console.WriteLine("3. Ver puntaje alto");
			Console.WriteLine("4. Salir");

			Console.Write("\nSeleccione una opcion: ");
			opcion = int.Parse(Console.ReadLine());

			switch (opcion)
			{
				case 1:
					Console.WriteLine("\nIniciando juego...");
					break;

				case 2:
					VerReglas();
					break;

				case 3:
					VerPuntajeAlto();
					break;

				case 4:
					Console.WriteLine("\nSaliendo del sistema...");
					break;

				default:
					Console.WriteLine("\nOpcion invalida");
					break;
			}

		} while (opcion != 4);
	}

	static void VerReglas()
	{
		Console.WriteLine("\n===== REGLAS =====");
		Console.WriteLine("- El rey se mueve una casilla");
		Console.WriteLine("- La torre se mueve en linea recta");
		Console.WriteLine("- El soldado avanza una casilla");
	}

	static void VerPuntajeAlto()
	{
		Console.WriteLine("\n===== PUNTAJE ALTO =====");
		Console.WriteLine("Jugador: Fernando");
		Console.WriteLine("Puntaje: 150");
	}
}