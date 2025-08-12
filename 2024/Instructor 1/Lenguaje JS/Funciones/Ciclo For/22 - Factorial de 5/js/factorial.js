/**
 * Función Factorial - Imprimir el factorial de 5
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function factorial(pNumero){
    let numero = pNumero
    let fac = 1
    for(let contar = 1; contar <= numero; contar++){
        fac = fac * contar;
        
    }
    return fac
}

//Como Expresion
const factorialExpresion = function(pNumero){
    let numero = pNumero
    let fac = 1
    
    for(let contar = 1; contar <= numero; contar++){
        fac = fac * contar;
        
    }
    return fac
}
