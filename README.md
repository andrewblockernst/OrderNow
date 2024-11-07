# OrderNow

**Descripción del Proyecto:**

OrderNow es una aplicación diseñada para gestionar pedidos de comida de manera eficiente, utilizando una arquitectura de microservicios. Este proyecto implementa dos microservicios clave:

## Microservicios

### Stock Management Service

- Se encarga de la gestión de inventarios de productos, permitiendo agregar, actualizar y eliminar productos del stock.

- Garantiza que la disponibilidad de los productos esté siempre actualizada y disponible para el servicio de pedidos.

### Order Service

- Gestiona el ciclo de vida de los pedidos, permitiendo a los usuarios realizar pedidos de productos disponibles.

- Se encarga de recibir las solicitudes de pedido, procesarlas y actualizar el stock en consecuencia.

- Proporciona una interfaz RESTful para interactuar con otras aplicaciones y microservicios.

## Características Principales

- **Arquitectura basada en microservicios**: Permite escalabilidad y mantenimiento independiente de cada componente.

- **Integración entre microservicios**: A través de llamadas HTTP, asegurando la actualización del stock al realizar un pedido.

- **Documentación de la API**: Usando Swagger para facilitar la interacción con los servicios.

- **Gestión de errores y excepciones**: Asegura una experiencia de usuario fluida.

## Tecnologías Utilizadas

- **.NET Core**: Para el desarrollo de microservicios.

- **Entity Framework Core**: Para la gestión de datos.

- **SQL Server**: Como sistema de gestión de bases de datos.

## Instrucciones para Ejecutar

1. Clona el repositorio:

   ```bash
   git clone <url del repositorio>
   ```

2. Navega a la carpeta del servicio que deseas ejecutar.

3. Restaura las dependencias:

   ```bash
   dotnet restore
   ```

4. Ejecuta el servicio:

   ```bash
   dotnet run
   ```

5. Accede a la API a través de `http://localhost:<puerto>`.

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir al proyecto, por favor abre un issue o envía un pull request.

## Licencia

Este proyecto está bajo la licencia "BUBO's Company".
