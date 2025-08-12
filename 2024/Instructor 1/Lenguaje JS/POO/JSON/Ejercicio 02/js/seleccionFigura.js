function seleccionFigura() {
    const selecion = document.getElementById("figuraSelecionada").value;
    const solicitudValores = document.getElementById("solicitud-valores");
    switch (selecion) {
        case "selecCuadrado":
            solicitudValores.innerHTML = `
            <div class="col-md-12">
                <input placeholder="Lado del Cuadrado" type="text" 
                class="input form-control" id="txtLadoCuadrado" name="ladoCuadrado"
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
                class="input form-control" id="txtAlturaRectangulo" name="alturaRectangulo"
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>
            <div class="col-md-12">
                <input placeholder="Base Rectángulo" type="text" 
                class="input form-control" id="txtBaseRectangulo" name="baseRectangulo"
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
                class="input form-control" id="txtBaseTriangulo" name="baseTriangulo"
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>
            <div class="col-md-12">
                <input placeholder="Altura Triángulo" type="text" 
                class="input form-control" id="txtAlturaTriangulo" name="alturaTriangulo"
                    pattern="[0-9]+([,\.][0-9]+)?" required>
                <div class="invalid-feedback">
                    ¡CAMPO VACIO!
                </div>
            </div>
            `
            break
    }
}