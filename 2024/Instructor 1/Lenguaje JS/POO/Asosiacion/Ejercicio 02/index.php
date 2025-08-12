<?php
    include('php/calcularArea.php');

    $lado = new ValorMedida(0);
    $baseRectangulo = new ValorMedida(0);
    $alturaRectangulo = new ValorMedida(0);
    $baseTriangulo = new ValorMedida(0);
    $alturaTriangulo = new ValorMedida(0);

    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $lado->setValor($_POST['lado']);

        $baseRectangulo->setValor($_POST['baseRectangulo']);
        $alturaRectangulo->setValor($_POST['alturaRectangulo']);
        
        $baseTriangulo->setValor($_POST['baseTriangulo']);
        $alturaTriangulo->setValor($_POST['alturaTriangulo']);
    }

    // Area Cuadrado
    $calcularAreaCuadrado = new AreaFiguras($lado, $lado, $lado);
    $areaCuadrado = $calcularAreaCuadrado->areaCuadrado();

    // Area Rectangulo
    $calcularAreaRectangulo = new AreaFiguras($lado, $baseRectangulo, $alturaRectangulo);
    $areaRectangulo = $calcularAreaRectangulo->areaRectangulo();

    // Area Triangulo
    $calcularAreaTriangulo = new AreaFiguras($lado, $baseTriangulo, $alturaTriangulo);
    $areaTriangulo = $calcularAreaTriangulo->areaTriangulo();
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Calcular Área de Figuras</title>
</head>
<body>

    <form method="POST" action="index.php">
        <label for="lado">Lado del cuadrado:</label>
        <input type="number" id="lado" name="lado" required><br><br>

        <label for="baseRectangulo">Base del rectángulo:</label>
        <input type="number" id="baseRectangulo" name="baseRectangulo" required>

        <label for="alturaRectangulo">Altura del rectángulo:</label>
        <input type="number" id="alturaRectangulo" name="alturaRectangulo" required><br><br>

        <label for="baseTriangulo">Base del triángulo:</label>
        <input type="number" id="baseTriangulo" name="baseTriangulo" required>

        <label for="alturaTriangulo">Altura del triángulo:</label>
        <input type="number" id="alturaTriangulo" name="alturaTriangulo" required><br><br>

        <button type="submit">Calcular Areas</button>
    </form>

    <h3>Resultados:</h3>
    <p>Área del Cuadrado: <?php echo $areaCuadrado; ?></p>
    <p>Área del Rectángulo: <?php echo $areaRectangulo; ?></p>
    <p>Área del Triángulo: <?php echo $areaTriangulo; ?></p>

</body>
</html>
