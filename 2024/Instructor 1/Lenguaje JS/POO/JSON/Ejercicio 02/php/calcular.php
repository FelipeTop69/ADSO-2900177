<?php

    include('medidaFiguras.php');
    include('calcularArea.php');

    $lado = new ValorMedida(0);

    $baseR = new ValorMedida(0);
    $alturaR = new ValorMedida(0);

    $baseT = new ValorMedida(0);
    $alturaT = new ValorMedida(0);

    // Obtener los datos JSON de la solicitud POST
    $input = json_decode(file_get_contents('php://input'), true);
    $lado->setValor($input['ladoEnviar']);

    $baseR->setValor($input['baseRectanguloEnviar']);
    $alturaR->setValor($input['alturaRectanguloEnviar']);

    $baseT->setValor($input['baseTrianguloEnviar']);
    $alturaT->setValor($input['alturaTrianguloEnviar']);

     // Area Cuadrado
    $calcularAreaCuadrado = new AreaFiguras($lado, $lado, $lado);
    $areaCuadrado = $calcularAreaCuadrado->areaCuadrado();

    // Area Rectangulo
    $calcularAreaRectangulo = new AreaFiguras(null, $baseR, $alturaR);
    $areaRectangulo = $calcularAreaRectangulo->areaRectangulo();

    // Area Triangulo
    $calcularAreaTriangulo = new AreaFiguras(null, $baseT, $alturaT);
    $areaTriangulo = $calcularAreaTriangulo->areaTriangulo();

    $respuesta = [];

    $respuesta['cuadrado'] = $calcularAreaCuadrado->areaCuadrado();
    $respuesta['rectangulo'] = $calcularAreaRectangulo->areaRectangulo();
    $respuesta['triangulo'] = $calcularAreaTriangulo->areaTriangulo();

    header('Content-Type: application/json');
    echo json_encode($respuesta);

?>