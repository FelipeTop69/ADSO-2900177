/**
 * Función Numero Mayor - Imprimir el mayor de dos números
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */

function comparacion(pNum1, pNum2){
    let num1 = pNum1;
    let num2 = pNum2;
    let numeroMayor

    if(num1 > num2){
        numeroMayor = num1;
    }else{
        numeroMayor = num2;
    }

    return numeroMayor
}

function numeroMayor() {
    let numeroUno = parseFloat(document.getElementById("txtNumeroUno").value);
    let numeroDos = parseFloat(document.getElementById("txtNumeroDos").value);
    
    if(isNaN(numeroUno) || isNaN(numeroDos)){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let numeroMayor = comparacion(numeroUno, numeroDos)
        document.getElementById("resultado").innerHTML = `<strong>El numero mayor es: ${numeroMayor}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false;
}