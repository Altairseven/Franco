<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="MVCProyect.Views.Test.List" %>--%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<style type="text/css">
div#container {
    border: #c9e2f4;
    border-style: solid;
    border-width: thin;
    /* size: auto; */
    margin: auto;
    width: fit-content;
    border-radius: 4px;
    padding-right: 1px;
}
div#gbox_TB1 {
    margin: auto;
}



</style>


<script src="../../Scripts/Core/jquery-1.6.2.min.js"></script>
<script src="../../Scripts/Core/jquery-ui-1.8.14.custom.min.js"></script>
<link href="../../Content/css/Core/jquery-ui-1.8.14.custom.css" rel="stylesheet" />
<link href="../../Content/css/Core/ui.jqgrid.css" rel="stylesheet" />
<script src="../../Scripts/Core/grid.locale-es.js"></script>
<script src="../../Scripts/Core/jquery.jqGrid.min.js"></script>
<link href="../../Content/css/Core/ui-timepickercss.css" rel="stylesheet" />

<script src="../../Scripts/Core/jquery.ui.core.js"></script>


<div class="jumbotron">


</div> <!-- Div que contiene la jqgrid-->
    <div id="container" class=" ui-widget">
    <table id="TB1" style="overflow:hidden;"></table>
    <div id="PG1"></div>
</div>

<script type="text/javascript">

    $("#PopUp-Clientes").dialog({
        autoOpen: false,
        height: 150,
        width: 300,
        modal: true,
        resizable: false,
        closeOnEscape: false,
        dialogClass: "popUpClass",
        //                    show: 'slide',
        open: function () {

        },
        beforeClose: function () {
        },
        buttons: [
            {
                id: "btn-Delete",
                text: "Eliminar",
                click: function () {
                    CarpetasCred.DeleteDet();

                }
            },
            {
                id: "btn-Cancel",
                text: "Cancelar",
                click: function () {
                    $("#TB1").jqGrid('resetSelection');
                    CarpetasCred.SelectedID = null;
                    $(this).dialog('close');
                }
            }]
    })



    var TestView = {
        SelectedID: null,


        Grilla: {
            selector: $("#TB1").jqGrid({
                url: "../../Test/GetList",
                datatype: "json",
                colNames: ['ID', 'Nombre', 'Apellido', 'Tipo Documento', 'Documento', 'Localidad', 'Direccion', 'Telefono', 'Celular', 'E-mail'],
                colModel: [
                    { name: 'ID', index: 'ID', width: 50, editable: false },
                    { name: 'Nombre', index: 'Nombre', width: 250, editable: true },
                    { name: 'Apellido', index: 'Apellido', width: 250, editable: true },
                    { name: 'DocNombre', index: 'DocNombre', width: 50, editable: true },
                    { name: 'Documento', index: 'Documento', width: 150, editable: true },
                    { name: 'LocNombre', index: 'LocNombre', width: 250, editable: true },
                    { name: 'Direccion', index: 'Direccion', width: 250, editable: true },
                    { name: 'Telefono', index: 'Telefono', width: 250, editable: true },
                    { name: 'Celular', index: 'Celular', width: 250, editable: true },
                    { name: 'Email', index: 'Email', width: 250, editable: true },
                ],
                rowNum: 10,
                rowList: [10, 50, 100],
                footerrow: false,
                shrinkToFit: false,
                pager: '#PG1',
                sortname: 'Nombre',
                sortorder: "asc",
                width: 920,
                height: 230,
                multiselect: false,
                onSelectRow: function (id) {
                    //debugger
                    TestView.SelectedID = id;
                },
                ondblClickRow: function () {

                }

            }).navGrid("#PG1", {
                edit: true, add: true, del: true, search: true, refresh: true,
                editfunc: function () {
                    TestView.PopupForm.Dialog.dialog('open');
                },
                addfunc: function () {
                    TestView.PopupForm.Dialog.dialog('open');
                }
            },
                {}, //Edit Button Ignorado porque existe "editfunc" arriba
                {}, //AddButton Ignorado porque existe "addfunc" arriba
                {
                    zIndex: 999,
                    url: "../../AE_Carpetas_Crediticias/Delete",
                    closeOnEscape: true,
                    closeAfterDelete: true,
                    //                recreateForm: true,
                    msg: "¿Está seguro que desea eliminar el registro seleccionado? ",
                    afterComplete: function (response) {
                        debugger;
                        if (response.responseText) {
                            if (response.responseText != "")
                                _showError(response.responseText);
                            else
                                _success("El registro ha sido removido correctamente.");
                        }
                    }
                }, { closeAfterSearch: true }),
        },

        PopupForm: {
            Dialog: $("#PopUp-Clientes").dialog({
                autoOpen: false,
                height: 150,
                width: 300,
                modal: true,
                resizable: false,
                closeOnEscape: false,
                dialogClass: "popUpClass",
                //                    show: 'slide',
                open: function () {

                },
                beforeClose: function () {
                },
                buttons: [
                    {
                        id: "btn-Delete",
                        text: "Eliminar",
                        click: function () {
                            CarpetasCred.DeleteDet();

                        }
                    },
                    {
                        id: "btn-Cancel",
                        text: "Cancelar",
                        click: function () {
                            $("#TB1").jqGrid('resetSelection');
                            CarpetasCred.SelectedID = null;
                            $(this).dialog('close');
                        }
                    }]
            })


        }


        

        



    


    


    };

    



    var CustomFuctions = {
        //Sirve para Agregar campos en un select (combobox) de a uno.
        AppendToSelect: function (_HtmlSelectID, _innerhtml, _value) {

            // _HtmlSelectID : id de la etiqueta, con el # y entre comillas
            var select = $(_HtmlSelectID)
            var opt = document.createElement('option');
            opt.innerHTML = _innerhtml;
            opt.value = _value;
            select.append(opt)
        },

        //Llena un select con los datos de una tabla que tenga campos ID y NOMBRE
        //se llama asi.. xq en ayj hicieron una que hace lo mismo y se llama asi
        FeedDLL: function (_url, selector) {

            CustomFuctions.AppendToSelect(selector, "", 0);
            $.ajax({
                type: 'GET',
                async: 'False',
                url: _url,
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        CustomFuctions.AppendToSelect(selector, data[i].Nombre, data[i].id);

                    }

                },
                error: function (xhr, status) {
                    alert('Fire fire ratatatata (FeedDll)');
                }


            });
        }
    }; 



















    $(document).ready(function () {
        CustomFuctions.FeedDLL("../../Tipos_Documento/GetList", "#ID_Tipo_Documento");
    });

</script>

<div id="PopUp-Clientes" class="ui-dialog" title="Clientes" style="overflow: hidden; display: none;">
	<form id="FormClientes" name="Form-Clientes" runat="server" method="post">
	<fieldset style="border-style: none;">
        <div>
        <table id="DatosClientesTb" border="0">
            <tr>
                <td>Nombre:</td>
                <td><input type="text" id="Nombre" value="" style="width: 180px;"/></td>
                <td>Apellido:</td>
                <td><input type="text" id="Apellido" value="" style="width: 180px;"/></td>
            </tr>
            <tr>
                <td>Nombre:</td>
                <td><select id="ID_Tipo_Documento"></select></td>
                <td>Apellido:</td>
                <td><input type="text" id="Documento" value="" style="width: 180px;"/></td>
            </tr>





        
        </table>
        </div>
	</fieldset>
	</form>
</div>