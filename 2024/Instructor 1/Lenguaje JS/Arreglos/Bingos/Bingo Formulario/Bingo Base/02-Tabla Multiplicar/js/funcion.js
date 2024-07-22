document.addEventListener("DOMContentLoaded", function(){
    
    let tabla = [];
    let mutiplo = [];
    let iteracionTabla;
    let iteracionNumeroMultiplo;
    let numeroTabla;
    let numeroMutiplo;
    let pantallaConsola = "";
    let pantallaDOOM = "";
    

    // Generar Tablas
    for(iteracionTabla = 0; iteracionTabla < 5; iteracionTabla++){
        mutiplo = [];
        numeroTabla = iteracionTabla + 1; 
        for(iteracionNumeroMultiplo = 0; iteracionNumeroMultiplo < 10; iteracionNumeroMultiplo++){
            numeroMutiplo = iteracionNumeroMultiplo + 1;  
            pantallaConsola = numeroTabla * numeroMutiplo;
            mutiplo.push(pantallaConsola);
        }
        tabla.push(mutiplo);

    }
    console.log(tabla)

    // Mostrar Tablas
    for(iteracionTabla = 0; iteracionTabla < tabla.length; iteracionTabla++){
        numeroTabla = iteracionTabla + 1;
        pantallaDOOM += `<div class="accordion-item">`; 
            pantallaDOOM += `<h2 class="accordion-header"">`;
                pantallaDOOM += `<button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTabla${numeroTabla}" aria-expanded="true" aria-controls="collapseTabla${numeroTabla}">`;
                    pantallaDOOM += `Tabala del ${numeroTabla}`;
                pantallaDOOM += `</button>`;
            pantallaDOOM += `</h2>`;
            pantallaDOOM += `<div id="collapseTabla${numeroTabla}" class="accordion-collapse collapse show" data-bs-parent="#accordionExample">`;
                pantallaDOOM += `<div class="accordion-body d-flex flex-column align-items-center">`;
                    for(iteracionNumeroMultiplo = 0; iteracionNumeroMultiplo < 10; iteracionNumeroMultiplo++){
                        numeroMutiplo = iteracionNumeroMultiplo + 1
                        pantallaDOOM += `<h4>${numeroTabla} X ${numeroMutiplo} = ${tabla[iteracionTabla][iteracionNumeroMultiplo]}</h4>`
                    }
                pantallaDOOM += `</div>`;
            pantallaDOOM += `</div>`;
        pantallaDOOM += `<div>`;
        pantallaDOOM += ``
    }
    
    document.getElementById("accordionExample").innerHTML = pantallaDOOM
    

})


/* 
<div class="accordion-item">
    <h2 class="accordion-header">
        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
            Accordion Item #1
        </button>
    </h2>
    <div id="collapseOne" class="accordion-collapse collapse show" data-bs-parent="#accordionExample">
        <div class="accordion-body d-flex flex-column align-items-center gap-1">
            <strong>This is the first item's accordion body.</strong> It is shown by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
        </div>
    </div>
</div>
  */