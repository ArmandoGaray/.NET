namespace  ControlVentas.Models
{
    class Producto
    {
        private int _id_producto;
        private string _nombre_producto;
        private int _cantidad;
        private int _costo;

        public Producto (int id_producto, string nombre_producto, int cantidad, int costo)
        {
            this._id_producto = id_producto;
            this._nombre_producto = nombre_producto;
            this._cantidad = cantidad;
            this._costo = costo;
        }

        public int idProducto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }

        public string nombreProducto
        {
            get { return _nombre_producto; }
            set { _nombre_producto = value; }
        }

        public int cantidadProducto
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public int costoProducto
        {
            get { return _costo; }
            set { _costo = value; }
        }

        public override string ToString()
        {
            return $"Id: {_id_producto}, Nombre: {_nombre_producto}, Cantidad: {_cantidad}, Costo: {_costo}";
        }
    }
}