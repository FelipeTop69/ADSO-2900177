<?php
    include('php/saludo.php');
    $saludo = new Saludo();

    // Si deseas iniciar con un mensaje por defecto
    $mensaje = $saludo->getSaludar();
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Saludo en tiempo real</title>
    <script>
        function actualizarSaludo() {
            const inputMensaje = document.getElementById("txtMensaje").value;
            const outputMensaje = document.getElementById("mensajeMostrado");
            
            // Si el campo está vacío, mostramos un mensaje por defecto
            if (inputMensaje.trim() === "") {
                outputMensaje.innerHTML = "Introduce un mensaje para mostrar";
            } else {
                outputMensaje.innerHTML = inputMensaje;
            }
        }
    </script>
</head>
<body>

    <label for="txtMensaje">Introduce tu saludo:</label>
    <input type="text" id="txtMensaje" onkeyup="actualizarSaludo()" placeholder="Escribe un saludo">
    
    <!-- Mostrar el saludo -->
    <p>Saludo: <span id="mensajeMostrado">Introduce un mensaje para mostrar</span></p>

</body>
</html>
