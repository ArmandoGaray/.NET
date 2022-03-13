namespace ControlVentas.Models
{
    class Venta
    {
        private int _id_venta;
        private int _cantidad_ventas;
        private Producto _producto;

        public Producto producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        public Venta(int id_venta, int cantidad_ventas, Producto producto) 
        {
            this._id_venta = id_venta;
            this._cantidad_ventas = cantidad_ventas;
            this._producto = producto;
        }

        public int idVenta
        {
            get { return _id_venta; }
            set { _id_venta = value; }
        }

        public int cantidadVentas
        {
            get { return _cantidad_ventas; }
            set { _cantidad_ventas = value; }
        }

        public override string ToString()
        {
            return $"Id: {_id_venta}, Producto: {_producto.nombreProducto}, Cantidad ventas: {_cantidad_ventas}";
        }
    }
}