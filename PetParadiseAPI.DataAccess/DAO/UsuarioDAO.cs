﻿using PetParadiseAPI.DataAccess.Data;
using PetParadiseAPI.Common.DTOS;

namespace PetParadiseAPI.DataAccess.DAO
{
    public interface IUsuarioDAO
    {
        List<Usuario> ObtenerTodos();
        Usuario ObtenerPorID(int id);
        UsuarioDTO Agregar(UsuarioDTO entity);
        UsuarioDTO Modificar(UsuarioDTO entity);
        bool Eliminar(int id);

    }
    public class UsuarioDAO : IUsuarioDAO
    {
        //Se inyecta depencia sobre la interfaz de métodos genericos
        private readonly IBaseDAO<Usuario> _daoBase;
        public UsuarioDAO(IBaseDAO<Usuario> daoBase)
        {
            _daoBase = daoBase;
        }

        #region Inicio Métodos
        public List<Usuario> ObtenerTodos() => _daoBase.GetAll();

        public Usuario ObtenerPorID(int id)
        {
            return _daoBase.GetById(id);
        }
        public UsuarioDTO Agregar(UsuarioDTO entity)
        {
            Usuario reg = new()
            {
                NombreUsuario = entity.NombreUsuario,
                ApellidosUsuario = entity.ApellidosUsuario,
                TelefonoUsuario = entity.TelefonoUsuario,
                ContraseñaUsuario = entity.ContraseñaUsuario,
                CorreoUsuario = entity.CorreoUsuario
            };

            //Obtenemos el id creado en la inserción del registro
            entity.IdUsuario = _daoBase.Add(reg).IdUsuario;
            return entity;
        }

        public UsuarioDTO Modificar(UsuarioDTO entity)
        {
            Usuario reg = new()
            {
                IdUsuario = entity.IdUsuario,
                NombreUsuario = entity.NombreUsuario,
                ApellidosUsuario = entity.ApellidosUsuario,
                TelefonoUsuario = entity.TelefonoUsuario,
                ContraseñaUsuario = entity.ContraseñaUsuario,
                CorreoUsuario = entity.CorreoUsuario
            };

            _daoBase.Modify(reg);
            return entity;
        }

        public bool Eliminar(int id) => _daoBase.Delete(id);
        #endregion
    }
}
