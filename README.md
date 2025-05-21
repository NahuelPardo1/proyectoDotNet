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
 
### 🔧 Paso 1: Iniciar ejecución del sistema

Al iniciar el programa, se solicita al usuario que ingrese su DNI para verificar si ya está registrado en el sistema.

```text
BIENVENIDO AL SISTEMA DE GESTIÓN DEL CENTRO DEPORTIVO UNIVERSITARIO

Ingrese su DNI:
```
### 👤 Paso 2: Ingreso de un nuevo DNI (no registrado)

El usuario ingresa el DNI `12345678`. Como este no se encuentra registrado, el sistema solicita los datos para registrarlo.
```text
El DNI ingresado no existe en el sistema, por favor registrese primero.

Ingrese su nombre:

John

Ingrese su apellido:

Doe

Ingrese su DNI:

12345678

Ingrese su email:

jhondoe@gmail.com

Ingrese su telefono:

2216549873
```
(Internamente se ejecuta `agregarPersona.Ejecutar()` con los datos ingresados)
### 🖥️ Paso 3: Menú de opciones

Luego del registro exitoso, se muestra el menú principal:
```text
Seleccione una opción: 

1. Listar personas                       | 2. Agregar persona 

3. Modificar persona                     | 4. Eliminar persona 

4. Listar eventos deportivos             | 6. Agregar evento deportivo 

7. Modificar evento deportivo            | 8. Eliminar evento deportivo 

9. Listar reservas                       | 10. Agregar reserva 

11. Modificar reserva                    | 12. Eliminar reserva 

13. Listar asistencia a evento deportivo | 14. Listar eventos deportivos con cupo disponible 

15. Salir 

```
### 📋 Paso 4: Listar personas

El usuario selecciona la opción **1** para listar todas las personas registradas.
```text
Personas registradas:
ID: 1 - John Doe - DNI: 12345678 - Email: johndoe@gmail.com - Teléfono: 2216549873
```
## ✅ Resultado

El sistema permitió:
- Registrar una nueva persona.
- Validar su existencia al inicio.
- Mostrar el menú principal.
- Listar correctamente las personas registradas.

---
