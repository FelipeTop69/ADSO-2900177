/**
 * Función Promedio - Calcular el promedio de notas y demas
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */

function validarNota(psumPorc){
    let sumPorc = psumPorc
    let mensaje
    if(sumPorc > 4.5){
        mensaje = "El porcentaje de notas es superior" 
    }else if (sumPorc <= 4.5 && sumPorc > 3.5){
        mensaje = "El porcentaje de notas es buena" 
    }else if (sumPorc <= 3.5 && sumPorc >= 3.0){
        return "El porcentaje de notas es media" 
    }else{
        mensaje = "El porcentaje de notas es mala" 
    }
    return mensaje
}


function promedioNotas() {
    let nota1 = parseFloat(document.getElementById("txtNota1").value)
    let porcentajeNota1 = parseFloat(document.getElementById("txtPorcentajeNota1").value)
    let nota2 = parseFloat(document.getElementById("txtNota2").value)
    let porcentajeNota2 = parseFloat(document.getElementById("txtPorcentajeNota2").value)
    let nota3 = parseFloat(document.getElementById("txtNota3").value)
    let porcentajeNota3 = parseFloat(document.getElementById("txtPorcentajeNota3").value)
    
    if(isNaN(nota1) || isNaN(nota2) || isNaN(nota3) || isNaN(porcentajeNota1) || isNaN(porcentajeNota2) || isNaN(porcentajeNota3)){
        document.getElementById("nota1").innerHTML = "";
        document.getElementById("nota2").innerHTML = "";
        document.getElementById("nota3").innerHTML = "";
        document.getElementById("sumaPorcentajes").innerHTML = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("error").style.display = "block";
        
    }else{
        
        let porcentaje1 = nota1 * porcentajeNota1
        let porcentaje2 = nota2 * porcentajeNota2
        let porcentaje3 = nota3 * porcentajeNota3
        let sumaPorcentajes = porcentaje1 + porcentaje2 + porcentaje3
        let mensaje = validarNota(sumaPorcentajes)
        
        let resultadoPorcentaje1 = `El porcentaje de la nota ${nota1} es : ${porcentaje1.toFixed(2)}`
        let resultadoPorcentaje2 = `El porcentaje de la nota ${nota2} es : ${porcentaje2.toFixed(2)}`
        let resultadoPorcentaje3 = `El porcentaje de la nota ${nota3} es : ${porcentaje3.toFixed(2)}`
        let resultadoSumaPorcentajes = `La suma de los porcentajes es : ${sumaPorcentajes.toFixed(2)}`

        document.getElementById("nota1").innerHTML=`<strong>${resultadoPorcentaje1}</strong>`
        document.getElementById("nota2").innerHTML=`<strong>${resultadoPorcentaje2}</strong>`
        document.getElementById("nota3").innerHTML=`<strong>${resultadoPorcentaje3}</strong>`
        document.getElementById("sumaPorcentajes").innerHTML=`<strong>${resultadoSumaPorcentajes}</strong>`
        document.getElementById("mensaje").innerHTML=`<strong>${mensaje}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false
}
