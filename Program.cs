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

miCadeteria.GestionarPedidos();