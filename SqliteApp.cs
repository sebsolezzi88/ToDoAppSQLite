namespace ToDoAppProgram
{
    using Microsoft.Data.Sqlite;

    class SqliteApp
    {
        static readonly string connectionString = "Data Source=miBase.db";
        private static string sql;

        /* Crea la tabla si no existe */
        public static void Init()
        {
            using SqliteConnection conn = new(connectionString);
            try
            {
                conn.Open();
                sql = "CREATE TABLE IF NOT EXISTS tasks (id INTEGER PRIMARY KEY AUTOINCREMENT, task TEXT NOT NULL)";
                using SqliteCommand cmd = new(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al crear la base de base de detaos");
                throw;
            }
        }
        /* Agregar una tarea */
        public static bool AddTask(string task)
        {
            using SqliteConnection conn = new(connectionString);
            sql = "INSERT INTO tasks (task) VALUES (@task)";
            using SqliteCommand cmd = new(sql, conn);
            var rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}