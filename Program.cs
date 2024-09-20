Console.WriteLine("Bienvenido al sistema de gestión de cadetería");
Console.WriteLine("Elija la opción con cual desea cargar los datos");
Console.WriteLine("1.CSV  2.JSON");
int num;
while (!Int32.TryParse(Console.ReadLine(), out num) || (num!=1 && num!=2)) {
    Console.WriteLine("1.CSV  2.JSON");
}
AccesoADatos miLector;
if (num == 1) {
    miLector = new AccesoCSV();
} else {
    miLector = new AccesoJSON();
}

Cadeteria miCadeteria = miLector.LeerCadeteria();

List<Cadete> listaCadetes = miLector.LeerCadetes();

foreach (Cadete c in listaCadetes) {
    miCadeteria.contratarCadete(c);
}

/*

public void GestionarPedidos() {
        bool seguir = true;
        while (seguir == true) {
            Console.WriteLine("Elija la opción deseada");
            Console.WriteLine("1.Dar de alta pedidos");
            Console.WriteLine("2.Asignar cadete a pedido");
            Console.WriteLine("3.Cambiar estado de pedidos");
            Console.WriteLine("4.Reasignar pedidos a otro cadete");
            Console.WriteLine("5.Finalizar jornada");
            string opcion = Console.ReadLine();
            Int32.TryParse(opcion, out int op);
            switch (op) {
                case 1: Console.Clear();
                        RegistrarPedidos();
                break;
                case 2: Console.Clear();
                        AsignarCadeteAPedido();
                break;
                case 3: Console.Clear();
                        CambiarEstadoDePedido();
                break;
                case 4: Console.Clear();
                        ReasignarCadete();
                break;
                case 5: 
                        Console.Clear();
                        seguir = false;
                        MostrarInforme();
                break;
            }
        }
        
    }

    private void ReasignarCadete(int numPedido, string idCadete)
    {
        Console.WriteLine("Ingrese el número de pedido para reasignarle cadete");
        Int32.TryParse(Console.ReadLine(), out int num);
        Pedido p = listadoPedidos.Find(x => x.Numero == num);
        Console.WriteLine("El cadete encargado de este pedido es: ");
        Console.WriteLine("Nombre: " + p.Cadete.Nombre);
        Console.WriteLine("ID: " + p.Cadete.Id);
        Console.WriteLine("Ingrese el ID del cadete al que quiere asignarle el pedido");
        string idCadete = Console.ReadLine();
        Cadete c = listadoCadetes.Find(x => x.Id == idCadete);
        p.AsociarCadete(c);
        Console.WriteLine("Cadete reasignado");
    }

    public void RegistrarPedidos() {
        Console.WriteLine("Usted está por encargar un pedido en " + nombre);
        Console.WriteLine("Por favor ingrese su nombre y apellido");
        string nombreCliente = Console.ReadLine();
        Console.WriteLine("Ahora su número de teléfono");
        string telCliente = Console.ReadLine();
        Console.WriteLine("A continuación indique sU dirección");
        string direcCliente = Console.ReadLine();
        Console.WriteLine("Alguna referencia de su dirección para facilitar la entrega?");
        string refCliente = Console.ReadLine();
        string[] datosCliente = [nombreCliente, telCliente, direcCliente, refCliente];
        Console.WriteLine("Ingrese el nombre del producto y observaciones");
        string observaciones = Console.ReadLine();
        int numPedido;
        if (listadoPedidos.Count==0) {
            numPedido = 1;
        } else {
            numPedido = listadoPedidos.Last().Numero + 1;
        }
        Pedido p = new(numPedido, observaciones, datosCliente);
        listadoPedidos.Add(p);
        Console.WriteLine("Su pedido está registrado.");
    }
    public void AsignarCadeteAPedido() {
        Console.WriteLine("Ingrese el número del pedido que quiere asignar a un cadete");
        int numPedido = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el ID del cadete");
        string idCadete = Console.ReadLine();
        Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
        Cadete c = listadoCadetes.Find(x => x.Id == idCadete);
        p.AsociarCadete(c);
    }

    public void CambiarEstadoDePedido() {
        Console.WriteLine("Ingrese el número de pedido para cambiarle el estado");
        Int32.TryParse(Console.ReadLine(), out int num);
        Pedido p = listadoPedidos.Find(x => x.Numero == num);
        Console.WriteLine("El estado del pedido es: " + p.Estado);
        if (p.Estado == Estado.Entregado) {
            p.Estado = Estado.PendienteDeEntrega;
        } else {
            p.Estado = Estado.Entregado;
        }
        Console.WriteLine("El nuevo estado del pedido es: " + p.Estado);
    }
    public float JornalACobrar(string idCadete) {
        float montoTotal = 0;
        IEnumerable<Pedido> pedidosDelCadete = listadoPedidos.TakeWhile(x => x.Cadete.Id == idCadete && x.Estado==Estado.Entregado);
        montoTotal = pedidosDelCadete.Count() * 500;
        return montoTotal;
    }

    public void MostrarInforme() {
        int totalEnvios = 0;
        Console.WriteLine("INFORME DE LA JORNADA");
        foreach (Cadete c in listadoCadetes) {
            Console.WriteLine("\nID del cadete: " + c.Id);
            Console.WriteLine("Nombre del cadete: " + c.Nombre);
            int cantidadEntregas= listadoPedidos.Where(x => x.Estado == Estado.Entregado && x.Cadete.Id == c.Id).Count();
            Console.WriteLine("Cantidad de pedidos entregados:" + cantidadEntregas);
            totalEnvios += cantidadEntregas;
        }
        Console.WriteLine("\nCantidad total de pedidos entregados: " + totalEnvios);
        Console.WriteLine("Monto ganado: " + totalEnvios*500);
        Console.WriteLine("Cantidad de envíos promedio por cadete: " + totalEnvios/listadoCadetes.Count());
        Console.WriteLine("¡Hasta la próxima!");
    }
} */