function realizarOperaciones(pLado, pBaseR, pAlturaR, pBaseT, pAlturaT){
    fetch('php/calcular.php',{
        method: 'POST',
        headers: {
            'Content-Type':'application/json'
        },
        body: JSON.stringify({
            ladoEnviar: pLado,
            baseRectanguloEnviar: pBaseR,
            alturaRectanguloEnviar: pAlturaR,
            baseTrianguloEnviar: pBaseT,
            alturaTrianguloEnviar: pAlturaT,
        })
    })

    .then(respuesta => respuesta.json())
    .then(data => {
        if(data.error){
            alert(data.error);
        }else{
            document.getElementById('areaCuadrado').textContent = `${data.cuadrado}cm²`;
            document.getElementById('areaRectangulo').textContent = `${data.rectangulo}cm²`;
            document.getElementById('areaTriangulo').textContent = `${data.triangulo}cm²`;
        }
    })
    .catch(error => console.log('Error: ', error));
}


document.addEventListener("DOMContentLoaded", function(){
    const formulario = document.getElementById('operacionFormulario');
    formulario.addEventListener('submit', function(event) {
        event.preventDefault(); // Evitar el comportamiento por defecto del formulario (se recargue)
        // Cuadrado
        const lado = parseFloat(document.getElementById('txtLadoCuadrado').value);

        // Rectangulo
        const baseR = parseFloat(document.getElementById('txtBaseRectangulo').value);
        const alturaR = parseFloat(document.getElementById('txtAlturaRectangulo').value);

        // Triangulo
        const baseT = parseFloat(document.getElementById('txtBaseTriangulo').value);
        const alturaT = parseFloat(document.getElementById('txtAlturaTriangulo').value);
        realizarOperaciones(lado, baseR, alturaR, baseT, alturaT);
    });
})
