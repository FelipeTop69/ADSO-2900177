/*
Funcion Operaciones Basicas
Autor: Ruben Felipe Tovar Aviles
Fecha: 17 de junio del 2024
*/

function operaciones() {
    const numeroUno = parseFloat(document.getElementById("txtNumeroUno").value);
    const numeroDos = parseFloat(document.getElementById("txtNumeroDos").value);
    const selecion = document.getElementById("operacionSelecionada").value;

    if(isNaN(numeroUno) || isNaN(numeroDos) || selecion == ""){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";

    }else{

        let sumar = numeroUno + numeroDos
        let restar = numeroUno - numeroDos;
        let multiplicar = numeroUno * numeroDos;
        let dividir = numeroUno / numeroDos;

        let suma = `Suma: ${sumar} </br>`
        let resta = `Resta: ${restar} </br>`;
        let multiplicacion = `Multiplicación: ${multiplicar} </br>`;
        let division = `División: ${dividir.toFixed(2)} </br>`;

        switch(selecion){
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
        
        document.getElementById("error").style.display = "none";
    }
    return false
}
