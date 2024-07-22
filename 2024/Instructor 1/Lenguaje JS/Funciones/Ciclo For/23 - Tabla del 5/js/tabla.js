/**
 * Función Tabla - Imprimir la tabla del 5
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function tabla(pNumero){
    let numero = pNumero
    let mul = 1
    let resultado = "" 
    for(let contar = 1; contar <= numero; contar++){
        mul = numero * contar;
        resultado += `${numero} x ${contar} = ${mul} \n`
    }
    return resultado
}

//Como Expresion
const tablaExpresion = function(pNumero){
    let numero = pNumero
    let mul = 1
    let resultado = "" 
    for(let contar = 1; contar <= numero; contar++){
        mul = numero * contar;
        resultado += `${numero} x ${contar} = ${mul} \n`
    }
    return resultado
}
