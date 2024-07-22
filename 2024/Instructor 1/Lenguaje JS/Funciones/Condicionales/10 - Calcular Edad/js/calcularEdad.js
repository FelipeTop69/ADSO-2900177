/**
 * Función Calcular Edad - Calcular la edad de una persona e imprimir si es mayor de edad
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function mayorEdad(pFechaN, pYearActual){
    let fechaN = pFechaN;
    let yearActual = pYearActual
    let edad
    edad = yearActual - fechaN

    if(edad > 17){
        return "Es Mayor de Edad"
    }else{
        return "Es Menor de Edad"
    }
}

//Como Expresion
const mayorEdadExpresion = function(pFechaN, pYearActual){
    let fechaN = pFechaN;
    let yearActual = pYearActual
    let edad
    edad = yearActual - fechaN

    if(edad > 17){
        return "Es Mayor de Edad"
    }else{
        return "Es Menor de Edad"
    }
}
