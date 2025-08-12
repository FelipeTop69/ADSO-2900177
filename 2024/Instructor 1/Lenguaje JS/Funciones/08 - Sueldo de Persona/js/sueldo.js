/**
 * Función Sueldo - Calcular el sueldo de un trabajador con deducciones de pensión, salud y ARL. (pensión = 0.16, salud = 0.12, ARL = 0.052)
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */


//Como Parametro
function calcularSueldo(pValorD, pDiasT){
    let valorD = pValorD;
    let diasT = pDiasT;
    let sueldo
    sueldo = valorD * diasT;
    return sueldo;
}

function calcularPension(pValorD, pDiasT){
    let pen;
    pen = calcularSueldo(pValorD, pDiasT) * 0.16;
    return pen;
}

function calcularSalud(pValorD, pDiasT){
    let salud;
    salud = calcularSueldo(pValorD, pDiasT) * 0.12;
    return salud;
}

function calcularARL(pValorD, pDiasT){
    let arl;
    arl = calcularSueldo(pValorD, pDiasT) * 0.16;
    return arl;
}

function calcularSueldoTotal(pValorD, pDiasT) {
    let sueldoCalculado = calcularSueldoExpresion(pValorD, pDiasT); 
    let pen = calcularPension(pValorD, pDiasT);
    let salud = calcularSalud(pValorD, pDiasT);
    let arl = calcularARL(pValorD, pDiasT);
    let desc = pen + salud + arl;
    let sueldoTotal = sueldoCalculado - desc;
    return sueldoTotal;
}


//Como Expresion
const calcularSueldoExpresion = function(pValorD, pDiasT){
    let valorD = pValorD;
    let diasT = pDiasT;
    let sueldo;
    sueldo = valorD * diasT;
    return sueldo;
}

const calcularPensionExpresion = function(pValorD, pDiasT){
    let pen;
    pen = calcularSueldo(pValorD,pDiasT) * 0.16;
    return pen;
}

const calcularSaludExpresion = function(pValorD, pDiasT){
    let salud;
    salud = calcularSueldo(pValorD,pDiasT) * 0.12;
    return salud;
}

const calcularARLExpresion = function(pValorD, pDiasT){
    let arl;
    arl = calcularSueldo(pValorD,pDiasT) * 0.16;
    return arl;
}

const calcularSueldoTotalExpresion = function(pValorD, pDiasT) {
    let sueldoCalculado = calcularSueldoExpresion(pValorD, pDiasT); 
    let pen = calcularPensionExpresion(pValorD, pDiasT);
    let salud = calcularSaludExpresion(pValorD, pDiasT);
    let arl = calcularARLExpresion(pValorD, pDiasT);
    let desc = pen + salud + arl;
    let sueldoTotal = sueldoCalculado - desc;
    return sueldoTotal;
}