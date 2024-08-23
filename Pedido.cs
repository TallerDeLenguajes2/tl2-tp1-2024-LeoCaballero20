class Pedido {
    private string numero;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    public Pedido(string num, string obs, Cliente cli, Estado est) {
        numero = num;
        observacion = obs;
        estado = est;
        cliente = cli;
    }

    public string Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
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
    CanceladoPorCliente,
    CanceladoPorCadete,
    Extraviado,
    Pendiente,
}