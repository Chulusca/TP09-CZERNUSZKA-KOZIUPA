namespace TP_09_CZERNUSZKA_KOZIUPA.Models;

public class Usuario{
    public string Username{get;set;}    
    public string Contrasena{get;set;}
    public string Nombre{get;set;}
    public int Telefono{get;set;}
    public string Email{get;set;}

     public Usuario(string username, string contrasena, string nombre, int telefono, string email)
    {
        Username = username;
        Contrasena = contrasena;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
    }
}


