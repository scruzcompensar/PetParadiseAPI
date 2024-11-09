namespace PetParadiseAPI.Common.DTOS
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string ApellidosUsuario { get; set; } = null!;
        public string TelefonoUsuario { get; set; } = null!;
        public string CorreoUsuario { get; set; } = null!;
        public string ContraseñaUsuario { get; set; } = null!;
    }
}
