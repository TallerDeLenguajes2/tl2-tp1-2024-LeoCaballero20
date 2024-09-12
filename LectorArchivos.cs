static class LectorArchivos {

    public static List<Cadete> leerCadetes() {
        string nombreArchivo = "csv/cadetes.csv";
        var sr = new StreamReader(nombreArchivo);
        string linea;
        var listaCadetes = new List<Cadete>();
        while ((linea = sr.ReadLine()) != null) {
            string[] campos = linea.Split(',');
            Cadete c = new(campos[0], campos[1], campos[2], campos[3]);
            listaCadetes.Add(c);
        }
        return listaCadetes;
    }

    public static Cadeteria leerCadeteria() {
        string nombreArchivo = "csv/cadeteria.csv";
        StreamReader sr = new StreamReader(nombreArchivo);
        string linea;
        Cadeteria miCadeteria;
        string[] campos = new string[2];
        while ((linea = sr.ReadLine()) != null) {
            campos = linea.Split(',');
        }
        miCadeteria = new(campos[0],campos[1]);
        return miCadeteria;
    }
}