<?php
    include ('php/numero.php');
    include ('php/operaciones.php');
        $numeroUnoRecibido = 0;
        $numeroDosRecibido = 0;
        
        if ($_SERVER["REQUEST_METHOD"] == "POST") {
            $numeroUnoRecibido = $_POST['numeroUno'];
            $numeroDosRecibido = $_POST['numeroDos'];
            
        }  
    
        $numeroUno = new Numero($numeroUnoRecibido);
        $numeroDos = new Numero($numeroDosRecibido);
        $operaciones = new Operaciones($numeroUno, $numeroDos);


        $suma = $operaciones -> sumar();
        $resta = $operaciones -> restar();
        $multiplicacion = $operaciones -> multiplicar();
        $division = $operaciones -> dividir();


        
    
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Nomina</title>
</head>
<body>
    <form method="POST" action="index.php">
        <label for="txtNumeroUno">Ingresa el primer Numero:</label>
        <input type="number" id="txtNumeroUno" name="numeroUno" required>

        <label for="txtNumeroDos">Ingresa el segundo Numero:</label>
        <input type="number" id="txtNumeroDos" name="numeroDos" required>
        <button type="submit">Enviar</button>
    </form>

    <?php

        echo "Suma: " . $suma . "<br>";
        echo "Resta: " . $resta . "<br>";
        echo "Multiplicacion: " . $multiplicacion . "<br>";
        echo "Division: " . $division . "<br>";
    
    ?>

</body>
</html>