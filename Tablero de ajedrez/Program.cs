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