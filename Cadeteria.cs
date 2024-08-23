
class Cadeteria {
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    public Cadeteria() {

    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public void atenderLlamada() {
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
            tomarPedido();
        }
    }
    public void tomarPedido() {
        Console.WriteLine("");
    }
}