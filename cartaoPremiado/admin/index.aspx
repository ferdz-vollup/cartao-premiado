<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="cartaoPremiado.admin.index" %>

<%@ Register Src="~/admin/inc/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/admin/inc/menu-topo.ascx" TagPrefix="besni" TagName="menuTopo" %>
<%@ Register Src="~/admin/inc/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/admin/inc/footer.ascx" TagPrefix="besni" TagName="footer" %>

<!DOCTYPE html>
<html lang="pt">

<head>
    <besni:head runat="server" ID="head" />
    <style>
        .xml-btn > * {
            display: inline-block
        }
    </style>
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
                <div class="col-lg-4 col-md-6">
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
                        <a href="clientes.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">Ver detalhes</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
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
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-credit-card-alt fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-right">
                                    <div class="huge" id="contagemGastos" runat="server">x</div>
                                    <div>Vendidos na promoção</div>
                                </div>
                            </div>
                        </div>
                        <a href="compras.aspx">
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
                    <div class="panel panel-default" style="min-height: 430px">
                        <div class="panel-heading">
                            <i class="fa fa-university fa-fw"></i>Último sorteio
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
                            <a href="ganhadores.aspx" class="btn btn-default btn-block" style="float: left; margin-right: 15px; width: 50%;">Veja os ganhadores</a>
                            <div class="xml-btn">
                                <p>Ganhadores</p>
                                <a title="Fazer Download" href="/ajax/acoes.aspx?acao=donwloadGanhadores">
                                    <img src="../assets/images/ico-excel.png" alt="Fazer Download" style="margin-right: 10px" width="34px"></a>
                                <p>Cupons</p>
                                <a title="Fazer Download" href="/ajax/acoes.aspx?acao=donwloadCupons">
                                    <img src="../assets/images/ico-excel.png" alt="Fazer Download" width="34px"></a>
                            </div>
                        </div>

                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel .chat-panel -->
                </div>
                <!-- /.col-lg-4 -->

                <div class="col-lg-6">
                    <div class="panel panel-default" style="min-height: 430px">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i>Idade
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
                    <div class="panel panel-default" style="min-height: 430px">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i>Cadastros
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div id="divCadastros" style="width: 100%; min-height: 341px;"></div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                 <div class="col-lg-6">
                    <div class="panel panel-default" style="min-height: 430px">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i>Vendas
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div id="divVendas" style="width: 100%; min-height: 341px;"></div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i>Última Atualização
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <a href="javascript:void(0);" class="list-group-item">
                                    <i class="fa fa-gift fa-fw"></i><strong>Planilha</strong>
                                    <span class="pull-right text-muted" id="Span1" runat="server">modelo.csv</span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>Data da Importação</strong>
                                    <span class="pull-right text-muted small" id="Span2" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>Total em Vendas</strong>
                                    <span class="pull-right text-muted small" id="Span3" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>Clientes Importados</strong>
                                    <span class="pull-right text-muted small" id="Span4" runat="server"></span>
                                </a>
                                <a href="javascript:void(0);" class="list-group-item">
                                    <strong>Ticket Médio</strong>
                                    <span class="pull-right text-muted small" id="Span5" runat="server"></span>
                                </a>
                                <%--<a href="javascript:void(0);" class="list-group-item">
                                    <strong>5º</strong> Prêmio
                                    <span class="pull-right text-muted small" id="Span6" runat="server"></span>
                                </a>--%>
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

                        rangeVendas();
                    }
                }
            }
            ajax2.send(null);
        }

        function rangeVendas() {
            ajax2 = ajaxInit();
            ajax2.open("GET", "../ajax/acoes.aspx?acao=rangeVendas&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        var arr = ajax2.responseText.split('|');
                        var data = google.visualization.arrayToDataTable([
                            ['Vendas', 'Vendas', { role: "style" }],
                            ['R$ 250 à R$ 500', parseInt(arr[0]), "#b87333"],
                            ['R$ 501 à R$ 999', parseInt(arr[1]), "silver"],
                            ['+R$ 1.000', parseInt(arr[2]), "gold"]
                        ]);

                        //var options = {
                        //    title: { position: "none" },
                        //    legenda: { position: "none" }
                        //};

                        var chart = new google.visualization.BarChart(document.getElementById('divVendas'));

                        chart.draw(data);

                    }
                }
            }
            ajax2.send(null);
        }
        
    </script>

</body>

</html>
