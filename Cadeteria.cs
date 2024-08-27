
class Cadeteria {
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes = new();
    public Cadeteria(string nom, string tel) {
        nombre = nom;
        telefono = tel;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public void contratarCadete(Cadete cadete) {
        listadoCadetes.Add(cadete);
    }

    public void GestionarPedido() {
        bool confirmaPedido = false;
        Console.WriteLine("Buenas, desea realizar un pedido?");
        string respuesta;
        do {
            Console.WriteLine("SI / NO");
            respuesta = Console.ReadLine();
        } while (respuesta!="SI" && respuesta!="NO");
        if (respuesta == "SI") {
            confirmaPedido = true;
        }
        if (confirmaPedido) {
            TomarPedido();
        }
    }
    public void TomarPedido() {
        Console.WriteLine("");
    }
}