<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="cartaoPremiado.admin.index" %>

<%@ Register Src="~/admin/inc/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/admin/inc/menu-topo.ascx" TagPrefix="besni" TagName="menuTopo" %>
<%@ Register Src="~/admin/inc/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/admin/inc/footer.ascx" TagPrefix="besni" TagName="footer" %>

<!DOCTYPE html>
<html lang="pt">

<head>
    <besni:head runat="server" ID="head" />
    <style>.xml-btn>*{display:inline-block}</style>
</head>

<body id="bodyInterna">
    <div id="wrapper">

        <!--menu-->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <besni:menuTopo runat="server" ID="menuTopo" />
            <besni:menu runat="server" ID="menu" />
        </nav>

        <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Dashboard</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user-plus fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-right">
                                    <div class="huge" id="contagemCadastros" runat="server"></div>
                                    <div>Clientes participantes</div>
                                </div>
                            </div>
                        </div>
                        <a href="usuarios.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">Ver detalhes</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-barcode fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-right">
                                    <div class="huge" id="contagemCupons" runat="server"></div>
                                    <div>Cupons gerados</div>
                                </div>
                            </div>
                        </div>
                        <a href="cupons.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">Ver detalhes</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-credit-card-alt fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-right">
                                    <div class="huge" id="contagemGastos" runat="server"></div>
                                    <div>Vendidos na promoção</div>
                                </div>
                            </div>
                        </div>
                        <a href="relatorios.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">Ver detalhes</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-instagram fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-right">
                                    <div class="huge" id="contagemInstagram" runat="server"></div>
                                    <div>Fotos do Instagram</div>
                                </div>
                            </div>
                        </div>
                        <a href="instagram.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">Ver detalhes</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <!-- /.row -->
            <div class="row">
                <!-- DIV ÚLTIMOS RESULTADOS -->
                <div class="col-lg-6">
                    <div class="panel panel-default" style="min-height:430px">
                        <div class="panel-heading">
                            <i class="fa fa-university fa-fw"></i> Último sorteio
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="list-group">
                                <a href="http://www.loterias.caixa.gov.br/wps/portal/loterias/landing/federal" target="_blank" title="Conferir na CEF" class="list-group-item">
                                    <strong id="linha1" runat="server"></strong>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <i class="fa fa-gift fa-fw"></i><strong>Número da Sorte Besni</strong>
                                    <span class="pull-right text-muted" id="premioBesni" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>1º</strong> Prêmio
                                    <span class="pull-right text-muted small" id="premio1" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>2º</strong> Prêmio
                                    <span class="pull-right text-muted small" id="premio2" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>3º</strong> Prêmio
                                    <span class="pull-right text-muted small" id="premio3" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>4º</strong> Prêmio
                                    <span class="pull-right text-muted small" id="premio4" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>5º</strong> Prêmio
                                    <span class="pull-right text-muted small" id="premio5" runat="server"></span>
                                </a>
                            </div>
                            <!-- /.list-group -->
                            <a href="ganhadores.aspx" class="btn btn-default btn-block" style="float: left;margin-right:15px;width: 50%;">Veja os ganhadores</a>
                            <div class="xml-btn">
                                <p>Ganhadores</p>
                                <a title="Fazer Download" href="/ajax/acoes.aspx?acao=donwloadGanhadores"><img src="../assets/imagens/ico-excel.png" alt="Fazer Download" style="margin-right:10px" width="34px"></a>
                                <p>Cupons</p>
                                <a title="Fazer Download" href="/ajax/acoes.aspx?acao=donwloadCupons"><img src="../assets/imagens/ico-excel.png" alt="Fazer Download" width="34px"></a>
                            </div>
                        </div>

                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel .chat-panel -->
                </div>
                <!-- /.col-lg-4 -->

                <div class="col-lg-6">
                    <div class="panel panel-default"  style="min-height:430px">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i> Cadastros
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div id="piechart" style="width: 100%; min-height: 341px;"></div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                  <div class="col-lg-6">
                    <div class="panel panel-default"  style="min-height:430px">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i> Idade
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div id="divIdade" style="width: 100%; min-height: 341px;"></div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                   <div class="col-lg-6">
                    <div class="panel panel-default"  style="min-height:430px">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i> Lojas
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div id="divLoja" style="width: 100%; min-height: 341px;"></div>
                           <%-- <center><a href="javascript:void(0);">Ver vendas de todas as lojas</a></center>--%>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-8 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /#page-wrapper -->

    </div>
    <!-- /#wrapper -->

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
       
        function rangeIdade() {
            ajax2 = ajaxInit();
            ajax2.open("GET", "../ajax/acoes.aspx?acao=rangeIdade&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        var arr = ajax2.responseText.split('|');
                        var data = google.visualization.arrayToDataTable([
                        ['Idade', 'Quantidade'],
                        ['18 - 24', parseInt(arr[0])],
                        ['25 - 34', parseInt(arr[1])],
                        ['35 - 44', parseInt(arr[2])],
                        ['45 - 54', parseInt(arr[3])],
                        ['55 - 64', parseInt(arr[4])],
                        ['65+', parseInt(arr[5])]
                        ]);

                        var options = {
                            title: ''
                        };

                        var chart = new google.visualization.PieChart(document.getElementById('divIdade'));

                        chart.draw(data, options);

                        totalPorLoja();
                    }
                }
            }
            ajax2.send(null);
        }

        function totalPorLoja() {
            ajax2 = ajaxInit();
            ajax2.open("GET", "../ajax/acoes.aspx?acao=totalPorLoja&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        var arr = ajax2.responseText.split('|');
                        
                        var data = google.visualization.arrayToDataTable([
                            ['Loja', 'Vendas'],
                            [arr[0], parseInt(arr[1])],
                            [arr[2], parseInt(arr[3])],
                            [arr[4], parseInt(arr[5])],
                            [arr[6], parseInt(arr[7])],
                            [arr[8], parseInt(arr[9])],
                            [arr[10], parseInt(arr[11])],
                            [arr[12], parseInt(arr[13])],
                            [arr[14], parseInt(arr[15])],
                            [arr[16], parseInt(arr[17])],
                            [arr[18], parseInt(arr[19])],
                            [arr[20], parseInt(arr[21])],
                            [arr[22], parseInt(arr[23])],
                            [arr[24], parseInt(arr[25])],
                            [arr[26], parseInt(arr[27])],
                            [arr[28], parseInt(arr[29])],
                            [arr[30], parseInt(arr[31])],
                            [arr[32], parseInt(arr[33])],
                            [arr[34], parseInt(arr[35])],
                            [arr[36], parseInt(arr[37])],
                            [arr[38], parseInt(arr[39])],
                            [arr[40], parseInt(arr[41])],
                            [arr[42], parseInt(arr[43])],
                            [arr[44], parseInt(arr[45])],
                            [arr[46], parseInt(arr[47])],
                            [arr[46], parseInt(arr[49])],
                            [arr[48], parseInt(arr[51])],
                            [arr[50], parseInt(arr[53])],
                            [arr[52], parseInt(arr[55])],
                            [arr[54], parseInt(arr[57])],
                            [arr[56], parseInt(arr[59])],
                            [arr[58], parseInt(arr[61])],
                            [arr[60], parseInt(arr[63])],
                            [arr[62], parseInt(arr[65])],
                            [arr[64], parseInt(arr[67])]
                        ]);

                        var options = {
                            title: ''
                        };

                        var chart = new google.visualization.PieChart(document.getElementById('divLoja'));

                        chart.draw(data, options);
                    }
                }
            }
            ajax2.send(null);
        }

    </script>

</body>

</html>