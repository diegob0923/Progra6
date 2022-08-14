$(function () {
    obtenerRegistrosPolizasCliente();
});


/// función que obtiene los registros
// del método del controlador
// RetornaAdiccionesClienteLista()
function obtenerRegistrosPolizasCliente() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/RegistroPolizas/RetornaPolizasClienteLista'
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
            pageSize: 2,
            
        },
        //El pageable crea paginación en el grid del reporte
        pageable: true,
        //Es un array
        columns: [
            //Cada columna se agrega por llaves
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Id_Poliza',
                
                //Texto del encabezado
                title: 'Identificador'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Cobertura',
                //Texto del encabezado
                title: 'Cobertura'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field:'Nombre',
                //Texto del encabezado
                title: 'Nombre completo'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Primer_Apellido',
                //Texto del encabezado
                title: 'Primer Apellido'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Segundo_Apellido',
                //Texto del encabezado
                title: 'Segundo Apellido'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Fecha_Vencimiento',
                type: "date", format: "{0:yyyy/MM/dd}",
                //Texto del encabezado
                title: 'Fecha Vencimiento'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Monto_Asegurado',
                //Texto del encabezado
                title: 'Monto Asegurado'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Porcentaje_Cobertura',
                //Texto del encabezado
                title: 'Porcentaje Cobertura'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Numero_Adicciones',
                //Texto del encabezado
                title: 'Numero Adicciones'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Monto_Adicciones',
                //Texto del encabezado
                title: 'Monto Adicciones'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Prima_Antes_Impuestos',
                //Texto del encabezado
                title: 'Prima Antes Impuestos'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Impuestos',
                //Texto del encabezado
                title: 'Impuestos'
            },
            {
                //Propiedad de la fuente de datos a mostrar
                field: 'Prima_Final',
                //Texto del encabezado
                title: 'Prima Final'
            },
        ],
        //filterable es para filtrar
        filterable: true,
        //toolbar para exportar
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Lista de pólizas por cliente.xlsx"
        },
        pdf: {
            fileName: "Lista de pólizas por cliente.pdf",
            author: "Seguros El Equipo del Siglo XXI.",
            creator: "Seguros El Equipo del Siglo XXI.",
            date: new Date(),
        }
    });
}
