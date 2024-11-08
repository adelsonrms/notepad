<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Erro na Aplicação</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f9f9f9;
            color: #333;
        }
        .error-container {
            max-width: 600px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .details-hidden {
            display: none;
        }
        .show-details {
            cursor: pointer;
            color: #007bff;
            border: none;
            background: none;
            padding: 0;
            font-size: 0.9em;
        }
        button {
            margin-top: 20px;
            padding: 10px 15px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <div class="error-container">
        <h1>Erro na Aplicação</h1>
        <p><strong>Status:</strong> <span id="statusCode">500</span></p>
        <p><strong>Mensagem:</strong> <span id="message">Ocorreu um erro inesperado. Tente novamente mais tarde.</span></p>
        <button class="show-details" onclick="toggleDetails()">Ver detalhes técnicos</button>
        <div class="details-hidden" id="technicalDetails">
            <p><strong>Detalhes Técnicos:</strong></p>
            <pre id="technicalMessage">Exception stack trace or detailed info here...</pre>
        </div>
        <button onclick="sendErrorReport()">Enviar para Suporte</button>
    </div>

    <script>
        function toggleDetails() {
            const details = document.getElementById('technicalDetails');
            if (details.style.display === 'block') {
                details.style.display = 'none';
            } else {
                details.style.display = 'block';
            }
        }

        function sendErrorReport() {
            const statusCode = document.getElementById('statusCode').textContent;
            const message = document.getElementById('message').textContent;
            const technicalMessage = document.getElementById('technicalMessage').textContent;

            const errorReport = {
                statusCode,
                message,
                technicalMessage
            };

            // Simular envio de dados (exemplo usando fetch)
            fetch('/api/report-error', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(errorReport)
            })
            .then(response => {
                if (response.ok) {
                    alert('Erro reportado com sucesso.');
                } else {
                    alert('Erro ao enviar o relatório. Tente novamente mais tarde.');
                }
            })
            .catch(() => {
                alert('Falha na conexão. Verifique sua internet e tente novamente.');
            });
        }
    </script>
</body>
</html>
