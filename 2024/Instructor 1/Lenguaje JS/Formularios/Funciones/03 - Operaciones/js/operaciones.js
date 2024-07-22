/**
 * Función Operaciones Aricméticas - Sumar, restar, multiplicar y dividir dos números 
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: Lunes 01 de abril del 2024
 */

let numUno;
let numDos;

//Como Parametro
function suma(pNumUno, pNumDos){
    let sumar;
    numUno = pNumUno;
    numDos = pNumDos;
    sumar = numUno + numDos

    return sumar
}

function resta(pNumUno, pNumDos){
    let restar;
    numUno = pNumUno;
    numDos = pNumDos;
    restar = numUno - numDos

    return restar
}

function multiplicacion(pNumUno, pNumDos){
    let multiplicar;
    numUno = pNumUno;
    numDos = pNumDos;
    multiplicar = numUno * numDos

    return multiplicar
}

function division(pNumUno, pNumDos){
    let dividir;
    numUno = pNumUno;
    numDos = pNumDos;
    dividir = numUno / numDos

    return dividir
}

function operaciones(pOperador, pNumUno, pNumDos){
    let operadaor = pOperador
    numUno = pNumUno;
    numDos = pNumDos;
    if(operadaor == 'suma'){
        return suma(numUno, numDos)
    }else if(operadaor == 'resta'){
        return resta(numUno, numDos)
    }else if(operadaor == 'multiplicacion'){
        return multiplicacion(numUno, numDos)
    }else if(operadaor == 'division'){
        return division(numUno, numDos)
    }else{
        return 'No se reconoce la operación'
    }
}

//Como Expresión
const sumaExpresion = function(pNumUno, pNumDos){
    let sumar;
    numUno = pNumUno;
    numDos = pNumDos;
    sumar = numUno + numDos

    return sumar
}

const restaExpresion = function(pNumUno, pNumDos){
    let restar;
    numUno = pNumUno;
    numDos = pNumDos;
    restar = numUno - numDos

    return restar
}

const multiplicacionExpresion = function(pNumUno, pNumDos){
    let multiplicar;
    numUno = pNumUno;
    numDos = pNumDos;
    multiplicar = numUno * numDos

    return multiplicar
}

const divisionExpresion = function(pNumUno, pNumDos){
    let dividir;
    numUno = pNumUno;
    numDos = pNumDos;
    dividir = numUno / numDos

    return dividir
}

const operacionesExpresion = function(pOperador, pNumUno, pNumDos){
    let operadaor = pOperador
    numUno = pNumUno;
    numDos = pNumDos;
    if(operadaor == 'sumaExpresion'){
        return sumaExpresion(numUno, numDos)
    }else if(operadaor == 'restaExpresion'){
        return restaExpresion(numUno, numDos)
    }else if(operadaor == 'multiplicacionExpresion'){
        return multiplicacionExpresion(numUno, numDos)
    }else if(operadaor == 'divisionExpresion'){
        return divisionExpresion(numUno, numDos)
    }else{
        return 'No se reconoce la operación'
    }
}