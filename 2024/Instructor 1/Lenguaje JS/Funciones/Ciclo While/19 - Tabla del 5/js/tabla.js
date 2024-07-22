/**
 * Función Tabla - Imprimir la tabla del 5
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function tabla(pNumero){
    let numero = pNumero
    let contar = 0;
    let mul = 1
    let resultado = ""
    while(contar < numero){
        contar = contar + 1;
        mul = numero * contar
        resultado += `${numero} x ${contar} = ${mul} \n`
    }
    return resultado
}

//Como Expresion
const tablaExpresion = function(pNumero){
    let numero = pNumero
    let contar = 0;
    let mul = 1
    let resultado = ""
    while(contar < numero){
        contar = contar + 1;
        mul = numero * contar
        resultado += `${numero} x ${contar} = ${mul} \n`
    }
    return resultado
}
