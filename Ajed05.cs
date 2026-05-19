class Program
{
	static void Main()
	{
		string usuarioCorrecto = "admin";
		string contraseñaCorrecta = "Admin123!";

		string usuarioIngresado;
		string contraseñaIngresada;

		int opcion;

		Console.WriteLine("================================");
		Console.WriteLine("   SISTEMA DE AJEDREZ");
		Console.WriteLine("================================");

		Console.WriteLine("\nBienvenido al sistema");

		Console.Write("\nIngrese el usuario: ");
		usuarioIngresado = Console.ReadLine();

		Console.Write("Ingrese la contraseña: ");
		contraseñaIngresada = Console.ReadLine();

		if (usuarioIngresado == usuarioCorrecto &&
			contraseñaIngresada == contraseñaCorrecta)
		{
			Console.WriteLine("\nAcceso permitido");

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
						Console.WriteLine("\nMostrando reglas...");
						break;

					case 3:
						Console.WriteLine("\nMostrando puntaje alto...");
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
		else
		{
			Console.WriteLine("\nUsuario o contraseña incorrectos");
		}
	}
}