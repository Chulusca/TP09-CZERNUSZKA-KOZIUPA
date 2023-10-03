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
            if(matchingUser.Password == password)//verificar la contraseña
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
        return View("Index");
    }
    public IActionResult Register(string user, string pass, string name, int number, string email){
        Usuario USER = new Usuario(user, pass, name, number, email);
        BD.AgregarUsuario(USER);
        return View("Index");
    }

    public IActionResult ForgotPassword(string email, string name){
        List<Usuario> listaUsuarios = BD.ObtenerUsuarios(); //obtener usuarios
        Usuario matchingUser = listaUsuarios.FirstOrDefault(u => u.Email == email);

        if (matchingUser != null) //verificacion de usuario existente en la BD
        {
            if(matchingUser.Name == name)//verificar el nombre
            {
                ViewBag.Contraseña = matchingUser.Password;
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
    public IActionResult Bienvenida(Usuario user){
        ViewBag.Usuario = user;
        return View("Bienvenida");
    }
}
