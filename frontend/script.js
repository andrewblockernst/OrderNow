document.getElementById('orderButton').addEventListener('click', async () => {
    // Obtener los valores ingresados en el formulario
    const productIds = document.getElementById('productIds').value;
    const quantities = document.getElementById('quantities').value;

    // Limpiar el mensaje de respuesta previo
    const responseMessage = document.getElementById('responseMessage');
    const loadingMessage = document.getElementById('loading');
    responseMessage.innerHTML = '';
    loadingMessage.style.display = 'none'; // Ocultar el mensaje de carga

    // Validar que los campos no estén vacíos
    if (!productIds || !quantities) {
        responseMessage.innerHTML = 'Por favor, completa todos los campos.';
        responseMessage.style.color = 'red';
        return;
    }

    // Crear el objeto de la orden
    const orderData = {
        productIds: productIds.split(',').map(id => id.trim()), // Procesar los IDs de los productos
        quantities: quantities.split(',').map(q => parseInt(q.trim(), 10)), // Procesar las cantidades
    };

    // Configurar la solicitud a la API
    try {
        loadingMessage.style.display = 'block'; // Mostrar el mensaje de carga

        const response = await fetch('http://localhost:5056/api/orders', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderData)
        });

        // Manejar respuestas no exitosas
        if (!response.ok) {
            const errorResponse = await response.json();
            throw new Error(errorResponse.message || 'Error al realizar el pedido');
        }

        // Leer la respuesta JSON
        const data = await response.json();

        // Esperar 3 segundos antes de mostrar el estado de la orden
        setTimeout(() => {
            responseMessage.innerHTML = `Orden realizada con éxito! ID de Orden: ${data.orderId}`;
            responseMessage.style.color = 'green';
            loadingMessage.style.display = 'none'; // Ocultar el mensaje de carga
        }, 3000);
        
    } catch (error) {
        // Mostrar mensaje de error después de 3 segundos
        setTimeout(() => {
            responseMessage.innerHTML = `Error: ${error.message}`;
            responseMessage.style.color = 'red';
            loadingMessage.style.display = 'none'; // Ocultar el mensaje de carga
        }, 3000);
    }
});
