$(function () {
    
    estableceEventoChangeParaCobertura();
    estableceEventoChangeParaCliente();
    estableceEventoChangeParaMontoAsegurado();
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
        //llamar a la funcion que carga el Cliente
        asignarValorNumeroAdicciones(cliente);
    });
}

function estableceEventoChangeParaMontoAsegurado() {
    //evento change para el dropdownlist de coberturas
    $('#Monto_Asegurado').change(function () {
        //llamar a la funcion que realiza calculos
        RealizarCalculos();
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
    var porcentajeCobertura = $('#Porcentaje_Cobertura').val();
    var numAdicciones = $('#Numero_Adicciones').val();
    var monto = $('#Monto_Asegurado').val();
    //revisar si los campos de Porcentaje_Cobertura y Numero_Adicciones tienen valores para proceder con los calculos
    if (porcentajeCobertura != "" && numAdicciones != "" && monto != "") {
      
        MontoAdicciones(numAdicciones, monto);
        PrimaAntesImpuestos(porcentajeCobertura, $('#Monto_Adicciones').val());
        Impuestos($('#Prima_Antes_Impuestos').val());
        PrimaFinal($('#Prima_Antes_Impuestos').val(), $('#Impuestos').val());
    } else {
        console.log('falta valor')
    }
    
}




function MontoAdicciones(cantidadAdicciones, montoAsegurado)
{
    if (cantidadAdicciones == 1) {
        var montoAdicciones = montoAsegurado * 0.05;
    }
    else if (cantidadAdicciones == 2 || cantidadAdicciones == 3) {
        var montoAdicciones = montoAsegurado * 0.10;
    }
    else {// adicciones >3
        var montoAdicciones = montoAsegurado * 0.15;
    }

    $('#Monto_Adicciones').val(montoAdicciones);
}

function PrimaAntesImpuestos(porcentajeCobertura, montoAdicciones) {
    var primaAntesImpuestos = montoAdicciones * porcentajeCobertura;
    $('#Prima_Antes_Impuestos').val(primaAntesImpuestos);
}

function Impuestos(primaAntesImpuestos) {
    var impuestos = primaAntesImpuestos * 0.13; //13% de impuestos
    $('#Impuestos').val(impuestos);
}

 function PrimaFinal(primaAntesImpuestos, impuestos)
 {
     var primarFinal = parseFloat(primaAntesImpuestos) + parseFloat(impuestos);
     $('#Prima_Final').val(primarFinal);
}