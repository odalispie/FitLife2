using FitLife2.Repository;
using FitLife2.Services;
using FitLife2.Screens;

// 1. Configurar las capas
var repo = new MiembroRepository(); 
var service = new MiembroService(repo);
var menu = new MenuScreen(service);

// 2. Ejecutar el menú
menu.Show();
