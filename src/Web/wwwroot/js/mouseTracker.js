let mouseData = [];

function startTrackingMouse() {
    document.addEventListener('mousemove', (event) => {
        const timestamp = new Date();
        mouseData.push({
            T: timestamp.toISOString(),
            X: event.clientX,
            Y: event.clientY
        });
    });

    document.getElementById('sendData').addEventListener('click', () => {
        sendData(mouseData);
    });
}

function sendData(data) {
    fetch('/api/v1/MouseCoordinates', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                console.log('Данные успешно отправлены');
            } else {
                console.error('Ошибка при отправке данных');
            }
        })
        .catch(error => console.error('Ошибка:', error));
    
    mouseData = [];
}