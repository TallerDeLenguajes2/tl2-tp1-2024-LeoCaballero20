
public class Cadete {
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;

    public Cadete() {}

    public Cadete(string id, string nom, string dir, string tel) {
        this.id = id;
        nombre = nom;
        direccion = dir;
        telefono = tel;
    }

    public string Id { get => id; set => id = value;}
    public string Nombre { get => nombre; set => nombre = value;}
    public string Direccion { get => direccion; set => direccion = value;}
    public string Telefono { get => telefono; set => telefono = value;}


}