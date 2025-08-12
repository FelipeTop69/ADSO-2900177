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
        let contar = 0;
        let impar = 0
        let par = 0
        let mul
        let resul 
        let pantalla = ""


        while (contar < tablaLimite) {
            contar = contar + 1;
            pantalla += `Tabla del ${contar} </br>`
            mul = 0; 
            while (mul < factorLimite) {
                mul = mul + 1;
                resul = contar * mul;
                if(resul % 2 == 0){
                    pantalla += `${contar} x ${mul} = ${resul} Buzz </br>`
                    console.log(pantalla)
                    par = par + 1
                }else{
                    pantalla += `${contar} x ${mul} = ${resul} Bass </br>`
                    console.log(pantalla)
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