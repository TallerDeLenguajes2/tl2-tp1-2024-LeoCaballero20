public class Cadeteria {
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes = new();
    private List<Pedido> listadoPedidos = new();

    public Cadeteria() {}
    public Cadeteria(string nom, string tel) {
        nombre = nom;
        telefono = tel;
    }

    public string Nombre { get => nombre; set => nombre = value;}
    public string Telefono { get => telefono; set => telefono = value;}

    public void contratarCadete(Cadete cadete) {
        listadoCadetes.Add(cadete);
    }

    public bool RegistrarPedidos(string nombreCliente, string telCliente, string direcCliente, string refCliente, string obs) {
        string[] datosCliente = [nombreCliente, telCliente, direcCliente, refCliente];
        int numPedido;
        if (listadoPedidos.Count==0) {
            numPedido = 1;
        } else {
            numPedido = listadoPedidos.Last().Numero + 1;
        }
        Pedido p = new(numPedido, obs, datosCliente);
        listadoPedidos.Add(p);
        return true;
    }

    public bool AsignarCadeteAPedido(int numPedido, string idCadete) {
        Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
        Cadete c = listadoCadetes.Find(x => x.Id == idCadete);
        if (p!=null && c!=null) {
            p.AsociarCadete(c);
            return true;
        }
        return false;
    }

    public bool CambiarEstadoDePedido(int numPedido) {
        Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
        if (p.Estado == Estado.Entregado) {
            p.Estado = Estado.PendienteDeEntrega;
        } else {
            p.Estado = Estado.Entregado;
        }
        return true;
    }

    public float JornalACobrar(string idCadete) {
        float montoTotal = 0;
        IEnumerable<Pedido> pedidosDelCadete = listadoPedidos.TakeWhile(x => x.Cadete.Id == idCadete && x.Estado==Estado.Entregado);
        montoTotal = pedidosDelCadete.Count() * 500;
        return montoTotal;
    }

    public Informe MostrarInforme() {
        int totalEnvios = 0;
        foreach (Cadete c in listadoCadetes) {
            int cantidadEntregas= listadoPedidos.Where(x => x.Estado == Estado.Entregado && x.Cadete.Id == c.Id).Count();
            totalEnvios += cantidadEntregas;
        }
        Informe inf = new(totalEnvios, totalEnvios*500, totalEnvios/listadoCadetes.Count());
        return inf;
    }
}