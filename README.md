# SchoolEase

## Descripción

SchoolEase es una aplicación web diseñada para simplificar la gestión de escuelas y mejorar la comunicación entre el personal escolar, los estudiantes y los padres. Proporciona una plataforma integral que permite realizar tareas administrativas, seguimiento académico y acceso a información relevante de manera eficiente.

Esta solución consta de dos proyectos, por un lado se encuentra una API cuyo nombre es *ApiSchoolEase* desarrollada con **Web API en .NET 6** la cual nos permite la creación de la base de datos ya sea en memoria o en disco duro, ademas, por medio de esta se hacen las peticiones a la base de datos. Su documentación esta disponible con Swagger. Por otro lado tenemos la aplicación web llamada *WebAppSchoolEase* desarrollada con **Blazor WebAssembly** y **.NET 6**.

## Versiones
* Beta
## Instalación

1. Clona este repositorio: `git clone https://github.com/betancurm/SchoolEase.git`
2.  Se debe instalar [.NET CORE SDK ](https://dotnet.microsoft.com/en-us/download) en la máquina.
3. Si se desea crear la base de datos en local se debe instalar [SQL SERVER](https://info.microsoft.com/ww-landing-sql-server-2022.html?culture=en-us&country=us)
4. Accede al la carpeta del repositorio clonado y ejecuta el archivo SchoolEase.sln
5. Verifica que al momento de correr el programa ambos proyectos se ejecuten al tiempo

## Tecnologías utilizadas
* [.NET Core 6.*](https://dotnet.microsoft.com/es-es/) es una plataforma de desarrollo gratuita, multiplataforma y de código abierto para crear muchos tipos de aplicaciones. .NET se basa en un tiempo de ejecución de alto rendimiento(high-performance runtime) que se usa en producción en muchas aplicaciones de gran escala.
* [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) es una plataforma de datos híbrida escalable que ofrece un rendimiento y seguridad líderes en la industria. Ahora habilitado para Azure, puede descargar SQL Server 2022 o una edición especializada gratuita
* [Blazor WebAssembly](https://dotnet.microsoft.com/es-es/apps/aspnet/web-apps/blazor) es una plataforma de trabajo para la creación de interfaces de usuario web interactivas del lado del cliente con .NET. Ejecutar código .NET dentro de navegadores web es posible gracias a WebAssembly (abreviado wasm), un formato de bytecode compacto optimizado para una descarga rápida y una velocidad de ejecución máxima. 

## Equipo 🌟

<table>
  <tbody>
    <tr>
      <td align="center" valign="top" width="14.28%"><a href="https://www.linkedin.com/in/juanbetancurm/"><img src="https://avatars.githubusercontent.com/u/96802339?v=4" width="100px;" alt="Juan Manuel Betancur"/><br /><sub><b>Juan Manuel Betancur</b></sub></a><br /><a href="https://github.com/betancurm/SchoolEase" title="Code">💻</a><a title="Tutoriales">✅</a><a title="Documentación">📖</a></td>
      <td align="center" valign="top" width="14.28%"><a href="https://www.linkedin.com/in/jennysancheza/"><img src="https://avatars.githubusercontent.com/u/90258108?v=4" width="100px;" alt="Rina Plata"/><br /><sub><b>Jenny Sánchez Arango</b></sub></a><br /><a href="https://github.com/Jesaar/SchooEase" title="Codigo">💻</a> </td>
      <td align="center" valign="top" width="14.28%"><a href=""><img src="https://avatars.githubusercontent.com/u/99564268?v=4" width="100px;" alt="Estefany Builes Lopera"/><br /><sub><b>Estefany Builes Lopera</b></sub></a><br /><a href="https://github.com/Stefany023/SchooEase" title="Codigo">💻</a></td>
      <td align="center" valign="top" width="14.28%"><a href=""><img src="https://avatars.githubusercontent.com/u/105022840?v=4" width="100px;" alt="Geraldine Davila Echeverri"/><br /><sub><b>Geraldine Davila Echeverri</b></sub></a><br /><a href="https://github.com/Mteheran/api-colombia/mteheran/api-colombia/commits?author=mariobot" title="Code">💻</a></td>
    </tr>
</table>

## Cronograma

|Tarea	|Duración Estimada |Fecha de Inicio	|Fecha de Fin |
|-------|-------------------|-------------------|-------------|
|Análisis de Requerimientos                                                 |4 semanas	|24 de marzo	|21 de abril|
Creación base de datos                                                      |2 semanas  |22 de abril    |5 de mayo|
Desarrollo de la Interfaz de Usuario	                                    |2 semanas  |28 de abril    |11 de mayo|
Desarrollo del módulo de gestión de usuarios	                            |1 semanas  |28 de abril    |3 de mayo|
Desarrollo del módulo de matrícula	                                        |1 semanas  |2 de mayo      |5 de mayo|
Desarrollo del módulo de gestión de administración de materias y horarios   |1 semanas  |5 de mayo	    |12 de mayo|
Desarrollo del módulo de gestión de grupos	                                |1 semanas  |12 de mayo     |19 de mayo|
Desarrollo del módulo de gestión de horarios	                            |1 semanas	|19 de mayo	    |22 de mayo|
Desarrollo del módulo de gestión de calificaciones	                        |1 semanas	|26 de mayo	    |1 junio|
Pruebas y correcciones	                                                    |1 semanas	|2 de junio	    |8 de junio|
Entrega final	                                                            |           |               |9 de junio|


## Tablero Digital
Para la administración del proyecto Schoolease se utilizó [Trello](https://trello.com/), una herramienta de gestión de proyectos en línea. Trello permitió a los miembros del equipo organizar tareas, asignar responsabilidades y dar seguimiento al progreso de cada etapa del proyecto de manera eficiente. Mediante la creación de tableros, listas y tarjetas, se logró una coordinación efectiva y una visualización clara de las actividades, lo que contribuyó al éxito y la entrega oportuna del proyecto Schoolease.

[Aqui](https://trello.com/b/O1o3pG1Y/desarrollo-web) podras visualizar el seguimiento del proyecto.


## Capturas de pantalla
### Modelo Relacional de la Base de Datos
![Modelo Relacional](https://i.ibb.co/7QTHh5c/Modelo-Relacional-School-Ease.png)
### Captura de Pantalla de Trello
![Captura de Pantalla de Trello](https://i.ibb.co/2q9kNtF/Captura-de-Pantalla-del-tablero.png)
### Interfaz de Inicio
![Interfaz de Inicio](https://i.ibb.co/FmVzwfV/Interfaz-de-la-aplicacion.png)

### Ejemplo de Formularios
![Ejemplo de Formulario](https://i.ibb.co/PgrqHWR/formulario-de-ejemplo.png)