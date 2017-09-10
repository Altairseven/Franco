//#region Customs Properties

var jsDate = new Date();
var _day = jsDate.getDate().toString().length > 1 ? jsDate.getDate() : "0" + jsDate.getDate();
var _month = (jsDate.getMonth() + 1) > 9 ? (jsDate.getMonth() + 1) : "0" + (jsDate.getMonth() + 1);
var _year = jsDate.getFullYear();

var _currentDate;
var _currentDateComplete = _day + "/" + _month + "/" + _year;

var insertedPassword;
//#endregion

//#region Implementations

var _permisosEspeciales = {

    //#region VARIABLES
    _vista: 0,
    _fn: 0,
    _object: null,
    _rollBack: new Boolean(),
    _fnToReturn: null,
    _defaultValue: null,
    //#endregion VARIABLES

    //Metodo de inicializacion con parametros
    init: function (vista, funcion, objectName, fnToReturn, defaultValue) {

        // reemplazo los valores de la variables globales con los parametros recibidos
        this._vista = vista;
        this._fn = funcion;
        this._object = objectName;
        this._rollBack = true;
        this._fnToReturn = fnToReturn;
        this._defaultValue = defaultValue;

        // Verifico si el usuario loggueado tiene o no permiso, de no ser asi creo la ventana de usuario/clave (Salvo que el nuevo valor seleccionado es el usuario logueado
        if (this.hasPermission() == false) {

            // No pide version al nuevo valor si este es el id del usuario logueado
            var obj = $("#" + this._object)[0];
            if ($(obj).val() == this._defaultValue) {
                return;
            }

            // crea la ventana de usuario/clave
            this.createDialogPassword();

        }
        else {
            this._rollBack = false;
            _permisosEspeciales.result();
        }
    },

    // Metodo que verifica permisos con el usuario logueado (Parametros: vista/funcion)
    hasPermission: function () {

        var response = new Boolean();

        $.ajax({
            url: '../../PermisosEspeciales/HasPermission?vista=' + this._vista + '&funcion=' + this._fn,
            async: false,
            success: function (data) {
                response = eval(data);
            }
        });

        return response;

    },

    // Metodo que genera la ventana de usuario/clave incluyendo eventos de btn, etc
    createDialogPassword: function () {

        // Limpio div por si existe
        $("#UsuarioClave").remove();

        // Genero div
        $("body").append('<div id="UsuarioClave"></div>');

        // Genero contenido div
        $("#UsuarioClave").append('<div><label for=user" >Usuario</label><input type="text" style="width:250px;float:right" id="user" /><//div>');
        $("#UsuarioClave").append('<br />');
        $("#UsuarioClave").append('<div><label for=pass" >Clave</label><input type="password" style="width:250px;float:right" id="pass" /></div>');
        
        $("#UsuarioClave").append('<div style="width:306px;"><button id="validateUser" style="float:right; margin-top:15px">Ingresar</button></div>');

        // Evento click del btn INGRESAR
        $("#validateUser")
            .button()
            .click(function (event) {

                // Validaciones
                if (isEmpty($("#user").val())) {
                    $("#user").css("border-color", "Red");
                    return;
                }

                // Validaciones
                if (isEmpty($("#pass").val())) {
                    $("#pass").css("border-color", "Red");
                    return;
                }

                var url = "../../PermisosEspeciales/ValidateUserPassRol?" +
                    "user=" + $("#user").val() +
                    "&pass=" + $("#pass").val() +
                    "&vista=" + _permisosEspeciales._vista +
                    "&funcion=" + _permisosEspeciales._fn +
                    "&codop=0" +
                    "&numop=0" +
                    "&subsistema=1" +
                    "&concepto=" + "";

                $.ajax({
                    url: url,
                    beforeSend: function () {
                        $("#validateUser span").text("Evaluando..");
                        $("#validateUser").attr("disabled", "disabled");
                    },
                    success: function (response) {

                        $("#validateUser span").text("Ingresar");
                        $("#validateUser").attr("disabled", false);

                        if (response == "true" || response == true || response == "True") {

                            // declaro no hacer rollback
                            _permisosEspeciales._rollBack = false;

                            $("#UsuarioClave").dialog('close');

                        } else {

                            // declaro hacer rollback
                            _permisosEspeciales._rollBack = true;

                            _showError("Usted no posee suficientes permisos");
                            return;

                        }

                    }
                });

            });

        // Evento focus usuario
        $("#user").live("focus", function () {
            $(this).css("border-color", "inherit");
        });

        // Evento focus password
        $("#pass").live("focus", function () {
            $(this).css("border-color", "inherit");
        });

        // Declaracion dialogo ventana usuario/clave
        $("#UsuarioClave").dialog({
            autoOpen: false,
            height: 140,
            width: 330,
            resizable: false,
            draggable: false,
            modal: true,
            title: "Ingrese usuario y clave",
            close: function () {

                // Llamada al evento result para evaluar resultados
                _permisosEspeciales.result();

                $("#UsuarioClave").remove();
            }
        });

        // Cierro dialogo
        $("#UsuarioClave").dialog('open');

    },

    // Metodo para evaluacion de resultados
    result: function () {

        // Objeto en cuestion
        var obj = $("#" + this._object)[0];

        // verifico si tiene una fn, como parametro, para ejecutar si el resultado es positivo
        if (isEmpty(_permisosEspeciales._fnToReturn) == false) {

            // Verifico si debo hacer rollback
            if (_permisosEspeciales._rollBack) {

                // * //

                // Config. de SELECT
                if ($(obj).is("select")) {

                    if (_permisosEspeciales._defaultValue == null) {
                        $(obj).val(0);
                    }
                    else {
                        $(obj).val(_permisosEspeciales._defaultValue);
                    }

                }

                // Config. de CHECKBOX
                else if ($(obj).is("checkbox")) {
                    $(obj).attr("checked", false);
                }

                // Config. de DIALOG
                else if ($(obj).is(':data(dialog)')) {
                    $(obj).dialog("close");
                }

                // Config. de TEXTBOX
                else if ($(obj).is(':text')) {
                    if (_permisosEspeciales._defaultValue == null) {
                        $(obj).val("");
                    }
                    else {
                        $(obj).val(_permisosEspeciales._defaultValue);
                    }
                }

                return false;
            }
            else {

                // Devuelve fn que recibio como parametro
                return _permisosEspeciales._fnToReturn();
            }

        }

        // * //

        // Config. de SELECT
        if ($(obj).is("select")) {
            if (_permisosEspeciales._rollBack) {
                if (_permisosEspeciales._defaultValue == null) {
                    $(obj).val(0);
                }
                else {
                    $(obj).val(_permisosEspeciales._defaultValue);
                }
            }
        }

        // Config. de CHECKBOX
        else if ($(obj).is("checkbox")) {
            if (_permisosEspeciales._rollBack) {
                $(obj).attr("checked", false);
            }
        }

        // Config. de DIALOG
        else if ($(obj).is(':data(dialog)')) {
            if (_permisosEspeciales._rollBack) {
                $(obj).dialog("close");
            }
            else {

                var index_highest = 0;
                $(".ui-widget-overlay").each(function () {

                    var index_current = parseInt($(this).css("z-index"), 10);

                    if (index_current > index_highest) {
                        index_highest = index_current;
                    }
                });

                $('<div id="_custom_modal_dialog" style="display:none; position: absolute;top: 0;left: 0;width: 100%;height: 100%;' +
                                    'background-color:black;opacity: 0.3; z-index:' + (index_highest + 1) + '"></div>').appendTo("body");

                $("#_custom_modal_dialog").show();

                $(obj).css("z-index", index_highest + 200).dialog("open").bind('dialogbeforeclose', function () { $("#_custom_modal_dialog").remove() });

            }
        }

        else {
            return;
        }

    }

}

var _busquedaCliente = {

    // Variables
    strTextUrl: "",
    strToSearch: "",
    callerUrl: "",
    heightDialog: 400,
    widthDialog: 600,
    titleDialog: "Clientes",

    // Init
    init: function (urlId) {

        //Agregar las nuevas url's
        switch (urlId.toString()) {

            case "1":
                _busquedaCliente.strTextUrl = "Todos los clientes..";
                _busquedaCliente.callerUrl = "../../Cliente/GetFilteredList?searchValue=";
                break;

            case "2":
                _busquedaCliente.callerUrl = "../../Cliente/GetFilteredSoliTarNoRechazo?searchValue=";
                break;

            case "3":
                _busquedaCliente.callerUrl = "../../Cliente/GetFilteredNoBaja?searchValue=";

            default:
                _busquedaCliente.strTextUrl = "Todos los clientes..";
                _busquedaCliente.callerUrl = "../../Cliente/GetFilteredList?searchValue=";
                break;
        }

        // Limpio div por si existe
        $("#BuscadorCliente").remove();

        // Genero div
        $("body").append('<div id="BuscadorCliente"></div>');

        // Genero contenido div
        $("#BuscadorCliente").append('<div id="tablaCliente">' +
            'Valor a buscar:  ' +
            '<input type="text" id="txtbuscarCliente" style="width:450px;" onkeyup="javascript:_busquedaCliente._buscarCliente(this.value, event, this);" tabindex="1" />  ' +
            ' <br /><br />     <hr />     <table style="width: 100%">        ' +
            '<tr>            <th style="width: 50%; text-align:left;" >                Apellido y Nombre            </th> ' +
            '            <th style="width: 30%; text-align:center;" >                Documento            </th> <th style="width: 20%; text-align:center;">                Nro Cliente            </th>        </tr>    </table>    </div>');

        // Declaracion dialogo 
        $("#BuscadorCliente").dialog({
            autoOpen: false,
            height: _busquedaCliente.heightDialog,
            width: _busquedaCliente.widthDialog,
            resizable: false,
            draggable: false,
            modal: true,
            title: _busquedaCliente.titleDialog + (_busquedaCliente.strTextUrl != "" ? " (" + _busquedaCliente.strTextUrl + ")" : ""),
            close: function () {

                $("#BuscadorCliente").remove();
            },
            open: function () { },
            buttons: {
                Cancel: function () {
                    $("#BuscadorCliente").dialog("close");
                }
            }
        });

        $("#BuscadorCliente").dialog("open");

        $("#BuscadorCliente #tablaCliente table tbody tr td.td-field").live("click", function () {
            $("#BuscadorCliente").dialog("close");
        });
    },

    // Metodo de busqueda
    _buscarCliente: function (value, event, src) {

        if (event.keyCode == 13) {

            if ($(src).val() == "" || $(src).val() == null || $(src).val() == undefined) {

                _busquedaCliente._clearTableCliente();

                $("#txtbuscarCliente").attr("disabled", false).attr("class", "");

                $("#txtbuscarCliente").attr("class", "Style1");

                setTimeout(function () {
                    $("#txtbuscarCliente").attr("class", "Style2");
                }, 1250);

                setTimeout(function () {
                    $("#txtbuscarCliente").attr("class", "");
                }, 1750);

                return;
            }

            _busquedaCliente._loading(true);

            _busquedaCliente._clearTableCliente();

            $.ajax({
                url: _busquedaCliente.callerUrl + _busquedaCliente.strToSearch,
                async: true,
                success: function (response) {

                    _busquedaCliente._clearTableCliente();

                    if (response && response.length) {

                        for (var i = 0; i < response.length; i++) {
                            
                            var completeRow = response[i].NOMBRE.split("Ç");

                            var id = completeRow[0];
                            var denomina = completeRow[1];

                            var id_cliente = response[i].ID;
                            var apellido = denomina.split(",")[0];
                            var nombre = denomina.split(",")[1];

                            var cuit = completeRow[2];

                            $("#BuscadorCliente #tablaCliente table tbody").append(
                                '<tr class="tr-field" id="' + id + '" alt="' + id + '" >' +
                                    '<td class="td-field" style="width:250px; text-align:left;" id="' + id + '">' + apellido + " " + nombre + '</td>' +
                                    '<td class="td-field" style="width:150px; text-align:center;" id="' + id + '">' + cuit + '</td>' +
                                    '<td class="td-field" style="width:100px; text-align:center;" id="' + id + '">' + id + '</td>' +
                                '</tr>');

                        }

                    }

                    _busquedaCliente._loading(false);

                }
            });

        } else {

            _busquedaCliente.strToSearch = value;

        }

    },

    // Limpiar tabla cliente
    _clearTableCliente: function () {

        $("#tablaCliente table tbody tr").remove();
        $("#tablaCliente table tbody").append('<tr>            <th style="width:250px; text-align:left;" >                Apellido y Nombre            </th> ' +
            '            <th style="width:150px; text-align:center;" >                Documento            </th> <th style="width:100px; text-align:center;">                Nro Cliente            </th>        </tr>');

    },

    // Limpiar campo de busqueda
    _clearTextFieldCliente: function () {
        $("#txtbuscarCliente").val("");
    },

    // Cargando
    _loading: function (bool) {

        if (bool == true) {
            $("#BuscadorCliente #tablaCliente #txtbuscarCliente")
                .attr("disabled", "disabled")
                .css('background-image', 'url("../../Images/indicator.gif")')
                .css("background-position", "right center")
                .css("background-repeat", "no-repeat")
                .css("background-size", "19px 19px")
                .css("cursor", "pointer")
                ;
        }
        else {
            $("#BuscadorCliente #tablaCliente #txtbuscarCliente")
                .attr("disabled", false)
                .css('background-image', '')
                .css("background-position", "")
                .css("background-repeat", "")
                .css("background-size", "")
                .css("cursor", "")
                ;
        }

    },

    // Cierra dialog 
    closeDialog: function () {

        $("#BuscadorCliente").dialog("close");

    }

}

var exportToXLS = {

    start: function (path) {
        
        var _interval;

        if (path == "" || path == null || path == undefined) {
            _showError("La dirección es obligatoria para poder exportar..");
            return;
        }

        _showLoading("Aguarde", "Exportando archivo..");

        $("#tokenExportID").val(null);

        // Le doy tiempo al showLoading para que pueda levantar..
        setTimeout(function () {

            var token = new Date().getTime();

            $("#tokenExportID").val(token);

            //download file
            window.location.href = path + "&exportParameter=" + token;

            _interval = setInterval(function () {

                var cookieValue = $.cookie("export_file");

                if (cookieValue != undefined) {

                    // El controlador dio un error
                    if (cookieValue.indexOf("BAD") > -1) {

                        clearInterval(_interval);                               // Detengo el loop
                        _hideLoading();                                         // Oculto loading
                        $.removeCookie("export_file");                          // Limpio Cookie
                        _showError("Ha ocurrido un error");                     // Mensaje de aviso
                    }

                    // El controlador dio OK
                    if (cookieValue == token) {

                        clearInterval(_interval);                               // Detengo el loop
                        $.removeCookie("export_file");                          // Limpio Cookie

                        setTimeout(function () {
                            _hideLoading();                                         // Oculto loading
                            _success("Se ha exportado con éxito");                  // Mensaje de aviso
                        }, 1500);
                    }

                    $.removeCookie('export_file');
                }

            }, 1500);

        }, 1000);
    }

}

var openOrdenPago = {

    errorMessage: "Ha ocurrido un error.",
    customDialog: "",

    init: function (codop, numop, nroComprobante) {

        // Validacion CODOP
        if (isEmpty(codop)) {
            _showError(this.errorMessage);
            console.warn("## El parametro obligatorio CODOP es null - OpenOrdenPago. ##");
            console.warn("## El parametro obligatorio CODOP es null - OpenOrdenPago. ##");
            return;
        }

        // Validacion NUMOP
        if (isEmpty(numop)) {
            _showError(this.errorMessage);
            console.warn("## El parametro obligatorio NUMOP es null - OpenOrdenPago. ##");
            console.warn("## El parametro obligatorio NUMOP es null - OpenOrdenPago. ##");
            return;
        }

        // Validacion NRO COMPROBANTE
        if (isEmpty(nroComprobante)) {
            _showError(this.errorMessage);
            console.warn("## El parametro obligatorio NRO COMPROBANTE es null - OpenOrdenPago. ##");
            console.warn("## El parametro obligatorio NRO COMPROBANTE es null - OpenOrdenPago. ##");
            return;
        }

        _showLoading();

        for (var i = 0; i < 15; i++) {
            $("#OrdenPagoPartialView").empty().remove();
        }

        // Traigo la partialView y la cargo en divName
        $.ajax({
            url: "../../OrdenPago/OrdenPagoPartialView?numero=" + nroComprobante,
            success: function (response) {

                customDialog = $('<div id="OrdenPagoPartialView"></div>')
                                .html(response)
                                .dialog({
                                    autoOpen: false,
                                    resizable: false,
                                    height: 555,
                                    width: 810,
                                    modal: true,
                                    buttons: {

                                        Imprimir: function () {

                                            openOrdenPago.print(codop, numop, nroComprobante);

                                        },
                                        Salir: function () {

                                            customDialog.dialog("close");

                                        }

                                    },
                                    open: function () {
                                        _hideLoading();
                                    },
                                    close: function (event, ui) {
                                        $("#OrdenPagoPartialView").empty();

                                    }
                                });

                customDialog.dialog("open");

            }

        });
    },

    print: function (codop, numop, nroComprobante) {

        var _params = "";

        //#region op com
        if (codop == "17" || codop == "20") {
            $.ajax({
                url: "../../OrdenPago/GetPagoByComprobante?decNroComprobante=" + nroComprobante,
                async: false,
                success: function (response) {

                    _params += "&dtDesde="; // +$("#txtDesde").val();
                    _params += "&dtFecha="; // +$("#txtHasta").val();
                    _params += "&decIdComercio=" + response;
                    _params += "&decIdSucursal=0";
                    _params += "&decIdZona=0";
                    _params += "&decIdFormaPago=0";
                    _params += "&sucursales=";
                    _params += "&decEntregada=";
                    _params += "&decNumeroOP=" + nroComprobante;
                    var _url = "../../OrdenPago/ExportWithSucursales?" + _params.substring(1, _params.length) + "&format=PDF";

                    window.open(_url, "Orden de Pago", "width=835px, height=525px, scrollbars=yes, status=yes, location=no, directory=no, menubar=no, resizable=yes, toolbar=no");
                }
            });
        }
        //#endregion

        //#region op prov
        if (codop == "38" || codop == "42") {

            _params += "dtDesde=0";
            _params += "&dtFecha=0";
            _params += "&decIdComercio=0";
            _params += "&decIdSucursal=0";
            _params += "&decIdZona=0";
            _params += "&decIdFormaPago=0";
            _params += "&sucursales=" + "";
            _params += "&decEntregada=0";
            _params += "&decNumeroOP=";
            _params += "&codop_numop=" + codop + "_" + numop;
            _params += "&id=" + nroComprobante;

            var _url = "../../Co_ListadoOP/ExportWithSucursales?" + _params.substring(1, _params.length) + "&format=PDF";

            window.open(_url, "Orden de Pago", "width=835px, height=525px, scrollbars=yes, status=yes, location=no, directory=no, menubar=no, resizable=yes, toolbar=no");
        }

        //#endregion

        $.ajax({
            url: '../../ConsultaIntegralComercio/tieneRetenciones?numop=' + numop,
            success: function (dato) {
                if (dato) {
                    var _urlRet = "../../OrdenPago/ExportRetenciones?" + _params.substring(1, _params.length) + "&format=PDF";

                    window.open(_urlRet, "", "width=835px, height=525px, scrollbars=yes, status=yes, location=no, directory=no, menubar=no, resizable=yes, toolbar=no");
                }
            }
        });

    }
}

//asignadole la clase .upperCase a cualquier textbox, transformará el caracter ingresado en mayúscula
$('.upperCase').die().live('input', function (evt) {
    $(this).val(function (_, val) {
        return val.toUpperCase();
    });
});

//asignadole la clase .lowerCase a cualquier textbox, transformará el caracter ingresado en minúscula
$('.lowerCase').die().live('input', function (evt) {
    $(this).val(function (_, val) {
        return val.toLowerCase();
    });
});

//#endregion

//#region Functions

/*******************************************************************************************/
/* metodo generico para mostrar mensajes con errores */
function _showError(msg, height, closeTime, fn) {
    var button = parseFloat(closeTime) == (-1) ? {
        Ok: function () {
            $(this).dialog("close");
            if (fn) {
                fn();
            }
        }
    } : {};
    var _modal = parseFloat(closeTime) == (-1) ? true : false;
    var startHeight = parseFloat(closeTime) == (-1) ? 130 : 75;
    
    errDialog = $('<div></div>')
			        .html(msg)
			        .dialog({
			            autoOpen: false,
			            title: 'Advertencia!!',
			            modal: _modal,
			            resizable: false,
			            height: isEmpty(height) ? startHeight : (startHeight + parseInt(height)),
			            buttons: button
			        });

	errDialog.dialog("open");
	
	if (parseFloat(closeTime) != (-1)) {
		setTimeout(function () { errDialog.dialog('close'); }, isEmpty(closeTime) ? 5500 : closeTime);
	}
    
}

/*******************************************************************************************/
/* metodo generico para mostrar mensajes con exito  */
function _success(msg, height, closeTime) {
    var button = parseFloat(closeTime) == (-1) ? {
        Ok: function () {
            $(this).dialog("close");
        }
    } : {};
    var _modal = parseFloat(closeTime) == (-1) ? true : false;
    var startHeight = parseFloat(closeTime) == (-1) ? 130 : 75;

    successDialog = $('<div></div>')
			        .html(msg)
			        .dialog({
			            autoOpen: false,
			            modal: _modal,
			            resizable: false,
			            title: 'Confirmación!',
			            height: isEmpty(height) ? startHeight : (startHeight + parseInt(height)),
			            buttons: button
			        });

	successDialog.dialog("open");
	if (parseFloat(closeTime) != (-1)) {
		setTimeout(function () { successDialog.dialog('close'); }, isEmpty(closeTime) ? 3000 : closeTime);
	}
}

/*******************************************************************************************/
/* metodo generico para sumar 2 variables  */
function sumar(sum1, sum2) {
    var resultado;
    
    sum1 = parseFloat(sum1);
    sum2 = parseFloat(sum2);

    resultado = sum1 + sum2;
    
    return resultado;
}

/*******************************************************************************************/
/* metodo generico para restar 2 variables  */
function restar(Num1, Num2) {
    var resultado;

    Num1 = parseFloat(Num1);
    Num2 = parseFloat(Num2);

    resultado = Num1 - Num2;

    return resultado;
}

/*******************************************************************************************/
/* limpia los objetos enviados */
function CleanObject(ArrayOfObject) {

    var length = ArrayOfObject.length;

    for (var i = 0; i < length; i++) {

        $(ArrayOfObject[i]).val(null);
    }

}

/*******************************************************************************************/
/* metodo generico para cambiar el estado (value) habilitado o deshabilitado de un array de objetos  */
function StateObjects(ArrayOfObjects, value) {

    var _obj = $(ArrayOfObjects);

    var canDisable = new Boolean();

    var _disabledAttr = "Disabled";

    if (value == 1) {
        canDisable = false;
    }  else if (value == 0) {
        canDisable = true;
    }
    else {
        alert("Se ha encontrado un error en el metodo 'StateObjects'. Valores permitidos: \n 1 - Habilita \n 0 - Deshabilita");
        return;
    }

    _obj.find(':input').each(function () {
        switch (this.type) {

            case 'password':
            case 'text':
            case 'textarea':
            case 'checkbox':
            case 'radio':
            case 'button':
            case 'select-multiple':
            case 'select-one':
            case 'select':
                $(this).attr(_disabledAttr, canDisable);
                break;
        }
    });
          
}

/*******************************************************************************************/
/*Comparar fechas
   se usa para saber si la 1er fecha ingresada es MAYOR a la segunda fecha ingresada.
   De esta manera :
   devuelve TRUE si fecha > fecha2 
   devuelve FALSE si fecha < fecha2 
   devuelve FALSE si fecha = fecha2 */
function mayor(fecha, fecha2) {

    //alert(fecha + " > " + fecha2 + " ?");

    var xMes = fecha.substring(3, 5);
    var xDia = fecha.substring(0, 2);
    var xAnio = fecha.substring(6, 10);
    var yMes = fecha2.substring(3, 5);
    var yDia = fecha2.substring(0, 2);
    var yAnio = fecha2.substring(6, 10);
    if (xAnio > yAnio) {
        return (true);
    } else {
        if (xAnio == yAnio) {
            if (xMes > yMes) {
                return (true);
            }
            if (xMes == yMes) {
                if (xDia > yDia) {
                    return (true);
                } else {
                    return (false);
                }
            } else {
                return (false);
            }
        } else {
            return (false);
        }
    }

}

/*******************************************************************************************/
/*Comparar numeros*/
/*
    - Si el 1er valor es MAYOR al 2do valor, compare devuelve false;
    - Si el 1er valor es MENOR al 2do valor, compare devuelve true,
    - Si el 1er valor es IGUAL al 2do valor, compare devuelve false;
*/
function compare(first, second) {

    var first = parseFloat(first);
    var second = parseFloat(second);

    if (first > second) {
        return false;
    } else if (first < second) {
        return true;
    } else {return false; }
}

/*******************************************************************************************/
/* funcion para limpiar todo tipo de INPUT */
function clear_form_elements(ele) {

    $(ele).find(':input').each(function () {
        switch (this.type) {
            
            case 'password':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            
            case 'checkbox':
            case 'radio':
                this.checked = false;
                break;
            
            case 'select-multiple':
            case 'select-one':
            case 'select':
                $(this).val(0);
                break;
        }
    });

}

/*******************************************************************************************/
/* funcion para seleccionar 0 a todos los select */
function clear_form_select(ele) {

    $(ele).find('select').each(function () {
        $(this).val(0);
    });

}

/*******************************************************************************************/
/*Only Numbers*/
function validateNumbers(evt, canUseDot) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);

    var regex;

    if (canUseDot != null && canUseDot == true) {
        regex = /^[\d.\s]+$/;
    }
    else {
        regex = /^[\d\s]+$/;
    }

    
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

/*******************************************************************************************/
/*Only Numbers, with Minus symbol*/
function validateNegativeNumbers(evt, canUseDot) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);

    var regex;

    if (canUseDot != null && canUseDot == true) {
        regex = /^[\d.\s\-]+$/;
    }
    else {
        regex = /^[\d\s]+$/;
    }


    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

/*******************************************************************************************/
/* Only Numbers, no spaces */
function validateNumbersNoSpaces(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);

    var regex;

    regex = /^[0-9]+$/i;


    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

/*******************************************************************************************/
/* Only Letters */
function validateOnlyLetters(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);

    var regex;

    regex = /^[ñA-Za-z _]*[ñA-Za-z][ñA-Za-z _]*$/;
    
    if (theEvent.keyCode != 32) {
        if (!regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault) theEvent.preventDefault();
        }
    }
    
}

/*******************************************************************************************/
/* Feed DropDownList */
function feedDDL(url, object, defaultValue, disabled, callbackFn) {

    if (disabled == undefined || disabled == null) {
        disabled = true;
    }

    if ($(object).is("select")) {
        
        $(object).empty();

        $(object).append("<option value='0'></option>");

        if ($(object).length) {

            $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //async: false,
                beforeSend: function () {
                    $(object).attr('disabled', 'disabled');
                },
                success: function (response) {

                    //console.log($(object).attr("id") + " " + response.length);

                    for (var i = 0; i < response.length; i++) {

                        var val = response[i].ID;
                        var text = response[i].NOMBRE;

                        $(object).get(0).options[$(object).get(0).options.length] = new Option(text, val);

                    }

                    if (defaultValue != null || defaultValue != "" || defaultValue != undefined) {
                        $(object).val(defaultValue);
                    }
                    if (disabled) {
                        $(object).attr('disabled', false);
                    }

                    if (typeof (callbackFn) === "function") {
                        callbackFn();
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        alert("Object: " + $(object).attr('id') + "\n" + "ErrorCode: " + response.status + "\n " + response.statusText);

                }
            });
        }
        else {
            alert("El objeto " + $(object).attr("id") + " no es de tipo select para llenarlo desde " + url);
            return;
        }
    }
    else {
        alert("El objeto " + $(object).attr("id") + " no es un combo y por ende no puede llenarse con opciones..");
    }
}

function feedDDLUsuarios(url, object, defaultValue) {

    if ($(object).is("select")) {

        $(object).empty();

        $(object).append("<option value='0'></option>");

        if ($(object).length) {

            $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                beforeSend: function () {
                    $(object).attr('disabled', 'disabled');
                },
                success: function (response) {

                    //console.log($(object).attr("id") + " " + response.length);

                    for (var i = 0; i < response.length; i++) {

                        var val = response[i].ID;
                        var text = response[i].Apellido +" " +response[i].Nombre;

                        $(object).get(0).options[$(object).get(0).options.length] = new Option(text, val);

                    }

                    if (defaultValue != null || defaultValue != "" || defaultValue != undefined) {
                        $(object).val(defaultValue);
                    }

                    $(object).attr('disabled', false);

                },
                error: function (response) {
                    if (response.length != 0)
                        alert("Object: " + $(object).attr('id') + "\n" + "ErrorCode: " + response.status + "\n " + response.statusText);

                }
            });
        }
        else {
            alert("El objeto " + $(object).attr("id") + " no es de tipo select para llenarlo desde " + url);
            return;
        }
    }
    else {
        alert("El objeto " + $(object).attr("id") + " no es un combo y por ende no puede llenarse con opciones..");
    }
}
/*******************************************************************************************/
/* Feed DropDownList Multiple */
function feedDDLMultiple(url, objects, defaultValue) {

    // Verifico que la lista de objetos venga con al menos uno
    if (objects && objects.length > 0) {
        
        // Obtengo los datos para llenar los select
        $.ajax({
            url: url,
            //async: false,
            beforeSend: function () {
                $(objects).each(function (i, el) {
                    $("#" + el).attr('disabled', 'disabled');
                    $("#" + el).empty();
                    $("#" + el).append("<option value='0'></option>");
                });
            },
            success: function (response) {

                // recorro los registros devueltos
                for (var i = 0; i < response.length; i++) {

                    var option = '<option value="' + response[i].ID + '">' + response[i].NOMBRE + '</option>';
                    var defaultOption = '<option value="' + response[i].ID + '" selected="selected">' + response[i].NOMBRE + '</option>';

                    for (var j = 0; j < objects.length; j++) {

                        if ($("#" + objects[j]).is("select")) {


                            $("#" + objects[j]).append(option);


                        } else {
                            console.warn("El objeto " + $("#" + objects[j]).attr("id") + " no es un combo y por ende no puede llenarse con opciones..");
                        }
                    }
                }

                if (defaultValue != undefined) {
                    for (var j = 0; j < objects.length; j++) {
                        $("#" + objects[j]).val(defaultValue);
                    }
                }

            },
            complete: function (jqXHR, textStatus) {

                $(objects).each(function (i, el) {
                    $("#" + el).attr('disabled', false);
                });

            },
            error: function (jqXHR, exception) {

                if (jqXHR.status === 0) {
                    console.warn('Not connect.\n Verify Network.');
                } else if (jqXHR.status == 404) {
                    console.warn('Requested page not found. [404]');
                } else if (jqXHR.status == 500) {
                    console.warn('Internal Server Error [500].');
                } else if (exception === 'parsererror') {
                    console.warn('Requested JSON parse failed.');
                } else if (exception === 'timeout') {
                    console.warn('Time out error.');
                } else if (exception === 'abort') {
                    console.warn('Ajax request aborted.');
                } else {
                    console.warn('Uncaught Error.\n' + jqXHR.responseText);
                }

            }
        });

    }

}

/*******************************************************************************************/
/* Feed DropDownList */
function feedEmpresas(object, defaultValue) {

    if ($(object).is("select")) {

        $(object).empty();

        $(object).append("<option value='0'></option>");

        if ($(object).length) {

            $.ajax({
                type: "GET",
                url: "../../Empresa/ListaEmpresas",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                beforeSend: function () {
                    $(object).attr('disabled', 'disabled');
                },
                success: function (response) {

                    //console.log($(object).attr("id") + " " + response.length);

                    for (var i = 0; i < response.length; i++) {

                        var val = response[i].ID;
                        var text = response[i].Nombre;

                        $(object).get(0).options[$(object).get(0).options.length] = new Option(text, val);

                    }

                    if (defaultValue != null || defaultValue != "" || defaultValue != undefined) {
                        $(object).val(defaultValue);
                    }

                    $(object).attr('disabled', false);

                },
                error: function (response) {
                    if (response.length != 0)
                        alert("Object: " + $(object).attr('id') + "\n" + "ErrorCode: " + response.status + "\n " + response.statusText);

                }
            });
        }
        else {
            alert("El objeto " + $(object).attr("id") + " no es de tipo select para llenarlo desde " + url);
            return;
        }
    }
    else {
        alert("El objeto " + $(object).attr("id") + " no es un combo y por ende no puede llenarse con opciones..");
    }
}

/*******************************************************************************************/
/* Método para limpiar una grilla jquery  */
function cleanJqgrid(object) {

    $(object).jqGrid("clearGridData", true).trigger("reloadGrid");

}
/* Feed DropDownList async */
function feedDDLSync(url, object, defaultValue) {

    if ($(object).is("select")) {

        $(object).empty();

        $(object).append("<option value='0'></option>");

        if ($(object).length) {

            $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                beforeSend: function () {
                    $(object).attr('disabled', 'disabled');
                },
                success: function (response) {

                    //console.log($(object).attr("id") + " " + response.length);

                    for (var i = 0; i < response.length; i++) {

                        var val = response[i].ID;
                        var text = response[i].NOMBRE;

                        $(object).get(0).options[$(object).get(0).options.length] = new Option(text, val);

                    }

                    if (defaultValue != null || defaultValue != "" || defaultValue != undefined) {
                        $(object).val(defaultValue);
                    }

                    $(object).attr('disabled', false);

                },
                error: function (response) {
                    if (response.length != 0)
                        alert("Object: " + $(object).attr('id') + "\n" + "ErrorCode: " + response.status + "\n " + response.statusText);

                }
            });
        }
        else {
            alert("El objeto " + $(object).attr("id") + " no es de tipo select para llenarlo desde " + url);
            return;
        }
    }
    else {
        alert("El objeto " + $(object).attr("id") + " no es un combo y por ende no puede llenarse con opciones..");
    }
}
/*******************************************************************************************/
/* Método para validar que un string tenga una cadena válidad como FECHA */
function ValidarFecha(Cadena){
    var Fecha = new String(Cadena)
    var RealFecha= new Date()  
    // Cadena Año
    var Ano = new String(Fecha.substring(Fecha.lastIndexOf("/") + 1, Fecha.length))
    // Cadena Mes  
    var Mes = new String(Fecha.substring(Fecha.indexOf("/") + 1, Fecha.lastIndexOf("/")))
    // Cadena Día  
    var Dia = new String(Fecha.substring(0, Fecha.indexOf("/")))
  
    // Valido el año  
    if (isNaN(Ano) || Ano.length<4 || parseFloat(Ano)<1900){  
        return false  
    }  
    // Valido el Mes  
    if (isNaN(Mes) || parseFloat(Mes)<1 || parseFloat(Mes)>12){  
        return false  
    }  
    // Valido el Dia  
    if (isNaN(Dia) || parseInt(Dia, 10)<1 || parseInt(Dia, 10)>31){  
        return false
    }
    
    var Bisiesto = new Boolean;
    Bisiesto = false;
    if (((parseFloat(Ano) / 4) - parseInt(Ano / 4, 10)) == 0) { Bisiesto = true; }
    if (Mes == 4 || Mes == 6 || Mes == 9 || Mes == 11) {
        if (Dia > 30) {
            return false
        }
    }
    if (Mes == 2 && Bisiesto && Dia > 29) {
        return false
    }
    if (Mes == 2 && !Bisiesto && Dia > 28) {
        return false
    }

  return true
}

/*******************************************************************************************/
/* Funcion para validar */
/* lcImputacion: indica la cuenta contable que se va a verificar que exista */
/* lcCampo: indica donde se deberá escribir la denominación de la cuenta */
/* lcCampo2: (OPCIONAL) indica donde se deberá duplicar la cuenta */
/* lcCampoNom2: (OPCIONAL) indica donde se deberá escribir la denominación de la cuenta duplicada */
function ValidarImputacion(lcImputacion, lcCampo, lcCampo2, lcCampoNom2) {

    lnImputacion = parseFloat(lcImputacion);

    if (lnImputacion == "NaN") { _showError("Cuenta contable inválida."); return false; }

    $.ajax({
        url: '../../PlanCuenta/ObtenerCuentaByCuenta/' + lcImputacion,
        success: function (data) {
            if (data.DENOMINA == "" || data.DENOMINA == null) { _showError("Cuenta contable inexistente."); return false; }
            if (lcCampo != "") {
                $('#' + lcCampo).val(data.DENOMINA);
                if (!(lcCampo2 == "" || lcCampo2 == null))
                {
                    $('#' + lcCampo2).val(lcImputacion);
                    $('#' + lcCampoNom2).val(data.DENOMINA);
                }
                return true;
            }
        },
        error: function (e, err) {
            _showError("Cuenta contable inválida.");
            return false;
        }
    });
}

/*******************************************************************************************/
/* AutoComplete 

    1er objeto es el control de autocomplete
    2do es la url con la cual vas a alimentar el control
*/
function feedAutoCompleteControl(Object, url, fn) {

    Object.autocomplete(url, {
        dataType: 'json',
        parse: function (data) {
            var rows = new Array();
            for (var i = 0; i < data.length; i++) {
                var obj = data[i].Tag;
                rows[i] = { data: obj, value: obj.ID, result: obj.NOMBRE };
            }
            return rows;
        },
        formatItem: function (row, i, max) {
            return row.NOMBRE.toUpperCase();
        },
        width: 300

    }).result(function (event, row) {
        if (fn != null || fn != undefined)
            fn(row.ID);
    });

}

/*******************************************************************************************/
/* funcion para parsear jsonData a Date */
function parseJsonDataToDateObject(Object, data) {

    var parsedDate = new Date(parseInt($.trim(data).substr(6)));
   
        var jsDate = new Date(parsedDate);
        var jsDay = jsDate.getDate();
        var jsMonth = jsDate.getMonth() + 1;

        if (jsDay.toString().length < 2) {
            jsDay = "0" + jsDay;
        }
        if (jsMonth.toString().length < 2) {
            jsMonth = "0" + jsMonth;
        }

        var _date = jsDay + "/" + jsMonth + "/" + jsDate.getFullYear();

        Object.val(_date);

    }

/* fn que devuelve la fecha ya parseada como variable */
function parseJsonDataToDate(data) {

    var jsDate = new Date(new Date(parseInt($.trim(data).substr(6))));
    var jsDay = jsDate.getDate();
    var jsMonth = jsDate.getMonth() + 1;

    if (jsDay.toString().length < 2) {
        jsDay = "0" + jsDay;
    }
    if (jsMonth.toString().length < 2) {
        jsMonth = "0" + jsMonth;
    }

    var _date = jsDay + "/" + jsMonth + "/" + jsDate.getFullYear();

    return _date;

}

/*******************************************************************************************/
/* función para validar números de CUIT */
function ValidarCuit(inputValor) {
        inputString = inputValor.toString()
        if (inputString.length == 11) {
            var Caracters_1_2 = inputString.charAt(0) + inputString.charAt(1)
            if (Caracters_1_2 == "20" || Caracters_1_2 == "23" || Caracters_1_2 == "24" || Caracters_1_2 == "27" || Caracters_1_2 == "30" || Caracters_1_2 == "33" || Caracters_1_2 == "34") {
                var Count = inputString.charAt(0) * 5 + inputString.charAt(1) * 4 + inputString.charAt(2) * 3 + inputString.charAt(3) * 2 + inputString.charAt(4) * 7 + inputString.charAt(5) * 6 + inputString.charAt(6) * 5 + inputString.charAt(7) * 4 + inputString.charAt(8) * 3 + inputString.charAt(9) * 2 + inputString.charAt(10) * 1
                Division = Count / 11;
                if (Division == Math.floor(Division)) {
                    return true
                }
            }
        }
        return false
    }

/*******************************************************************************************/
/* funcion para hacer que la X de la grilla cierre el formulario */
function closeWithX(TableName) {

    var name = "#gview_" + TableName + " div a span";
    
    $(name).css("background-position"," -31px -192px");

    setTimeout(function () {

        $("#gbox_" + TableName).find(".ui-jqgrid-titlebar-close").bind("click", function () {
            CloseDialog();
        });

    }, 1500);
}

/*******************************************************************************************/
/* Funcion para quitar filtro de la grilla .- */
function clearFilterGrid(TableName, TablePager) {

    var _table = "#" + TableName;
    var _pager = "#" + TablePager;
    var _btn = "#fbox_"+ TableName +"_reset";

    $(_table).jqGrid('navButtonAdd', _pager,
    {
        caption: "",
        title: "Limpiar filtros",
        buttonicon: 'ui-icon-arrowreturnthick-1-w',
        id: "Limpiar",
        onClickButton: function () {

            $(_btn).click();

            /* $("#listaGrupoAfi").jqGrid('setGridParam', { search: false, 
            postData: { "searchField": "", "searchOper": "", "searchString": "" } }).trigger("reloadGrid"); */

            // el nombre del btn presionado se construye asi: "fbox_ + NOMBRE DE TABLA + _reset" .-


        }
    });
    //).navSeparatorAdd(_pager, { sepclass: 'ui-separator', sepcontent: '' });

}

/*******************************************************************************************/
/* Funcion para validar solo letras .- */
function validateWords(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /^[A-z _]+$/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

/*******************************************************************************************/
/* Funcion para quitar filtro de la grilla .- */
function clearFilterWithParent(TableName, TablePager, idElement) {

    var _table = "#" + TableName;
    var _pager = "#" + TablePager;
    var _btn = "#fbox_" + TableName + "_reset";

    $(_table).jqGrid('navButtonAdd', _pager,
    {
        caption: "",
        title: "Limpiar filtros",
        buttonicon: 'ui-icon-arrowreturnthick-1-w',
        id: "Limpiar",
        onClickButton: function () {

            //$(_btn).click();

            if (idElement == null || idElement == undefined) {
                idElement = 0;
            }

            $(_table).jqGrid('setGridParam', { search: false,
                postData: { "searchField": "", "searchOper": "eq", "searchString": "", "id": idElement }
            }).trigger("reloadGrid");

            // el nombre del btn presionado se construye asi: "fbox_ + NOMBRE DE TABLA + _reset" .-


        }
    });
    //).navSeparatorAdd(_pager, { sepclass: 'ui-separator', sepcontent: '' });

}

/*******************************************************************************************/
/* Verificamos los permisos de la persona para realizar una accion determinada en una vista .- */
function hasPermission(vista, funcion) {

    var response = new Boolean();

    $.ajax({
        url: '../../PermisosEspeciales/HasPermission?vista=' + vista + '&funcion=' + funcion,
        async: false,
        success: function (data) {
            response = eval(data); 
        }
    });

    return response;

}

/*******************************************************************************************/
/* Convertir caracteres entity a caracteres html .- */
function convert(str)
{
    return $("<div/>").html(str).text();
}

/*******************************************************************************************/
/*  */
function replaceChar(stringValue) {
    
    var newString = new String();

    for (var i = 0; i < stringValue.length; i++) {

        newString += stringValue[i].replace("&", "®");  
    }

    return newString;

}

/*******************************************************************************************/
/* Esta funcion devuelve true si el valor de una VARIABLE es null y false si no es null */
function isEmpty(value) {
    return typeof value == 'string' && !value.trim() || typeof value == 'undefined' || value == null;
}

/*******************************************************************************************/
/* Funcion para quitar el btn que minimiza la grilla */
function hideMinimizeBtn(GridName) {

    $("#gview_" + GridName + " div a span").parent().hide();

}

/*******************************************************************************************/
/* Esta funcion devuelve 
    true si el valor de una VARIABLE es (true, True, "true", "True") 
   false si el valor de una VARIABLE es (false, False, "false", "False") 
    null si el valor no es boolean
*/
function isTrue(value) {

    if (typeof value == "boolean") {

        if (value == true || value == "true" || value == "True") {
            return true;
        }
        else if (value == false || value == "false" || value == "False") {
        return false;
        }

    }
    else {
        return null;
    }

}

/*******************************************************************************************/
/*Crea el cuil de una persona a partir del sexo y el documento*/
function createCuil(sexo, documento) {
    
    var AB = sexo == 1 ? "20" : "27";

    documento = documento.toString();

    var pad = "00000000";
    documento = pad.substring(0, pad.length - documento.length) + documento;

    var suma;

    var multiplicadores = new Array('3', '2', '7', '6', '5', '4', '3', '2');

    var calculo = ((parseInt(AB.charAt(0)) * 5) + (parseInt(AB.charAt(1)) * 4));

    for (var i = 0; i < 8; i++) {
        calculo += (parseInt(documento.charAt(i)) * parseInt(multiplicadores[i]));
    }

    var resto = (parseInt(calculo)) % 11;

    if (resto == 0) {

        var C = '0';

    } else if (resto == 1) {
        
        if (sexo == 1) {
            var C = '9';
        } else {
            var C = '4';
        }

        AB = '23';

    } else {

        C = 11 - resto;

    }
    
    //Almaceno el CUIL o CUIT en una variable.
    //var cuil_cuit = AB + "-" + documento + "-" + C;
    var cuil_cuit = AB + "" + documento + "" + C;

    return cuil_cuit;
}

/*******************************************************************************************/
/* Descarga archivos YA CREADOS */
function downloadWithName(uri, name) {

    

    // evento del click 
    function eventFire(el, etype) {

        

        //existe el evento?
        if (el.fireEvent) {
            (el.fireEvent('on' + etype));
        } else {
            //Creo el evento
            var evObj = document.createEvent('Events');
            evObj.initEvent(etype, true, false);
            el.dispatchEvent(evObj); // disparo el evento creado
        }
    }

    var link = document.createElement("a");
    link.download = name + ".txt";
    link.href = uri;
    eventFire(link, "click");

}

/*******************************************************************************************/
/* Validaciones de ingreso obligatorio
   Para validar cada campo se deben colocar 2 atributos:
   required="true" : para indicar que es requerido .-
   textName= "Fecha Cierre" : es el nombre que el cliente ve .-
    */
function ValidateForm(containerDiv) {

    var message = function (field) {
        _showError("El campo " + field + " es de ingreso obligatorio");
        return;
    }

    var attributes = {

        required: "required",
        defaultSelectVal: 0,
        defaultBooleanVal: true,
        isSelect: "select",
        isText: "input"

    }

    var save = true;

    var _objList = distinct($('#' + containerDiv + ' [' + attributes.required + '="true"]'));

    for (var i = 0; i < _objList.length; i++) {

        var object = $(_objList[i])[0];
        var textName = $(object).attr("textname");

        if (textName !== undefined) {
            
            if (isEmpty(textName) == true) {

                _showError("El campo " + object.id + " posee la propiedad textName obligatoria VACIA y es obligatorio");
                console.error("El campo " + object.id + " posee la propiedad textName obligatoria VACIA y es obligatorio");
                save = false;
                break;

            }

        } else {

            _showError("El campo " + object.id + " no posee la propiedad textName obligatoria");
            console.error("El campo " + object.id + " no posee la propiedad textName obligatoria");
            save = false;
            break;

        }

        if ($(object).is(attributes.isSelect)) {

            if ($(object).val() == attributes.defaultSelectVal) { message(textName); save = false; break; }

        } else if ($(object).is(attributes.isText)) {

            if (isEmpty($(object).val())) { message(textName); save = false; break; }

        } else {

            console.log("Error Validation form: unknown tpye. \n ElementName: " + object.id);

        }

    }

    if (save) {
        return true;
    }
    else {
        return false;
    }

    function distinct(_array) {
        
        var dupes = {};
        var singles = [];

        $.each(_array, function (i, el) {

            if (!dupes[$(el).attr("textname")]) {
                dupes[$(el).attr("textname")] = true;
                singles.push(el);
            }
        });

        return singles;
    }

}

/*******************************************************************************************/
/* funciones para mostrar y ocultar el cargando */
function _showLoading(title, message) {

    var html;

    if (!isEmpty(message)) {
        html = '<img src="../../Images/cargando.gif" alt="Cargando" id="imgCargando" style="margin-top:-4px; margin-left:118px;" /><br />' + 
                '<center><span>' + message + '</span></center>';
    }
    else {
        html = '<img src="../../Images/cargando.gif" alt="Cargando" id="imgCargando" style="margin-top:-4px; margin-left:118px;" /><br />' + 
                '<center><span>Cargando..</span></center>';
    }

    $("#modal-content").append('<div id="_loadingFormDialog"></div>');

    $("#_loadingFormDialog").html(html);

    $("#_loadingFormDialog").dialog({ autoOpen: false, resizable: false, draggable: false, modal: true, zIndex: 10000006, title: title, height: 100, width: 300});

    $("#_loadingFormDialog").dialog("open");

}

function _hideLoading() {

    if ($('#_loadingFormDialog')) {
        $('#_loadingFormDialog').dialog("close");
        $('#_loadingFormDialog').remove();
    }

}

/*******************************************************************************************/
/* Compara dos fechas y devuelve la cantidad de dias de diferencia */
function DaysBetweenDates(t2, t1) { 
    
    var one_day=1000*60*60*24; 

    var x=t1.split("/");     
    var y=t2.split("/");

    var date1=new Date(x[2],(x[1]-1),x[0]);  
    var date2=new Date(y[2],(y[1]-1),y[0]);
    var month1=x[1]-1;
    var month2=y[1]-1;

    var diff = Math.ceil((date2.getTime() - date1.getTime()) / (one_day));

    return diff;
}

/*******************************************************************************************/
/* Esta funcion crea un dialog de los talonarios CON AUTORIZACIÖN .- */
function CreateDialogTalonarios(decIdEmpresa, decIdSucursal, decIdForm, fn, open) {

    if (isEmpty(decIdEmpresa)) {
        _showError("Para obtener los talonarios es requerida la empresa");
        return;
    }

    if (isEmpty(decIdSucursal)) {
        _showError("Para obtener los talonarios es requerida la sucursal");
        return;
    }

    if (isEmpty(decIdForm)) {
        _showError("Para obtener los talonarios es requerido el ID del formulario");
        return;
    }

    if (isEmpty(fn)) {
        _showError("Para obtener los talonarios es requerida la función correspondiente");
        return;
    }

    var functions = {

        createDivContainer: function () {

            $("body").append('<div id="_divTalonarios"></div>');

            var table = '<table>' +
                            '<tr><td>Facturas A</td><td><select id="_slFA" style="max-width: 250px; width: 250px"></select></td></tr>' +
                            '<tr><td>Facturas B</td><td><select id="_slFB" style="max-width: 250px; width: 250px"></select></td></tr>' +
                            '<tr><td>Notas Cred. A</td><td><select id="_slCA" style="max-width: 250px; width: 250px"></select></td></tr>' +
                            '<tr><td>Notas Cred. B</td><td><select id="_slCB" style="max-width: 250px; width: 250px"></select></td></tr>' +
                        '</table>';

            $("#_divTalonarios").html(table);

            $("#_divTalonarios").dialog({
                autoOpen: false,
                resizable: false,
                height: 250,
                width: 368,
                top: 130,
                left: 418,
                hide: 'fold',
                show: 'fold',
                modal: true,
                draggable: false,
                title: "Talonarios",
                buttons: {
                    Aceptar: function () {

                        // guardar los valores de c/u
                        $("#slFA").val($("#_slFA").val());
                        $("#slFB").val($("#_slFB").val());
                        $("#slCA").val($("#_slCA").val());
                        $("#slCB").val($("#_slCB").val());

                        $(this).dialog("close");

                    }
                },
                close: function () {

                    $("#_divTalonarios").remove();
                }
            });

            functions.feedSelect("../../PREDevengamiento/GetListTalonarios?strParametros=" + decIdEmpresa + "Ç" + decIdSucursal + "ÇFA", "#_slFA");
            functions.feedSelect("../../PREDevengamiento/GetListTalonarios?strParametros=" + decIdEmpresa + "Ç" + decIdSucursal + "ÇFB", "#_slFB");
            functions.feedSelect("../../PREDevengamiento/GetListTalonarios?strParametros=" + decIdEmpresa + "Ç" + decIdSucursal + "ÇNCA", "#_slCA");
            functions.feedSelect("../../PREDevengamiento/GetListTalonarios?strParametros=" + decIdEmpresa + "Ç" + decIdSucursal + "ÇNCB", "#_slCB");

            if (open == false) {

                setTimeout(function () {
                    $("#slFA").val($("#_slFA").val());
                    $("#slFB").val($("#_slFB").val());
                    $("#slCA").val($("#_slCA").val());
                    $("#slCB").val($("#_slCB").val());
                }, 1500);

            } else {

                $("#_divTalonarios").dialog("open");
                
            }
        },

        feedSelect: function (url, object) {

            $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                beforeSend: function () {
                    $(object).attr('disabled', 'disabled');
                },
                success: function (response) {


                    if (response.length == 0) {
                        _showError("POR FAVOR COMPLETE LOS TALONARIOS ANTES DE GRABAR UNA OPERACIÓN, NOTIFIQUE A ADMINISTRACION");
                    }

                    for (var i = 0; i < response.length; i++) {

                        var val = response[i].ID;
                        var text = response[i].NOMBRE;

                        if (response.length == 1) {
                            $(object).append('<option value="' + val + '" selected="selected">' + text + '</option>');
                        }
                        else if (response.length > 1) {
                            if (i == 0) {
                                $(object).append('<option value="' + val + '" selected="selected">' + text + '</option>');
                            }
                            else {
                                $(object).append('<option value="' + val + '">' + text + '</option>');
                            }
                        }
                    }

                    $(object).attr('disabled', false);

                },
                error: function (response) {
                    if (response.length != 0)
                        console.log("Object: " + $(object).attr('id') + "\n" + "ErrorCode: " + response.status + "\n " + response.statusText);

                }
            });

        },

        autorization: function () {

            var hasPerm = hasPermission(decIdForm, fn);

            if (!hasPerm && open == true) {

                $("body").append('<div id="UsuarioClave"></div>');

                $("#UsuarioClave").append('<span>Usuario: </span> <input type="text" style="width:251px;" id="user" />');
                $("#UsuarioClave").append('<br />');
                $("#UsuarioClave").append('<span>Clave: </span> <input type="password" style="width:251px;margin-left:11px;" id="pass" />');
                $("#UsuarioClave").append('<hr />');
                $("#UsuarioClave").append('<div style="width:306px;"><button id="validateUser" style="float:right;">Ingresar</button></div>');

                $("#validateUser")
                    .button()
                    .click(function (event) {

                        if (isEmpty($("#user").val())) {
                            $("#user").css("border-color", "Red");
                            return;
                        }

                        if (isEmpty($("#pass").val())) {
                            $("#pass").css("border-color", "Red");
                            return;
                        }

                        var url = "../../PermisosEspeciales/ValidateUserPassRol?user=" + $("#user").val() +
                            "&pass=" + $("#pass").val() +
                            "&vista=" + decIdForm +
                            "&funcion=" + fn +
                            "&codop=0" +
                            "&numop=0" +
                            "&subsistema=1" +
                            "&concepto=" + "Modificación de talonarios por defecto";

                        $.ajax({
                            url: url,
                            beforeSend: function () {
                                $("#validateUser span").text("Evaluando..");
                                $("#validateUser").attr("disabled", "disabled");
                            },
                            success: function (response) {

                                $("#validateUser span").text("Ingresar");
                                $("#validateUser").attr("disabled", false);

                                if (response == "true" || response == true || response == "True") {
                                    $("#UsuarioClave").dialog('close');

                                    functions.createDivContainer();
                                }
                                else {
                                    _showError("Usted no posee permisos para el cambio de talonarios");
                                    return;
                                }

                            }
                        });

                    }
                );

                $("#user").live("focus", function () {
                    $(this).css("border-color", "White");
                });

                $("#pass").live("focus", function () {
                    $(this).css("border-color", "White");
                });

                $("#UsuarioClave").dialog({
                    autoOpen: false,
                    height: 140,
                    width: 330,
                    resizable: false,
                    draggable: false,
                    modal: true,
                    title: "Ingrese usuario y clave",
                    close: function () {
                        $("#UsuarioClave").remove();
                    }
                });

                $("#UsuarioClave").dialog('open');

            }
            else {

                functions.createDivContainer();

            }
        }

    }

    functions.autorization();

}

/*******************************************************************************************/
/* Esta funcion dockea el main modal pasando como parametro el attr id de la view .- */
function dockModal(divName) {

    if ($("#" + divName).length > 0) {
        $("#modal-content")
        .dialog('option', 'position',
            ((screen.width - $("#" + divName).css("width").toString().split("p")[0]) / 2) + "px",
            ((screen.height - $("#" + divName).css("height").toString().split("p")[0]) / 2) + "px");
    }

}

/*******************************************************************************************/
/* Funcion que valida que ninguna columna de la grilla este en modo edicion */
function validateTable(TableName, fn) {

    var response = new Boolean();

    var postdata = $("#" + TableName).getDataIDs(); // obtengo los id de la grilla

    response = true; // se aplica valor por defecto .-

    if ($("#" + TableName + " tbody tr td select").length > 0 || $("#" + TableName + " tbody tr td input[type='text']").length) {

        _showError("No se puede continuar ya que existen columnas en modo edición.");

        response = false;

        return;
    }

    

    if (response) {
        return fn();
    }
    else {
        return;
    }

}

/*******************************************************************************************/
/*Fn que valida que el tamaño de los archivos agregados no exedan determinado limite */
/* 1) Se debe tener en cuenta que los input de tipo FILE se deben llamar file1, file2, etc.-
   2) Los archivos donde se muestran los nombres de los archivos subidos se deben llamar file1_name, file2_name, file3_name, etc  */
function validateUploadedFiles(divFiles, limit, deleteFiles, fn) {

    var canSaveFiles = true;
    var arrayFileName = [];
    var defaultLimitValue = 1000000;
    var defaultLimitText = "1(Mb).";
    var arrayFilesForDelete = [];

    $("#" + divFiles + " input[type='file']").each(function () {
        
        if ($(this)[0].files[0] != undefined && $(this)[0].files[0].size > (isEmpty(limit) ? defaultLimitValue : limit)) {

            

            canSaveFiles = false;
            arrayFileName.push($(this).attr("id").split("e")[1]);
            arrayFilesForDelete.push($(this).attr("id"));
        }

    });

    if (canSaveFiles) {
        return fn();
    }
    else {

        var mensaje;

        mensaje = arrayFileName.length > 1 ? "Los archivos " : "El archivo ";

        for (var i = 0; i < arrayFileName.length; i++) {
            mensaje += '<u>"' + $("#file" + arrayFileName[i] + "_name").val() + '"</u>';

            if (i < (arrayFileName.length - 1)) {
                mensaje += ", ";
            }
        }

        mensaje += (arrayFileName.length > 1 ? " exceden " : " excede ");

        mensaje += "el tamaño permitido " + defaultLimitText;

        if (deleteFiles) {
            for (var i = 0; i < arrayFilesForDelete.length; i++) {
                _deleteFile(arrayFilesForDelete[i]);
            }
        }

        _showError(mensaje, arrayFileName.length + "0", 6000);

        return false;
    }

    function _deleteFile(textName) {
        
        var control =$($("#" + textName)[0]);
        control.replaceWith(control = control.clone(true));
        
        $($("#" + textName + "_name")[0]).val("");

    }
}

/*******************************************************************************************/
/* Validacion de comercio */
/* */
function validateComercio(decIdComercio, objOutId, objOutName, fn) {

    var id = decIdComercio;

    var canReturnFnParam = true;

    if (id == null || id == undefined || id.length <1) {
        objOutName.val("COMERCIO INEXISTENTE");
        canReturnFnParam = false;
    }
    else {

        objOutName.attr("disabled", "disabled");
        objOutName.val("Validando..");

        $.ajax({
            url: '../../Comercios/ExisteComercio?id=' + id,
            async: false,
            success: function (data) {

                if (data == "False" || data == "false" || data == false) {

                    objOutName.val("COMERCIO INEXISTENTE");

                    canReturnFnParam = false;

                } else {

                    $.ajax({
                        url: '../../Comercios/GetEntityById?id=' + id,
                        async: false,
                        success: function (data) {

                            
                            objOutId.val(data.ID);
                            objOutName.val(data.NOMBRE);

                        },
                        error: function (err, e) {
                          
                            canReturnFnParam = false;
                            _showError(err);
                        }
                    });
                }
            },
            error: function (err, e) {

              
                objOutName.val("");

                canReturnFnParam = false;

                _showError(err, e);
            }
        });

    }

    if (canReturnFnParam == true && fn != null) {
        return fn();
    }
    else {
        return;
    }

}

/*******************************************************************************************/
/* Impresion multiple */
/* Se le pasa como parametro una lista de url para que el reporte los pueda renderizar */
function printMultipleReports(arrayList) {
    
    var innerHtml = "";

    innerHtml += '<html><head>' +

                '<meta name="description" content="A&J Sistemas" /> ' +
                '<meta name="keywords" content="A&J Sistemas" /> ' +
                '<meta http-equiv="content-type" content="text/html; charset=utf-8" /> ' +
                '<link rel="shortcut icon" href="../../Images/ico.png" /> ' +

                '<title>Reportes</title><script></script></head><body>';

    for (var i = 0; i < arrayList.length; i++) {

        var url = arrayList[i];

        innerHtml += '<center><h3 style="text-decoration:underline;">Impresión Nº ' + (i + 1) + ' </h3></center>' + 
                        '<iframe id="mainFrame_' + i + '" style="width:100%; height:200%;" src="' + url + '" frameborder="0"></iframe>' + 
                        '<br /><hr />';

    }

    innerHtml += '</body></html>';

    var w = window.open();
    w.document.open();
    w.document.write(innerHtml);
    w.document.close();

}

/*******************************************************************************************/
/* Funcion que convierte un numero con separadores de decimales y miles */
/* Miles: (.) - Decimales: (,)  */
function numberWithCommas(x) {

    var parts = x.toString().indexOf(".") > -1 ? x.toString().split(".") : x.toString().replace(",", ".").split(".");
    
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ".");

    parts[1] == undefined ? (parts[1] = "00") : (parts[1].length == 1 ? parts[1] = parts[1] + "0" : parts[1] = parts[1]);

    return parts.join(",");
}

/*******************************************************************************************/
/* Función que deshace el formato de numberWithCommas y devuelve un Float*/
function revertNumberWithCommas(x) {
    return (x.split('.').join('').split(',').join('.'));
}

/*******************************************************************************************/
/* Función para la busqueda rápida sobre grillas en las vistas */
function quickSearch(input, dataTable, colArray) {
    this.element = input;
    this.table = dataTable;
    this.arrayCol = colArray;
    this.arrayResult = new Array();
    this.index = 0;
    this.initialize = function () {
        
        if (this.element == null) return;

        // Verificaciones sobre la propiedad OBLIGATORIA scrollrows
        var tableName = this.table[0].id;
        if ($("#" + tableName).jqGrid("getGridParam", "scrollrows") == null || $("#" + tableName).jqGrid("getGridParam", "scrollrows") == false) {
            $("#" + tableName).jqGrid("setGridParam", "scrollrows") == true;
        }

        this.element.parent().append("<img src='../../Images/navigate_up.png' id='imgArrowUp'" +
                                            "style='width: 10px; height:10px; margin-top: -17px;margin-left: 94%; display: none;' " +
                                            " onclick='" + this.element[0].name + ".next()' class='quickSearchNavigation' >");

        this.element.parent().append("<img src='../../Images/navigate_down.png' id='imgArrowDown'" +
                                            "style='width: 10px; height:10px; margin-top: -17px;margin-left: 87%; display: none;' " +
                                            " onclick='" + this.element[0].name + ".prev()' class='quickSearchNavigation' >");

        $(this.element).live("keyup", function () {
            
            eval(this.name).keyup(event);
        });

        $(this.element.parent()[0]).live("click", function (event) {
            $(this.children[0]).focus();
        });
    };
    this.keyup = function (e) {

        var valor = this.element[0].value;

        var objectName = this.element[0].name;

        if (isEmpty(valor)) { $("#" + this.element.parent()[0].id + " .quickSearchNavigation").hide('fast'); return; }

        if (e.keyCode == 13) {

            this.arrayResult = [];
            this.index = 0;
            sel = false;
            var tableName = this.table[0].id;

            $("#" + tableName + " tbody tr ").slice(1, $("#" + tableName + " tbody tr ").length).each(function () {
                var row = $(this).find("td");

                for (var i = 0; i < eval(objectName).arrayCol.length; i++) {

                    if ($(row[eval(objectName).arrayCol[i]]).html().split('.').join("").split(',').join("").toLowerCase().indexOf(valor.split('.').join("").split(',').join("").toLowerCase()) > -1) {

                        if (eval(objectName).arrayResult.indexOf($(this).attr("id")) == -1) {
                            eval(objectName).arrayResult.push($(this).attr("id"));
                        }

                    }
                }
            });

            if (eval(objectName).arrayResult.length > 0) {
                $("#" + tableName).jqGrid('setSelection', this.arrayResult[0], false);
            }

            if (eval(objectName).arrayResult.length > 1) {
                $("#" + this.element.parent()[0].id + " .quickSearchNavigation").show('fast');
            }
            else {
                $("#" + this.element.parent()[0].id + " .quickSearchNavigation").hide('fast');
            }

        }

    };
    this.next = function () {

        if (this.index == 0) {
            _showError("No se encuentra el valor previamente");
            return;
        }

        $("#" + this.table[0].id).jqGrid('setSelection', this.arrayResult[this.index - 1], false);

        this.index--;
    };
    this.prev = function () {
        if (this.index == this.arrayResult.length - 1) {
            _showError("No se encuentra el valor posteriormente");
            return;
        }

        $("#" + this.table[0].id).jqGrid('setSelection', this.arrayResult[this.index + 1], false);

        this.index++;
    };
    this.initialize();
}

/*******************************************************************************************/
/* Validacion de Tablas */
/* */
function validateInput(idTable, objOutId, objOutName, urlVerifyExist, urlGetData, errorMessage,tableName) {

    var canReturnFnParam = true;

    if (idTable == null || idTable == undefined || idTable.length < 1) {
        objOutName.val("");
        canReturnFnParam = false;
    }
    else {

        objOutName.val("Validando..");

        $.ajax({
            url: urlVerifyExist + idTable,
            async: false,
            success: function (data) {

                if (data == "False" || data == "false" || data == false) {

                    objOutId.val("");

                    objOutName.val("");

                    _showError(errorMessage);

                    canReturnFnParam = false;

                } else {

                    $.ajax({
                        url: urlGetData + idTable,
                        async: false,
                        success: function (data) {

                            objOutId.val(data.ID);


                            switch (tableName) {
                                case "PERSONAL":
                                    objOutName.val(data.Apellido + " " + data.Nombre);
                                    break;
                                case "CLIENTE":
                                    objOutName.val(data.APELLIDO + " " + data.NOMBRE);
                                    break;
                                case "COMERCIOS":
                                    objOutName.val(data.NOMBRE_FANTASIA);
                                    break;
                                default:
                                    objOutName.val(data.APELLIDO + " " + data.NOMBRE);
                            }

                        },
                        error: function (err, e) {
                            
                            canReturnFnParam = false;
                            _showError(err);
                        }
                    });
                }
            },
            error: function (err, e) {

                objOutName.val("");

                canReturnFnParam = false;

                _showError(err, e);
            }
        });

    }

}


/*CREA UN DIALOG PARA VER LA FOTO DE LAS DISTINTAS PERSONAS */
function viewPersonsPhoto(idPerson,tableName) {

    var nombreArchivo;

    switch (tableName) {

        case "CLIENTE":

            jQuery.ajax({
                type: "GET",
                async: false,
                url: '../../CLIENTE/GetEntityById?id=' + idPerson,
                success: function (data) {
                    nombreArchivo = data.DOCUMENTO + "_" + data.SEXO;
                }
            });

            break;

        case "AUTORIZADOS_CLI":

            jQuery.ajax({
                type: "GET",
                async: false,
                url: '../../AutorizadosCliente/GetEntityById?id=' + idPerson,
                success: function (data) {
                    nombreArchivo = data.DOCUMENTO + "_" + data.SEXO;
                }
            });

            break;

        case "AUTORIZADOS_COMERCIO":

            jQuery.ajax({
                type: "GET",
                async: false,
                url: '../../AutorizadosComercio/GetEntityById?id=' + idPerson,
                success: function (data) {
                    nombreArchivo = data.DOCUMENTO + "_" + data.SEXO;
                }
            });

            break;

        case "PERSONAL":

            jQuery.ajax({
                type: "GET",
                async: false,
                url: '../../Usuarios/GetUserById?id=' + idPerson,
                success: function (data) {

                    var sexo;

                    if (data.Sexo == "H") {
                        sexo = "1";
                    } else {
                        sexo = "2";
                    }

                    nombreArchivo = data.Documento + "_" + sexo;
                }
            });

            break;

        default:

    }

    $("#modal-content").append('<div id="dialog_view_photo" style="display:none"><img id="imgPhoto" /></div>');

    $("#dialog_view_photo").dialog({
        autoOpen: false,
        height: "auto",
        width: "auto",
        resizable: false,
        title: "Foto",
        modal: true

    });

    $.ajax({
        type: "GET",
        async: false,
        url: '../../HuellaFotoFirma/ExistPhoto?fileName=' + nombreArchivo + ".jpg",
        success: function (data) {

            if (data) {

                setTimeout(function () {

                    $("#imgPhoto").removeAttr("src").attr('src', '../../Files/FOTOS/' + nombreArchivo + ".jpg?" + new Date().getTime());

                    setTimeout(function () {

                        _hideLoading();

                        $("#dialog_view_photo").dialog('open');

                    }, 1500);
                }, 100);

            } else {

                _hideLoading();

                _showError("No existe foto para la persona selecionada.");
            }

        }
    });





}

//#endregion

/*******************************************************************************************/
/* Validacion para no permitir signos en alfanumerico */
/* */
function validateAlpha(evt, canUseDot) {

    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    var regexChar = /^[A-z _]+$/;
    key = String.fromCharCode(key);

    var regexNum;

    if (canUseDot != null && canUseDot == true) {
        regexNum = /^[\d.\s]+$/;
    }
    else {
        regexNum = /^[\d\s]+$/;
    }

    if (!regexChar.test(key) && !regexNum.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}


/******************************************************************************************/

/* Selecciona un valor de select mediante el texto del mismo // parametros 1- nombre del select con #, 2- valor texto*/

function selectByText(object, value) {
    
    $(object).find("option").filter(function () {
        return (($(this).val() == value) || ($(this).text() == value))
    }).prop('selected', true);
}

/************************************************************************/


/*******************************************************************************************/
/* Funcion que agrega un buscador de productos simple en el paginador de la grilla.- */
function lectorBarras(TableName, TablePager, _successFunction) {

    var _table = "#" + TableName;
    var _pager = "#" + TablePager;

    $(_pager + "_left table tbody tr #txtCodigoBarra").remove()
    $(_pager + "_left table tbody tr").append("<td><input  type='text' id='txtCodigoBarra'  placeholder='Ingrese código...' /></td>");

    $("#txtCodigoBarra").die();

    $("#txtCodigoBarra").live('keypress', function (event) {

        if (event.charCode == 13) {
            
            $.ajax({
                url: '../../Producto/GetEntityByCodigo?codigo=' + this.value,
                async: false,
                success: function (data) {
                    
                    $("#txtCodigoBarra").val('');
                    _successFunction(data);

                    if (data.ID == 0) {
                        _showError("Código de producto no encontrado.");
                        $("#txtCodigoBarra").focus();
                        $("#txtCodigoBarra").select();
                    }
                }
            });

        }

    });
}

/************************************************************************/


/*******************************************************************************************/
/* Funcion que llena las fechas de cierre- */
function feedFechaCierre(url, object) {

    $(object).empty();

    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            $(object).get(0).options[$(object).get(0).options.length] = new Option("", 0);

            for (var i = 0; i < response.length; i++) {

                var val = response[i].ID;

                var parsedDate = new Date(parseInt($.trim(response[i].FECHA_CIERRE).substr(6)));

                var text = parsedDate.toLocaleString().substr(0, 9);

                $(object).get(0).options[$(object).get(0).options.length] = new Option(text, val);

            }
        },
        error: function (response) {
            if (response.length != 0)
                alert("Object: " + $(object).attr('id') + "\n" + "ErrorCode: " + response.status + "\n " + response.statusText);

        }
    });

}

/************************************************************************/

/* metodo generico para mostrar mensajes */
function _showMessage(title, msg, height, closeTime) {
    var button = parseFloat(closeTime) == (-1) ? {
        Aceptar: function () {
            $(this).dialog("close");
        }
    } : {};
    var _modal = parseFloat(closeTime) == (-1) ? true : false;
    var startHeight = parseFloat(closeTime) == (-1) ? 130 : 75;

    successDialog = $('<div></div>')
			        .html(msg)
			        .dialog({
			            autoOpen: false,
			            modal: _modal,
			            resizable: false,
			            title: title,
			            height: isEmpty(height) ? startHeight : (startHeight + parseInt(height)),
			            buttons: button
			        });

    successDialog.dialog("open");
    if (parseFloat(closeTime) != (-1)) {
        setTimeout(function () { successDialog.dialog('close'); }, isEmpty(closeTime) ? 3000 : closeTime);
    }
}

/*******************************************************************************************/

/* Funcion que pide una validación de contraseña para continuar- */
function validateUserPass(msg, _successFunction) {

    $("body").append('<div id="_divValidateUser"></div>');

    var _mensaje = "<p>" + msg + "</p>";

    $("#_divValidateUser").html(_mensaje);

    $("#_divValidateUser").append("<input type='password' id='txtValidatePass' />");

    $("#_divValidateUser").dialog({
        autoOpen: false,
        resizable: false,
        height: 200,
        width: 368,
        //        top: 130,
        //        left: 418,
        hide: 'fold',
        show: 'fold',
        modal: true,
        draggable: false,
        title: "Advertencia!!!",
        buttons: {
            Aceptar: function () {

                validatePass();

            },
            Cancelar: function myfunction() {
                $(this).dialog("close");
                $("#_divValidateUser").remove();
            }
        },
        close: function () {

            $("#_divValidateUser").remove();
        }
    });

    $("#txtValidatePass").die();

    $("#txtValidatePass").live('keypress', function (event) {

        if (event.charCode == 13) validatePass();        

    });

    $("#_divValidateUser").dialog('open');

    function validatePass() {

        var _pass = $("#txtValidatePass").val();

        $.ajax({
            url: '../../Personal/ValidatePass?pass=' + _pass,
            async: false,
            success: function (data) {
                
                if (isTrue(data)) {
                    _successFunction();
                    $("#_divValidateUser").dialog("close");
                    $("#_divValidateUser").remove();
                } else {
                    _showError("La contraseña ingresada no es correcta.", null, -1);
                }
            }
        });

        
    }

}

/*******************************************************************************************/

/* AGREGA 0 DELANTE DE UNA CADENA O DE UN NUMERO*/
function paddingZeros(n, length) {
    var str = (n > 0 ? n : -n) + "";
    var zeros = "";
    for (var i = length - str.length; i > 0; i--)
        zeros += "0";
    zeros += str;
    return n >= 0 ? zeros : "-" + zeros;
}

/*******************************************************************************************/

//agrega dias a una fecha    date= fecha con formato dd/mm/yyyy    daystoAdd= dias que se van a agregar a la fecha, numero entero
function AddDays(date, daysToAdd) {

    var date = new Date(date);

    var newdate = new Date(date);

    newdate.setDate(newdate.getDate() + daysToAdd);

    var dd = newdate.getDate();
    var mm = newdate.getMonth() + 1;
    var y = newdate.getFullYear();

    var someFormattedDate = paddingZeros(dd, 2) + '/' + paddingZeros(mm, 2) + '/' + y;

    return someFormattedDate;

}

//Confirma 
function _showQuestion(title, msg, height, closeTime) {

    var button = parseFloat(closeTime) == (-1) ? {
        Si: function () {

            $(this).dialog("close");
            $("#respuesta").val("SI");
        },
        No: function () {
            $(this).dialog("close");
            $("#respuesta").val("NO");
        }

    } : {};
    var _modal = parseFloat(closeTime) == (-1) ? true : false;
    var startHeight = parseFloat(closeTime) == (-1) ? 130 : 75;

    successDialog = $('<div>/div>')
			        .html(msg + "<input type='hidden' id='respuesta' />")
			        .dialog({
			            autoOpen: false,
			            modal: _modal,
			            resizable: false,
			            title: title,
			            height: isEmpty(height) ? startHeight : (startHeight + parseInt(height)),
			            buttons: button
			        });

    successDialog.dialog("open");
    if (parseFloat(closeTime) != (-1)) {
        setTimeout(function () { successDialog.dialog('close'); }, isEmpty(closeTime) ? 3000 : closeTime);
    }
}

/* SETEA CUALQUIER VALOR A BOOLEAN, SEA 1,0,"true","true","False","false",true,false */
function parseBoolean(val) {
    return !!JSON.parse(String(val).toLowerCase());
}

//pinta la fila de color, para mostrar campos anulados de una grilla por ejemplo

function paintRow(table,rowId, color) {
    $('tr:eq(' + (rowId +1) + ')', table).find("td").css("background-color", color);
}

function paintedCell(cellValue, options, rowObject) {
    paintedCell[paintedCell.length] = options.rowId;
    return cellValue;
}

//////////////////////////////////////////////////////////////////////////////////
