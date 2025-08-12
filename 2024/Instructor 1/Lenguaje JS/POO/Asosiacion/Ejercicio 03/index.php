<?php
    include ('php/valor.php');
    include ('php/nomina.php');

    $diasTrabajadosRecibido = 0;
    $valorDiaRecibido = 0;
    $edadPersonaRecibida = 0;
    
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $diasTrabajadosRecibido = $_POST['diasTrabajados'];
        $valorDiaRecibido = $_POST['valorDia'];
        $edadPersonaRecibida = $_POST['edadPersona'];
    }

    $diasTrabjados = new ValoresNomina($diasTrabajadosRecibido);
    $valorDia = new ValoresNomina($valorDiaRecibido);
    $edadPersona = new ValoresNomina($edadPersonaRecibida);

    $nomina = new CalcularNomina($diasTrabjados, $valorDia, $edadPersona);
    $sueldo = $nomina -> calcularSueldo();
    $subTransporte = $nomina -> calcularSubsidioTransporte();
    $pension = $nomina -> calcularPension();
    $salud = $nomina -> calcularSalud();
    $arl = $nomina -> calcularARL();
    $retencion = $nomina -> calcularRetencion();
    $extra = $nomina -> calcularExtra();
    $deducibles = $nomina -> calcularDeducibles();
    $sueldoTotal = $nomina -> calcularSueldoTotal();

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Nomina</title>
</head>
<body>
    <form method="POST" action="" >
        <label for="txtDiasTrabajados">Ingresa los dias trabajados:</label>
        <input type="number" id="txtDiasTrabajados" name="diasTrabajados" required>

        <label for="txtValorDia">Ingresa el valor del dia:</label>
        <input type="number" id="txtValorDia" name="valorDia" required>

        <label for="txtEdadPersona">Ingresa su edad:</label>
        <input type="number" id="txtEdadPersona" name="edadPersona" required>
        <button type="submit">Enviar</button>
    </form>

    <?php
        echo "Sueldoo: " . $sueldo . "<br>";
        echo "Subsidio de Transporte: " . $subTransporte . "<br>";
        echo "Pension: " . $pension . "<br>";
        echo "Salud: " . $salud . "<br>";
        echo "ARL: " . $arl . "<br>";
        echo "Retencion: " . $retencion . "<br>";
        echo "Extras: " . $extra . "<br>";
        echo "Deducibles (pension, salud, ARL): " . $deducibles . "<br>";
        echo "Sueldo Total: " . $sueldoTotal . "<br>";
    ?>
</body>
</html>