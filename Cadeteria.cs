
using System.Runtime.InteropServices.Marshalling;

class Cadeteria {
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes = new();
    private List<Pedido> listadoPedidos = new();
    public Cadeteria(string nom, string tel) {
        nombre = nom;
        telefono = tel;
    }

    public string Nombre { get => nombre; }
    public string Telefono { get => telefono; 
    
    }

    public void contratarCadete(Cadete cadete) {
        listadoCadetes.Add(cadete);
    }

    public void GestionarPedidos() {
        bool seguir = true;
        while (seguir == true) {
            Console.WriteLine("Elija la opción deseada");
            Console.WriteLine("1.Dar de alta pedidos");
            Console.WriteLine("2.Asignar pedidos a cadetes");
            Console.WriteLine("3.Cambiar estado de pedidos");
            Console.WriteLine("4.Reasignar pedidos a otro cadete");
            Console.WriteLine("5.Salir");
            string opcion = Console.ReadLine();
            Int32.TryParse(opcion, out int op);
            switch (op) {
                case 1: RegistrarPedidos();
                break;
                case 2: AsignarPedidosACadetes();
                break;
                case 3: CambiarEstadoDePedido();
                break;
                case 4: ReasignarPedidos();
                break;
                case 5 : seguir = false;
                         Console.WriteLine("Usted salió del sistema.");
                break;
            }
        }
        
    }
    public void RegistrarPedidos() {
        Console.WriteLine("Usted está por encargar un pedido en " + nombre);
        Console.WriteLine("Por favor ingrese su nombre y apellido");
        string nombreCliente = Console.ReadLine();
        Console.WriteLine("Ahora su número de teléfono");
        string telCliente = Console.ReadLine();
        Console.WriteLine("A continuación indique si dirección");
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
    public void AsignarPedidosACadetes() {
        Console.WriteLine("Los pedidos registrados son:\n");
        foreach (Pedido p in listadoPedidos) {
            Console.WriteLine("\nNúmero de pedido: " + p.Numero);
            Console.WriteLine("Detalle del pedido: " + p.Observacion);
        }
        while (listadoPedidos.Count > 0) {
            foreach (Cadete c in listadoCadetes) {
                foreach (Pedido p in listadoPedidos) {
                    if (p.Estado==Estado.PendienteDeEntrega) {
                        c.aceptarPedido(p);
                        break;
                    }
                }
            }
        }  
    }
    public void CambiarEstadoDePedido() {
        string num = "";
        int numPedido;
        while (!Int32.TryParse(num, out numPedido)) {
            Console.WriteLine("Ingrese el número del pedido");
            num = Console.ReadLine();
        }
        Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
        if (p.Estado == Estado.PendienteDeEntrega) {
            p.Estado = Estado.Entregado;
        } else {
            p.Estado = Estado.PendienteDeEntrega;
        }
    }

    public void ReasignarPedidos() {
        bool seguir = true;
        while (seguir == true) {
            string num = "";
            int numPedido;
            while (!Int32.TryParse(num, out numPedido)) {
                Console.WriteLine("Ingrese el número del pedido a reasignar");
                num = Console.ReadLine();
            }
            Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
            Console.WriteLine("El cadete asignado para este pedido es: ");
        }
    }
}