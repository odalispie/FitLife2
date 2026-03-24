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
                        .AddChoices(new[] {
                            "Registrar Miembro",
                            "Listar Miembros",
                            "Buscar por Cédula",
                            "Actualizar Teléfono",
                            "Eliminar Miembro",
                            "Salir"
                        }));

                if (opcion == "Salir") break;

                switch (opcion)
                {
                    case "Registrar Miembro":
                        var nombre = AnsiConsole.Ask<string>("Nombre completo:");
                        var cedula = AnsiConsole.Ask<string>("Cédula:");
                        var tel = AnsiConsole.Ask<string>("Teléfono:");
                        _service.Registrar(nombre, cedula, tel);
                        AnsiConsole.MarkupLine("[green]¡Miembro registrado![/]");
                        break;

                    case "Listar Miembros":
                        MostrarTabla();
                        break;

                    case "Buscar por Cédula":
                        var cBuscar = AnsiConsole.Ask<string>("Ingrese la cédula a buscar:");
                        var m = _service.BuscarPorCedula(cBuscar); 
                        if (m != null)
                            AnsiConsole.MarkupLine($"[green]Encontrado:[/] {m.NombreCompleto} - {m.Telefono}");
                        else
                            AnsiConsole.MarkupLine("[red]Miembro no encontrado.[/]");
                        break;

                    case "Actualizar Teléfono":
                        var cAct = AnsiConsole.Ask<string>("Cédula del miembro a actualizar:");
                        var nuevoTel = AnsiConsole.Ask<string>("Nuevo teléfono:");
                        _service.ActualizarTelefono(cAct, nuevoTel); 
                        AnsiConsole.MarkupLine("[yellow]¡Teléfono actualizado exitosamente![/]");
                        break;

                    case "Eliminar Miembro":
                        var cEli = AnsiConsole.Ask<string>("Cédula del miembro a eliminar:");
                        _service.Eliminar(cEli); 
                        AnsiConsole.MarkupLine("[red]¡Miembro eliminado del sistema![/]");
                        break;
                }

                AnsiConsole.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void MostrarTabla()
        {
            var tabla = new Table().Border(TableBorder.Rounded);
            tabla.AddColumn("Nombre");
            tabla.AddColumn("Cédula");
            tabla.AddColumn("Teléfono");

            foreach (var m in _service.ObtenerTodos())
                tabla.AddRow(m.NombreCompleto, m.Cedula, m.Telefono);

            AnsiConsole.Write(tabla);
        }
    }
}
