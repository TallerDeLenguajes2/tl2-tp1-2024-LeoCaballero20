using System.Text.Json;
using System.Text.Json.Serialization;

public abstract class AccesoADatos {

    public abstract List<Cadete> LeerCadetes();

    public abstract Cadeteria LeerCadeteria();
}

public class AccesoCSV:AccesoADatos {
    public override List<Cadete> LeerCadetes() {
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
    public override Cadeteria LeerCadeteria() {
        string nombreArchivo = "csv/cadeteria.csv";
        StreamReader sr = new StreamReader(nombreArchivo);
        string linea;
        Cadeteria miCadeteria;
        string[] campos = ["Nombre Cadeteria","123456789"];
        while ((linea = sr.ReadLine()) != null) {
            campos = linea.Split(',');
        }
        miCadeteria = new(campos[0],campos[1]);
        return miCadeteria;
    }
}

public class AccesoJSON:AccesoADatos {
    public override List<Cadete> LeerCadetes() {
        string nombreArchivo = "json/cadetes.json";
        string jsonString = File.ReadAllText(nombreArchivo);
        List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
        return cadetes;
    }
    public override Cadeteria LeerCadeteria() {
        string nombreArchivo = "json/cadeteria.json";
        string jsonString = File.ReadAllText(nombreArchivo);
        Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonString);
        return cadeteria;
    }
}