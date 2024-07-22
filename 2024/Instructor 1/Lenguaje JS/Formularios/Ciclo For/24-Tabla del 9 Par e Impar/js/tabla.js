/**
 * Función Tabla - Imprimir la tabla del 9 con los números pares e impares
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
        let mul = 1
        let resultado = ""

        for(let contar = 1; contar <= numeroLimite; contar++){
            mul = numero * contar
            if(mul % 2 == 0){
                resultado += `${numero} x ${contar} = ${mul} Es Par </br>`

            }else{
                resultado += `${numero} x ${contar} = ${mul} Es Impar </br>`
            }
        } 
        document.getElementById("resultado").innerHTML = `<strong>Tabla del ${numero} </br> ${resultado}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false;
}