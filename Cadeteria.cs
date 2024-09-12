
using System.Timers;

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
            Console.WriteLine("2.Asignar cadete a pedido");
            Console.WriteLine("3.Cambiar estado de pedidos");
            Console.WriteLine("4.Reasignar pedidos a otro cadete");
            Console.WriteLine("5.Salir del sistema");
            string opcion = Console.ReadLine();
            Int32.TryParse(opcion, out int op);
            Pedido p;
            int num;
            switch (op) {
                case 1: RegistrarPedidos();
                break;
                case 2: Console.WriteLine("Ingrese el número del pedido que quiere asignar a un cadete");
                        int numPedido = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el ID del cadete");
                        string idCadete = Console.ReadLine();
                        AsignarCadeteAPedido(idCadete,numPedido);
                break;
                case 3: Console.WriteLine("Ingrese el número de pedido para cambiarle el estado");
                        Int32.TryParse(Console.ReadLine(), out num);
                        p = listadoPedidos.Find(x => x.Numero == num);
                        Console.WriteLine("El estado del pedido es: " + p.Estado);
                        Console.WriteLine("Ingrese el nuevo estado");
                        Console.WriteLine();
                break;
                case 4: Console.WriteLine("Ingrese el número de pedido para reasignarle cadete");
                        Int32.TryParse(Console.ReadLine(), out num);
                        p = listadoPedidos.Find(x => x.Numero == num);
                        Console.WriteLine("El cadete encargado de este pedido es: ");
                        Console.WriteLine("Nombre: " + p.Cadete.Nombre);
                        Console.WriteLine("ID: " + p.Cadete.Id);
                        Console.WriteLine("Ingrese el ID del cadete al que quiere asignarle el pedido");
                        idCadete = Console.ReadLine();
                        Cadete c = listadoCadetes.Find(x => x.Id == idCadete);
                        p.AsociarCadete(c);
                        Console.WriteLine("Cadete reasignado");
                break;
                case 5: seguir = false;
                        Console.WriteLine("Usted salió del sistema");
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
    public void AsignarCadeteAPedido(string idCadete, int numPedido) {
        Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
        Cadete c = listadoCadetes.Find(x => x.Id == idCadete);
        p.AsociarCadete(c);
    }

    public void CambiarEstadoDePedido(Pedido p, Estado e) {
        p.Estado = e;
    }
    public float JornalACobrar(string idCadete) {
        float montoTotal = 0;
        IEnumerable<Pedido> pedidosDelCadete = listadoPedidos.TakeWhile(x => x.Cadete.Id == idCadete && x.Estado==Estado.Entregado);
        montoTotal = pedidosDelCadete.Count() * 500;
        return montoTotal;
    }
}