/**
  * Función Contador - Imprimir los numeros del 1 al 5
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function contador() {
    let numero = parseInt(document.getElementById("txtNumero").value);
    
    if(isNaN(numero)) {
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let contar = 0;
        let resultado = ""
        for(let contador = 1; contador <= numero; contador++){
        resultado += `Numero: ${contador} </br>`;  
    }
        document.getElementById("resultado").innerHTML = `<strong>${resultado}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false;
}