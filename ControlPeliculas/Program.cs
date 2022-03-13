using ControlPeliculas.Models;
using ControlPeliculas;

ControlPeliculasAdmin control = new ControlPeliculasAdmin();
control.inicializarDatos();
control.showMenuPrincipal();

// En la busqueda se ordenan los datos lo cual agrupa
// los datos iguales y los muestra al usuario
// por los diferentes parametros de una pelicula.