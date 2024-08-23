class Cliente {
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDireccion;
    public Cliente(string nom, string dir, string telef, string datos) {
        Nombre = nom;
        Direccion = dir;
        Telefono = telef;
        DatosReferenciaDireccion = datos;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
}