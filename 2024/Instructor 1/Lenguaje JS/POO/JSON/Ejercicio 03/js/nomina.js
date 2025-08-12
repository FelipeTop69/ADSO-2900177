function realizarNomina(pDiasTrabajados, pValorDia, pEdadPersona){
    fetch('php/calcular.php',{
        method: 'POST',
        headers: {
            'Content-Type':'application/json'
        },
        body: JSON.stringify({
            diasTrabajadosEnviar: pDiasTrabajados,
            valorDiaEnviar: pValorDia,
            edadPersonaEnviar: pEdadPersona,
        })
    })

    .then(respuesta => respuesta.json())
    .then(data => {
        if(data.error){
            alert(data.error);
        }else{
            document.getElementById('resultadoSueldo').textContent = data.sueldo;
            document.getElementById('resultadoSubTransporte').textContent = data.subTransporte;
            document.getElementById('resultadoPension').textContent = data.pension;
            document.getElementById('resultadoSalud').textContent = data.salud;
            document.getElementById('resultadoARL').textContent = data.arl;
            document.getElementById('resultadoRetencion').textContent = data.retencion;
            document.getElementById('resultadoExtras').textContent = data.extras;
            document.getElementById('resultadoDeducibles').textContent = data.deducibles;
            document.getElementById('resultadoSueldoTotal').textContent = data.sueldoTotal;
        }
    })
    .catch(error => console.log('Error: ', error));
}


document.addEventListener("DOMContentLoaded", function(){
    const formulario = document.getElementById('pagosFormulario');
    formulario.addEventListener('submit', function(event) {
        event.preventDefault(); // Evitar el comportamiento por defecto del formulario (se recargue)
        
        const diasTrabajados = parseFloat(document.getElementById('txtDiasTrabajados').value);
        const valorDia = parseFloat(document.getElementById('txtValorDia').value);
        const edadPersona = parseFloat(document.getElementById('txtEdadPersona').value);

        realizarNomina(diasTrabajados, valorDia, edadPersona);
    });
})
