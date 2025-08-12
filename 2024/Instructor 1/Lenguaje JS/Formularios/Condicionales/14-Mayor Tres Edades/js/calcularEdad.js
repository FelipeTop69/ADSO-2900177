/**
 * Función Mayor de Edad - Calcular la edad de una persona e imprimir si es mayor o menor de edad y calcular el promedio de edades
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

function validacion(pfechaNacimiento) {
    let edad = calcularEdad(pfechaNacimiento);
    let mensaje 
    if(edad > 17){
        mensaje = "Es Mayor de edad"
    }else{
        mensaje = "Es Menor de edad";
    }
    return { 
        texto: mensaje, 
        edad: edad };
}




function mayorEdad() {
    let primeraFechaNacimiento = document.getElementById("txtPrimeraFechaNacimiento").value;
    let segundaFechaNacimiento = document.getElementById("txtSegundaFechaNacimiento").value;
    let terceraFechaNacimiento = document.getElementById("txtTerceraFechaNacimiento").value;
    
    
    if(primeraFechaNacimiento == "" || segundaFechaNacimiento == "" || terceraFechaNacimiento == ""){
        document.getElementById("error").style.display = "block";
        document.getElementById("primeraEdad").innerHTML = "";
        document.getElementById("segundaEdad").innerHTML = "";
        document.getElementById("teceraEdad").innerHTML = "";
    }else{
        let edadUno = validacion(primeraFechaNacimiento)
        let mensajeUno = validacion(primeraFechaNacimiento)

        let edadDos = validacion(segundaFechaNacimiento)
        let mensajeDos = validacion(segundaFechaNacimiento)

        let edadTres = validacion(terceraFechaNacimiento)
        let mensajeTres = validacion(terceraFechaNacimiento)

        document.getElementById("primeraEdad").innerHTML = `<strong>La edad de la Primera Persona es: 
        ${edadUno.edad} años. </br> ${mensajeUno.texto}</strong>`;

        document.getElementById("segundaEdad").innerHTML = `<strong>La edad de la Segunda Persona es: 
        ${edadDos.edad} años. </br> ${mensajeDos.texto} </strong>`;
        
        document.getElementById("teceraEdad").innerHTML = `<strong>La edad de la Tercera Persona es: 
        ${edadTres.edad} años. </br> ${mensajeTres.texto} </strong>`;
        
        document.getElementById("error").style.display = "none";
        

    }

    return false;
}