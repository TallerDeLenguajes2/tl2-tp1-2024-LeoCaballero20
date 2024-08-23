
class Cadete {
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoDePedidos;

    public Cadete(string id, string nom, string dir, string tel) {
        this.Id = id;
        Nombre = nom;
        Direccion = dir;
        Telefono = tel;
    }

    public string Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    internal List<Pedido> ListadoDePedidos { get => listadoDePedidos; set => listadoDePedidos = value; }
}