/**
 * Función Promedio - Calcular el promedio de notas y demas
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function calcularSumaPorcentaje(pNota1, pNota2, pNota3,){
    let nota1 = pNota1
    let nota2 = pNota2
    let nota3 = pNota3

    let porce1 = nota1 * 0.21
    let porce2 = nota2 * 0.35
    let porce3 = nota3 * 0.45

    let sumPorc = porce1 + porce2 + porce3
    return sumPorc

}

function validarNota(pNota1, pNota2, pNota3){
    let sumPorc = calcularSumaPorcentaje(pNota1, pNota2, pNota3)
    if(sumPorc > 4.5){
        return "El porcentaje de notas es superior" 
    }else if (sumPorc <= 4.5 && sumPorc > 3.5){
        return "El porcentaje de nota es buena" 
    }else if (sumPorc <= 3.5 && sumPorc >= 3.0){
        return "El porcentaje de nota es media" 
    }else{
        return "El porcentaje de nota es mala" 
    }
}

//Como Expresion
const calcularSumaPorcentajeExpresion = function(pNota1, pNota2, pNota3,){
    let nota1 = pNota1
    let nota2 = pNota2
    let nota3 = pNota3

    let porce1 = nota1 * 0.21
    let porce2 = nota2 * 0.35
    let porce3 = nota3 * 0.45

    let sumPorc = porce1 + porce2 + porce3
    return sumPorc

}

const validarNotaExpresion = function(pNota1, pNota2, pNota3){
    let sumPorc = calcularSumaPorcentajeExpresion(pNota1, pNota2, pNota3)
    if(sumPorc > 4.5){
        return "El porcentaje de notas es superior" 
    }else if (sumPorc <= 4.5 && sumPorc > 3.5){
        return "El porcentaje de nota es buena" 
    }else if (sumPorc <= 3.5 && sumPorc >= 3.0){
        return "El porcentaje de nota es media" 
    }else{
        return "El porcentaje de nota es mala" 
    }
}
