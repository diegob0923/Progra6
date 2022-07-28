$(function () {
    
    estableceEventoChangeParaCobertura();
    estableceEventoChangeParaCliente();
});

function estableceEventoChangeParaCobertura() {
    //evento change para el dropdownlist de coberturas
    $('#Id_Cobertura').change(function () {
        //obtener valores inputs
        var cobertura = $('#Id_Cobertura').val()//obtiene el valor del parametro value de la etiqueta <select> de coberturas
        
        //llamar a la funcion que carga el porcentajeCobertura
        asignarValorPorcentajeCobertura(cobertura);
        
    });
    
}

function estableceEventoChangeParaCliente() {
  
    $('#Id_Cliente').change(function () {
        //obtener valores inputs

        var cliente = $('#Id_Cliente').val()//obtiene el valor del parametro value de la etiqueta <select> de coberturas
        //llamar a la funcion que carga el porcentajeCobertura
        asignarValorNumeroAdicciones(cliente);
    });
}


function asignarValorPorcentajeCobertura(idCobertura) {
    ///dirección a donde se enviarán los datos
    var url = '/RegistroPolizas/RetornarCoberturaPorID';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        //estos son los parametros que recibe el action del controler
        id_Cobertura: idCobertura
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            //posicionarnos en el input de porcentaje cobertura
            var inputPorcentajeCobertura = $('#Porcentaje_Cobertura');
            //limpiar lista
            inputPorcentajeCobertura.empty();
            //asignar el valor al input
            inputPorcentajeCobertura.val(data.Porcentaje);
            RealizarCalculos();
            
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}


function asignarValorNumeroAdicciones(pIdCliente) {
    ///dirección a donde se enviarán los datos
    var url = '/RegistroPolizas/RetornarNumeroAdicciones';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        //estos son los parametros que recibe el action del controler
        id_Cliente: pIdCliente
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            //posicionarnos en el input de porcentaje cobertura
            var inputNumeroAdicciones = $('#Numero_Adicciones');
            //limpiar lista
            inputNumeroAdicciones.empty();
            //asignar el valor al input
            inputNumeroAdicciones.val(data);
            RealizarCalculos();
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

function RealizarCalculos() {

    if ($('#Porcentaje_Cobertura').val() != "" && $('#Numero_Adicciones').val() != "") {
        console.log('ambos tienen valor')
    } else {
        console.log('falta valor')
    }
    
}