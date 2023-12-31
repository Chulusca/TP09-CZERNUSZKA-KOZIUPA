using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_09_CZERNUSZKA_KOZIUPA.Models;
using System.Linq;

namespace TP_09_CZERNUSZKA_KOZIUPA.Controllers;

public class AccountController : Controller
{
    public IActionResult Login(string targetUsername, string password){
        List<Usuario> listaUsuarios = BD.ObtenerUsuarios(); //obtener usuarios
        
        Usuario matchingUser = listaUsuarios.FirstOrDefault(u => u.Username == targetUsername);

        if (matchingUser != null) //verificacion de usuario existente en la BD
        {
            if(matchingUser.Contrasena== password)//verificar la contraseña
            {
                return RedirectToAction("Bienvenida", new {user = matchingUser});
            }
            else{
                ViewBag.MsjError = "Contraseña Incorrecta";
            }
        }
        else{
            ViewBag.MsjError = "Usuario inexistente";
        }
        return View("Login");
    }
    public IActionResult CrearUsuario(string user, string pass, string name, int number, string email){
        Usuario USER = new Usuario(user, pass, name, number, email);
        BD.AgregarUsuario(USER);
        return RedirectToAction("Login");
    }
    public IActionResult CambioContrasena(){
        return View();
    }
    public IActionResult CambiarContraseña(string Username, string nuevaContrasena){
        BD.CambiarContraseña(Username, nuevaContrasena);
        return View("Login");
    }
    public IActionResult ForgotPassword(string email, string name){
        List<Usuario> listaUsuarios = BD.ObtenerUsuarios(); //obtener usuarios
        Usuario matchingUser = listaUsuarios.FirstOrDefault(u => u.Email == email);

        if (matchingUser != null) //verificacion de usuario existente en la BD
        {
            if(matchingUser.Nombre == name)//verificar el nombre
            {
                ViewBag.Contraseña = matchingUser.Contrasena;
            }
            else{
                ViewBag.MsjError = "Nombre Incorrecto";
            }
        }
        else{
            ViewBag.MsjError = "Usuario inexistente";
        }
        return View("Index");
    }

    public IActionResult Registro(){
        return View();
    }
    public IActionResult Bienvenida(Usuario user){
        ViewBag.Usuario = user;
        return View("Bienvenida");
    }
}

