/*
Funcion Bingo
Autor: Ruben Felipe Tovar Aviles
Fecha: 16 de julio del 2024
*/

function generarBingo(pNumeroRecibido){
    let numeroRecibido = pNumeroRecibido;
    let bingo = [];
    let lineaInterna = [];
    let iteracionUno;
    let iteracionDos;
    let numeroTabla;
    let contador = 0;

    for (iteracionUno = 0; iteracionUno < 5; iteracionUno++) {
        lineaInterna = [];
        for (iteracionDos = 0; iteracionDos < 5; iteracionDos++) {
            contador = contador + 1;
            numeroTabla = contador * numeroRecibido;
            lineaInterna.push(numeroTabla);
        }
        bingo.push(lineaInterna);
    }
    return bingo;
}


function mostrarBingo(pBingo){
    let bingo = pBingo;
    let iteracionUno;
    let iteracionDos;
    let pantallaBingo = "";

    for(iteracionUno = 0; iteracionUno < bingo.length; iteracionUno++){

        pantallaBingo += `<tr>`
        pantallaBingo += `<tr>`
        for(iteracionDos = 0; iteracionDos < bingo.length; iteracionDos++){
            pantallaBingo += `<td id="celda-${iteracionUno}-${iteracionDos}" class="td-numero">${bingo[iteracionUno][iteracionDos]}</td>`;
        }
        pantallaBingo += `</tr>`
    }

    return pantallaBingo;
    
}

function recibirValor() {
    const numeroBingo = parseFloat(document.getElementById("txtNumeroBingo").value);

    if(isNaN(numeroBingo) || numeroBingo == 0){
        document.getElementById("error").style.display = "block";
        document.getElementById("cuerpo-tabla").style.display = "none";
        document.getElementById("contendor-botones").style.display = "none";
        document.getElementById("cuerpo-bingo").innerHTML = "";

    }else{
        let pantallaDOOM = ""
        let bingo;
        
        bingo = generarBingo(numeroBingo);
        pantallaDOOM = mostrarBingo(bingo)

        document.getElementById("cuerpo-tabla").style.display = "block";
        document.getElementById("contendor-botones").style.display = "flex ";
        document.getElementById("cuerpo-bingo").innerHTML = pantallaDOOM;
        document.getElementById("error").style.display = "none";
    }
    return false
}

// Invocada en enviarLetra.js y enviarX.js
function limpiarSeleccion() {
    let iteracionLetraUno;
    let iteracionLetraDos;
    
    for (iteracionLetraUno = 0; iteracionLetraUno < 5; iteracionLetraUno++) {
        for (iteracionLetraDos = 0; iteracionLetraDos < 5; iteracionLetraDos++) {
            document.getElementById(`celda-${iteracionLetraUno}-${iteracionLetraDos}`).style.backgroundColor = "";
        }
    }
}



