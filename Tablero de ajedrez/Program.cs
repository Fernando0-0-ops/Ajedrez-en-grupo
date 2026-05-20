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
    //Función que recibe un tipo de pieza y devuelve puntos. devuelve un int 
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
    //Función para guardar el récord.
    public void GuardarRecord(Jugador ganador)
    {
        //ganador pasa a representar al jugador que ganó la partida, y se compara su puntaje con el puntaje máximo registrado.
        //Si el puntaje del ganador es mayor que el puntaje máximo, se actualiza el puntaje máximo y se guarda el nombre del mejor jugador.
        if (ganador.puntaje > puntajeMaximo)
        {
            //guardamos el nuevo puntaje y nombre
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
    // CAPTURAR PIEZA
    //Función que recibe el tablero
    ///la posición de origen y destino, 
    //el jugador actual y el sistema de puntaje. 
    //Realiza la captura de la pieza enemiga
    //suma puntos al jugador actual y mueve la pieza.
    static void CapturarPieza(Pieza[,] tablero, int filaOrigen, int columnaOrigen, int filaDestino, int columnaDestino, Jugador jugadorActual, SistemaPuntaje sistemaPuntaje)
    {
        //Crea variable para guardar pieza destino.
        Pieza piezaDestino;

        //Guarda la pieza que está en destino.
        piezaDestino = tablero[filaDestino, columnaDestino];

        // SI HAY PIEZA ENEMIGA
        //¿hay pieza ahí? null = vacio
        if (piezaDestino != null)
        {
            //¿la pieza que está en destino pertenece al jugador contrario?
            //Si es diferente, entonces es una captura.
            if (piezaDestino.jugador != tablero[filaOrigen, columnaOrigen].jugador)
            {
                Console.WriteLine("\nCAPTURA!");
                //Obtiene tipo de pieza atacante.               //Obtiene tipo de pieza capturada.
                Console.WriteLine(tablero[filaOrigen, columnaOrigen].tipo + " capturo a " + piezaDestino.tipo);

                // SUMAR PUNTOS
                int puntos;
                ///Calcula puntos según pieza capturada 
                //mandamos información al metodo calcular puntaje
                puntos = sistemaPuntaje.CalcularPuntaje(piezaDestino.tipo);

                //Suma puntos al jugador.
                jugadorActual.puntaje = jugadorActual.puntaje + puntos;

                Console.WriteLine("Puntos ganados: " + puntos);

                Console.WriteLine("Puntaje total: " + jugadorActual.puntaje);

                // ELIMINAR PIEZA
                //Elimina la pieza capturada del tablero.
                tablero[filaDestino, columnaDestino] = null;
            }
        }

        // MOVER PIEZA
        //Mueve la pieza desde la posición de origen a la posición de destino.
        tablero[filaDestino, columnaDestino] = tablero[filaOrigen, columnaOrigen];

        //Vacía posición original.
        tablero[filaOrigen, columnaOrigen] = null;
    }

    // VERIFICAR GANADOR
    static bool VerificarGanador(Pieza[,] tablero, Jugador jugador1, Jugador jugador2)
    {
        //Variable para saber si existe rey blanco o negro 
        bool reyBlanco = false;
        bool reyNegro = false;

        //Contador de piezas blancas y de negras
        int piezasBlancas = 0;
        int piezasNegras = 0;

        // RECORRER TABLERO
        //filas
        for (int i = 0; i < 8; i++)
        {
            //columnas
            for (int j = 0; j < 8; j++)
            {
                //¿hay pieza?
                if (tablero[i, j] != null)
                {
                    // CONTAR PIEZAS
                    // si hay pieza blanca sumamos 1
                    if (tablero[i, j].jugador == "Blanco")
                    {
                        piezasBlancas++;
                    }

                    // si hay pieza negra sumamos 1
                    else if (tablero[i, j].jugador == "Negro")
                    {
                        piezasNegras++;
                    }

                    // BUSCAR REYES
                    //indicamos si hay rey blanco o negro 
                    //¿Hay pieza rey?
                    if (tablero[i, j].tipo == "Rey")
                    {
                        //¿Hay blanca?
                        if (tablero[i, j].jugador == "Blanco")
                        {
                            reyBlanco = true;
                        }
                        //¿Hay negra?
                        else if (tablero[i, j].jugador == "Negro")
                        {
                            reyNegro = true;
                        }
                    }
                }
            }
        }

        // SI NO EXISTE EL REY BLANCO
        if (reyBlanco == false)
        {
            Console.WriteLine("\nGANADOR: " + jugador2.nombre);

            return true;
        }

        // SI NO EXISTE EL REY NEGRO
        if (reyNegro == false)
        {
            Console.WriteLine("\nGANADOR: " + jugador1.nombre);

            return true;
        }

        // SI NO HAY PIEZAS BLANCAS
        if (piezasBlancas == 0)
        {
            Console.WriteLine("\nGANADOR: " + jugador2.nombre);

            return true;
        }

        // SI NO HAY PIEZAS NEGRAS
        if (piezasNegras == 0)
        {
            Console.WriteLine("\nGANADOR: " + jugador1.nombre);

            return true;
        }

        return false;
    }


    //Es un parámetro que sirve para recibir datos desde consola.
    //args Es un parámetro que sirve para recibir datos desde consola.
    static void Main(string[] args)
    {
        // TABLERO
        Pieza[,] tablero = new Pieza[8, 8];

        // JUGADOR 1
        Jugador jugador1 = new Jugador();

        jugador1.nombre = "Fernando";
        jugador1.color = "Blanco";
        jugador1.puntaje = 0;

        // JUGADOR 2
        Jugador jugador2 = new Jugador();

        jugador2.nombre = "Pablo";
        jugador2.color = "Negro";
        jugador2.puntaje = 0;

        // PIEZAS NEGRAS
        tablero[0, 0] = new Pieza();
        tablero[0, 0].tipo = "Rey";
        tablero[0, 0].jugador = "Negro";

        tablero[0, 1] = new Pieza();
        tablero[0, 1].tipo = "Torre";
        tablero[0, 1].jugador = "Negro";

        tablero[1, 0] = new Pieza();
        tablero[1, 0].tipo = "Soldado";
        tablero[1, 0].jugador = "Negro";

        // PIEZAS BLANCAS
        tablero[7, 7] = new Pieza();
        tablero[7, 7].tipo = "Rey";
        tablero[7, 7].jugador = "Blanco";

        tablero[7, 6] = new Pieza();
        tablero[7, 6].tipo = "Torre";
        tablero[7, 6].jugador = "Blanco";

        tablero[6, 7] = new Pieza();
        tablero[6, 7].tipo = "Soldado";
        tablero[6, 7].jugador = "Blanco";

        // SISTEMA PUNTAJE
        //Creamos otro objeto del sistema de puntaje.
        SistemaPuntaje sistemaPuntaje = new SistemaPuntaje();

        // MOVIMIENTO
        int filaOrigen = 7;
        int columnaOrigen = 6;

        int filaDestino = 0;
        int columnaDestino = 1;

        // CAPTURA
        //Llamamos al metodo capturar pieza, mandamos la información necesaria para realizar la captura.
        CapturarPieza(tablero, filaOrigen, columnaOrigen, filaDestino, columnaDestino, jugador1, sistemaPuntaje);

        // VERIFICAR GANADOR
        bool finJuego;
        //Revisa si alguien ganó.
        finJuego = VerificarGanador(tablero, jugador1, jugador2);

        // GUARDAR RECORD
        if (finJuego == true)
        {
            if (jugador1.puntaje > jugador2.puntaje)
            {
                sistemaPuntaje.GuardarRecord(jugador1);
            }

            else
            {
                sistemaPuntaje.GuardarRecord(jugador2);
            }
        }

        // MOSTRAR RECORD
        sistemaPuntaje.VerPuntajeAlto();

        Console.ReadKey();
    }
}