<?php

    include('valor.php');
    include('calcularNomina.php');

    // Obtener los datos JSON de la solicitud POST
    $input = json_decode(file_get_contents('php://input'), true);

    $diasTrabajadosRecibido = $input['diasTrabajadosEnviar'];
    $valorDiaRecibido = $input['valorDiaEnviar'];
    $edadPersonaRecibida = $input['edadPersonaEnviar'];

    $diasTrabjados = new ValoresNomina($diasTrabajadosRecibido);
    $valorDia = new ValoresNomina($valorDiaRecibido);
    $edadPersona = new ValoresNomina($edadPersonaRecibida);


    $nomina = new CalcularNomina($diasTrabjados, $valorDia, $edadPersona);

    $respuesta = [];

    $respuesta['sueldo'] = $nomina->calcularSueldo();
    $respuesta['subTransporte'] = $nomina->calcularSubsidioTransporte();
    $respuesta['pension'] = $nomina->calcularPension();
    $respuesta['salud'] = $nomina->calcularSalud();
    $respuesta['arl'] = $nomina->calcularARL();
    $respuesta['retencion'] = $nomina->calcularRetencion();
    $respuesta['extras'] = $nomina->calcularExtra();
    $respuesta['deducibles'] = $nomina->calcularDeducibles();
    $respuesta['sueldoTotal'] = $nomina->calcularSueldoTotal();
    

    header('Content-Type: application/json');
    echo json_encode($respuesta);

?>