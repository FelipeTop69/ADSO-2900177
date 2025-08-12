/**
 * Función Tabla - Imprimir la tabla del 9 con los números pares e impares
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function tabla() {
    let tablaLimite = parseInt(document.getElementById("txtTablaLimite").value);
    let factorLimite = parseInt(document.getElementById("txtFactorLimite").value);
    
    if(isNaN(tablaLimite) || isNaN(factorLimite))  {
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let impar = 0
        let par = 0
        let mul
        let resul 
        let pantalla = ""


        for(contar = 1; contar <= tablaLimite; contar++){
            pantalla += `Tabla del ${contar} </br>`
            mul = 0;
            for(mul = 1; mul <= factorLimite; mul++){
                resul = contar * mul;
                if(resul % 2 == 0){
                    pantalla += `${contar} x ${mul} = ${resul} Buzz </br>`
                    par = par + 1
                }else{
                    pantalla += `${contar} x ${mul} = ${resul} Bass </br>`
                    impar = impar + 1
                }
            }
            pantalla += `</br>`
        }
        document.getElementById("resultado").innerHTML = `<strong>${pantalla}</strong>`
        document.getElementById("cantidadPares").innerHTML = `<strong>Cantidad de Pares: ${par}</strong>`
        document.getElementById("cantidadImpares").innerHTML = `<strong>Cantidad de Impares: ${impar}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false;
}