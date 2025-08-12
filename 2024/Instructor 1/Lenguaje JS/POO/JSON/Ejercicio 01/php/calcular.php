<?php

    include('numero.php');
    include('operaciones.php');
    
    // Obtener los datos JSON de la solicitud POST
    $input = json_decode(file_get_contents('php://input'), true);

    $numeroUno = new Numero($input['numeroUnoEnviar']);
    $numeroDos = new Numero($input['numeroDosEnviar']);

    $operaciones = new Operaciones($numeroUno, $numeroDos);

    $respuesta = [];

    $respuesta['suma'] = $operaciones -> sumar();
    $respuesta['resta'] = $operaciones -> restar();
    $respuesta['multiplicacion'] = $operaciones -> multiplicar();
    $respuesta['division'] = $operaciones -> dividir();

    header('Content-Type: application/json');
    echo json_encode($respuesta)

?>