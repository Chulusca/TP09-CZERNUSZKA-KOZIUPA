using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_09_CZERNUSZKA_KOZIUPA.Models;
using System.Linq;

namespace TP_09_CZERNUSZKA_KOZIUPA.Controllers;

public class AccountController : Controller
{
    public IActionResult Login(string targetUsername, string password){
        List<Usuario> listaUsuarios = BD.ObtenerUsuarios(); //obtener usuarios
        
        matchingUser = listaUsuarios.FirstOrDefault(u => u.Username == targetUsername);

        if (matchingUser != null) //verificacion de usuario existente en la BD
        {
            if(matchingUser.ObtenerContrasena == password)//verificar la contraseña
            {
                return View("Bienvenida");
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
        Usuario USER = new Usuario();
        BD.AgregarUsuario()
    }
}
