public bool MovimientoValido(int fo, int co, int fd, int cd)
{
    if (fo < 0 || fo > 7 || co < 0 || co > 7 ||
        fd < 0 || fd > 7 || cd < 0 || cd > 7)
        return false;

    Pieza p = t.tablero[fo, co];

    if (p == null || p.jugador != turnoActual)
        return false;

    Pieza destino = t.tablero[fd, cd];

    if (destino != null && destino.jugador == turnoActual)
        return false;

    return ValidarMovimiento(p.tipo, p.jugador, fo, co, fd, cd);
}

public void CambiarTurno()
{
    turnoActual = (turnoActual == "Blanco")
        ? "Negro"
        : "Blanco";
}