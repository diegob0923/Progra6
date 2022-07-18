$(function () {
    validarAdicciones();
});

function validarAdicciones() {

    //selector haciendo referencia al form de validación, aplica para insertar y eliminar
    $("#frmAdicciones").validate({
        rules: {
            Nombre: {
                required: true
            },
            Codigo: {
                required: true,
                number:true
            }
        }
    });
}