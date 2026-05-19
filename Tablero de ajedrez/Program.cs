using System;

class Jugador
{
    public string nombre;
    public string color;
    public int puntaje;
}

class Pieza
{
    public string tipo;
    public string jugador;
}

class SistemaPuntaje
{
    public int puntajeMaximo = 0;
    public string mejorJugador = "";

    // CALCULAR PUNTOS
    public int CalcularPuntaje(string tipo)
    {
        if (tipo == "Soldado")
        {
            return 10;
        }

        else if (tipo == "Torre")
        {
            return 10;
        }

        else if (tipo == "Rey")
        {
            return 60;
        }

        return 0;
    }

    // GUARDAR RECORD
    public void GuardarRecord(Jugador ganador)
    {
        if (ganador.puntaje > puntajeMaximo)
        {
            puntajeMaximo = ganador.puntaje;
            mejorJugador = ganador.nombre;
        }
    }

    // MOSTRAR RECORD
    public void VerPuntajeAlto()
    {
        if (puntajeMaximo == 0)
        {
            Console.WriteLine("No hay puntajes guardados");
        }

        else
        {
            Console.WriteLine("\n-----Puntaje Más Alto-----");
            Console.WriteLine("Jugador: " + mejorJugador);
            Console.WriteLine("Puntaje: " + puntajeMaximo);
        }
    }
}

class Program
{
    static void CapturarPieza
    (
        Pieza[,] tablero,
        int filaOrigen,
        int columnaOrigen,
        int filaDestino,
        int columnaDestino,
        Jugador jugadorActual,
        SistemaPuntaje sistemaPuntaje
    )
    {
        Pieza piezaDestino;

        piezaDestino = tablero[filaDestino, columnaDestino];

        if (piezaDestino != null)
        {
            if (piezaDestino.jugador != tablero[filaOrigen, columnaOrigen].jugador)
            {
                Console.WriteLine("\nCAPTURA!");

                Console.WriteLine
                (
                    tablero[filaOrigen, columnaOrigen].tipo + " capturo a " + piezaDestino.tipo );

                int puntos;

                puntos = sistemaPuntaje.CalcularPuntaje(piezaDestino.tipo);

                jugadorActual.puntaje =
                jugadorActual.puntaje + puntos;

                Console.WriteLine("Puntos ganados: " + puntos);

                Console.WriteLine
                (
                    "Puntaje total: " +
                    jugadorActual.puntaje
                );

                tablero[filaDestino, columnaDestino] = null;
            }
        }

        tablero[filaDestino, columnaDestino] =  tablero[filaOrigen, columnaOrigen];

        tablero[filaOrigen, columnaOrigen] = null;
    }
}