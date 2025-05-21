# Sistema de Gestión de Eventos Deportivos Universitarios

Este proyecto es parte del Trabajo Práctico 1 para la materia **Seminario de Lenguajes - Opción .NET**. El objetivo es desarrollar un sistema web que permita organizar, gestionar y visualizar eventos deportivos a nivel universitario.

## 🏗️ Tecnologías Utilizadas

- .NET 8
- C#

## 🎯 Funcionalidades Principales

- Registro y login de usuarios
- Alta, baja y modificación de eventos deportivos
- Inscripción a eventos por parte de los estudiantes

## 👥 Integrantes

- **Nahuel Pardo**
- **Jonathan Hiriart**

## ⚙️ Ejecución

Para ejecutar el proyecto, asegúrate de tener instalado .NET 8 y sigue estos pasos:
1. Situate en el Program.cs de la carpeta CentroEventos/CentroEventos.Consola.
2. Compila el proyecto con dotnet run.
3. Una vez compilado, se te pedirá que ingreses tu DNI para registrarte o iniciar sesión (En caso de no estar registrado, se te pedirá que completes el formulario de registro).
4. Si es el primer ingreso tendras todos los permisos para las funcionalidades, si no es el primer ingreso, solo tendrás acceso a las funcionalidades de listado.
5. Te va a aparecer un menú de opciones y tendrás que ingresar el numero de la opcion que deseas realizar.
6. Si deseas realizar una acción que no está en el menú, se te indicará que la opción no es válida y se volverá a mostrar el menú.
7. Una vez que hayas terminado de usar el sistema, podés salir ingresando la clave 15.

## 👾 Ejemplo de uso
### Caso de Uso: Alta de Persona y Listado

### Descripción  
Se simula el ingreso de un usuario nuevo, que no está registrado en el sistema. El sistema solicita los datos necesarios y lo registra. Luego, se lista a todas las personas registradas.

---

### Código Ejecutado

```csharp
// Simulación de ingreso de un nuevo usuario
Console.WriteLine("Ingrese su DNI:");
string? dni = "12345678";
usuario = repositorioPersona.obtenerPorDNI(dni);
if (usuario == null)
{
    usuario = new Persona();
    usuario.Nombre = "Nahuel";
    usuario.Apellido = "Pardo";
    usuario.DNI = dni;
    usuario.Email = "nahuelpardo@example.com";
    usuario.Telefono = "2211234567";
    agregarPersona.Ejecutar(usuario, 1);
}

// Listado de personas
List<Persona> personas = listarPersonas.Ejecutar();
if (personas.Count == 0)
{
    Console.WriteLine("No hay personas registradas.");
}
else
{
    Console.WriteLine("Personas registradas: ");
    personas.ForEach(p => Console.WriteLine(p.ToString()));
}

## Salida esperada por consola
```csharp
Ingrese su DNI:
El DNI ingresado no existe en el sistema, por favor registrese primero.
Ingrese su nombre:
Ingrese su apellido:
Ingrese su DNI:
Ingrese su email:
Ingrese su telefono:

Personas registradas:
[1] Nahuel Pardo - DNI: 12345678 - Email: nahuelpardo@example.com - Teléfono: 2211234567


## 📄 Licencia	
Este proyecto es de uso académico exclusivamente.
