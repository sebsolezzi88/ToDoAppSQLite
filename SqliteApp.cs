namespace ToDoAppProgram
{
    using ClassTaskItem;
    using Microsoft.Data.Sqlite;

    class SqliteApp
    {
        static readonly string connectionString = "Data Source=miBase.db";
        private static string sql;

        /* Crea la tabla si no existe */
        public static void Init()
        {
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open();
                sql = "CREATE TABLE IF NOT EXISTS tasks (id INTEGER PRIMARY KEY AUTOINCREMENT, task TEXT NOT NULL)";
                using SqliteCommand cmd = new(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al crear la base de base de detaos");
            }
        }
        /* Obtener todas las tareas */
        public static List<TaskItem> GetTasks()
        {
            var tasks = new List<TaskItem>(); //Creamos la lista de las tareas
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open();
                sql = "SELECT * FROM tasks"; //query sql
                using SqliteCommand cmd = new(sql, conn);
                using SqliteDataReader reader = cmd.ExecuteReader(); //Ejecutamos la consulta y obtenemos las tareas

                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Task = reader["task"].ToString()!
                    });
                }

            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al obtener las tareas.");
            }
            return tasks;
        }
        /* Agregar una tarea */
        public static bool AddTask(string task)
        {
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open(); //Abrir la conexion
                sql = "INSERT INTO tasks (task) VALUES (@task)"; //query sql
                using SqliteCommand cmd = new(sql, conn); //Usando comando sql
                cmd.Parameters.AddWithValue("@task", task); //Agregar parametros al comando sql
                var rows = cmd.ExecuteNonQuery(); //Ejecutar el comando sql y obtener las filas afectadas
                return rows > 0; //Si hay filas afectadas regresa true por q se realizó el insert
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al agregar la tarea.");
                return false;
            }
        }
        public static bool DeleteTask(int id)
        {
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open(); //Abrir la conexion
                sql = "DELETE FROM tasks WHERE id=@id"; //query sql
                using SqliteCommand cmd = new(sql, conn); //Usando comando sql
                cmd.Parameters.AddWithValue("@id", id); //Agregar parametros al comando sql
                var rows = cmd.ExecuteNonQuery(); //Ejecutar el comando sql y obtener las filas afectadas
                return rows > 0; //Si hay filas afectadas regresa true por q se realizó el delete
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al borrar la tarea.");
                return false;
            }
        }
        /* Actulizar una tarea */
        public static bool UpdateTask(int id, string text)
        {
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open(); //Abrir la conexion
                sql = "UPDATE tasks SET task=@text WHERE id=@id"; //query sql
                using SqliteCommand cmd = new(sql, conn); //Usando comando sql
                cmd.Parameters.AddWithValue("@id", id); //Agregar parametros al comando sql
                cmd.Parameters.AddWithValue("@text", text); //Agregar parametros al comando sql
                var rows = cmd.ExecuteNonQuery(); //Ejecutar el comando sql y obtener las filas afectadas
                return rows > 0; //Si hay filas afectadas regresa true por q se realizó el delete

                /*
                Si son muchos parametros de puede usar esta forma
                cmd.Parameters.AddRange(new[]
                {
                    new SqliteParameter("@id", id),
                    new SqliteParameter("@text", text)
                }); 
                */
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al borrar la tarea.");
                return false;
            }
        }
    }
}