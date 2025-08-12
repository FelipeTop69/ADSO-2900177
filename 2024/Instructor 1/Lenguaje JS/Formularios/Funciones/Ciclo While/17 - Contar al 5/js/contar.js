/**
 * Función Contador - Imprimir los numeros del 1 al 5
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function contador(pNumero){
    let numero = pNumero
    let contar = 0;
    let resultado = ""
    while(contar < numero){
        contar = contar + 1;
        resultado += `${contar}\n`
    }
    return resultado
}

//Como Expresion
const contadorExpresion = function(pNumero){
    let numero = pNumero
    let contar = -6;
    let resultado = ""
    while(contar < numero){
        contar = contar + 1;
        resultado += `${contar}\n`
    }
    return resultado
}
