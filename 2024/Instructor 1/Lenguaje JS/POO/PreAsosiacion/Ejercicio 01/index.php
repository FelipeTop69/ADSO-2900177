<?php
    include('php/saludo.php');
    $saludo = new Saludo();
    $error = '';  // Variable para almacenar el mensaje de error

    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        // Verificar si el campo mensaje está vacío
        if (!empty($_POST['mensaje'])) {
            $mensajeInput = trim($_POST['mensaje']); // Eliminamos espacios en blanco al inicio o final
            $saludo->setSaludar($mensajeInput);
        } else {
            // Mensaje de error si el campo está vacío
            $error = 'Por favor, ingrese un saludo.';
        }
    }

    $mensaje = $saludo->getSaludar();
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Saludo</title>
</head>
<body>

    <form method="POST" action="index.php">
        <label for="txtMensaje">Introduce tu saludo:</label>
        <input type="text" id="txtMensaje" name="mensaje" required>
        <button type="submit">Enviar</button>
    </form>

    <!-- Mostrar el mensaje de error si hay alguno -->
    <?php if ($error): ?>
        <p style="color: red;"><?php echo $error; ?></p>
    <?php endif; ?>

    <!-- Mostrar el saludo solo si está disponible -->
    <p>Saludo: <?php echo $mensaje ? $mensaje : "Introduce un mensaje para mostrar"; ?></p>

</body>
</html>