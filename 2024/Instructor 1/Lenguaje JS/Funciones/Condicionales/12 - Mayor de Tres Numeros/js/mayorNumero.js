/**
 * Función Numeros Mayores - Imprimir el mayor de tres números con la misma validación
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function numeroMayor(pNum1, pNum2, pNum3){
    let num1 = pNum1;
    let num2 = pNum2;
    let num3 = pNum3;

    if(num1 == num2 || num1 == num2 || num2 == num3){
        return "Los números son iguales";
    }
    else if(num1 > num2 && num1 > num3){
        return "El primer número es mayor: " + num1;
    }
    else if(num2 > num1 && num2 > num3){
        return "El segundo número mayor es: " + num2;
    }
    else{
        return "El tercer número mayor es: " + num3;
    }
}

//Como Expresion
const numeroMayorExpresion = function(pNum1, pNum2, pNum3){
    let num1 = pNum1;
    let num2 = pNum2;
    let num3 = pNum3;

    if(num1 == null || num2 == null || num3 == null){
        return "No hay números"
    }else{
        if(num1 == num2 || num1 == num2 || num2 == num3){
            return "Los números son iguales";
        }
        else if(num1 > num2 && num1 > num3){
            return "El primer número es mayor: " + num1;
        }
        else if(num2 > num1 && num2 > num3){
            return "El segundo número mayor es: " + num2;
        }
        else{
            return "El tercer número mayor es: " + num3;
        }
    }
    
}
