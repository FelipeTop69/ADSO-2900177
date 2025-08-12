/*
Funcion Suma
Autor: Ruben Felipe Tovar Aviles
Fecha: 17 de junio del 2024
*/

function suma() {
    let numeroUno = parseFloat(document.getElementById("txtNumeroUno").value)
    let numeroDos = parseFloat(document.getElementById("txtNumeroDos").value)
    
    if(isNaN(numeroUno) || isNaN(numeroDos)){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";

    }else{
        let sumar = numeroUno + numeroDos

        let suma = `Suma: ${sumar} </br>`

        document.getElementById("resultado").innerHTML=`<strong>${suma}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false
}
