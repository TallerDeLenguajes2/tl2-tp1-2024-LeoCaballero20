La relación del Pedido con el Cliente se realiza por composición, ya que en este caso la existencia del Cliente depende de la del Pedido. La relación del Cadete con el Pedido es de agregación.

La clase Cadetería podría tener métodos como PagarJornal, AtenderLlamada, TomarPedido, AsignarCadete...
La clase Cadete podría tener métodos como LlevarPedido, ConfirmarEstadoDelPedido...

Todos los atributos deberían ser privados con sus respectivas propiedades públicas. Métodos como VerDireccionCliente y VerDatosCliente deberían ser públicos.

Dentro del constructor de Pedido tendría que crearse el Cliente que lo pidió con su correspondiente información.

