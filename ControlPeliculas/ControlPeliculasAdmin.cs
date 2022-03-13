using ControlPeliculas.Models;

namespace ControlPeliculas
{
    class ControlPeliculasAdmin
    {
        private List<Pelicula> _peliculas;

        private List<Pelicula> _ordenAlfabeto;

        private List<Pelicula> _ordenGenero;

        private List<Pelicula> _ordenFormato;

        private List<Pelicula> _ordenDirector;

        private List<Ubicacion> _ubicaciones;

        private List<Ubicacion> _ubicacionObtenida;

        public ControlPeliculasAdmin()
        {
            _peliculas = new List<Pelicula>();
            _ubicaciones = new List<Ubicacion>();
            _ubicacionObtenida = new List<Ubicacion>();
            _ordenAlfabeto = _peliculas.OrderBy(x => x.nombrePelicula).ToList();
            _ordenGenero = _peliculas.OrderBy(x => x.generoPelicula).ToList();
            _ordenFormato = _peliculas.OrderBy(x => x.formatoPelicula).ToList();
            _ordenDirector = _peliculas.OrderBy(x => x.directorPelicula).ToList();
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
                Console
                    .WriteLine("El valor ingresado no es válido, debes ingresar un número.");
                return false;
            }
        }

        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Control Peliculas");
                Console.WriteLine("1.- Administrar Pelicula");
                Console.WriteLine("2.- Administrar Ubicacion Pelicula");
                Console.WriteLine("3.- Buscar Pelicula");
                Console.WriteLine("4.- Salir");
            }
            while (!validaMenu(4, ref opcionSeleccionada));

            switch (opcionSeleccionada)
            {
                case 1:
                    crudPeliculas();
                    break;
                case 2:
                    crudUbicaciones();
                    break;
                case 3:
                    buscarPeliculas();
                    break;
                case 4:
                    break;
            }
        }

        private void crudPeliculas()
        {
            string? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Pelicula");
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
                    listarPeliculas();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudPeliculas();
                    break;
                case 2:
                    crearPelicula();
                    break;
                case 3:
                    editarPelicula();
                    break;
                case 4:
                    eliminarPelicula();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
            }
        }

        private void listarPeliculas()
        {
            Console.WriteLine("Lista de Peliculas");
            foreach (Pelicula item in _peliculas)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void crearPelicula()
        {
            string? nombrePelicula;
            string? genero;
            string? formato;
            string? director;
            Console.WriteLine("Alta de Pelicula");
            nombrePelicula = pedirValorString("Nombre");
            genero = pedirValorString("Genero");
            formato = pedirValorString("Formato");
            director = pedirValorString("Director");
            Pelicula nuevaPelicula =
                new Pelicula(_peliculas.Count() + 1,
                    nombrePelicula,
                    genero,
                    formato,
                    director);
            _peliculas.Add (nuevaPelicula);
            Console.WriteLine("Pelicula añadida correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            crudPeliculas();
        }

        private void editarPelicula()
        {
            int? id;
            string? nombrePelicula;
            string? genero;
            string? formato;
            string? director;
            listarPeliculas();
            id = pedirValorInt("Escribe el Id de la Unidad a Editar");
            Pelicula? peliculaEdicion = _peliculas.FirstOrDefault(p => p.idPelicula == id);
            if (peliculaEdicion == null)
            {
                Console.WriteLine("No se encontró la Pelicula. Presiona 'Enter' para continuar...");
            }
            else
            {
                nombrePelicula = pedirValorString("Nombre");
                genero = pedirValorString("Genero");
                formato = pedirValorString("Formato");
                director = pedirValorString("Director");
                peliculaEdicion.nombrePelicula = nombrePelicula;
                peliculaEdicion.generoPelicula = genero;
                peliculaEdicion.formatoPelicula = formato;
                peliculaEdicion.directorPelicula = director;
                Console.WriteLine($"La pelicula con id: {peliculaEdicion.idPelicula} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudPeliculas();
        }

        private void eliminarPelicula()
        {
            int? id = null;
            listarPeliculas();
            id = pedirValorInt("Escribe el Id de la Pelicula a Eliminar");
            Pelicula? peliculaEliminar = _peliculas.FirstOrDefault(p => p.idPelicula == id);
            if (peliculaEliminar == null)
            {
                Console.WriteLine("No se encontró la Pelicula. Presiona 'Enter' para continuar...");
            }
            else
            {
                _peliculas.Remove(peliculaEliminar);
                Console.WriteLine($"La pelicula con id: {peliculaEliminar.idPelicula} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudPeliculas();
        }

        private void crudUbicaciones()
        {
            string? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Ubicaciones");
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
                    listarUbicaciones();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudUbicaciones();
                    break;
                case 2:
                    if (_ubicaciones.Count() > 0)
                        crearUbicacion();
                    else
                    {
                        Console.WriteLine("No puedes crear una Ubicacion si no existen Peliculas previamente.Presiona 'Enter' para continuar...");
                        Console.ReadLine();
                        crudUbicaciones();
                    }
                    break;
                case 3:
                    editarUbicacion();
                    break;
                case 4:
                    eliminarUbicacion();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
            }
        }

        private void crearUbicacion()
        {
            string? nombre;
            int? id_Pelicula;
            Console.WriteLine("Alta de Ubicacion");
            nombre = pedirValorString("Nombre");
            Console.Clear();
            listarPeliculas();
            id_Pelicula = pedirValorInt("Escribe el Id de la Pelicula a la que pertenece la Ubicacion");
            Pelicula? pelicula = _peliculas.FirstOrDefault(p => p.idPelicula == id_Pelicula);
            if (pelicula == null)
            {
                Console.WriteLine("No se encontró la Pelicula. Presiona 'Enter' para continuar...");
            }
            else
            {
                Ubicacion nuevaUbicacion = new Ubicacion(_ubicaciones.Count()+1, nombre, pelicula);
                _ubicaciones.Add(nuevaUbicacion);
                Console.WriteLine("Ubicacion creada correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudUbicaciones();
        }

        private void editarUbicacion()
        {
            int? id;
            string? nombre;
            listarUbicaciones();
            id = pedirValorInt("Escribe el Id de la Ubicacion a Editar");
            Ubicacion? ubicacionEdicion = _ubicaciones.FirstOrDefault(u => u.idUbicacion == id);
            if (ubicacionEdicion == null)
            {
                Console.WriteLine("No se encontró la Ubicacion. Presiona 'Enter' para continuar...");
            }
            else
            {
                nombre = pedirValorString("Nombre");
                ubicacionEdicion.nombreUbicacion = nombre;
                Console.WriteLine($"La Ubicacion con id: {ubicacionEdicion.idUbicacion} se editó correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudUbicaciones();
        }

        private void eliminarUbicacion()
        {
            int? id = null;
            listarUbicaciones();
            id = pedirValorInt("Escribe el Id de la Ubicacion a Eliminar");
            Ubicacion? unicacionEliminar = _ubicaciones.FirstOrDefault(u => u.idUbicacion == id);
            if (unicacionEliminar == null)
            {
                Console.WriteLine("No se encontró la Ubicacion. Presiona 'Enter' para continuar...");
            }
            else
            {
                _ubicaciones.Remove(unicacionEliminar);
                Console.WriteLine($"La ubicacion con id: {unicacionEliminar.idUbicacion} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudUbicaciones();
        }

        private void listarUbicaciones()
        {
            Console.WriteLine("Lista de Ubicaciones");
            foreach (Ubicacion item in _ubicaciones)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void listarPeliculasAlfabeticamente()
        {   
            _ordenAlfabeto = _peliculas.OrderBy(x => x.nombrePelicula).ToList();
            Console.WriteLine("Lista de Peliculas en orden alfabetico");
            foreach (Pelicula item in _ordenAlfabeto)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void listarOrdenGenero()
        {
            _ordenGenero = _peliculas.OrderBy(x => x.generoPelicula).ToList();
            Console.WriteLine("Lista de Peliculas en orden de genero");
            foreach (Pelicula item in _ordenGenero)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void listarOrdenFormato()
        {
            _ordenFormato = _peliculas.OrderBy(x => x.formatoPelicula).ToList();
            Console.WriteLine("Lista de Peliculas en orden de formato");
            foreach (Pelicula item in _ordenFormato)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void listarOrdenDirector()
        {
            _ordenDirector = _peliculas.OrderBy(x => x.directorPelicula).ToList();
            Console.WriteLine("Lista de Peliculas en orden de Director");
            foreach (Pelicula item in _ordenDirector)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void listarUbicacionEncontrada()
        {
            Console.WriteLine("Lista de Peliculas en orden de Director");
            foreach (Ubicacion item in _ubicacionObtenida)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void buscarPeliculas()
        {
            int? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Buscar Pelicula");
                Console.WriteLine("1.- Buscar Pelicula por orden Alfabetico");
                Console.WriteLine("2.- Buscar Pelicula por Genero");
                Console.WriteLine("3.- Buscar Pelicula por Formato");
                Console.WriteLine("4.- Buscar Pelicula por Director");
                Console.WriteLine("5.- regresar");
            } while (!validaMenu(5, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {

                case 1:
                    listarPeliculasAlfabeticamente();
                    obtenerUbicacion();
                    break;
                case 2:
                    listarOrdenGenero();
                    obtenerUbicacion();
                    break;
                case 3:
                    listarOrdenFormato();
                    obtenerUbicacion();
                    break;
                case 4:
                    listarOrdenDirector();
                    obtenerUbicacion();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
            }
        }

        private void obtenerUbicacion()
        {
            int? id = null;
            id = pedirValorInt("Escribe el Id de la Pelicula para obtener la ubicacion");
            Ubicacion? unicacionBuscar = _ubicaciones.FirstOrDefault(u => u.idUbicacion == id);
            if (unicacionBuscar == null)
            {
                Console.WriteLine("No se encontró la Ubicacion. Presiona 'Enter' para continuar...");
            }
            else
            {   
                if (_ubicaciones.Count() > 0)
                {
                    _ubicacionObtenida.RemoveAt(0);   
                }
                _ubicacionObtenida.Add(unicacionBuscar);
                Console.WriteLine($"La ubicacion es:\n");
                listarUbicacionEncontrada();
                Console.WriteLine($"Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            buscarPeliculas();
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
            }
            while (valor == null || valor == "");
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
            Pelicula pelicula1 = new Pelicula(_peliculas.Count()+1,"Atrapada en el fondo del mar","Drama","Digital","Joachim Heden");
            _peliculas.Add(pelicula1);
            Pelicula pelicula2 = new Pelicula(_peliculas.Count()+1,"Batman el largo Hallowen","Accion","VHS","Chris Palmer");
            _peliculas.Add(pelicula2);
            Pelicula pelicula3 = new Pelicula(_peliculas.Count()+1,"Raya y el Ultimo Dragon","Accion y aventura","Beta","Don Hall");
            _peliculas.Add(pelicula3);
            Pelicula pelicula4 = new Pelicula(_peliculas.Count()+1,"Cosas imposibles","Drama","DVD","Ernesto Contreras");
            _peliculas.Add(pelicula4);
            Pelicula pelicula5 = new Pelicula(_peliculas.Count()+1,"Spider-Man: No way Home","Ciencia Ficcion","Digital","Jon Watts");
            _peliculas.Add(pelicula5);
            Pelicula pelicula6 = new Pelicula(_peliculas.Count()+1,"Spider-Man","Aventura y Ciencia Ficcion","Digital","Jon Watts");
            _peliculas.Add(pelicula6);

            Ubicacion ubicacion1 = new Ubicacion(_ubicaciones.Count()+1,"En el librero de la primera habitacion", pelicula1);
            _ubicaciones.Add(ubicacion1);
            Ubicacion ubicacion2 = new Ubicacion(_ubicaciones.Count()+1,"En el librero de la segunda habitacion", pelicula2);
            _ubicaciones.Add(ubicacion2);
            Ubicacion ubicacion3 = new Ubicacion(_ubicaciones.Count()+1,"En el Ropero de la primera habitacion", pelicula3);
            _ubicaciones.Add(ubicacion3);
            Ubicacion ubicacion4 = new Ubicacion(_ubicaciones.Count()+1,"En el librero del comedor", pelicula4);
            _ubicaciones.Add(ubicacion4);
            Ubicacion ubicacion5 = new Ubicacion(_ubicaciones.Count()+1,"En el estante de la sala", pelicula5);
            _ubicaciones.Add(ubicacion5);
            Ubicacion ubicacion6 = new Ubicacion(_ubicaciones.Count()+1,"En el estante de la Habitacion de la entrada", pelicula6);
            _ubicaciones.Add(ubicacion6);
            _ubicacionObtenida.Add(ubicacion1);
        }
    }
}
