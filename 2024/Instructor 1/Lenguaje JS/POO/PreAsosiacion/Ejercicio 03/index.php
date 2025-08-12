<?php
    include ('php/nomina.php');
    $nomina = new nomina();
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $diasTrabajados = $_POST['diasTrabajados'];
        $nomina -> setDiasTrabajados($diasTrabajados);

        $valorDia = $_POST['valorDia'];
        $nomina -> setValorDia($valorDia);

        $edadPersona = $_POST['edadPersona'];
        $nomina -> setEdadPersona($edadPersona);
    }
    $diasTrabajados = $nomina -> getDiasTrabajados();
    $valorDia = $nomina -> getValorDia();
    $edadPersona = $nomina -> getEdadPersona();

    $calcularSueldo = new calcularNomina();
    $sueldo = $calcularSueldo -> calcularSueldo($nomina);
    $subTransporte = $calcularSueldo -> calcularSubsidioTransporte();
    $pension = $calcularSueldo -> calcularPension();
    $salud = $calcularSueldo -> calcularSalud();
    $arl = $calcularSueldo -> calcularARL();
    $retencion = $calcularSueldo -> calcularRetencion();
    $extra = $calcularSueldo -> calcularExtra($nomina);
    $deducibles = $calcularSueldo -> calcularDeducibles();
    $sueldoTotal = $calcularSueldo -> calcularSueldoTotal();

    

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
        <label for="txtDiasTrabajados">Ingresa los dias trabajados:</label>
        <input type="number" id="txtDiasTrabajados" name="diasTrabajados" required>

        <label for="txtValorDia">Ingresa el valor del dia:</label>
        <input type="number" id="txtValorDia" name="valorDia" required>

        <label for="txtEdadPersona">Ingresa su edad:</label>
        <input type="number" id="txtEdadPersona" name="edadPersona" required>
        <button type="submit">Enviar</button>
    </form>

    <?php
        
        echo "Sueldo bruto: " . $sueldo . "<br>";
        echo "Subsidio de transporte: " . $subTransporte . "<br>";
        echo "Pensión: " . $pension . "<br>";
        echo "Salud: " . $salud . "<br>";
        echo "ARL: " . $arl . "<br>";
        echo "Retención: " . $retencion . "<br>";
        echo "Extras: " . $extra . "<br>";
        echo "Deducibles: " . $deducibles . "<br>";
        echo "Sueldo total: " . $sueldoTotal . "<br>";
    
    ?>

</body>
</html>