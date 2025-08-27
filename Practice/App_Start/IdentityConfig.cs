using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Practice.App_Start
{
    public class IdentityConfig
    {

    }

    /// <summary>
    /// ApplicationUser: clase personalizada que hereda de IdentityUser, obteniendo sus propiedades y agregando otras.
    /// Sirve para gestionar los e informacion de los usuarios del sistema
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastNames { get; set; }
        public byte[] Icon { get; set; }

        /// <summary>
        /// Metodo que crea una identidad para el usuario logueado, esto para que se almacenen los datos en las cookies que seran usadas
        /// por el sistema en ciertas operaciones que requeriran validacion, acepta un parametro ManejadorDeUsuario con los datos del 
        /// usuario logueado en ese momento
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Conexion", throwIfV1Schema: false)
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class IdentityManager
    {
        public IQueryable<IdentityRole> GetRoles()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            return RoleManager.Roles;
        }

        public bool RoleExists(string name)
        {
            var RoleExists = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return RoleExists.RoleExists(name);
        }

        public bool CreateRole(string name)
        {
            var CreateRole = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var idRoleCreate = CreateRole.Create(new IdentityRole(name));

            return idRoleCreate.Succeeded;
        }
    }

}