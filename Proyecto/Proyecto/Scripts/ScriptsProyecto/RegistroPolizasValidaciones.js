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
                requiered: true,
                number: true
            },
            Porcentaje_Cobertura: {
                requiered: true
            },
            Numero_Adicciones: {
                requiered: true,
                number: true
            },
            Monto_Adicciones: {
                requiered: true,
                number: true
            },
            Prima_Antes_Impuestos: {
                requiered: true,
                number: true
            },
            Impuestos: {
                requiered: true
            } ,
            Prima_Final: {
                requiered: true,
                number: true},
        }
    });
}