using FitLife2.Services;
using Spectre.Console;

namespace FitLife2.Screens
{
    public class MenuScreen
    {
        private readonly MiembroService _service;

        public MenuScreen(MiembroService service)
        {
            _service = service;
        }

        public void Show()
        {
            while (true)
            {
                AnsiConsole.Clear();
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[blue]SISTEMA DE GIMNASIO FITLIFE[/]")
                        .AddChoices(new[] { "Registrar Miembro", "Listar Miembros", "Salir" }));

                if (opcion == "Salir") break;

                if (opcion == "Registrar Miembro")
                {
                    var nombre = AnsiConsole.Ask<string>("Nombre completo:");
                    var cedula = AnsiConsole.Ask<string>("Cédula:");
                    var tel = AnsiConsole.Ask<string>("Teléfono:");
                    _service.Registrar(nombre, cedula, tel);
                    AnsiConsole.MarkupLine("[green]¡Miembro registrado![/]");
                }
                else
                {
                    var tabla = new Table().Border(TableBorder.Rounded);
                    tabla.AddColumn("Nombre");
                    tabla.AddColumn("Cédula");
                    tabla.AddColumn("Teléfono");

                    foreach (var m in _service.ObtenerTodos())
                        tabla.AddRow(m.NombreCompleto, m.Cedula, m.Telefono);

                    AnsiConsole.Write(tabla);
                }
                AnsiConsole.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}