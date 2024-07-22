/**
 * Funciones de los registros de la nomina
 * Autor: Ruben Felipe Tovar Aviles
 * 6 de junio del 2024
 */
function calcularSueldo(pValorD, pDiasT) {
    let valorD = pValorD;
    let diasT = pDiasT;
    let sueldo;

    sueldo = valorD * diasT;

    return sueldo;
}

function calcularSubsidioTransporte(pSueldo){
    const salarioM = 1300000;
    let sueldoCalculado = pSueldo;
    let subsidioT;

    if(sueldoCalculado < salarioM * 2){
        subsidioT = 114000;
    }else{
        subsidioT = 0;
    }

    return subsidioT;
}

function calcularPension(pSueldo){
    let sueldoCalculado = pSueldo;
    let pen;

    pen = sueldoCalculado * 0.16;

    return pen;
}

function calcularSalud(pSueldo){
    let sueldoCalculado = pSueldo;
    let salud ;

    salud = sueldoCalculado * 0.12;

    return salud;
}

function calcularARL(pSueldo){
    let sueldoCalculado = pSueldo;
    let arl;

    arl = sueldoCalculado * 0.052;

    return arl;
    
}


function calcularRetencion(pSueldo){
    const salarioM = 1300000;
    let sueldoCalculado = pSueldo;
    let retencion;
    if(sueldoCalculado < salarioM * 4){
        retencion = 0;
    }else{
        retencion = sueldoCalculado * 0.04;
    }

    return retencion
}

function calcularExtra(pSueldo) {
    let sueldoCalculado = pSueldo;
    let edadPersona = nomina[iteracion].edad;
    let extraPersona;

    if (edadPersona > 39 && edadPersona < 60) {
        extraPersona = sueldoCalculado * 0.06;

    } else if (edadPersona >= 60) {
        extraPersona = sueldoCalculado * 0.08;
    }
    else {
        extraPersona = 0;
    }
    return extraPersona;
}

function calcularDeducibles(pSueldo) {
    let sueldoCalculado = pSueldo;
    let deduciblePension;
    let deducibleSalud;
    let deducibleArl;
    let deducibleRetencion;
    let descuento;

    deduciblePension = calcularPension(sueldoCalculado);
    deducibleSalud = calcularSalud(sueldoCalculado);
    deducibleArl = calcularARL(sueldoCalculado);
    deducibleRetencion = calcularRetencion(sueldoCalculado);

    descuento = deduciblePension + deducibleSalud + deducibleArl + deducibleRetencion

    return descuento;
}



function calcularSueldoTotal(pSueldo) {
    let sueldoCalculado = pSueldo;
    let subsidioT;
    let deducibles
    let extraPersona
    let pago;

    subsidioT = calcularSubsidioTransporte(sueldoCalculado);
    deducibles = calcularDeducibles(sueldoCalculado);
    extraPersona = calcularExtra(sueldoCalculado);

    pago = (sueldoCalculado + subsidioT + extraPersona) - deducibles;

    return pago;
}

