class Program
{
	static void Main(string[] args)
	{
		string usuarioCorrecto = "admin";
		string contraseñaCorrecta = "Admin123!";

		string usuarioIngresado;
		string contraseñaIngresada;

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
		}
		else
		{
			Console.WriteLine("\nUsuario o contraseña incorrectos");
		}
	}
}