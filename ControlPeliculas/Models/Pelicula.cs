namespace ControlPeliculas.Models
{
    internal class Pelicula
    {
        private int _id_pelicula;

        private string _nombre_pelicula;

        private string _genero;

        private string _formato;

        private string _director;

        public Pelicula(
            int pelicula,
            string nombrePelicula,
            string genero,
            string formato,
            string director
        )
        {
            this._id_pelicula = pelicula;
            this._nombre_pelicula = nombrePelicula;
            this._genero = genero;
            this._formato = formato;
            this._director = director;
        }

        public int idPelicula
        {
            get { return _id_pelicula; }
            set { _id_pelicula = value; }
        }

        public string nombrePelicula
        {
            get { return _nombre_pelicula; }
            set { _nombre_pelicula = value; }
        }

        public string generoPelicula
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string formatoPelicula
        {
            get { return _formato; }
            set { _formato = value; }
        }

        public string directorPelicula
        {
            get { return _director; }
            set { _director = value; }
        }

        public override string ToString()
        {
            return $"Id: {_id_pelicula} \n Nombre: {_nombre_pelicula} \n Genero: {_genero} \n Formato: {_formato} \n Director: {_director}\n";
        }
    }
}
