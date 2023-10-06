using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

namespace TP_09_CZERNUSZKA_KOZIUPA.Models;

public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=register;Trusted_Connection=True;";

    public static List<Usuario> ObtenerUsuarios(){
        List<Usuario> listaUsuarios = null;
        using(SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuario";
            listaUsuarios = BD.Query<Usuario>(sql).ToList();
        }
        return listaUsuarios;
    }
    public static void AgregarUsuario(Usuario user){
        using(SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "INSERT INTO Usuario(Username, Contraseña, Nombre, Telefono, Email) VALUES (@Username, @Contraseña, @Nombre, @Telefono, @Email)";
            BD.Execute(sql, new {Username = user.Username, Contraseña = user.Contrasena, Nombre = user.Nombre, Telefono = user.Telefono, Email = user.Email});
        }
    }

}