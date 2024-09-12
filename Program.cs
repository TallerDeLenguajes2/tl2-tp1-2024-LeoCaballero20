Cadeteria miCadeteria = LectorArchivos.leerCadeteria();

List<Cadete> listaCadetes = LectorArchivos.leerCadetes();

foreach (Cadete c in listaCadetes) {
    miCadeteria.contratarCadete(c);
}

miCadeteria.GestionarPedidos();