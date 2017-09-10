<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestList1.ascx.cs" Inherits="System.Web.Mvc.ViewUserControl" %>

<div>
    <table id="TB1"> teteasdasdasdasd</table>
    <div id="PG1"></div>
</div>

<link href="../../Content/css/Core/ui.jqgrid.css" rel="stylesheet" />
<script src="../../Scripts/Views/CustomFunctions.js"></script>
<script src="../../Scripts/Core/grid.locale-es.js"></script>
<script src="../../Scripts/Core/jquery.jqGrid.min.js"></script>


<script type="text/javascript">

    $("#TB1").jqGrid({
                url: "../../Test/GetList",
                datatype: 'json',
                mtype: 'Get',
                //table header name
                colNames: ['Id', 'Name', 'Phone', 'Address', 'DOB'],
                //colModel takes the data from controller and binds to grid
                colModel: [
                    {
                        key: true,
                        hidden: true,
                        name: 'Id',
                        index: 'Id',
                        editable: true
                    }, {
                        key: false,
                        name: 'DOB',
                        index: 'DOB',
                        editable: true,
                        formatter: 'date',
                        formatoptions: {
                            newformat: 'd/m/Y'
                        }
                    }],

                pager: jQuery('#pager'),
                rowNum: 10,
                rowList: [10, 20, 30, 40],
                height: '100%',
                viewrecords: true,
                caption: 'Jq grid sample Application',
                emptyrecords: 'No records to display',
                jsonReader:
                {
                    root: "rows",
                    page: "page",
                    total: "total",
                    records: "records",
                    repeatitems: false,
                    Id: "0"
                },
                autowidth: true,
                multiselect: false
                //pager-you have to choose here what icons should appear at the bottom
                //like edit,create,delete icons
            });

</script>