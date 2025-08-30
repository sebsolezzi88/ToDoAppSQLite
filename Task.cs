namespace ClassTaskItem
{
    //Clase para regresar los task obtenidos de la base de datos
    class TaskItem
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
    }
}