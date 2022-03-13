using ControlVentas.Models;
namespace ControlVentas
{
    class ControlVentasAdmin
    {
        private List<Producto> _productos;
        private List<Venta> _ventas;
        private List<Venta> _masVendido;
        private List<Venta> _menosoVendido;
        private List<Venta> _ordenMenorMayor;

        public ControlVentasAdmin()
        {
            _productos = new List<Producto>();
            _ventas = new List<Venta>();
            _menosoVendido = new List<Venta>();
            _masVendido = new List<Venta>();
            _ordenMenorMayor = _ventas.OrderBy(x => x.cantidadVentas).ToList();
        }

        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Ventas");
                Console.WriteLine("1.- Administración de Productos");
                Console.WriteLine("2.- Administración de Ventas");
                Console.WriteLine("3.- Mostrar estadisticas de Productos");
                Console.WriteLine("4.- Salir");
            } while (!validaMenu(4, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    crudProductos();
                    break;
                case 2:
                    crudVentas();
                    break;
                case 3:
                    menuEstadisticas();
                    break;
                case 4: break;
            }
        }

        private void crudProductos()
        {
            int? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Productos");
                Console.WriteLine("1.- Listar");
                Console.WriteLine("2.- Añadir");
                Console.WriteLine("3.- Editar");
                Console.WriteLine("4.- Eliminar");
                Console.WriteLine("5.- Regresar...");
            }
            while (!validaMenu(5, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {
                case 1:
                    listarProductos();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudProductos();
                    break;
                case 2:
                    crearProducto();
                    break;
                case 3:
                    editarProducto();
                    break;
                case 4:
                    eliminarProducto();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
            }
        }

        private void listarProductos()
        {
            Console.WriteLine("Lista de Productos");
            foreach (Producto item in _productos)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void crearProducto()
        {
            string? nombreProducto;
            int cantidad;
            int costo;
            Console.WriteLine("Alta de Producto");
            nombreProducto = pedirValorString("Nombre");
            cantidad = pedirValorInt("Cantidad");
            costo = pedirValorInt("Costo");
            Producto nuevoProducto =
                new Producto(_productos.Count() + 1,
                    nombreProducto,
                    cantidad,
                    costo);
            _productos.Add (nuevoProducto);
            Console.WriteLine("Producto añadido correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            crudProductos();
        }

        private void editarProducto()
        {
            int? id;
            string? nombreProducto;
            int cantidad;
            int costo;
            listarProductos();
            id = pedirValorInt("Escribe el Id del Producto a Editar");
            Producto? productoEdicion = _productos.FirstOrDefault(p => p.idProducto == id);
            if (productoEdicion == null)
            {
                Console.WriteLine("No se encontró el Producto. Presiona 'Enter' para continuar...");
            }
            else
            {
                nombreProducto = pedirValorString("Nombre");
                cantidad = pedirValorInt("Cantidad");
                costo = pedirValorInt("Costo");
                productoEdicion.nombreProducto = nombreProducto;
                productoEdicion.cantidadProducto = cantidad;
                productoEdicion.costoProducto = costo;
                Console.WriteLine($"El producto con id: {productoEdicion.idProducto} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudProductos();
        }

        private void eliminarProducto()
        {
            int? id = null;
            listarProductos();
            id = pedirValorInt("Escribe el Id del Producto a Eliminar");
            Producto? productoEliminar = _productos.FirstOrDefault(p => p.idProducto == id);
            if (productoEliminar == null)
            {
                Console.WriteLine("No se encontró el Producto. Presiona 'Enter' para continuar...");
            }
            else
            {
                _productos.Remove(productoEliminar);
                Console.WriteLine($"El producto con id: {productoEliminar.idProducto} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudProductos();
        }

        private void crudVentas()
        {
            int? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Ventas");
                Console.WriteLine("1.- Listar");
                Console.WriteLine("2.- Añadir");
                Console.WriteLine("3.- Editar");
                Console.WriteLine("4.- Eliminar");
                Console.WriteLine("5.- Regresar...");
            } while (!validaMenu(5, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {

                case 1:
                    listarVentas();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudVentas();
                    break;
                case 2:
                    if (_ventas.Count() > 0)
                        crearVenta();
                    else
                    {
                        Console.WriteLine("No puedes crear una Venta si no existen Productos previamente.Presiona 'Enter' para continuar...");
                        Console.ReadLine();
                        crudVentas();
                    }
                    break;
                case 3:
                    editarVenta();
                    break;
                case 4:
                    eliminarVenta();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
            }
        }

        private void listarVentas()
        {
            Console.WriteLine("Lista de Ventas");
            foreach (Venta item in _ventas)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void crearVenta()
        {
            int? id_producto;
            int cantidad;
            Console.WriteLine("Alta de Venta");
            cantidad = pedirValorInt("Cantidad");
            Console.Clear();
            listarProductos();
            id_producto = pedirValorInt("Escribe el Id del Producto a la que pertenece la Venta");
            Producto? producto = _productos.FirstOrDefault(p => p.idProducto == id_producto);
            if (producto == null)
            {
                Console.WriteLine("No se encontró el Producto. Presiona 'Enter' para continuar...");
            }
            else
            {
                Venta nuevaVenta = new Venta(_ventas.Count()+1, cantidad, producto);
                _ventas.Add(nuevaVenta);
                Console.WriteLine("Venta creada correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudVentas();
        }

        private void editarVenta()
        {
            int? id;
            int cantidad;
            listarVentas();
            id = pedirValorInt("Escribe el Id de la Venta a Editar");
            Venta? ventaEdicion = _ventas.FirstOrDefault(v => v.idVenta == id);
            if (ventaEdicion == null)
            {
                Console.WriteLine("No se encontró la Venta. Presiona 'Enter' para continuar...");
            }
            else
            {
                cantidad = pedirValorInt("Cantidad");
                ventaEdicion.cantidadVentas = cantidad;
                Console.WriteLine($"La Venta con id: {ventaEdicion.idVenta} se editó correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudVentas();
        }

        private void eliminarVenta()
        {
            int? id = null;
            listarVentas();
            id = pedirValorInt("Escribe el Id de la Venta a Eliminar");
            Venta? ventaEliminar = _ventas.FirstOrDefault(v => v.idVenta == id);
            if (ventaEliminar == null)
            {
                Console.WriteLine("No se encontró la Venta. Presiona 'Enter' para continuar...");
            }
            else
            {
                _ventas.Remove(ventaEliminar);
                Console.WriteLine($"La Venta con id: {ventaEliminar.idVenta} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudVentas();
        }

        public void menuEstadisticas()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de estadisticas de ventas: ");
                Console.WriteLine("1.- Productos menos vendidos");
                Console.WriteLine("2.- Productos mas vendidos");
                Console.WriteLine("3.- Regresar..");
            } while (!validaMenu(3, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    obtenerMenosVendido();
                    break;
                case 2:
                    obtenerMasVendido();
                    break;
                case 3:
                    showMenuPrincipal();
                    break;
            }   
        }

        private void listarMassVendido()
        {
            Console.WriteLine("Lista de Productos mas vendidos");
            foreach (Venta item in _masVendido)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void obtenerMasVendido()
        {
            if(_masVendido.Count() >= 1)
            {
                _masVendido.RemoveRange(0, _masVendido.Count()-1);
                _masVendido.RemoveAt(0);
            }
            _ordenMenorMayor = _ventas.OrderBy(x => x.cantidadVentas).ToList();
            if(_ventas.Count() == 1)
            {
                Console.WriteLine("Solo hay un producto registrado con ventas");
                for (int i = 0; i < 1; i++)
                {
                    _masVendido.Add(_ordenMenorMayor[i]);
                }
            } 
            if (_ventas.Count() == 2)
            {
               for (int i = 1; i >= 0; i--)
                {
                    _masVendido.Add(_ordenMenorMayor[i]);
                }
            }
            if (_ventas.Count() == 3)
            {
                for (int i = 2; i >= 1; i--)
                {
                    _masVendido.Add(_ordenMenorMayor[i]);
                }
            }
            if (_ventas.Count() == 4)
            {
                for (int i = 3; i >= 1; i--)
                {
                    _masVendido.Add(_ordenMenorMayor[i]);
                }
            }
            if (_ventas.Count() > 4)
            {
                for (int i = _ordenMenorMayor.Count()-1; i > _ordenMenorMayor.Count()-4; i--)
                {
                    _masVendido.Add(_ordenMenorMayor[i]);
                }
            }
            Console.Clear();
            listarMassVendido();
            Console.WriteLine("Presiona 'Enter' para continuar...");
            Console.ReadLine();
            menuEstadisticas();
        }

        private void listarMenosVendido()
        {
            Console.WriteLine("Lista de Productos menos vendidos");
            foreach (Venta item in _menosoVendido)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void obtenerMenosVendido()
        {
            if(_menosoVendido.Count() >= 1)
            {
                _menosoVendido.RemoveRange(0, _menosoVendido.Count()-1);
                _menosoVendido.RemoveAt(0);
            }
            _ordenMenorMayor = _ventas.OrderBy(x => x.cantidadVentas).ToList();
            if(_ventas.Count() == 1)
            {
                Console.WriteLine("Solo hay un producto registrado con ventas");
                for (int i = 0; i < 1; i++)
                {
                    _menosoVendido.Add(_ordenMenorMayor[i]);
                }
            } 
            if (_ventas.Count() == 2)
            {
                for (int i = 0; i < 1; i++)
                {
                    _menosoVendido.Add(_ordenMenorMayor[i]);
                }
            }
            if (_ventas.Count() > 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    _menosoVendido.Add(_ordenMenorMayor[i]);
                }
            }
            Console.Clear();
            listarMenosVendido();
            Console.WriteLine("Presiona 'Enter' para continuar...");
            Console.ReadLine();
            menuEstadisticas();
        }

        private bool validaMenu(int opciones, ref int opcionSeleccionada)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones)
                {
                    opcionSeleccionada = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción Invalida.");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido, debes ingresar un número.");
                return false;
            }
        }

        private string pedirValorString(string texto)
        {
            string? valor;
            do
            {
                Console.Write($"{texto}: ");
                valor = Console.ReadLine();
                if (valor == null || valor == "")
                {
                    Console.WriteLine("Valor inválido.");
                }
            } while (valor == null || valor == "");
            return valor;
        }

        private int pedirValorInt(string texto)
        {
            int valor;
            Console.Write($"{texto}: ");
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Debes ingresar un número.");
                Console.Write($"{texto}: ");
            }
            return valor;
        }

        public void inicializarDatos()
        {
            Producto producto1 = new Producto(_productos.Count()+1,"Jabon liquido",30,45);
            _productos.Add(producto1);
            Producto producto2 = new Producto(_productos.Count()+1,"Jabon en barra",43,34);
            _productos.Add(producto2);
            Producto producto3 = new Producto(_productos.Count()+1,"Escoba",100,60);
            _productos.Add(producto3);
            Producto producto4 = new Producto(_productos.Count()+1,"Trapeador",30,65);
            _productos.Add(producto4);
            Producto producto5 = new Producto(_productos.Count()+1,"Trapo",200,25);
            _productos.Add(producto5);
            Producto producto6 = new Producto(_productos.Count()+1,"Esponja",90,15);
            _productos.Add(producto6);
            Producto producto7 = new Producto(_productos.Count()+1,"Cepillo",26,56);
            _productos.Add(producto7);
            Producto producto8 = new Producto(_productos.Count()+1,"Creama",36,50);
            _productos.Add(producto8);
            Producto producto9 = new Producto(_productos.Count()+1,"Acondicionador",60,52);
            _productos.Add(producto9);
            Producto producto10 = new Producto(_productos.Count()+1,"Shampoo",66,54);
            _productos.Add(producto10);

            Venta venta1 = new Venta(_ventas.Count()+1,42,producto1);
            _ventas.Add(venta1);
            Venta venta2 = new Venta(_ventas.Count()+1,11,producto2);
            _ventas.Add(venta2);
            Venta venta3 = new Venta(_ventas.Count()+1,30,producto3);
            _ventas.Add(venta3);
            Venta venta4 = new Venta(_ventas.Count()+1,13,producto4);
            _ventas.Add(venta4);
            Venta venta5 = new Venta(_ventas.Count()+1,19,producto5);
            _ventas.Add(venta5);
            Venta venta6 = new Venta(_ventas.Count()+1,18,producto6);
            _ventas.Add(venta6);
            Venta venta7 = new Venta(_ventas.Count()+1,24,producto7);
            _ventas.Add(venta7);
            Venta venta8 = new Venta(_ventas.Count()+1,3,producto8);
            _ventas.Add(venta8);
            Venta venta9 = new Venta(_ventas.Count()+1,9,producto9);
            _ventas.Add(venta9);
            Venta venta10 = new Venta(_ventas.Count()+1,7,producto10);
            _ventas.Add(venta10);
        }
    }
}