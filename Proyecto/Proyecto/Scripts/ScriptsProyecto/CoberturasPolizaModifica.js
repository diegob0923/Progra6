///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmCoberturasPolizaModifica").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido

        rules: {
            Nombre: {
                required: true
            },
            Descripcion: {
                required: true,
                minlength: 5,
                maxlength: 100
            },
            Porcentaje: {
                required: true,
                digits: true,
                min: 0.01,
                max: 100
            },
        }
    });
}