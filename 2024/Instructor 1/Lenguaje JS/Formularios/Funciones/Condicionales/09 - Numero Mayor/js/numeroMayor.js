/**
 * Función Numero Mayor - Imprimir el mayor de dos números
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function numeroMayor(pNum1, pNum2){
    let num1 = pNum1;
    let num2 = pNum2;

    if(num1 > num2){
        return num1;
    }else{
        return num2;
    }
}

//Como Expresion
const numeroMayorExpresion = function(pNum1, pNum2){
    let num1 = pNum1;
    let num2 = pNum2;

    if(num1 > num2){
        return num1;
    }else{
        return num2;
    }
}
