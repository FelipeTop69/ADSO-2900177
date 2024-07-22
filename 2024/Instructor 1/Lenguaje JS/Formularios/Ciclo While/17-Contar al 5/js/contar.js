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
        while(contar < numero){
        contar = contar + 1;
        resultado += `Numero: ${contar} </br>`
        }
        document.getElementById("resultado").innerHTML = `<strong>${resultado}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false;
}