<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <?php 
    
    include('php/areaFiguras.php');
    $calcular->lado = 2;
    $calcular->areaCuadrado();
    echo "Área del cuadrado: " . $calcular->area . "</br>";
    
    $calcular->base = 20;
    $calcular->altura = 10;
    $calcular->areaRectangulo();
    echo "Área del rectángulo: " . $calcular->area . "</br>";
    
    $calcular->base = 6;
    $calcular->altura = 8;
    $calcular->areaTriangulo();
    echo "Área del triángulo: " . $calcular->area."</br>";
    
    ?>

</body>

</html>