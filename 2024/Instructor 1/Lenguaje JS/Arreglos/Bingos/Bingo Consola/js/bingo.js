let bingo = [];
let lineaInterna = [];
let iteracionUno;
let iteracionUnoX;
let iteracionDosX;
let iteracionDos;
let iteracionLetras;
let numeroTabla;
let contador = 0;
let iteracionLetra;
let pantallaDOOM = "";
let letraB = "";
let primeraX;

// Crear Bingo
for (iteracionUno = 0; iteracionUno < 5; iteracionUno++) {
    lineaInterna = [];
    for (iteracionDos = 0; iteracionDos < 5; iteracionDos++) {
        contador = contador + 1;
        numeroTabla = contador * 5;
        lineaInterna.push(numeroTabla);
    }
    bingo.push(lineaInterna);
}

// Mostrar Bingo
for (iteracionUno = 0; iteracionUno < bingo.length; iteracionUno++) {
    pantallaDOOM += `<tr cl>`;
    for (iteracionDos = 0; iteracionDos < bingo[iteracionUno].length; iteracionDos++) {
        pantallaDOOM += `<td id="celda-${iteracionUno}-${iteracionDos}">${bingo[iteracionUno][iteracionDos]}</td>`;
    }
    pantallaDOOM += `</tr>`;
}

document.getElementById("cuerpo-bingo").innerHTML = pantallaDOOM;

// Obtener los números de la columna B
for (iteracionLetras = 0; iteracionLetras < 5; iteracionLetras++) {
    letraB += `${bingo[iteracionLetras][0]} `;
}


// Resaltar Letra B
document.getElementById("letraB").addEventListener("click", function () {
    for (iteracionLetras = 0; iteracionLetras < 5; iteracionLetras++) {
        document.getElementById(`celda-${iteracionLetras}-0`).style.backgroundColor = "yellow";
    }
});

// Obetner X
for (iteracionUnoX = 2; iteracionUnoX < 5; iteracionUnoX++) {
    for (iteracionDosX = 0; iteracionDosX < 3; iteracionDosX++) {
        if (iteracionUnoX % 2 == 0 && iteracionDosX % 2 == 0) {
            primeraX +=`${bingo[iteracionUnoX][iteracionDosX]}`;
        }else if (iteracionUnoX % 2 == 1 && iteracionDos % 2 == 1) {
            primeraX +=`${bingo[iteracionUnoX][iteracionDosX]}`;
        }else {
            primeraX += ` `;
        }
    }
}

document.getElementById("equis").addEventListener("click", function () {
    for (iteracionUnoX = 2; iteracionUnoX < 5; iteracionUnoX++) {
        for (iteracionDosX = 0; iteracionDosX < 3; iteracionDosX++) {
            if (iteracionUnoX % 2 == 0 && iteracionDosX % 2 == 0) {
                document.getElementById(`celda-${iteracionUnoX}-${iteracionDosX}`).style.backgroundColor = "blue";
            }else if (iteracionUnoX % 2 == 1 && iteracionDos % 2 == 1) {
                document.getElementById(`celda-${iteracionUnoX}-${iteracionDosX}`).style.backgroundColor = "blue";
            }else {
                document.getElementById(`celda-${iteracionUnoX}-${iteracionDosX}`).style.backgroundColor = "none";
            }
        }
    }
});

