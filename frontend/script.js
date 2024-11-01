document.getElementById('orderButton').addEventListener('click', async () => {
    // Obtener los valores ingresados en el formulario
    const productIds = document.getElementById('productIds').value;
    const quantities = document.getElementById('quantities').value;

    // Limpiar el mensaje de respuesta previo
    const responseMessage = document.getElementById('responseMessage');
    responseMessage.innerHTML = '';

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
        const response = await fetch("http://localhost:5056/api/orders", {
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
        // Mostrar mensaje de éxito
        responseMessage.innerHTML = `Orden realizada con éxito! ID de Orden: ${data.orderId}`;
        responseMessage.style.color = 'green';
    } catch (error) {
        // Mostrar mensaje de error
        responseMessage.innerHTML = `Error: ${error.message}`;
        responseMessage.style.color = 'red';
    }
});
