$(function () {
    validarRegistroPolizas();
});

function validarRegistroPolizas() {

    $("#frmAdiccionesCliente").validate({
        rules: {
            Monto_Asegurado: {
                required: true,
                range: [3000000, 100000000]

            },
           
        }
    });
}