$(function () {
    ///llamamos a la función que se encargará de crear los eventos
    ///que nos permitirán controlar cuando se haga una selección en las respectivas listas
    estableceEventosChange();
    ///Carga inicialmente la lista der provincias, ya que es 
    ///la lista con la que iniciaremos.
    cargaDropdownListProvincias();
});

///función que registrará los eventos necesarios para "monitorear"
///cuando se ejecute el método change de las respectivas listas
///Solo se utiliza el cantón y distritos que son producto de la seleccion de la provincia
///en los eventoschange

function estableceEventosChange() {
    ///Evento para cantones
    $("#Id_Provincia").change(function () {
        ///Obtenemos el id de la provincia seleccionada con .val
        var provincia = $("#Id_Provincia").val();
        ///Se llama a la funcion que carga los cantones asociados a la provincia
        cargaDropdownListCantones(provincia);
    });

    ///Evento para distritos
    $("#Id_Canton").change(function () {
        ///Obtenemos el id de canton seleccionada con .val
        var canton = $("#Id_Canton").val();
        ///Se llama a la funcion que carga los distrito asociados a la provincia
        cargaDropdownListDistritos(canton);
    });

}

///carga los registros de las provincias
function cargaDropdownListProvincias() {
    ///dirección a donde se enviarán los datos
    var url = '/Clientes/RetornarProvincias';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            ///Data es el resultado del llamado al metodo del controlador
            ///es el resultado del procedimiento almacenado en formato Json
            procesarResultadoProvincias(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

/*
 * toma el resultado del método RetornaProvincias
 * y lo procesa, recorriendo cada posición
 */
function procesarResultadoProvincias(data) {

    ///Mediante un selector nos posicionamos sobre la lista de provincias
    var ddlProvincias = $("#Id_Provincia");
    ///Limpiamos todas las opciones de la lista de provincias
    ddlProvincias.empty();
    ///Se crea la opcion para la lista que se desplega de provincia
    var nuevaOpcion = "<option value=''>SELECCIONE UNA PROVINCIA</option>";
    ///Se agrega la opcion al dropdownlist
    ddlProvincias.append(nuevaOpcion);
    ///Se empieza a recorrer cada registro
    ///El each es para recorrer el objeto que retorna los datos
    $(data).each(function () {
        ///Se obtiene el objeto de tipo provincia con el uso del this
        ///con esto se accede a las propiedades
        var provinciaActual = this;
        ///Se crea la opcion de lista con el valor del id de la provincia y el nombre en la bd
        ///Se coloca en el value el id de la provincia el cual es el que se ocupa para traer los registros
        ///y se concatena con nombre que es lo que se muestra visualmente
        nuevaOpcion = "<option value='" + provinciaActual.id_Provincia + "'>" + provinciaActual.nombre + "</option>";
        ddlProvincias.append(nuevaOpcion);


    });

}

///carga los registros de los cantones
function cargaDropdownListCantones(pIdProvincia) {

    ///dirección a donde se enviarán los datos
    var url = '/Clientes/RetornarCantones';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Provincia: pIdProvincia
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoCantones(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

///data es lo que retorna el metodo de cargar cantones en el llamado
function procesarResultadoCantones(data) {
    ///Mediante el selector nos posicionamos en la lista de cantones
    var ddlCantones = $("#Id_Canton");
    ddlCantones.empty();
    var nuevaOpcion = "<option value=''>SELECCIONE UN CANTÓN</option>";
    ddlCantones.append(nuevaOpcion);
    $(data).each(function () {
        var cantonActual = this;
        nuevaOpcion = "<option value='" + cantonActual.id_Canton + "'>" + cantonActual.nombre + "</option>";
        ddlCantones.append(nuevaOpcion);

    });

}

function cargaDropdownListDistritos(pIdCanton) {

    ///dirección a donde se enviarán los datos
    var url = '/Clientes/RetornarDistritos';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Canton: pIdCanton
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoDistritos(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

function procesarResultadoDistritos(data) {
    ///Mendiante el selector nos posicionamos en la lista de distritos
    var ddlDistritos = $("#Id_Distrito");
    ddlDistritos.empty();
    var nuevaOpcion = "<option value=''>SELECCIONE UN DISTRITO</option>";
    ddlDistritos.append(nuevaOpcion);
    $(data).each(function () {
        var distritoActual = this;
        nuevaOpcion = "<option value='" + distritoActual.id_Distrito + "'>" + distritoActual.nombre + "</option>";
        ddlDistritos.append(nuevaOpcion);

    });

}
