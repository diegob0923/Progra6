///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmClientesModifica").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido



        rules: {
            Cedula: {
                required: true,
                digits: true,
                minlength: 9,
                maxlength: 9
            },
            Genero: {
                required: true

            },
            Fecha_Nacimiento: {
                required: true,
                date: true

            },
            Nombre: {
                required: true,

            },
            Primer_Apellido: {
                required: true,

            },
            Segundo_Apellido: {
                required: true,

            },
            Direccion: {
                required: true,
                minlength: 1,
                maxlength: 100
            },
            Telefono1: {
                required: true,
                digits: true,
                minlength: 8,
                maxlength: 8
            },
            Correo: {
                required: true,
                email: true
            },
            Id_Provincia: {
                required: true

            },
            Id_Canton: {
                required: true
            },
            Id_Distrito: {
                required: true
            },

        }
    });
}