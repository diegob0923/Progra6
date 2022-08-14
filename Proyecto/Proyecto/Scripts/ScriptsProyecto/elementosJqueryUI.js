$(function () {
    crearElementosJqueryUI();


});

function crearElementosJqueryUI() {

    crearDatePickerCreacion();
    
}

function crearDatePickerFecha() {

    $("#fechaCreacion").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "c-10:c+2",
        dateFormat: "yy/mm/dd"

    });

}


