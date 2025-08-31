# TODO App SQLite en C# 🗒️

Una pequeña aplicación de consola en C# que permite gestionar tareas utilizando una base de datos SQLite.  
Permite **agregar**, **listar**, **editar** y **eliminar** tareas de manera sencilla.

---

## ⚡ Características

- 🆕 Crear automáticamente la base de datos y la tabla de tareas si no existen.
- 📋 Listar todas las tareas registradas.
- ➕ Agregar nuevas tareas.
- ✏️ Editar tareas existentes.
- 🗑️ Eliminar tareas por ID.
- ⚠️ Manejo básico de errores de base de datos.

---

## 📂 Estructura del proyecto

- **Program.cs**: Contiene el menú principal y la interacción con el usuario.
- **SqliteApp.cs**: Clase que maneja todas las operaciones con SQLite (`Init`, `GetTasks`, `AddTask`, `UpdateTask`, `DeleteTask`).
- **TaskItem.cs**: Clase que representa una tarea (`Id` y `Task`).

---

## 🚀 Uso

1. Clonar el repositorio:

```
git clone https://github.com/sebsolezzi88/ToDoAppSQLite
```
2. Abrir el proyecto en Visual Studio o Visual Studio Code.

3. Ejecutar el proyecto. Aparecerá un menú en consola:
```
--- TODO App SQLite ---
Seleccione una opción
1-Mostrar tareas
2-Agregar tarea
3-Editar tarea
4-Eliminar tarea
5-Salir
```
4. Ingresar el número de opción deseada y seguir las instrucciones en pantalla.

## Ejemplo de uso

- Agregar tarea:
``` 
Ingrese opción: 2
Ingrese el nombre de la tarea a guardar: Comprar leche
La tarea Comprar leche fue agregada correctamente
```
- Listar tareas:
```
Ingrese opción: 1
ID: 1, Task: Comprar leche
ID: 2, Task: Estudiar C#
```

- Editar tarea:
```
Ingrese opción: 3
Ingrese el Id de la tarea a editar: 1
Ingrese el texto para actualizar la tarea: Comprar pan
La tarea fue actualizada
```

- Eliminar tarea:
```
Ingrese opción: 4
Ingrese el Id de la tarea a borrar: 2
Tarea borrada.
```

## Requisitos
- [.NET 6 o superior](https://dotnet.microsoft.com/es-es/download)

- [Paquete Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/10.0.0-preview.7.25380.108)
