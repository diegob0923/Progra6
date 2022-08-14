///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmInicioSesion").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido

        rules: {
            Usuario: {
                required: true,
                digits: true,
                minlength: 9,
                maxlength: 9
            },
            Contrasena: {
                required: true
            }
        }
    });
}