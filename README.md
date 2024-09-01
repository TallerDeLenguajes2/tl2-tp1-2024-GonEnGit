1. Cliente es creado por Pedido por lo que es una composicion;
   Los pedidos se le asignan a los cadetes;
   Cadete pertenece a Cadeteria, es una relación de composicion;

2. Como los cadetes van a depender de la Cadeteria, esta deberia tener
   por lo menos un metodo para crear los Cadetes y guardarlos en alguna lista

3. En general los atributos propios de cada clase deberian ser privados,
   mientras que las propiedades deberian ser publicas para poder alterarlas, así ocmo los
   metodos par apoder hacerlo. Los contructores, como son metodos especiales, tambien tienen que ser publicos.

4. En todos los casos, los contructores van a necesitar parametros para poder usar los datos de los archivos.
   En casos como el de Pedido y Cadeteria, sus constructores tambien van a necesitar incluir los de Cliente y Cadete
   respectivamente.

5. La Cadeteria podria crearse sola sin crear los Cadetes por composicion y agregarlos despues conciderando por ejemplo,
   que el programa tiene varias sucursales y los Cadetes pueden pasar de una a otra.