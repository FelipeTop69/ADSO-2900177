/**
  * Función Factorial - Imprimir el factorial de un numero
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function tabla() {
    let numero = parseInt(document.getElementById("txtNumero").value);
    let numeroLimite = parseInt(document.getElementById("txtNumeroLimite").value);
    
    if(isNaN(numero) || isNaN(numeroLimite))  {
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let contar = 0;
        let mul = 1
        let resultado = ""
        while(contar < numeroLimite){
            contar = contar + 1;
            mul = numero * contar
            resultado += `${numero} x ${contar} = ${mul} <br>`
        }
        document.getElementById("resultado").innerHTML = `<strong>Tabla del ${numero} </br> ${resultado}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false;
}