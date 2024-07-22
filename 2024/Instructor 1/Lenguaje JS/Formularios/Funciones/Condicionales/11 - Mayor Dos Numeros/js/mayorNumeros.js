/**
 * Función Numeros Mayores - Imprimir el mayor de dos números validando que no sean iguales
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function numeroMayor(pNum1, pNum2){
    let num1 = pNum1;    
    let num2 = pNum2;

    if(num1 == num2){
        return "Los números son iguales ";
    }else if(num1 > num2){
        return "El " + num1 + " es mayor";
    }else{
        return "El " + num2 + " es mayor";
    }
}

//Como Expresion
const numeroMayorExpresion = function(pNum1, pNum2){
    let num1 = pNum1;
    let num2 = pNum2;

    if(num1 == num2){
        return "Los números son iguales ";
    }else if(num1 > num2){
        return "El " + num1 + " es mayor";
    }else{
        return "El " + num2 + " es mayor";
    }
}
