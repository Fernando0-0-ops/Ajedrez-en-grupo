public bool MovimientoValido(int fo, int co, int fd, int cd)
{
    if (fo < 0 || fo > 7 || co < 0 || co > 7 || fd < 0 || fd > 7 || cd < 0 || cd > 7) return false;

    Pieza p = t.tablero[fo, co];
    if (p == null || p.jugador != turnoActual) return false;

    Pieza destino = t.tablero[fd, cd];
    if (destino != null && destino.jugador == turnoActual) return false;

    return ValidarMovimiento(p.tipo, p.jugador, fo, co, fd, cd);
}

public bool ValidarMovimiento(string tipo, string jugador, int fo, int co, int fd, int cd)
{
    if (fo == fd && co == cd) return false;

    if (tipo == "Rey")
    {
        return Math.Abs(fd - fo) <= 1 && Math.Abs(cd - co) <= 1;
    }

    if (tipo == "Torre")
    {
        if (fo != fd && co != cd) return false;

        if (fo == fd)
        {
            int paso = co < cd ? 1 : -1;
            for (int c = co + paso; c != cd; c += paso)
                if (t.tablero[fo, c] != null) return false;
        }
        else
        {
            int paso = fo < fd ? 1 : -1;
            for (int f = fo + paso; f != fd; f += paso)
                if (t.tablero[f, co] != null) return false;
        }
        return true;
    }

    if (tipo == "Soldado")
    {
        int direccion = jugador == "Blanco" ? -1 : 1;
        if (co == cd && fd == fo + direccion && t.tablero[fd, cd] == null) return true;
        if (Math.Abs(cd - co) == 1 && fd == fo + direccion && t.tablero[fd, cd] != null) return true;
    }
    return false;
}

public void CambiarTurno()
{
    turnoActual = (turnoActual == "Blanco") ? "Negro" : "Blanco";
}