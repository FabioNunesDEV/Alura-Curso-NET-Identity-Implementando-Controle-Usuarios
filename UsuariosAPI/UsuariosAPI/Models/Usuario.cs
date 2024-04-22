using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Models;

public class Usuario: IdentityUser
{
    public DateTime DataNacimento { get; set; }

    public Usuario() : base() { }

}