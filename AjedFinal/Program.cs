using System;


class Program
{
	static void Main(string[] args)
	{
		Juego juego = new Juego();
		juego.Login();
	}
}

// ============================================================================
// CLASES GENERALES
// ============================================================================

public class Jugador
{
	public string nombre;
	public string color;
	public int puntaje;
}

public class Pieza
{
	public string tipo;
	public string jugador;
}

// ============================================================================
// SISTEMA DE PUNTAJE
// ============================================================================

public class SistemaPuntaje
{
	public int puntajeActual;
	public int puntajeMaximo = 0;
	public string mejorJugador = "Ninguno";

	public void CalcularPuntaje(string ganador)
	{
		puntajeActual = 100;

		Console.WriteLine("Puntaje obtenido por " + ganador + ": " + puntajeActual);
	}

	public void GuardarRecord(string jugador, int puntaje)
	{
		if (puntaje > puntajeMaximo)
		{
			puntajeMaximo = puntaje;
			mejorJugador = jugador;

			Console.WriteLine("NUEVO RECORD");
		}
	}
}


// TABLERO


public class Tablero
{
	// TABLERO NUEVO
	public string[,] tablero = new string[8, 4];

	// Inicializar tablero
	public void Inicializar()
	{
		// Vacío
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				tablero[i, j] = ".";
			}
		}

		// =========================
		// PIEZAS NEGRAS
		// =========================

		// Torres
		tablero[0, 0] = "t";
		tablero[0, 3] = "t";

		// Rey
		tablero[0, 1] = "r";

		tablero[1, 1] = "p";
		tablero[1, 2] = "p";
		tablero[1, 3] = "p";
		tablero[1, 0] = "p";

		// =========================
		// PIEZAS BLANCAS
		// =========================

		// Torres
		tablero[7, 0] = "T";
		tablero[7, 3] = "T";

		// Rey
		tablero[7, 1] = "R";

		// Soldados
		tablero[6, 0] = "P";
		tablero[6, 1] = "P";
		tablero[6, 2] = "P";
		tablero[6, 3] = "p";
	}

	// Mostrar tablero
	public void Mostrar()
	{
		Console.Clear();

		Console.WriteLine("        COLUMNAS");
		Console.WriteLine("       PIEZAS NEGRAS");
		Console.WriteLine("        0 1 2 3");
		Console.WriteLine();

		for (int i = 0; i < 8; i++)
		{
			Console.Write("FILA " + i + "  ");

			for (int j = 0; j < 4; j++)
			{
				Console.Write(tablero[i, j] + " ");
			}

			Console.WriteLine();
		}
		Console.WriteLine("      PIEZAS BLANCAS");
		Console.WriteLine();

		Console.WriteLine("Filas = Arriba y abajo");
		Console.WriteLine("Columnas = Izquierda y derecha");

	}

	// Mover pieza
	public void Mover(int fo, int co, int fd, int cd)
	{
		tablero[fd, cd] = tablero[fo, co];

		tablero[fo, co] = ".";
	}
}

// ============================================================================
// JUEGO
// ============================================================================

public class Juego
{
	private string usuarioCorrecto = "admin";
	private string contraseñaCorrecta = "Admin123!";

	private string usuarioIngresado;
	private string contraseñaIngresada;

	private Tablero t = new Tablero();

	private SistemaPuntaje sp = new SistemaPuntaje();

	private string turnoActual;

	private int victoriasBlancas = 0;
	private int victoriasNegras = 0;

	// LOGIN
	public void Login()
	{
		while (true)
		{
			Console.Clear();

			Console.WriteLine("=== LOGIN ===");

			Console.Write("Usuario: ");
			usuarioIngresado = Console.ReadLine();

			if (usuarioIngresado.ToLower() != usuarioCorrecto.ToLower())
			{
				Console.WriteLine(" Usuario Incorrecto");
			}

			Console.Write("Contraseña: ");

			contraseñaIngresada = "";

			while (usuarioIngresado == usuarioCorrecto)
			{
				var tecla = Console.ReadKey(true);

				if (tecla.Key == ConsoleKey.Enter)
				{
					break;
				}

				if (tecla.Key == ConsoleKey.Backspace)
				{
					if (contraseñaIngresada.Length > 0)
					{
						contraseñaIngresada =
						contraseñaIngresada.Substring(0, contraseñaIngresada.Length - 1);

						Console.Write("\b \b");
					}
				}

				else
				{
					contraseñaIngresada += tecla.KeyChar;

					Console.Write("*");
				}
			}

			Console.WriteLine();

			if (usuarioIngresado == usuarioCorrecto && contraseñaIngresada == contraseñaCorrecta)
			{
				MostrarMenu();
				break;
			}

			else
			{
				Console.WriteLine("Contraseña incorrectas");

				Console.ReadKey();
			}
		}
	}

	// MENU
	public void MostrarMenu()
	{
		while (true)
		{
			Console.Clear();

			Console.WriteLine("=== MENU ===");

			Console.WriteLine("1. Jugar");
			Console.WriteLine("2. Reglas");
			Console.WriteLine("3. Puntaje Alto");
			Console.WriteLine("4. Salir");

			Console.Write("Seleccione: ");

			string op = Console.ReadLine();

			if (op == "1")
			{
				IniciarJuego();
			}

			else if (op == "2")
			{
				VerReglas();
			}

			else if (op == "3")
			{
				VerPuntajeAlto();
			}

			else if (op == "4")
			{
				break;
			}
		}
	}

	// REGLAS
	public void VerReglas()
	{
		Console.Clear();

		Console.WriteLine("=== REGLAS ===");

		Console.WriteLine("- Rey: 1 casilla cualquier direccion");
		Console.WriteLine("- Torre: horizontal o vertical");
		Console.WriteLine("- Torre no puede saltar piezas");
		Console.WriteLine("- Soldado avanza una casilla");
		Console.WriteLine("- Soldado ataca en diagonal");
		Console.WriteLine("- No puedes mover piezas del mismo equipo");
		Console.WriteLine("- Captura el rey enemigo");

		Console.ReadKey();
	}

	// PUNTAJE ALTO
	public void VerPuntajeAlto()
	{
		Console.Clear();

		Console.WriteLine("=== PUNTAJE ALTO ===\n");

		// MAYOR PUNTAJE
		Console.WriteLine("Jugador con mayor puntaje: " + sp.mejorJugador);
		Console.WriteLine("Puntaje máximo: " + sp.puntajeMaximo);

		Console.WriteLine();

		// VICTORIAS
		Console.WriteLine("Victorias Blancas: " + victoriasBlancas);
		Console.WriteLine("Victorias Negras: " + victoriasNegras);

		Console.WriteLine();

		// QUIEN VA GANANDO
		if (victoriasBlancas > victoriasNegras)
		{
			Console.WriteLine("El equipo con más victorias es: BLANCAS");
		}

		else if (victoriasNegras > victoriasBlancas)
		{
			Console.WriteLine("El equipo con más victorias es: NEGRAS");
		}

		else
		{
			Console.WriteLine("Ambos equipos tienen las mismas victorias");
		}

		Console.ReadKey();
	}

	// JUEGO
	public void IniciarJuego()
	{
		t.Inicializar();

		turnoActual = "Blanco";

		bool juegoActivo = true;

		while (juegoActivo)
		{
			t.Mostrar();
			Console.WriteLine("si desea salir del juego, ingrese -1 en todo.");
			Console.WriteLine("");
			Console.WriteLine("\nTurno: " + turnoActual);


			try
			{
				Console.Write("Fila origen: ");
				int fo = int.Parse(Console.ReadLine());

				Console.Write("Columna origen: ");
				int co = int.Parse(Console.ReadLine());

				Console.Write("Fila destino: ");
				int fd = int.Parse(Console.ReadLine());

				Console.Write("Columna destino: ");
				int cd = int.Parse(Console.ReadLine());
				if (fo == -1)
				{
					Console.WriteLine("Saliendo del juego...");
					Console.ReadKey();
					break;
				}

				if (MovimientoValido(fo, co, fd, cd))
				{
					if (t.tablero[fd, cd] != ".")
					{
						CapturarPieza(fd, cd);
					}

					t.Mover(fo, co, fd, cd);

					string ganador = VerificarGanador();

					if (ganador != "Ninguno")
					{
						t.Mostrar();

						Console.WriteLine("\nGANADOR: " + ganador);

						sp.CalcularPuntaje(ganador);

						sp.GuardarRecord(ganador, sp.puntajeActual);

						Console.ReadKey();

						juegoActivo = false;
					}

					else
					{
						CambiarTurno();
					}
				}

				else
				{
					Console.WriteLine("Movimiento invalido");

					Console.ReadKey();
				}
			}

			catch
			{
				Console.WriteLine("Error");

				Console.ReadKey();
			}

		}
	}

	// VALIDAR MOVIMIENTO
	public bool MovimientoValido(int fo, int co, int fd, int cd)
	{
		// VALIDAR TABLERO
		if (fo < 0 || fo > 7 || co < 0 || co > 3 || fd < 0 || fd > 7 || cd < 0 || cd > 3)
		{
			return false;
		}

		// VALIDAR PIEZA
		if (t.tablero[fo, co] == ".")
		{
			return false;
		}

		string pieza;

		pieza = t.tablero[fo, co];

		// VALIDAR MISMO EQUIPO
		if (t.tablero[fd, cd] != ".")
		{
			string destino;

			destino = t.tablero[fd, cd];

			// BLANCAS
			if (pieza == pieza.ToUpper() && destino == destino.ToUpper())
			{
				return false;
			}

			// NEGRAS
			if (pieza == pieza.ToLower() && destino == destino.ToLower())
			{
				return false;
			}
		}

		// VALIDAR TURNO
		if (turnoActual == "Blanco")
		{
			if (pieza != pieza.ToUpper())
			{
				return false;
			}
		}

		else
		{
			if (pieza != pieza.ToLower())
			{
				return false;
			}
		}

		// =========================
		// REY
		// =========================

		if (pieza == "R" || pieza == "r")
		{
			int filas;
			int columnas;

			filas = Math.Abs(fd - fo);
			columnas = Math.Abs(cd - co);

			if (filas <= 1 && columnas <= 1)
			{
				return true;
			}

			return false;
		}

		// =========================
		// TORRE
		// =========================

		else if (pieza == "T" || pieza == "t")
		{
			// SOLO HORIZONTAL O VERTICAL
			if (fo == fd || co == cd)
			{
				// MOVIMIENTO HORIZONTAL
				if (fo == fd)
				{
					int inicio;
					int fin;

					if (co < cd)
					{
						inicio = co + 1;
						fin = cd;
					}

					else
					{
						inicio = cd + 1;
						fin = co;
					}

					for (int i = inicio; i < fin; i++)
					{
						if (t.tablero[fo, i] != ".")
						{
							return false;
						}
					}
				}

				// MOVIMIENTO VERTICAL
				else
				{
					int inicio;
					int fin;

					if (fo < fd)
					{
						inicio = fo + 1;
						fin = fd;
					}

					else
					{
						inicio = fd + 1;
						fin = fo;
					}

					for (int i = inicio; i < fin; i++)
					{
						if (t.tablero[i, co] != ".")
						{
							return false;
						}
					}
				}

				return true;
			}

			return false;
		}

		// =========================
		// SOLDADO BLANCO
		// =========================

		else if (pieza == "P")
		{
			// AVANZAR
			if (fd == fo - 1 &&
				cd == co &&
				t.tablero[fd, cd] == ".")
			{
				return true;
			}

			// ATACAR DIAGONAL
			if (fd == fo - 1 &&
				(cd == co - 1 || cd == co + 1) &&
				t.tablero[fd, cd] != ".")
			{
				return true;
			}

			return false;
		}

		// =========================
		// SOLDADO NEGRO
		// =========================

		else if (pieza == "p")
		{
			// AVANZAR
			if (fd == fo + 1 &&
				cd == co &&
				t.tablero[fd, cd] == ".")
			{
				return true;
			}

			// ATACAR DIAGONAL
			if (fd == fo + 1 && (cd == co - 1 || cd == co + 1) && t.tablero[fd, cd] != ".")
			{
				return true;
			}

			return false;
		}

		return false;
	}

	// CAMBIAR TURNO
	public void CambiarTurno()
	{
		if (turnoActual == "Blanco")
		{
			turnoActual = "Negro";
		}

		else
		{
			turnoActual = "Blanco";
		}
	}

	// CAPTURA
	public void CapturarPieza(int fd, int cd)
	{
		Console.WriteLine("Pieza capturada: " + t.tablero[fd, cd]);

		Console.ReadKey();
	}

	// GANADOR
	public string VerificarGanador()
	{
		bool reyBlanco = false;
		bool reyNegro = false;

		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (t.tablero[i, j] == "R")
				{
					reyBlanco = true;
				}

				if (t.tablero[i, j] == "r")
				{
					reyNegro = true;
				}
			}
		}

		if (reyBlanco == false)
		{
			return "Negro";
		}

		if (reyNegro == false)
		{
			return "Blanco";
		}

		return "Ninguno";
	}
}
