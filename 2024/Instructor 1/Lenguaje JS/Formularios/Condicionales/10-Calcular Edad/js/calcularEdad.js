/**
 * Función Calcular Edad - Calcular la edad de una persona e imprimir si es mayor de edad
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function calcularEdad(pFechaNacimiento){
    let fechaNacimiento = pFechaNacimiento
    let fechaActual = new Date
    let añoActual = parseInt(fechaActual.getFullYear());
    let mesActual = parseInt(fechaActual.getMonth()+1);
    let diaActual = parseInt(fechaActual.getDate());

    let añoNacimiento = parseInt(String(fechaNacimiento).substring(0,4));
    let mesNacimiento = parseInt(String(fechaNacimiento).substring(5,7));
    let diaNacimiento = parseInt(String(fechaNacimiento).substring(8,10));
    
    let edad = añoActual - añoNacimiento;
    if(mesActual < mesNacimiento){
        edad--;
    }else if(mesActual === mesNacimiento){
        if(diaActual < diaNacimiento){
            edad--;
        }
    }

    return edad;
}


function mayorEdad() {
    let fechaNacimiento = document.getElementById("txtFechaNacimiento").value;
    
    
    if(fechaNacimiento == ""){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let edad = calcularEdad(fechaNacimiento)
        if(edad > 17){
            document.getElementById("resultado").innerHTML = `<strong>Tienes ${edad} años </br> Eres Mayor de Edad :(</strong>`;
        }else{
            document.getElementById("resultado").innerHTML = `<strong>Tienes ${edad} años </br> Eres Menor de Edad :)</strong>`;
        }
        document.getElementById("error").style.display = "none";

    }

    return false;
}