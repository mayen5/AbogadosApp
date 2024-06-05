using AbogadosApp.Models;
using System;
using System.Linq;
namespace AbogadosApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(AbogadosContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Clients.
            if (context.Clientes.Any())
            {
                return;   // DB has been seeded
            }

            var clientes = new Cliente[]
            {
                new Cliente{Nombre="Carson",Apellido="Alexander",Direccion="Calle 1",Telefono="123456"},
                new Cliente{Nombre="Meredith",Apellido="Alonso",Direccion="Calle 2",Telefono="123456"},
                new Cliente{Nombre="Arturo",Apellido="Anand",Direccion="Calle 3",Telefono="123456"},
                new Cliente{Nombre="Gytis",Apellido="Barzdukas",Direccion="Calle 4",Telefono="123456"},
                new Cliente{Nombre="Yan",Apellido="Li",Direccion="Calle 5",Telefono="123456"},
                new Cliente{Nombre="Peggy",Apellido="Justice",Direccion="Calle 6",Telefono="123456"},
                new Cliente{Nombre="Laura",Apellido="Norman",Direccion="Calle 7",Telefono="123456"},
                new Cliente{Nombre="Nino",Apellido="Olivetto",Direccion="Calle 8",Telefono="123456"}
            };
            foreach (Cliente c in clientes)
            {
                context.Clientes.Add(c);
            }
            context.SaveChanges();

            var asuntos = new Asunto[]
            {
                new Asunto{IdCliente=1,Descripcion="Asunto 1",Fecha=DateTime.Parse("2023-09-01")},
                new Asunto{IdCliente=2,Descripcion="Asunto 2",Fecha=DateTime.Parse("2023-09-01")},
                new Asunto{IdCliente=3,Descripcion="Asunto 3",Fecha=DateTime.Parse("2023-09-01")},
                new Asunto{IdCliente=4,Descripcion="Asunto 4",Fecha=DateTime.Parse("2023-09-01")},
                new Asunto{IdCliente=5,Descripcion="Asunto 5",Fecha=DateTime.Parse("2023-09-01")},
                new Asunto{IdCliente=6,Descripcion="Asunto 6",Fecha=DateTime.Parse("2023-09-01")},
                new Asunto{IdCliente=7,Descripcion="Asunto 7",Fecha=DateTime.Parse("2024-06-04")}
            };
            foreach (Asunto a in asuntos)
            {
                context.Asuntos.Add(a);
            }
            context.SaveChanges();
        }

    }
}
