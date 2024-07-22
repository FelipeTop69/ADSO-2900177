/*
Función Sueldo - Calcular el sueldo de un trabajador con deducciones de pensión, salud y ARL. (pensión = 0.16, salud = 0.12, ARL = 0.052)
Autor: Ruben Felipe Tovar Aviles
Fecha: 17 de junio del 2024
*/

function limpiarNumero(numeroConFormato) {
    return numeroConFormato.replace(/[,\.]/g, '');
}

function calcularSueldo(pValorD, pDiasT){
    let valorD = pValorD; 
    let diasT = pDiasT;
    let sueldo = valorD * diasT;
    return sueldo;
}

function calcularPension(pValorD, pDiasT){
    let pen = calcularSueldo(pValorD, pDiasT) * 0.16;
    return pen;
}

function calcularSalud(pValorD, pDiasT){
    let salud = calcularSueldo(pValorD, pDiasT) * 0.12;
    return salud;
}

function calcularARL(pValorD, pDiasT){
    let arl = calcularSueldo(pValorD, pDiasT) * 0.16;
    return arl;
}

function calcularSueldoTotal() {
    let valorDiaTomado = document.getElementById("txtValorDia").value;
    let diasTrabajadosTomado = document.getElementById("txtDiasTrabajados").value;

    let valorDiaLimpio = limpiarNumero(valorDiaTomado);
    let diasTrabajadosLimpio = limpiarNumero(diasTrabajadosTomado);

    let valorDia = parseFloat(valorDiaLimpio);
    let diasTrabajados = parseInt(diasTrabajadosLimpio);

    if(isNaN(valorDia) || isNaN(diasTrabajados)){
        document.getElementById("error").style.display = "block";
        document.getElementById("sueldoAntes").innerHTML = "";
        document.getElementById("pension").innerHTML = "";
        document.getElementById("salud").innerHTML = "";
        document.getElementById("arl").innerHTML = "";
        document.getElementById("sueldoTotal").innerHTML = "";
    } else {
        let sueldoCalculado = calcularSueldo(valorDia, diasTrabajados); 
        let pen = calcularPension(valorDia, diasTrabajados);
        let salud = calcularSalud(valorDia, diasTrabajados);
        let arl = calcularARL(valorDia, diasTrabajados);
        let desc = pen + salud + arl;
        let sueldoTotal = sueldoCalculado - desc;

        document.getElementById("sueldoAntes").innerHTML = `<strong>Sueldo Inicial: $${sueldoCalculado} </br> Se le Descuenta:</strong>`;
        document.getElementById("pension").innerHTML = `<strong>Pensión: $${pen}</strong>`;
        document.getElementById("salud").innerHTML = `<strong>Salud: $${salud}</strong>`;
        document.getElementById("arl").innerHTML = `<strong>Arl: $${arl}</strong>`;
        document.getElementById("sueldoTotal").innerHTML = `<strong>Sueldo Total: $${sueldoTotal}</strong>`;
        document.getElementById("error").style.display = "none";
    }

    return false; 
}


