/**
 * Función Contar - Contar del 1 al 5
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function contador(pNumero){
    let numero = pNumero;
    let resultado  = ""; 
    for(let contador = 1; contador <= numero; contador++){
        resultado += `${contador}\n`;  
    }
    return resultado; 
}

//Como Expresion
const contadorExpresion = function(pNumero){
    let numero = pNumero
    let resultado  = "";  
    for(let contador = -5; contador <= numero; contador++){
        resultado += `${contador}\n`; 
    }
    return resultado; 
}
