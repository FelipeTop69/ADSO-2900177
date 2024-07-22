let metalesArreglo = [
    { nombres: 'Celda 1', apellidos: 'Informacion celda 1' },
    { nombres: 'Celda 2', apellidos: 'Informacion celda 2' },
];

document.querySelectorAll('.metales').forEach((metales, index) => {
    metales.addEventListener('click', () => {
        const modalTitle = document.querySelector('.modal-title-metales');
        const modalBody = document.querySelector('.modal-body-metales');
        const data = metalesArreglo[index];
        modalTitle.textContent = data.nombres;
        modalBody.textContent = data.apellidos;
    });
});

let alogenosArreglo = [
    { nombres: 'Celda 3', apellidos: 'Informacion celda 3' },
    { nombres: 'Celda 4', apellidos: 'Informacion celda 4' },
];

document.querySelectorAll('.alogenos').forEach((alogenos, index) => {
    alogenos.addEventListener('click', () => {
        const modalTitle = document.querySelector('.modal-title-alogenos');
        const modalBody = document.querySelector('.modal-body-alogenos');
        const data = alogenosArreglo[index];
        modalTitle.textContent = data.nombres;
        modalBody.textContent = data.apellidos;
    });
});

