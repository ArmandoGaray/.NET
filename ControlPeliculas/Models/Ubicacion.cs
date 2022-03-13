namespace ControlPeliculas.Models
{
    internal class Ubicacion
    {
        private int _id_ubicacion;

        private string _nombre_ubicacion;

        private Pelicula _pelicula;

        public Pelicula pelicula
        {
            get { return _pelicula; }
            set { _pelicula = value; }
        }

        public Ubicacion(
            int ubicacion,
            string nombreUbicacion,
            Pelicula pelicula
        )
        {
            this._id_ubicacion = ubicacion;
            this._nombre_ubicacion = nombreUbicacion;
            this._pelicula = pelicula;
        }

        public int idUbicacion
        {
            get { return _id_ubicacion; }
            set { _id_ubicacion = value; }
        }

        public string nombreUbicacion
        {
            get { return _nombre_ubicacion; }
            set { _nombre_ubicacion = value; }
        }

        public override string ToString()
        {
            return $"Id: {_id_ubicacion}\n Se ubica en: {_nombre_ubicacion}\n Nombre de la Pelicua: {_pelicula.nombrePelicula}";
        }
    }
}
