/**
 * Función Porcentaje - Hallar el porcentaje de un numero
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */


function porcentaje() {
    let numero = parseFloat(document.getElementById("txtNumero").value);

    if (isNaN(numero)) {
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    } else {
        let porcentaje = numero / 100;
        let porcentajeNumero = `El porcentaje de ${numero} es: ${porcentaje.toFixed(2)}%`;
        document.getElementById("resultado").innerHTML = `<strong>${porcentajeNumero}</strong>`;
        document.getElementById("error").style.display = "none";
    }

    return false;
}