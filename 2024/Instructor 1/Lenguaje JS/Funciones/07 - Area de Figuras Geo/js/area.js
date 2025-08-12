/**
 * Función Area - Calcular el area de un cuadrado, rectangulo y trinagulo
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: lunes 08 de abril del 2024
 */

//Como parametros
function areaCuadrado(pLado){
    let lado = pLado
    let area
    area = lado * lado

    return area
}
function areaRectangulo(pBase, pAltura){
    let base = pBase
    let altura = pAltura
    let area
    area = base * altura

    return area
}
function areaTriangulo(pBase, pAltura){
    let base = pBase
    let altura = pAltura
    let area
    area = (base * altura)/2

    return area
}

//Como Expresion
const areaCuadradoExpresion = function(pLado){
    let lado = pLado
    let area
    area = lado * lado

    return area
}

const areaRectanguloExpresion = function(pBase, pAltura){
    let base = pBase
    let altura = pAltura
    let area
    area = base * altura

    return area
}

const areaTrianguloExpresion = function(pBase, pAltura){
    let base = pBase
    let altura = pAltura
    let area
    area = (base * altura)/2

    return area
}