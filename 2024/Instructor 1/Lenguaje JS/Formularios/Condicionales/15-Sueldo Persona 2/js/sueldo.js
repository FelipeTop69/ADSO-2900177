/*
Función Sueldo - Calcular el sueldo de una persona todo incluido
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

function calcularSubsidioTransporte(pValorD, pDiasT){
    const salarioM = 1300000;
    let sueldoCalculado = calcularSueldo(pValorD, pDiasT)
    let subsidioT
    // let subsidioT = calcularSueldo(43333, 30) < salarioM * 2 ? 114000 : 0;
    if(sueldoCalculado < salarioM * 2){
        subsidioT = 114000;
    }else{
        subsidioT = 0;
    }
    return subsidioT
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

function calcularRetencion(pValorD, pDiasT){
    const salarioM = 1300000;
    let sueldoCalculado = calcularSueldo(pValorD, pDiasT)
    let retencion
    // let retencion = calcularSueldo(43333, 30) < salarioM * 4 ? 0 : sueldoP * 0.04;
    if(sueldoCalculado < salarioM * 4){
        retencion = 0;
    }else{
        retencion = sueldoCalculado * 0.04;
    }
    return retencion
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
        document.getElementById("subsidioTransporte").innerHTML = "";
        document.getElementById("pension").innerHTML = "";
        document.getElementById("salud").innerHTML = "";
        document.getElementById("arl").innerHTML = "";
        document.getElementById("retencion").innerHTML = "";
        document.getElementById("sueldoTotal").innerHTML = "";
    } else {
        let sueldoCalculado = calcularSueldo(valorDia, diasTrabajados); 
        let subsidioT = calcularSubsidioTransporte(valorDia, diasTrabajados)
        let pen = calcularPension(valorDia, diasTrabajados);
        let salud = calcularSalud(valorDia, diasTrabajados);
        let arl = calcularARL(valorDia, diasTrabajados);
        let retencion = calcularRetencion(valorDia, diasTrabajados)
        let desc = pen + salud + arl;
        let sueldoTotal = ((sueldoCalculado + subsidioT) - (retencion + desc)).toFixed(0)

        document.getElementById("sueldoAntes").innerHTML = `<strong>El sueldo de la persona antes de procesos era de: $${sueldoCalculado}</strong>`;
        document.getElementById("subsidioTransporte").innerHTML = `<strong>Al subsidio de Transporte se le dio un valor de: $${subsidioT}</strong>`;
        document.getElementById("pension").innerHTML = `<strong>Pensión: $${pen}</strong>`;
        document.getElementById("salud").innerHTML = `<strong>Salud: $${salud}</strong>`;
        document.getElementById("arl").innerHTML = `<strong>Arl: $${arl}</strong>`;
        document.getElementById("retencion").innerHTML = `<strong>Se le hizo una retencion de: $${retencion}</strong>`;
        document.getElementById("sueldoTotal").innerHTML = `<strong>Sueldo Total: $${sueldoTotal}</strong>`;
        document.getElementById("error").style.display = "none";
    }

    return false; 
}


