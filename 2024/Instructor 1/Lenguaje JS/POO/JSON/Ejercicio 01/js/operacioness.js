function realizarOperaciones(pNumeroUno, pNumeroDos, pSeleccion){
    fetch('php/calcular.php',{
        method: 'POST',
        headers: {
            'Content-Type':'application/json'
        },
        body: JSON.stringify({
            numeroUnoEnviar: pNumeroUno,
            numeroDosEnviar: pNumeroDos,
        })
    })

    .then(respuesta => respuesta.json())
    .then(data => {
        if(data.error){
            alert(data.error);
        }else{
            const seleccion = pSeleccion
            let suma = `Suma: ${data.suma} </br>`
            let resta = `Resta: ${data.resta} </br>`;
            let multiplicacion = `Multiplicación: ${data.multiplicacion} </br>`;
            let division
            if(pNumeroDos > pNumeroUno){
                division = `División: ${data.division.toFixed(1)} </br>`;
            }else{
                division = `División: ${data.division.toFixed(0)} </br>`;
            }

            switch(seleccion){
                case "selecSuma":
                    document.getElementById("resultado").innerHTML = `<strong>${suma}</strong>`;
                    break
                case "selecResta":
                    document.getElementById("resultado").innerHTML = `<strong>${resta}</strong>`;
                    break
                case "selecMultiplicacion":
                    document.getElementById("resultado").innerHTML = `<strong>${multiplicacion}</strong>`;
                    break
                case "selecDivision": 
                    document.getElementById("resultado").innerHTML = `<strong>${division}</strong>`;
                    break
                case "selecTodas": 
                    document.getElementById("resultado").innerHTML = `<strong>${suma + resta + multiplicacion + division}</strong>`;
                    break
            }
        }
    })
    .catch(error => console.log('Error: ', error));
}


document.addEventListener("DOMContentLoaded", function(){
    const formulario = document.getElementById('operacionFormulario');
    formulario.addEventListener('submit', function(event) {
        event.preventDefault(); // Evitar el comportamiento por defecto del formulario (se recargue)
        const numeroUno = parseInt(document.getElementById('txtNumeroUno').value);
        const numeroDos = parseInt(document.getElementById('txtNumeroDos').value);
        const seleccion = document.getElementById("operacionSelecionada").value;
        const msgError = document.getElementById("error")
        const cajaResultado = document.getElementById("resultado")
        if(isNaN(numeroUno) || isNaN(numeroDos) || seleccion == ""){
            msgError.style.display = "block";
            msgError.textContent = "Sin Resultados"
            cajaResultado.innerHTML = "";
        }else{
            if(seleccion == "selecDivision" && numeroDos == 0){
                msgError.style.display = "block";
                msgError.textContent = "No se puede dividir por 0"
                cajaResultado.innerHTML = "";
            }else{
                realizarOperaciones(numeroUno, numeroDos, seleccion);
                msgError.style.display = "none";
            }
            
        }
    });
})


