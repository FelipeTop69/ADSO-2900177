<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Nomina</title>
</head>

<body>
    <?php 
    include('php/nomina.php');
    
    $nomina->valorDia = 200000;
    $nomina->diasTrabajados = 30;
    $nomina->edad = 45;
    
    $nomina->calcularSueldo();
    $nomina->calcularSubsidioTransporte();
    $nomina->calcularPension();
    $nomina->calcularSalud();
    $nomina->calcularARL();
    $nomina->calcularRetencion();
    $nomina->calcularExtra();
    $nomina->calcularDeducibles();
    $nomina->calcularSueldoTotal();
    
    echo "Sueldo bruto: " . $nomina->sueldo . "<br>";
    echo "Subsidio de transporte: " . $nomina->subsidioTransporte . "<br>";
    echo "Pensión: " . $nomina->pension . "<br>";
    echo "Salud: " . $nomina->salud . "<br>";
    echo "ARL: " . $nomina->arl . "<br>";
    echo "Retención: " . $nomina->retencion . "<br>";
    echo "Extras: " . $nomina->extra . "<br>";
    echo "Deducibles: " . $nomina->deducibles . "<br>";
    echo "Sueldo total: " . $nomina-> sueldoTotal . "<br>";

    
    ?>

</body>

</html>