/**
 * Función Mayor de Edad - Calcular la edad de una persona e imprimir si es mayor o menor de edad y calcular el promedio de edades
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function mayorEdadUno(pFechaN1, pYearActual1){
    let fechaN1 = pFechaN1;
    let yearActual1 = pYearActual1;
    let edad1 = yearActual1 - fechaN1;
    let mensaje = (edad1 > 17) ? "Es Mayor de edad" : "Es Menor de edad";

    return { texto: mensaje, edad: edad1 }
}

function mayorEdadDos(pFechaN2, pYearActual2){
    let fechaN2 = pFechaN2;
    let yearActual2 = pYearActual2;
    let edad2 = yearActual2 - fechaN2;
    let mensaje = (edad2 > 17) ? "Es Mayor de edad" : "Es Menor de edad";

    return { texto: mensaje, edad: edad2 }
}

function mayorEdadTres(pFechaN3, pYearActual3){
    let fechaN3 = pFechaN3;
    let yearActual3 = pYearActual3;
    let edad3 = yearActual3 - fechaN3;
    let mensaje = (edad3 > 17) ? "Es Mayor de edad" : "Es Menor de edad";

    return { texto: mensaje, edad: edad3 }
}

function promedioEdades(pFechaN1, pYearActual1, pFechaN2, pYearActual2, pFechaN3, pYearActual3){
    let edad1 = mayorEdadUno(pFechaN1, pYearActual1).edad;
    let edad2 = mayorEdadDos(pFechaN2, pYearActual2).edad;
    let edad3 = mayorEdadTres(pFechaN3, pYearActual3).edad;
    
    let prom = (edad1 + edad2 + edad3) / 3;

    if(prom > 17){
        return "El promedio es Mayor de Edad: " + prom.toFixed(0)
    }else{
        return "El promedio es Menor de Edad: " + prom.toFixed(0)
    }
}

//Como Expresion
const mayorEdadUnoExpresion = function(pFechaN1, pYearActual1){
    let fechaN1 = pFechaN1;
    let yearActual1 = pYearActual1;
    let edad1 = yearActual1 - fechaN1;
    let mensaje = (edad1 > 17) ? "Es Mayor de edad" : "Es Menor de edad";

    return { texto: mensaje, edad: edad1 }
}

const mayorEdadDosExpresion = function(pFechaN2, pYearActual2){
    let fechaN2 = pFechaN2;
    let yearActual2 = pYearActual2;
    let edad2 = yearActual2 - fechaN2;
    let mensaje = (edad2 > 17) ? "Es Mayor de edad" : "Es Menor de edad";

    return { texto: mensaje, edad: edad2 }
}

const mayorEdadTresExpresion = function(pFechaN3, pYearActual3){
    let fechaN3 = pFechaN3;
    let yearActual3 = pYearActual3;
    let edad3 = yearActual3 - fechaN3;
    let mensaje = (edad3 > 17) ? "Es Mayor de edad" : "Es Menor de edad";

    return { texto: mensaje, edad: edad3 }
}

const promedioEdadesExpresion = function(pFechaN1, pYearActual1, pFechaN2, pYearActual2, pFechaN3, pYearActual3){
    let edad1 = mayorEdadUnoExpresion(pFechaN1, pYearActual1).edad;
    let edad2 = mayorEdadDosExpresion(pFechaN2, pYearActual2).edad;
    let edad3 = mayorEdadTresExpresion(pFechaN3, pYearActual3).edad;
    
    let prom = (edad1 + edad2 + edad3) / 3;

    if(prom > 17){
        return "El promedio es Mayor de Edad: " + prom.toFixed(0)
    }else{
        return "El promedio es Menor de Edad: " + prom.toFixed(0)
    }
}