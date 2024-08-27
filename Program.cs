string nombreArchivo = "csv/cadeteria.csv";
StreamReader sr = new StreamReader(nombreArchivo);
string linea;
Cadeteria miCadeteria;
string[] campos = ["Nombre Cadeteria","123456789"];
while ((linea = sr.ReadLine()) != null) {
    campos = linea.Split(',');
}
miCadeteria = new(campos[0],campos[1]);

nombreArchivo = "csv/cadetes.csv";
sr = new StreamReader(nombreArchivo);
while ((linea = sr.ReadLine()) != null) {
    campos = linea.Split(',');
    Cadete c = new(campos[0], campos[1], campos[2], campos[3]);
    miCadeteria.contratarCadete(c);
}

//miCadeteria.GestionarPedido();