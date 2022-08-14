///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmCoberturasPolizaInserta").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido

        rules: {
            Nombre: {
                required: true
            },
            Descripcion: {
                required: true,
                minlength: 10,
                maxlength: 1000
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
