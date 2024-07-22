/**
 * Función Sueldo - Calcular el sueldo de una persona todo incluido
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function calcularSueldo(pValorD, pDiasT){
    let valorD = pValorD;
    let diasT = pDiasT;
    let sueldo;
    sueldo = valorD * diasT;
    return sueldo;
}

function calcularSubsidioTransporte(pValorD, pDiasT, pSalarioM){
    let salarioM = pSalarioM
    let sueldoCalculado = calcularSueldo(pValorD, pDiasT)
    let subsidioT
    // let subsidioT = calcularSueldo(43333, 30) < salarioM * 2 ? 114000 : 0;
    if(sueldoCalculado < salarioM * 2){
        subsidioT = 114000;
    }else{
        subsidioT = 0;
    }
    return subsidioT
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
    arl = calcularSueldo(pValorD, pDiasT) * 0.052;
    return arl;
}

function calcularRetencion(pValorD, pDiasT, pSalarioM){
    let salarioM = pSalarioM
    let sueldoCalculado = calcularSueldo(pValorD, pDiasT)
    let retencion
    // let retencion = calcularSueldo(43333, 30) < salarioM * 4 ? 0 : sueldoP * 0.04;
    if(sueldoCalculado < salarioM * 4){
        retencion = 0;
    }else{
        retencion = sueldoCalculado * 0.04;
    }
    return retencion
}

function calcularSueldoTotal(pValorD, pDiasT, pSalarioM) {
    let sueldoCalculado = calcularSueldo(pValorD, pDiasT); 
    let subsidioT = calcularSubsidioTransporte(pValorD, pDiasT, pSalarioM)
    let pen = calcularPension(pValorD, pDiasT);
    let salud = calcularSalud(pValorD, pDiasT);
    let arl = calcularARL(pValorD, pDiasT);
    let retencion = calcularRetencion(pValorD, pDiasT, pSalarioM)
    let desc = pen + salud + arl;
    let sueldoTotal = ((sueldoCalculado + subsidioT) - (retencion + desc)).toFixed(0)
    return sueldoTotal;
}

//Como Expresion
const calcularSueldoExpresion = function(pValorD, pDiasT){
    let valorD = pValorD;
    let diasT = pDiasT;
    let sueldo
    sueldo = valorD * diasT;
    return sueldo;
}

const calcularSubsidioTransporteExpresion = function(pValorD, pDiasT, pSalarioM){
    let salarioM = pSalarioM
    let sueldoCalculado = calcularSueldo(pValorD, pDiasT)
    let subsidioT
    // let subsidioT = calcularSueldoExpresion(180000, 30) < salarioM * 2 ? 114000 : 0;
    if(sueldoCalculado < salarioM * 2){
        subsidioT = 114000;
    }else{
        subsidioT = 0;
    }
    return subsidioT
}

const calcularPensionExpresion = function(pValorD, pDiasT){
    let pen;
    pen = calcularSueldo(pValorD, pDiasT) * 0.16;
    return pen;
}

const calcularSaludExpresion = function(pValorD, pDiasT){
    let salud;
    salud = calcularSueldo(pValorD, pDiasT) * 0.12;
    return salud;
}

const calcularARLExpresion = function(pValorD, pDiasT){
    let arl;
    arl = calcularSueldo(pValorD, pDiasT) * 0.052;
    return arl;
}

const calcularRetencionExpresion = function(pValorD, pDiasT, pSalarioM){
    let salarioM = pSalarioM
    let sueldoCalculado = calcularSueldo(pValorD, pDiasT)
    let retencion
    // let retencion = calcularSueldoExpresion(180000, 30) < salarioM * 4 ? 0 : calcularSueldoExpresion(180000, 30) * 0.04;
    if(sueldoCalculado < salarioM * 4){
        retencion = 0;
    }else{
        retencion = sueldoCalculado * 0.04;
    }
    return retencion
}

const calcularSueldoTotalExpresion = function(pValorD, pDiasT, pSalarioM) {
    let sueldoCalculado = calcularSueldoExpresion(pValorD, pDiasT); 
    let subsidioT = calcularSubsidioTransporteExpresion(pValorD, pDiasT, pSalarioM)
    let pen = calcularPensionExpresion(pValorD, pDiasT);
    let salud = calcularSaludExpresion(pValorD, pDiasT);
    let arl = calcularARLExpresion(pValorD, pDiasT);
    let retencion = calcularRetencionExpresion(pValorD, pDiasT, pSalarioM)
    let desc = pen + salud + arl;
    let sueldoTotal = ((sueldoCalculado + subsidioT) - (retencion + desc)).toFixed(0)
    return sueldoTotal;
}
