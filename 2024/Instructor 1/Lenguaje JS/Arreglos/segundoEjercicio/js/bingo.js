/**
 * Segundo ejercicio - Bingo
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: Miercoles 8 de abril del 2024
*/

//Ejemplo Base 

let bingo = [];
let interno = []
let iteracionBingo;
let iteracionInterno;
let contador = 0;
let tablaBingo;
let pares = 0;
let impares = 0;
let arregloPares = [];
let arregloImpares = [];
let numeroLetraB = [];

//Crear matriz 
for(iteracionBingo = 0; iteracionBingo < 5; iteracionBingo++){
    let interno = []
    for(iteracionInterno = 0; iteracionInterno < 5; iteracionInterno++){
        contador = contador + 1;
        tablaBingo = contador * 3;
        interno.push(tablaBingo);
    }
    bingo.push(interno);
    
}

console.log(bingo)

//Obtener cantidad de Pares e Impares
for(iteracionBingo = 0; iteracionBingo < 5; iteracionBingo++){
    for(iteracionInterno = 0; iteracionInterno < 5; iteracionInterno++){
        if(bingo[iteracionBingo][iteracionInterno] % 2 == 0){
            pares = pares + 1
            arregloPares.push(bingo[iteracionBingo][iteracionInterno])
        }else{
            impares = impares + 1
            arregloImpares.push(bingo[iteracionBingo][iteracionInterno])

        }
    }
}
console.log("Pares: " + arregloPares)
console.log("Impares: " + arregloImpares)
console.log("La cantidad de numeros pares es: " + pares)
console.log("La cantidad de numeros impares es: " + impares)

// Numeros letra B
for(iteracionBingo = 0; iteracionBingo < 5; iteracionBingo++){
    numeroLetraB.push(bingo[iteracionBingo][0])
}

console.log("Letra B: " + numeroLetraB)







