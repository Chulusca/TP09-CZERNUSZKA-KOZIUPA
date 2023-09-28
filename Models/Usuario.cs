namespace TP_09_CZERNUSZKA_KOZIUPA.Models;

public class Usuario{
    private string Username{get;set;}    
    private string Password{get;set;}
    private string Name{get;set}
    private int Number{get;set;}
    private string Email{get;set;}

    public static string ObtenerUsuario(){return Username;}
    public static string ObtenerContrasena(){return Password;}
    public static string ObtenerNombre(){return Name;}
    public static int ObtenerNumero(){return Number;}
    public static string ObtenerEmail(){return Email;}
}


