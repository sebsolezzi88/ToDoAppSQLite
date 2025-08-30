using ToDoAppProgram;

class Program
{
    static void Main(string[] args)
    {
        //Crear base de datos si no existe
        SqliteApp.Init();
        string opcion;
        string userInput;
        bool run = true;
        Console.WriteLine("--- TODO App SQLite --- ");
        while (run)
        {
            Console.WriteLine("Seleccione una opción \n 1-Mostrar tareas \n 2-Agregar tarea \n 3-Editar tarea \n 4-Eliminar tarea \n 5-Salir ");
            Console.Write("Ingrese opción: ");
            opcion = Console.ReadLine() ?? "";
            switch (opcion)
            {
                case "1": //Mostrar Tareas
                    Console.WriteLine("---------------");
                    var tareas = SqliteApp.GetTasks();
                    foreach (var t in tareas)
                    {
                        Console.WriteLine($"ID: {t.Id}, Task: {t.Task}");
                    }
                    break;

                case "2"://Agregar Tarea
                    Console.WriteLine("---------------");
                    Console.Write("Ingrese el nombre de la tarea a guardar: ");
                    userInput = Console.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        if (SqliteApp.AddTask(userInput))
                        {

                            Console.WriteLine($"La tarea {userInput} fue agregada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("La tarea no fue guardada");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La tarea debe tener contenido: ");
                    }
                    break;
                case "3": //Agregar Editar tarea
                    Console.WriteLine("Editar tareas");
                    break;
                case "4": //Eliminar Tarea
                    Console.WriteLine("Eliminar tareas");
                    break;
                case "5": //Cerrar programa
                    run = false;
                    break;

            }
            Console.WriteLine("---------------");
        }
    }
}
