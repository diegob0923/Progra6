$(function () {
    obtenerRegistrosAdiccionesCliente();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaAdiccionesClienteLista()
function obtenerRegistrosAdiccionesCliente() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/AdiccionesCliente/RetornaAdiccionesClienteLista'
    var parametros = {};
    var funcion = creaGridKendo;
    ///ejecuta la función $.ajax utilizando un método genérico
    //para no declarar toda la instrucción siempre
    ejecutaAjax(urlMetodo, parametros, funcion);
}
///encargada de crear el grid de kendo y mostrar
//los datos obtenidos al llamar al método
// RetornaAdiccionesClienteLista
function creaGridKendo(data) {

    $("#divKendoGrid").kendoGrid({

        //Asignar la fuente de datos al objeto kendo grid
        dataSource: {
            data: data.resultado,
            pageSize:2
        },
        //El pageable crea paginacion en el grid del reporte
        pageable: true,
        //Es un array
        columns: [
        //Cada columna se agrega por llaves
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Id',
                //Texto del encabezado
                title:'Identificador'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Nombre',
                //Texto del encabezado
                title: 'Nombre de la adicción'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'NombreCompleto',
                //Texto del encabezado
                title: 'Nombre del cliente'
            },
        ],
        //filterable es para filtrar
        filterable: true,
        //toolbar para exportar
        toolbar: ["excel", "pdf"],
        excel: {
            fileName:"Lista de adicciones por cliente.xlsx"
        },
        pdf: {
            fileName: "Lista de adicciones por cliente.pdf",
            author: "Seguros El Equipo del Siglo XXI.",
            creator:"Seguros El Equipo del Siglo XXI.",
            date: new Date(),
        }
    });


}