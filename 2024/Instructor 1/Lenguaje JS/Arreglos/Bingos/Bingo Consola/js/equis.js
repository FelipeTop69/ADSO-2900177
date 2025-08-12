// Patron por Posicionamiento
/**
 * Numeros de Primera X = 33 39 51 63 69
 * 
 * Posicion de Cada Numero
 * 33 = [2],[0] Ambas Posiciones Son Pares
 * 39 = [2],[2] Ambas Posiciones Son Pares
 * 51 = [3],[1] Ambas Posiciones Son Impares
 * 63 = [4],[0] Ambas Posiciones Son Pares
 * 69 = [4],[2] Ambas Posiciones Son Pares
 */
let primeraX = "";
console.log("\nPrimera X:\n");
for (iteracionUno = 2; iteracionUno < 5; iteracionUno++) {
    for (iteracionDos = 0; iteracionDos < 3; iteracionDos++) {
        if (iteracionUno % 2 == 0 && iteracionDos % 2 == 0) {
            primeraX +=`${bingo[iteracionUno][iteracionDos]}`;
        }else if (iteracionUno % 2 == 1 && iteracionDos % 2 == 1) {
            primeraX +=`${bingo[iteracionUno][iteracionDos]}`;
        }else {
            primeraX += ` `;
        }
    }
}
console.log(primeraX);


// Patron por Posicionamiento
/**
 * Numeros de Segunda X = 39 45 57 69 75
 * 
 * Posicion de Cada Numero
 * 39 = [2],[2] Ambas Posiciones Son Pares
 * 45 = [2],[4] Ambas Posiciones Son Pares
 * 57 = [3],[3] Ambas Posiciones Son Impares
 * 69 = [4],[2] Ambas Posiciones Son Pares
 * 75 = [4],[4] Ambas Posiciones Son Pares
 */
let segundaX = "";
console.log("\nSegunda X:\n");
for (iteracionUno = 2; iteracionUno < 5; iteracionUno++) {
    for (iteracionDos = 2; iteracionDos < 5; iteracionDos++) {
        if (iteracionUno % 2 == 0 && iteracionDos % 2 == 0) {
            segundaX +=`${bingo[iteracionUno][iteracionDos]}`;
        }else if (iteracionUno % 2 == 1 && iteracionDos % 2 == 1) {
            segundaX +=`${bingo[iteracionUno][iteracionDos]}`;
        }else {
            segundaX += ` `;
        }
    }
}
console.log(segundaX);


// Patron por Posicionamiento
/**
 * Numeros de Tercera X = 6 12 24 36 42
 * 
 * Posicion de Cada Numero
 * 6  = [0],[1] Posicion Par y Posicion Impar
 * 12 = [0],[3] Posicion Par y Posicion Impar
 * 24 = [1],[2] Posicion Impar y Posicion Par
 * 36 = [2],[1] Posicion Par y Posicion Impar
 * 42 = [2],[3] Posicion Par y Posicion Impar
 */
let terceraX = "";
console.log("\nTercera X:\n");
for (iteracionUno = 0; iteracionUno < 3; iteracionUno++) {
    for (iteracionDos = 1; iteracionDos < 4; iteracionDos++) {
        if (iteracionUno % 2 == 0 && iteracionDos % 2 == 1) {
            terceraX +=`${bingo[iteracionUno][iteracionDos]}`;
        }else if (iteracionUno % 2 == 1 && iteracionDos % 2 == 0) {
            terceraX +=`${bingo[iteracionUno][iteracionDos]}`;
        }else {
            terceraX += ` `;
        }
    }
}
console.log(terceraX);


// Patron por Posicionamiento
/**
 * Numeros X Grande = 3 15 21 27 39 51 57 63 75 
 * 
 * Posicion de Cada Numero
 * 3  = [0],[0] Posiciones Iguales
 * 15 = [0],[4] La suma de las posiciones es igual a 4
 * 21 = [1],[1] Posiciones Iguales
 * 27 = [1],[3] La suma de las posiciones es igual a 4
 * 39 = [2],[2] Posiciones Iguales
 * 51 = [3],[1] La suma de las posiciones es igual a 4
 * 57 = [3],[3] Posiciones Iguales
 * 63 = [4],[0] La suma de las posiciones es igual a 4
 * 75 = [4],[4] Posiciones Iguales
 */
let xGrande = "";
console.log("\nX Grande:\n");
for (iteracionUno = 0; iteracionUno < 5; iteracionUno++) {
    for (iteracionDos = 0; iteracionDos < 5; iteracionDos++) {
        if (iteracionUno == iteracionDos) {
            xGrande +=`${bingo[iteracionUno][iteracionDos]} `;
        }else if (iteracionUno + iteracionDos == 4) {
            xGrande +=`${bingo[iteracionUno][iteracionDos]} `;
        }else {
            xGrande += ``;
        }
    }
}
console.log(xGrande);