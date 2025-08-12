/**
 * Función Numeros Mayores - Imprimir el mayor de tres números con la misma validación
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */

function comparacion(pNum1, pNum2, pNum3){
    let num1 = pNum1;
    let num2 = pNum2;
    let num3 = pNum3;
    let numeroMayor
    
    if(num1 == num2 || num1 == num2 || num2 == num3){
        numeroMayor = null
    }
    else if(num1 > num2 && num1 > num3){
        numeroMayor = num1
    }
    else if(num2 > num1 && num2 > num3){
        numeroMayor = num2
    }
    else{
        numeroMayor = num3
    }
    

    return numeroMayor;
}

function numeroMayor() {
    let numeroUno = parseFloat(document.getElementById("txtNumeroUno").value);
    let numeroDos = parseFloat(document.getElementById("txtNumeroDos").value);
    let numeroTres = parseFloat(document.getElementById("txtNumeroTres").value);
    
    if(isNaN(numeroUno) || isNaN(numeroDos) || isNaN(numeroTres)){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let numeroMayor = comparacion(numeroUno, numeroDos, numeroTres);
        if (numeroMayor != null){
            document.getElementById("resultado").innerHTML = `<strong>El Numero Mayor es: ${numeroMayor}</strong>`
            document.getElementById("error").style.display = "none";
        }else{
            document.getElementById("resultado").innerHTML = `<strong>Los Numeros son Iugales</strong>`
            document.getElementById("error").style.display = "none";
        }
        
    }

    return false;
}