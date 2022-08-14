$(function () {
    validarRegistroPolizas();
});

function validarRegistroPolizas() {

    $("#frmRegistroPolizas").validate({
        rules: {
            Id_Cobertura: {
                required: true
            },
            Id_Cliente: {
                required: true
            },

            Fecha_Vencimiento: {
                required: true,
                date: true
            },
            Monto_Asegurado: {
                required: true,
                range:[3000000,100000000]
            },
        }   
    });
}