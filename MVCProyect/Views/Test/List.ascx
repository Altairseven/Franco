<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="MVCProyect.Views.Test.List" %>--%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<style type="text/css">
/*div#container {
    align-content: center;
}*/
div#gbox_TB1 {
    margin: auto;
}



</style>


<script src="../../Scripts/Core/jquery-1.6.2.min.js"></script>
<link href="../../Content/css/Core/jquery-ui-1.8.14.custom.css" rel="stylesheet" />
<link href="../../Content/css/Core/ui.jqgrid.css" rel="stylesheet" />
<script src="../../Scripts/Core/grid.locale-es.js"></script>
<script src="../../Scripts/Core/jquery.jqGrid.min.js"></script>
<link href="../../Content/css/Core/ui-timepickercss.css" rel="stylesheet" />




<div class="jumbotron">


</div> <!-- Div que contiene la jqgrid-->
    <div id="container" class=" ui-widget">
    <table id="TB1" style="overflow:hidden;"></table>
    <div id="PG1"></div>
</div>

<script type="text/javascript">

    var TestView = {
        SelectedID: null,
        

        Grilla: {
            selector: $("#TB1").jqGrid({
                url: "../../Test/GetList",
                datatype: "json",
                colNames: ['ID', 'Nombre', 'Apellido', 'Tipo Documento', 'Documento','Localidad', 'Direccion', 'Telefono', 'Celular', 'E-mail' ],
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
                    CarpetasCred.PopupForm.Open("Edit");
                },
                addfunc: function () {
                    CarpetasCred.PopupForm.Open("Add");
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
                }, { closeAfterSearch: true }), },


        

        



    


    


    };

    



</script>