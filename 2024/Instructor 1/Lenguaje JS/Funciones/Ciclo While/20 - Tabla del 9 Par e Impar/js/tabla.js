/**
 * Función Tabla - Imprimir la tabla del 9 con los números pares e impares
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function tabla(pNumero){
    let numero = pNumero
    let contar = 0;
    let mul = 1
    resultado = ""
    while(contar < 5){
        contar = contar + 1;
        mul = numero * contar
        if(mul % 2 == 0){
        resultado += `${numero} x ${contar} = ${mul} Es Par \n`
        }else{
        resultado += `${numero} x ${contar} = ${mul} Es Impar \n`
        }
    } 
    return resultado
}

//Como Expresion
const tablaExpresion = function(pNumero){
    let numero = pNumero
    let contar = 0;
    let mul = 1
    resultado = ""
    while(contar < 5){
        contar = contar + 1;
        mul = numero * contar
        if(mul % 2 == 0){
        resultado += `${numero} x ${contar} = ${mul} Es Par \n`
        }else{
        resultado += `${numero} x ${contar} = ${mul} Es Impar \n`
        }
    }
    return resultado
}
