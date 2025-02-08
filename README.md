Sales Date Prediction - Prueba Técnica

Este proyecto consta de un backend en .NET 8 y un frontend en Angular 18, diseñado para gestionar las predicciones de ventas.

🔹 1. Configuración de la Base de Datos

Antes de ejecutar el sistema, es necesario configurar la base de datos ejecutando los siguientes scripts en SQL Server en el orden indicado:

1️⃣ Ejecutar el script 01_DBSetup.sql

Crea la base de datos y las tablas necesarias.

2️⃣ Ejecutar el script 02_Sp_Queries.sql

Configura el procedimiento almacenado para manejar las operaciones.

🔹 2. Configuración de la Cadena de Conexión

Después de configurar la base de datos, es necesario modificar la cadena de conexión en el archivo appsettings.json para apuntar a tu servidor local.

📌 Ubicación del archivo:

Server\Sales_Date_Prediction.API\appsettings.json

📌 Ejemplo de cómo se debe modificar la cadena de conexión (ConnectionStrings):

"ConnectionStrings": {
   "DefaultConnection": "Data Source=TU_SERVIDOR_SQL;Initial Catalog=StoreSample;Integrated Security=True;TrustServerCertificate=True;"
}

🚀 Reemplaza TU_SERVIDOR_SQL con el nombre de tu servidor SQL antes de continuar.

🔹 3. Ejecución del Backend (.NET)

Una vez configurada la base de datos y la cadena de conexión, es momento de ejecutar el backend.

📌 Ubicación del backend:

Server\Sales_Date_Prediction.API

▶️ Pasos para ejecutar el backend:

Abre una terminal en la carpeta Server.

Ejecuta el siguiente comando para iniciar el backend:

dotnet run --project Sales_Date_Prediction.API

Una vez iniciado, la API estará disponible en http://localhost:5149 o el puerto configurado.

🔹 4. Ejecución del Frontend (Angular 18)

Después de ejecutar la API, es necesario ejecutar el frontend que consume el backend.

📌 Ubicación del frontend:

Client

▶️ Pasos para ejecutar el frontend:

Abre una terminal en la carpeta Client.

Instala las dependencias necesarias con:

npm install

Inicia el servidor de desarrollo con:

ng serve

El frontend estará disponible en una ruta similar a esta: http://localhost:4200.

Nota: Asegúrate de que la URL de la API configurada en el archivo environment del frontend coincida con la dirección en la que se ejecuta el backend. Por defecto, la API se ejecuta en: http://localhost:5149 

Nota: Las ventanas fueron diseñadas siguiendo la misma estructura y apariencia solicitada en la prueba de referencia.

🔹 5. Ejecución del Javascript para la solución del Graficando con D3

Link: https://codepen.io/pen?template=PoVobyr