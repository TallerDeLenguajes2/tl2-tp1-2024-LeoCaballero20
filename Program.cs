Cadeteria miCadeteria = Persistencia.leerCadeteria();

List<Cadete> listaCadetes = Persistencia.leerCadetes();

foreach (Cadete c in listaCadetes) {
    miCadeteria.contratarCadete(c);
}

miCadeteria.GestionarPedidos();