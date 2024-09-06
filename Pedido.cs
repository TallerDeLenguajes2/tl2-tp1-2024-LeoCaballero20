class Pedido {
    private int numero;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    public Pedido(int num, string obs, string[] datosCliente) {
        numero = num;
        observacion = obs;
        estado = Estado.PendienteDeEntrega;
        cliente = new(datosCliente[0], datosCliente[1], datosCliente[2], datosCliente[3]);
    }

    public int Numero { get => numero; }
    public string Observacion { get => observacion; }
    public Cliente Cliente { get => cliente; }
    public Estado Estado { get => estado; set => estado = value; }

    public string VerDireccionCliente() {
        return Cliente.Direccion;
    }
    public string VerDatosCliente() {
        return Cliente.DatosReferenciaDireccion;
    }
}

enum Estado {
    Entregado,
    PendienteDeEntrega,
}