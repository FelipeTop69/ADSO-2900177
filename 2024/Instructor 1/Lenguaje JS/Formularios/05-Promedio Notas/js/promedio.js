/**
 * Función Promedio - Imprimir el promedio de tres notas
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function promedioNotas() {
    let nota1 = parseFloat(document.getElementById("txtNota1").value)
    let nota2 = parseFloat(document.getElementById("txtNota2").value)
    let nota3 = parseFloat(document.getElementById("txtNota3").value)
    
    if(isNaN(nota1) || isNaN(nota2) || isNaN(nota3)){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";

    }else{
        let promedio =(nota1 + nota2 + nota3) / 3

        let promedioNotas = `El promedio de las notas es : ${promedio.toFixed(1)}`

        document.getElementById("resultado").innerHTML=`<strong>${promedioNotas}</strong>`
        document.getElementById("error").style.display = "none";
    }

    return false
}
