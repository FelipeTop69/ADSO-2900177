/**
 * Función Promedio - Imprimir el promedio de tres notas
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function promedioNotas() {
    let nota1 = parseFloat(document.getElementById("txtNota1").value)
    let porcentajeNota1 = parseFloat(document.getElementById("txtPorcentajeNota1").value)
    let nota2 = parseFloat(document.getElementById("txtNota2").value)
    let porcentajeNota2 = parseFloat(document.getElementById("txtPorcentajeNota2").value)
    let nota3 = parseFloat(document.getElementById("txtNota3").value)
    let porcentajeNota3 = parseFloat(document.getElementById("txtPorcentajeNota3").value)
    
    if(isNaN(nota1) || isNaN(nota2) || isNaN(nota3) || isNaN(porcentajeNota1) || isNaN(porcentajeNota2) || isNaN(porcentajeNota3)){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";

    }else{
        
        let porcentaje1 = nota1 * porcentajeNota1
        let porcentaje2 = nota2 * porcentajeNota2
        let porcentaje3 = nota3 * porcentajeNota3
        let sumaPorcentajes = porcentaje1 + porcentaje2 + porcentaje3
        
        let resultadoPorcentaje1 = `El porcentaje de la nota ${nota1} es : ${porcentaje1.toFixed(2)}`
        let resultadoPorcentaje2 = `El porcentaje de la nota ${nota2} es : ${porcentaje2.toFixed(2)}`
        let resultadoPorcentaje3 = `El porcentaje de la nota ${nota3} es : ${porcentaje3.toFixed(2)}`
        let resultadoSumaPorcentajes = `La suma de los porcentajes es : ${sumaPorcentajes.toFixed(2)}`

        document.getElementById("nota1").innerHTML=`<strong>${resultadoPorcentaje1}</strong>`
        document.getElementById("nota2").innerHTML=`<strong>${resultadoPorcentaje2}</strong>`
        document.getElementById("nota3").innerHTML=`<strong>${resultadoPorcentaje3}</strong>`
        document.getElementById("sumaPorcentajes").innerHTML=`<strong>${resultadoSumaPorcentajes}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false
}
