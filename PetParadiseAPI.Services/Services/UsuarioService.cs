using PetParadiseAPI.Common.DTOS;
using PetParadiseAPI.DataAccess.DAO;

namespace PetParadiseAPI.Services.Services
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> ObtenerTodosUsuario();
        UsuarioDTO ObtenerPorID(int idUsuario);
        UsuarioDTO AgregarUsuario(UsuarioDTO usuarioRequest);
        UsuarioDTO ModificarUsuario(UsuarioDTO usuarioRequest);
        string EliminarUsuario(int idUsuario);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioDAO _usuarioDAO;
        public UsuarioService(IUsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        public List<UsuarioDTO> ObtenerTodosUsuario()
        {
            List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
            var listaUsuarios = _usuarioDAO.ObtenerTodos();
            foreach (var item in listaUsuarios)
            {
                UsuarioDTO usr = new()
                {
                    IdUsuario = item.IdUsuario,
                    NombreUsuario = item.NombreUsuario,
                    ApellidosUsuario = item.ApellidosUsuario,
                    TelefonoUsuario = item.TelefonoUsuario,
                    ContraseñaUsuario = item.ContraseñaUsuario,
                    CorreoUsuario = item.CorreoUsuario
                };
                usuarioDTOs.Add(usr);
            }
            return usuarioDTOs;
        }

        public UsuarioDTO ObtenerPorID(int idUsuario)
        {
            var usuario = _usuarioDAO.ObtenerPorID(idUsuario);
            UsuarioDTO usr = new()
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsuario = usuario.NombreUsuario,
                ApellidosUsuario = usuario.ApellidosUsuario,
                TelefonoUsuario = usuario.TelefonoUsuario,
                ContraseñaUsuario = usuario.ContraseñaUsuario,
                CorreoUsuario = usuario.CorreoUsuario
            };
            return usr;
        }

        public UsuarioDTO AgregarUsuario(UsuarioDTO usuarioRequest)
        {
            return _usuarioDAO.Agregar(usuarioRequest);
        }

        public UsuarioDTO ModificarUsuario(UsuarioDTO usuarioRequest)
        {
            return _usuarioDAO.Modificar(usuarioRequest);
        }

        public string EliminarUsuario(int idUsuario)
        {
            if (!_usuarioDAO.Eliminar(idUsuario))
            {
                return "Eliminado exitosamente";
            }
            else
            {
                return "No se pudo eliminar";
            }
        }
    }
}
