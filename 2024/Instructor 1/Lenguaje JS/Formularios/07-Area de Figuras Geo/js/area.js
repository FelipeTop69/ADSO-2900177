/*
Función Area - Calcular el area de un cuadrado, rectangulo y trinagulo
Autor: Ruben Felipe Tovar Aviles
Fecha: 17 de junio del 2024
*/

function seleccionFigura() {
    const selecion = document.getElementById("figuraSelecionada").value;
    const solicitudValores = document.getElementById("solicitud-valores");
    switch (selecion) {
        case "selecCuadrado":
            solicitudValores.innerHTML = `
            <div class="col-md-12">
                <input placeholder="Lado del Cuadrado" type="text" 
                class="input form-control" id="txtLadoCuadrado" 
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>`
            break
        case "selecRectangulo":
            solicitudValores.innerHTML = `
            <div class="col-md-12">
                <input placeholder="Altura Rectángulo" type="text" 
                class="input form-control" id="txtAlturaRectangulo"
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>
            <div class="col-md-12">
                <input placeholder="Base Rectángulo" type="text" 
                class="input form-control" id="txtBaseRectangulo"
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>
            `
            break
        case "selecTriangulo":
            solicitudValores.innerHTML = `
            <div class="col-md-12">
                <input placeholder="Base Triángulo" type="text" 
                class="input form-control" id="txtBaseTriangulo"
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>
            <div class="col-md-12">
                <input placeholder="Altura Triángulo" type="text" 
                class="input form-control" id="txtAlturaTriangulo"
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>
            `
            break
    }
}

function areaCuadrado(pLado){
    let lado = pLado;
    let area;
    area = lado * lado;

    return area
}
function areaRectangulo(pAltura, pBase){
    let base = pBase;
    let altura = pAltura;
    let area;
    area = base * altura;

    return area;
}
function areaTriangulo(pAltura, pBase){
    let base = pBase;
    let altura = pAltura;
    let area;
    area = (base * altura)/2;

    return area;
}

function calculoFigura() {
    const selecion = document.getElementById("figuraSelecionada").value;

    switch (selecion) {
        case "selecCuadrado":
            let ladoCuadrado = parseFloat(document.getElementById("txtLadoCuadrado").value);
            const  descripcionC = "Cuadrado"
            if(isNaN(ladoCuadrado)){
                document.getElementById("error").style.display = "block";
                document.getElementById("resultado").innerHTML = "";
            }else{
                let area = areaCuadrado(ladoCuadrado)
                document.getElementById("resultado").innerHTML = `<strong>El area del ${descripcionC} es : ${area}cm\u00b2 </strong>`;
                document.getElementById("error").style.display = "none";
            }
            break
        case "selecRectangulo":
            let alturaRectangulo = parseFloat(document.getElementById("txtAlturaRectangulo").value);
            let baseRectangulo = parseFloat(document.getElementById("txtBaseRectangulo").value);
            const  descripcionR = "Rectangulo"
            if(isNaN(alturaRectangulo) || isNaN(baseRectangulo)){
                document.getElementById("error").style.display = "block";
                document.getElementById("resultado").innerHTML = "";
            }else{
                let area = areaRectangulo(alturaRectangulo,baseRectangulo)
                document.getElementById("resultado").innerHTML = `<strong>El area del ${descripcionR} es : ${area}cm\u00b2 </strong>`;
                document.getElementById("error").style.display = "none";
            }
            break
        case "selecTriangulo":
            let alturaTriangulo = parseFloat(document.getElementById("txtAlturaTriangulo").value);
            let baseTriangulo = parseFloat(document.getElementById("txtBaseTriangulo").value);
            const  descripcionT = "Triangulo"
            if(isNaN(alturaTriangulo) || isNaN(baseTriangulo)){
                document.getElementById("error").style.display = "block";
                document.getElementById("resultado").innerHTML = "";
            }else{
                let area = areaRectangulo(alturaTriangulo,baseTriangulo)
                document.getElementById("resultado").innerHTML = `<strong>El area del ${descripcionT} es : ${area}cm\u00b2 </strong>`;
                document.getElementById("error").style.display = "none";
            }
            break
    }

    return false
}
