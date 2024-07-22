// Inicio Primera X
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
function primeraX(pBingo){
    let bingo = pBingo;
    let iteracionUno;
    let iteracionDos;
    let pantallaPrimeraX = "";

    for (iteracionUno = 2; iteracionUno < 5; iteracionUno++) {
        for (iteracionDos = 0; iteracionDos < 3; iteracionDos++) {
            if (iteracionUno % 2 == 0 && iteracionDos % 2 == 0) {
                pantallaPrimeraX +=`<h6>Numero Primera X: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else if (iteracionUno % 2 == 1 && iteracionDos % 2 == 1) {
                pantallaPrimeraX +=`<h6>Numero Primera X: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else {
                pantallaPrimeraX += ` `;
            }
        }
    }
    return pantallaPrimeraX;
}
function mostrarPrimeraX() {
    let iteracionPrimeraXUno;
    let iteracionPrimeraXDos;

    for (iteracionPrimeraXUno = 2; iteracionPrimeraXUno < 5; iteracionPrimeraXUno++) {
        for (iteracionPrimeraXDos = 0; iteracionPrimeraXDos < 3; iteracionPrimeraXDos++) {
            if (iteracionPrimeraXUno % 2 == 0 && iteracionPrimeraXDos % 2 == 0) {
                document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "blue";
            }else if (iteracionPrimeraXUno % 2 == 1 && iteracionPrimeraXDos % 2 == 1) {
                document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "blue";
            }else {
                document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "none";
            }
        }
    }
}
// Fin Primera X

// Inicio Segunda X
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
function segundaX(pBingo){
    let bingo = pBingo;
    let iteracionUno;
    let iteracionDos;
    let pantallaSegundaX = "";

    for (iteracionUno = 2; iteracionUno < 5; iteracionUno++) {
        for (iteracionDos = 2; iteracionDos < 5; iteracionDos++) {
            if (iteracionUno % 2 == 0 && iteracionDos % 2 == 0) {
                pantallaSegundaX +=`<h6>Numero Segunda X: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else if (iteracionUno % 2 == 1 && iteracionDos % 2 == 1) {
                pantallaSegundaX +=`<h6>Numero Segunda X: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else {
                pantallaSegundaX += ` `;
            }
        }
    }
    return pantallaSegundaX
}
function mostrarSegundaX() {
    let iteracionSegundaXUno;
    let iteracionSegundaXDos;

    for (iteracionSegundaXUno = 2; iteracionSegundaXUno < 5; iteracionSegundaXUno++) {
        for (iteracionSegundaXDos = 2; iteracionSegundaXDos < 5; iteracionSegundaXDos++) {
            if (iteracionSegundaXUno % 2 == 0 && iteracionSegundaXDos % 2 == 0) {
                document.getElementById(`celda-${iteracionSegundaXUno}-${iteracionSegundaXDos}`).style.backgroundColor = "blue";
            }else if (iteracionSegundaXUno % 2 == 1 && iteracionSegundaXDos % 2 == 1) {
                document.getElementById(`celda-${iteracionSegundaXUno}-${iteracionSegundaXDos}`).style.backgroundColor = "blue";
            }else {
                document.getElementById(`celda-${iteracionSegundaXUno}-${iteracionSegundaXDos}`).style.backgroundColor = "none";
            }
        }
    }
}
// Fin Segunda X


// Inicio Tercera X
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
function terceraX(pBingo){
    let bingo = pBingo;
    let iteracionUno;
    let iteracionDos;
    let pantallaTerceraX = "";

    for (iteracionUno = 0; iteracionUno < 3; iteracionUno++) {
        for (iteracionDos = 1; iteracionDos < 4; iteracionDos++) {
            if (iteracionUno % 2 == 0 && iteracionDos % 2 == 1) {
                pantallaTerceraX +=`<h6>Numero Tercera X: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else if (iteracionUno % 2 == 1 && iteracionDos % 2 == 0) {
                pantallaTerceraX +=`<h6>Numero Tercera X: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else {
                pantallaTerceraX += ` `;
            }
        }
    }
    return pantallaTerceraX
}
function mostrarTerceraX() {
    let iteracionTerceraXUno;
    let iteracionTerceraXDos;

    for (iteracionTerceraXUno = 0; iteracionTerceraXUno < 3; iteracionTerceraXUno++) {
        for (iteracionTerceraXDos = 1; iteracionTerceraXDos < 4; iteracionTerceraXDos++) {
            if (iteracionTerceraXUno % 2 == 0 && iteracionTerceraXDos % 2 == 1) {
                document.getElementById(`celda-${iteracionTerceraXUno}-${iteracionTerceraXDos}`).style.backgroundColor = "blue";
            }else if (iteracionTerceraXUno % 2 == 1 && iteracionTerceraXDos % 2 == 0) {
                document.getElementById(`celda-${iteracionTerceraXUno}-${iteracionTerceraXDos}`).style.backgroundColor = "blue";
            }else {
                document.getElementById(`celda-${iteracionTerceraXUno}-${iteracionTerceraXDos}`).style.backgroundColor = "none";
            }
        }
    }
}
// Fin Segunda X


// Inicio X General
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
function xGrande(pBingo){
    let bingo = pBingo;
    let iteracionUno;
    let iteracionDos;
    let pantallaXGrande = "";

    for (iteracionUno = 0; iteracionUno < 5; iteracionUno++) {
        for (iteracionDos = 0; iteracionDos < 5; iteracionDos++) {
            if (iteracionUno == iteracionDos) {
                pantallaXGrande +=`<h6>Numero X Grande: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else if (iteracionUno + iteracionDos == 4) {
                pantallaXGrande +=`<h6>Numero X Grande: ${bingo[iteracionUno][iteracionDos]}</h6>`;
            }else {
                pantallaXGrande += ` `;
            }
        }
    }
    return pantallaXGrande
}

function mostrarXGeneral() {
    let iteracionPrimeraXUno;
    let iteracionPrimeraXDos;

    for (iteracionPrimeraXUno = 0; iteracionPrimeraXUno < 5; iteracionPrimeraXUno++) {
        for (iteracionPrimeraXDos = 0; iteracionPrimeraXDos < 5; iteracionPrimeraXDos++) {
            if (iteracionPrimeraXUno == iteracionPrimeraXDos) {
                document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "orange";
            }else if (iteracionPrimeraXUno + iteracionPrimeraXDos == 4) {
                document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "orange";
            }else {
                document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "none";
            }
        }
    }
}
// Fin X General
