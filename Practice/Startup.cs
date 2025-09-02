using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using System;
using System.Security.Cryptography;


[assembly: OwinStartupAttribute(typeof(Practice.Startup))]
namespace Practice
{
    public partial class Startup
    {
        static void Main()
        {
            Console.WriteLine("¡Hola, mundo!");

        }
        public void Configuration(IAppBuilder app)
        {


            var password = "MiClaveDePrueba123!";
            var hasher = new PasswordHasher();

            // Genera hash en el formato oficial de Identity
            var hashedPassword = hasher.HashPassword(password);

            Console.WriteLine("Hash compatible con Identity: " + hashedPassword);

            ConfigureAuth(app);
        }
       
       
    }


}