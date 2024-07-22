/**
  * Función Factorial - Imprimir el factorial de un numero
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function factorial() {
    let numero = parseInt(document.getElementById("txtNumero").value);
    
    if(isNaN(numero)) {
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let fac = 1
        for(let contar = 1; contar <= numero; contar++){
            fac = fac * contar;
            
        }
        document.getElementById("resultado").innerHTML = `<strong>El Factorial de ${numero} es: ${fac}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false;
}