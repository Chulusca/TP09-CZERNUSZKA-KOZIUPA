namespace TP_09_CZERNUSZKA_KOZIUPA.Models;

public class Usuario{
    public string Username{get;set;}    
    public string Password{get;set;}
    public string Name{get;set;}
    public int Number{get;set;}
    public string Email{get;set;}

    public Usuario(string u, string p, string n, int num, string e){
        Username = u; Password = p; Name = n; Number =  num; Email = e;
    }
}


