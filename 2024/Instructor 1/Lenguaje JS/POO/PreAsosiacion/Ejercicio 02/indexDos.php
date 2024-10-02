<?php
    include ('php/operacionesDos.php');
    $operacion = new operaciones();
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $numeroUno = $_POST['numeroUno'];
        $operacion -> setNumeroUno($numeroUno);

        $numeroDos = $_POST['numeroDos'];
        $operacion -> setNumeroDos($numeroDos);
    }
    $numeroUno = $operacion -> getNumeroUno();
    $numeroDos = $operacion -> getNumeroDos();

    $control = new controlOperaciones();
    $suma = $control -> sumar($numeroUno, $numeroDos);
    $resta = $control -> restar($numeroUno, $numeroDos);
    $division = $control -> dividir($numeroUno, $numeroDos);
    $multiplicacion = $control -> multiplicar($numeroUno, $numeroDos);

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Operaciones</title>
</head>
<body>
    <form method="POST" action="indexDos.php">
        <label for="txtNumeroUno">Ingresa el primer número:</label>
        <input type="text" id="txtNumeroUno" name="numeroUno" required>

        <label for="txtNumeroDos">Ingresa el segundo número</label>
        <input type="text" id="txtNumeroDos" name="numeroDos" required>
        <button type="submit">Enviar</button>
    </form>

    <p>Suma: <?php echo $suma; ?></p>
    <p>Resta: <?php echo $resta; ?></p>
    <p>Multiplicacion: <?php echo $multiplicacion; ?></p>
    <p>Division: <?php echo $division; ?></p>

</body>
</html>