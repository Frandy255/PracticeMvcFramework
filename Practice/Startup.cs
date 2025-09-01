using Microsoft.Owin;
using Owin;
using System;


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
            ConfigureAuth(app);
        }
       
       
    }


}