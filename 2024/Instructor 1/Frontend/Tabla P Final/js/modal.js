// Modal Metales Alcalinos
let metalesAlcalinosArreglo = [
    { nombreElemento: 'Celda 1', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 2', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 3', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 4', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 5', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 6', descripcionElemento: 'Lorem' },
];

document.querySelectorAll('.alcalinos').forEach((alcalinos, index) => {
    alcalinos.addEventListener('click', () => {
        const modalTitle = document.querySelector('.modal-title-alcalinos');
        const modalBody = document.querySelector('.modal-body-alcalinos');
        const data = metalesAlcalinosArreglo[index];
        modalTitle.textContent = data.nombreElemento;
        modalBody.textContent = data.descripcionElemento;
    });
});

// Modal Alcalinoterreos
let alcalinoterreosArreglo = [
    { nombreElemento: 'Celda 7', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 8', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 9', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 10', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 11', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 12', descripcionElemento: 'Lorem' },

];

document.querySelectorAll('.alcalinoterreos').forEach((alcalinoterreos, index) => {
    alcalinoterreos.addEventListener('click', () => {
        const modalTitle = document.querySelector('.modal-title-alcalinoterreos');
        const modalBody = document.querySelector('.modal-body-alcalinoterreos');
        const data = alcalinoterreosArreglo[index];
        modalTitle.textContent = data.nombreElemento;
        modalBody.textContent = data.descripcionElemento;
    });
});

// Modal Otros Metales
let otrosMetalesArreglo = [
    { nombreElemento: 'Celda 13', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 14', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 15', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 16', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 17', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 18', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 19', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 20', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 21', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 22', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 23', descripcionElemento: 'Lorem' },
];

document.querySelectorAll('.otrosMetales').forEach((otrosMetales, index) => {
    otrosMetales.addEventListener('click', () => {
        const modalTitle = document.querySelector('.modal-title-otros-metales');
        const modalBody = document.querySelector('.modal-body-otros-metales');
        const data = otrosMetalesArreglo[index];
        modalTitle.textContent = data.nombreElemento;
        modalBody.textContent = data.descripcionElemento;
    });
});

// Modal Metales Transicion
let metalesTransicionArreglo = [
    { nombreElemento: 'Celda 24', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 25', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 26', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 27', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 28', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 29', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 30', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 31', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 32', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 33', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 34', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 35', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 36', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 37', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 38', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 39', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 40', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 41', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 42', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 43', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 44', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 45', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 46', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 47', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 48', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 49', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 50', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 51', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 52', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 53', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 54', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 55', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 56', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 57', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 58', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 59', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 60', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 61', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 62', descripcionElemento: 'Lorem' },
    { nombreElemento: 'Celda 63', descripcionElemento: 'Lorem' },
];

document.querySelectorAll('.metalesTransicion').forEach((metalesTransicion, index) => {
    metalesTransicion.addEventListener('click', () => {
        const modalTitle = document.querySelector('.modal-title-metales-transicion');
        const modalBody = document.querySelector('.modal-body-metales-transicion');
        const data = metalesTransicionArreglo[index];
        modalTitle.textContent = data.nombreElemento;
        modalBody.textContent = data.descripcionElemento;
    });
});
