class Pedido {
    private int numero;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    private Cadete cadete;
    public Pedido(int num, string obs, string[] datosCliente) {
        numero = num;
        observacion = obs;
        estado = Estado.Registrado;
        cliente = new(datosCliente[0], datosCliente[1], datosCliente[2], datosCliente[3]);
    }

    public int Numero { get => numero; }
    public string Observacion { get => observacion; }
    public Cliente Cliente { get => cliente; }
    public Estado Estado { get => estado; set => estado = value; }
    internal Cadete Cadete { get => cadete; }

    public string VerDireccionCliente() {
        return Cliente.Direccion;
    }
    public string VerDatosCliente() {
        return Cliente.DatosReferenciaDireccion;
    }
    public void AsociarCadete(Cadete c) {
        cadete = c;
    }
}

enum Estado {
    Entregado,
    Registrado,
    PendienteDeEntrega,
}