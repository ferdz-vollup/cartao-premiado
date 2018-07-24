<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="PromocaoBesni.admin.inc.footer" %>
<!-- jQuery -->
    <script src="js/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <%-- <script src="js/raphael.min.js"></script>
    <script src="js/morris.min.js"></script>
    <script src="js/morris-data.js"></script>--%>

    <!-- Flot Charts JavaScript -->
    <%-- <script src="js/excanvas.min.js"></script>
    <script src="js/jquery.flot.js"></script>
    <script src="js/jquery.flot.pie.js"></script>
    <script src="js/jquery.flot.resize.js"></script>
    <script src="js/jquery.flot.time.js"></script>
    <script src="js/jquery.flot.tooltip.min.js"></script>
    <script src="js/flot-data.js"></script>--%>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        //AJAX
        function ajaxInit() {
            var req;
            try {
                req = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                try {
                    req = new ActiveXObject("Msxml2.XMLHTTP");
                } catch (ex) {
                    try {
                        req = new XMLHttpRequest();
                    } catch (exc) {
                        alert("Esse browser não tem recursos para uso do Ajax");
                        req = null;
                    }
                }
            }
            return req;
        }

        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
    
        function drawChart() {
            ajax2 = ajaxInit();
            ajax2.open("GET", "../ajax/acoes.aspx?acao=totalSexo&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        var arr = ajax2.responseText.split('|');
                        var data = google.visualization.arrayToDataTable([
                        ['Sexo', 'Quantidade',  { role: "style" }],
                        ['Homens', parseInt(arr[0]), '#3366cc'],
                        ['Mulheres', parseInt(arr[1]), '#dc3912']
                        ]);

                        var options = {
                            title: ''
                        };

                        var chart = new google.visualization.ColumnChart(document.getElementById('piechart'));

                        chart.draw(data, options);
                       // rangeIdade();
                       // totalPorLoja();
                    }
                }
            }
            ajax2.send(null);
        }
    </script>

    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.js"></script>

    <script src="/assets/js/mascara.js"></script>
    <script src="/assets/js/scripts.js"></script>