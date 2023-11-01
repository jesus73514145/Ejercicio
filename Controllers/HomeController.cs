using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using registrar_listar_estudiante.Models;
namespace registrar_listar_estudiante.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) { _logger = logger; }

    //private static List<Estudiante> estudiantes = new List<Estudiante>();

    private static List<Estudiante> estudiantes = new List<Estudiante> {
        new Estudiante { Nombre = "Juan", Apellidos = "Pérez", FechaNacimiento = new DateTime(1998, 5, 15), Genero = "Masculino", TieneTarjetaCredito = "Si" , ColoresFavoritos = new List<string> { "Rojo", "Azul" } }, 
        new Estudiante { Nombre = "María", Apellidos = "Gómez", FechaNacimiento = new DateTime(2000, 2, 10), Genero = "Femenino", TieneTarjetaCredito = "No" , ColoresFavoritos = new List<string> { "Negro", "Blanco" } }, 
        new Estudiante { Nombre = "Jesus", Apellidos = "Soria", FechaNacimiento = new DateTime(1998, 5, 15), Genero = "Masculino", TieneTarjetaCredito = "Si" , ColoresFavoritos = new List<string> { "Blanco", "Azul" } }, 
        new Estudiante { Nombre = "Naty", Apellidos = "Soria", FechaNacimiento = new DateTime(2000, 2, 10), Genero = "Femenino", TieneTarjetaCredito = "No" , ColoresFavoritos = new List<string> { "Rojo", "Negro" } }, 
        new Estudiante { Nombre = "Alberto", Apellidos = "Soria", FechaNacimiento = new DateTime(1998, 5, 15), Genero = "Masculino", TieneTarjetaCredito = "Si" , ColoresFavoritos = new List<string> { "Dorado", "Azul" } }, 
        new Estudiante { Nombre = "Paula", Apellidos = "Sanchez", FechaNacimiento = new DateTime(2000, 2, 10), Genero = "Femenino", TieneTarjetaCredito = "No" , ColoresFavoritos = new List<string> { "Rojo", "Dorado" } }, 
        new Estudiante { Nombre = "Andres", Apellidos = "Lamillar", FechaNacimiento = new DateTime(1998, 5, 15), Genero = "Masculino", TieneTarjetaCredito = "Si" , ColoresFavoritos = new List<string> { "Amarillo", "Azul" } }, 
        new Estudiante { Nombre = "Kiara", Apellidos = "Meza", FechaNacimiento = new DateTime(2000, 2, 10), Genero = "Femenino", TieneTarjetaCredito = "No" , ColoresFavoritos = new List<string> { "Rojo", "Amarillo" } }, 
        new Estudiante { Nombre = "Arnold", Apellidos = "Soria", FechaNacimiento = new DateTime(1998, 5, 15), Genero = "Masculino", TieneTarjetaCredito = "Si" , ColoresFavoritos = new List<string> { "Celeste", "Azul" } }, 
        new Estudiante { Nombre = "Vivi", Apellidos = "Ortiz", FechaNacimiento = new DateTime(2000, 2, 10), Genero = "Femenino", TieneTarjetaCredito = "No" , ColoresFavoritos = new List<string> { "Rojo", "Celeste", "Azul" } }
    };
    public IActionResult Index() {
        ViewBag.Generos = new List<string> { "Masculino", "Femenino", "Otro" };
        List<string> colores = new List<string> {
            "Rojo",
            "Azul",
            "Verde",
            "Amarillo",
            "Naranja"
        };

        ViewBag.Colores = colores;

        return View(estudiantes);
    }

    [HttpPost]
    public IActionResult RegistrarEstudiante(Estudiante estudiante) {
        // Obtiene los colores seleccionados del formulario
        string[] coloresSeleccionados = HttpContext.Request.Form["ColoresFavoritos"];

        // Crea una nueva lista para almacenar los colores favoritos
        estudiante.ColoresFavoritos = new List<string>(coloresSeleccionados);


        estudiantes.Add(estudiante);
        return RedirectToAction("Index");
    }

    public IActionResult EstudiantesLista() {
        return View(estudiantes);
    }   

    public IActionResult Privacy() {    return View(); }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
