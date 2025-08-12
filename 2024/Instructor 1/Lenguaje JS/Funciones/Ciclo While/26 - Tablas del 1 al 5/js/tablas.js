/**
 * Función Tablas - Imprimir las cinco primeras tablas y demas
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function tablas(pNumero, pTabla){
    let numero = pNumero
    let tabla = pTabla;
    let contar = 0;
    let impar = 0
    let par = 0
    let mul
    let resul
    let resultado = ""

    while (contar < tabla) {
        contar = contar + 1;
        console.log("Tabla del " + contar)
        mul = 0; 
        while (mul < numero) {
            mul = mul + 1;
            resul = contar * mul;
            if(resul % 2 == 0){
                resultado += `${contar} x ${mul} = ${resul} Buzz \n`
                // console.log(contar + " x " + mul + " = " + resul + " Buzz");
                par = par + 1
            }else{
                resultado += `${contar} x ${mul} = ${resul} Bass \n`
                // console.log(contar + " x " + mul + " = " + resul + " Bass");
                impar = impar + 1
            }
            
        }
        console.log("\n")
    }
    // return {par, impar}
    return `${resultado}La Cantidad de Pares es ${par}\nLa cantidad de Impares es ${impar} ` 
}

//Como Expresion
const tablasExpresion = function(pNumero, pTabla){
    let numero = pNumero
    let tabla = pTabla;
    let contar = 0;
    let impar = 0
    let par = 0
    let mul
    let resul 

    while (contar < tabla) {
        contar = contar + 1;
        console.log("Tabla del " + contar)
        mul = 0; 
        while (mul < numero) {
            mul = mul + 1;
            resul = contar * mul;
            if(resul % 2 == 0){
                console.log(contar + " x " + mul + " = " + resul + " Buzz");
                par = par + 1
            }else{
                console.log(contar + " x " + mul + " = " + resul + " Bass");
                impar = impar + 1
            }
            
        }
        console.log("\n")
    }
    return {par, impar} 
}
