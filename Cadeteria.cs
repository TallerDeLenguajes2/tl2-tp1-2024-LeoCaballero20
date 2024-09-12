
using System.Collections;
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
            Console.WriteLine("5.Finalizar jornada");
            string opcion = Console.ReadLine();
            Int32.TryParse(opcion, out int op);
            switch (op) {
                case 1: Console.Clear();
                        RegistrarPedidos();
                break;
                case 2: Console.Clear();
                        AsignarPedidosACadetes();
                break;
                case 3: Console.Clear();
                        CambiarEstadoDePedido();
                break;
                case 4: Console.Clear();
                        ReasignarPedido();
                break;
                case 5: Console.Clear();
                        seguir = false;
                        MostrarInforme();
                break;
            }
        }
        
    }
    public void RegistrarPedidos() {
        Console.WriteLine("Usted está por registrar un pedido en " + nombre);
        Console.WriteLine("Por favor ingrese su nombre y apellido");
        string nombreCliente = Console.ReadLine();
        Console.WriteLine("Ahora su número de teléfono");
        string telCliente = Console.ReadLine();
        Console.WriteLine("A continuación indique su dirección");
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
        Console.WriteLine("\nLos pedidos son:");
        foreach (Pedido ped in listadoPedidos) {
            Console.WriteLine("\nNúmero de pedido: " + ped.Numero);
            Console.WriteLine("Detalle del pedido: " + ped.Observacion);
        }
        string num = "";
        int numPedido;
        while (!Int32.TryParse(num, out numPedido)) {
            Console.WriteLine("Ingrese el número del pedido a asignar");
            num = Console.ReadLine();
        }
        Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
        Console.WriteLine("Listado de cadetes para asignar: ");
        foreach (Cadete c in listadoCadetes) {
            Console.WriteLine("ID del cadete: " + c.Id);
            Console.WriteLine("Nombre del cadete: " + c.Nombre);
        }
        num = "";
        while (!Int32.TryParse(num, out numPedido)) {
            Console.WriteLine("Ingrese el ID del cadete");
            num = Console.ReadLine();
        }
        Cadete cadete = listadoCadetes.Find(x => x.Id == num);
        if (cadete != null) {
            cadete.aceptarPedido(p);
            Console.WriteLine("Pedido asignado con éxito!");
        } else {
            Console.WriteLine("Cadete inexistente");
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

    public void ReasignarPedido() {
            string num = "";
            int numPedido;
            while (!Int32.TryParse(num, out numPedido)) {
                Console.WriteLine("Ingrese el número del pedido a reasignar");
                num = Console.ReadLine();
            }
            Pedido p = listadoPedidos.Find(x => x.Numero == numPedido);
            Cadete anteriorCadete = listadoCadetes.Find(x => x.ListadoDePedidos.Contains(p));
            Console.WriteLine("El cadete asignado para este pedido es: ");
            Console.WriteLine("ID del cadete: " + anteriorCadete.Id);
            Console.WriteLine("Nombre del cadete: " + anteriorCadete.Nombre);
            List<Cadete> listaCadetesPosibles = listadoCadetes.Where(x => x.ListadoDePedidos.Find(x => x.Numero == numPedido) == null).ToList();
            Console.WriteLine("Listado de cadetes para reasignar: ");
            foreach (Cadete c in listaCadetesPosibles) {
                Console.WriteLine("ID del cadete: " + c.Id);
                Console.WriteLine("Nombre del cadete: " + c.Nombre);
            }
            num = "";
            while (!Int32.TryParse(num, out numPedido)) {
                Console.WriteLine("Ingrese el ID del nuevo cadete");
                num = Console.ReadLine();
            }
            Cadete nuevoCadete = listaCadetesPosibles.Find(x => x.Id == num);
            if (nuevoCadete != null) {
                anteriorCadete.eliminarPedido(p);
                nuevoCadete.aceptarPedido(p);
                Console.WriteLine("Pedido reasignado con éxito!");
            } else {
                Console.WriteLine("Cadete inexistente");
            }
    }

    public void MostrarInforme() {
        int totalEnvios = 0;
        Console.WriteLine("INFORME DE LA JORNADA");
        foreach (Cadete c in listadoCadetes) {
            Console.WriteLine("\nID del cadete: " + c.Id);
            Console.WriteLine("Nombre del cadete: " + c.Nombre);
            List<Pedido> entregados = c.ListadoDePedidos.Where(x => x.Estado == Estado.Entregado).ToList();
            int cantidadEntregas = entregados.Count();
            Console.WriteLine("Cantidad de pedidos entregados:" + cantidadEntregas);
            totalEnvios += cantidadEntregas;
        }
        Console.WriteLine("\nCantidad total de pedidos entregados: " + totalEnvios);
        Console.WriteLine("Monto ganado: " + totalEnvios*500);
        Console.WriteLine("Cantidad de envíos promedio por cadete: " + totalEnvios/listadoCadetes.Count());
        Console.WriteLine("¡Hasta la próxima!");
    }
}