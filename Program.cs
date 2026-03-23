using FitLife2.Database;
using FitLife2.Repository;
using FitLife2.Services;
using FitLife2.Screens;

// 1. Inicializar la base de datos
var db = new DatabaseConfig();
db.Initialize();

// 2. Configurar las capas
var repo = new MiembroRepository(db);
var service = new MiembroService(repo);
var menu = new MenuScreen(service);

// 3. Ejecutar el menú
menu.Show();