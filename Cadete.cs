
class Cadete {
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;

    public Cadete(string id, string nom, string dir, string tel) {
        this.id = id;
        nombre = nom;
        direccion = dir;
        telefono = tel;
    }

    public string Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }


}