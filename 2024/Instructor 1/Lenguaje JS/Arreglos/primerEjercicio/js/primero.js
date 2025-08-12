/**
 * Primer ejercicio de arreglos con JS
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: Lunes 29 de abril del 2024
*/

//VECTORES
let arregloNumeros = [];
let arregloPeliculas = [];
let sizeArrayNumeros;
let sizeArrayPeliculas; 
let datosAlerta = ""; 

arregloNumeros = [1,3,5,7,9];
arregloPeliculas = ["Avengers","Rapidos y Furiosos","La Roca","Interestellar"];

sizeArrayNumeros = arregloNumeros.length
sizeArrayPeliculas = arregloPeliculas.length

console.log("VECTORES")
console.log("\n")

console.log("NUMEROS")
console.log("Numeros Impares: " + arregloNumeros);
console.log("Numero Especifico: " + arregloNumeros[0])
for(let contador = 0; contador<sizeArrayNumeros; contador++){
    console.log("Posición " + contador + ": " + arregloNumeros[contador])
}
console.log("\n")

console.log("PELICULAS")
console.log("Peliculas: " + arregloPeliculas);
console.log("Pelicuala Especifica: " + arregloPeliculas[2])
for(let contador = 0; contador<sizeArrayPeliculas; contador++){
    console.log("Posición " + contador + ": " + arregloPeliculas[contador])
    datosAlerta += "Posición " + contador + ": " + arregloPeliculas[contador] + "\n"
}
alert(datosAlerta)
console.log("\n")


// MATRIZ
console.log("MATRIX")
console.log("\n")

let matriz = [];
let sizeArregloMatriz
let sizeArregloInterno

matriz = [
    [1,3,5],
    [7,9,11],
    [13,15,17]
]

sizeArregloMatriz = matriz.length


console.log("NUMEROS")
console.log(matriz)
for(let iteracion = 0; iteracion<sizeArregloMatriz; iteracion++){
    sizeArregloInterno = matriz[iteracion].length
    for(let contador = 0; contador<sizeArregloInterno; contador++){
        console.log(matriz[iteracion][contador])
    }
}