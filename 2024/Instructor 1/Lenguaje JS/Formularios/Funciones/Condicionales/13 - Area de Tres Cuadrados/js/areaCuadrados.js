/**
 * Función Area de Cuadrados - Calcular el área 3 de cuadrados e imprimir el mayor
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como Parametro
function areaCuadrados(pLado1, pLado2, pLado3){
    let l1 = pLado1;
    let l2 = pLado2;
    let l3 = pLado3;

    let cu1 = l1 * l1;
    let cu2 = l2 * l2;
    let cu3 = l3 * l3;

    if(l1 == null || l2 == null || l3 == null){
        return "No hay valores"
    }else{
        if(cu1 == cu2 || cu1 == cu2 || cu2 == cu3){
            return "El área de los cuadrados son iguales";
        }
        else if(cu1 > cu2 && cu1 > cu3){
            return "El área mayor es la del primer cuadrado: " + cu1 + " cm\u00b2";
        }
        else if(cu2 > cu1 && cu2 > cu3){
            return "El área mayor es la del segundo cuadrado: " + cu2 + " cm\u00b2";
        }
        else{
            return "El área mayor es la del tercer cuadrado: " + cu3 + " cm\u00b2";
        }
    }
}

//Como Expresion
const areaCuadradosExpresion = function(pLado1, pLado2, pLado3){
    let l1 = pLado1;
    let l2 = pLado2;
    let l3 = pLado3;

    let cu1 = l1 * l1;
    let cu2 = l2 * l2;
    let cu3 = l3 * l3;

    if(l1 == null || l2 == null || l3 == null){
        return "No hay valores"
    }else{
        if(cu1 == cu2 || cu1 == cu2 || cu2 == cu3){
            return "El área de los cuadrados son iguales";
        }
        else if(cu1 > cu2 && cu1 > cu3){
            return "El área mayor es la del primer cuadrado: " + cu1 + " cm\u00b2";
        }
        else if(cu2 > cu1 && cu2 > cu3){
            return "El área mayor es la del segundo cuadrado: " + cu2 + " cm\u00b2";
        }
        else{
            return "El área mayor es la del tercer cuadrado: " + cu3 + " cm\u00b2";
        }
    }
}
