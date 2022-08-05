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
            Monto_Asegurado: {
                required: true,
                range: [3000000, 100000000]
            },
            Fecha_Vencimiento: {
                required: true,
                date: true
            },
            Monto_Asegurado: {
                required: true,
                number: true
            },
            Porcentaje_Cobertura: {
                required: true
            },
            Numero_Adicciones: {
                required: true,
                number: true
            },
            Monto_Adicciones: {
                required: true,
                number: true
            },
            Prima_Antes_Impuestos: {
                required: true,
                number: true
            },
            Impuestos: {
                required: true
            } ,
            Prima_Final: {
                required: true,
                number: true},
        }
    });
}