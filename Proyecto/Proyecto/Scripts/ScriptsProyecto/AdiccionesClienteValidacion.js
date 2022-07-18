$(function () {
    validarAdiccionesCliente();
});

function validarAdiccionesCliente() {

    //selector haciendo referencia al form de validación, aplica para insertar y eliminar
    $("#frmAdiccionesCliente").validate({
        rules: {
            Id_Adiccion: {
                required: true,
                number: true
            },
            Id_Cliente: {
                required: true,
                number: true
            }
        }
    });
}