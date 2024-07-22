let noMetalesArreglo = [
    { nombreElemento: 'Hidrogeno', descripcionElemento: 'El hidrogeno es frio' },
    { nombreElemento: 'Helio', descripcionElemento: 'El hidrogeno es frio' },
    { nombreElemento: 'Carbono', descripcionElemento: 'El hidrogeno es frio' },
    { nombreElemento: 'Meitnerio', descripcionElemento: 'El hidrogeno es frio' },
    { nombreElemento: 'Livermorio', descripcionElemento: 'El hidrogeno es frio' },
    { nombreElemento: 'Fosforo', descripcionElemento: 'El hidrogeno es frio' },
];




document.querySelectorAll('.noMetales').forEach((noMetales, index) => {
    noMetales.addEventListener('click', () => {
        const modalTitle = document.querySelector('.modal-title-no-metales');
        const modalBody = document.querySelector('.modal-body-no-metales');
        const data = noMetalesArreglo[index];
        modalTitle.textContent = data.nombreElemento;
        modalBody.textContent = data.descripcionElemento;
    });
});


