<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="cartaoPremiado.admin.Compras" %>

<%@ Register Src="~/admin/inc/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/admin/inc/menu-topo.ascx" TagPrefix="besni" TagName="menuTopo" %>
<%@ Register Src="~/admin/inc/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/admin/inc/footer.ascx" TagPrefix="besni" TagName="footer" %>

<!DOCTYPE html>
<html lang="pt">

<head>
    <besni:head runat="server" ID="head" />
    <style>
        .input-fitro {
            display: inline-block;
            width: auto;
            vertical-align: middle;
        }

        .vermelho {
            color: #a8272d
        }

        .labelUser {
            display: inline-block
        }

        #mask {
            display: none;
        }
    </style>
</head>

<body id="bodyInterna">

    <div id="mask" style="z-index: 9999; top: 0; left: 0; position: fixed; width: 100%; height: 100%; background-color: rgba(255,255,255,0.6);">
        <div style="position: absolute; margin: auto; top: 0; bottom: 0; left: 0; right: 0; width: 770px; height: 490px">
            <img src="../assets/images/load.gif">
        </div>
    </div>

    <div id="wrapper">

        <!--menu-->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <besni:menuTopo runat="server" ID="menuTopo" />
            <besni:menu runat="server" ID="menu" />
        </nav>

        <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Compras Efetuadas</h1>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default" id="todosUsuarios">
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i>Compras registradas na promoção
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">                                  
                                <label>
                                Filtrar por data:
                                    <select onchange="carregaDtFim(this.value);" runat="server" required name="filtro" id="dtInicio" aria-controls="dataTables-example" class="form-control">
                                    </select>
                                </label>&nbsp;&nbsp;
                                <label>
                                    <select disabled="disabled"<%-- onchange="carregaDatas($('#dtInicio').val(),this.value);"--%> name="filtro" id="dtFim" aria-controls="dataTables-example" class="form-control">
                                        <option value="0">Data de Fim</option>
                                    </select>

                                </label>&nbsp;&nbsp;
                                <label>
                                    <input type="button" value="Filtrar" onclick="carregaDatas($('#dtInicio').val(), $('#dtFim').val(), $('#pagina').val());" /> <%--| <input type="button" value="limpar" onclick="limparFiltro();" />--%>
                                </label>
                                <input type="hidden" id="pagina" value="1" />
                                <%--<label>
                                    Filtrar por CPF:
                                    <input type="text" id="cpf" name="cpf" onblur="filtrarUsuario(this.value);" />
                                    <input type="button" class="btn btn-default" value="Filtrar" onclick="filtrarUsuario($('#cpf').val())" /> | <input type="button" class="btn btn-default" value="limpar" onclick="limparFiltro();" />
                                </label>--%>
                               <label style="float: right; display: none" runat="server" id="imgPlanilha">
                                    <img src="../assets/images/ico-excel.png" class="imagemExcel" title="Exportar para Excel" onclick="exportarCompras($('#dtInicio').val(), $('#dtFim').val())" id="btnEXportar"  alt="Exportar para Excel" style="margin-right:10px;cursor: pointer;"  width="34px">
                                </label>
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th colspan="2" style="text-align: right;"><span id="totalizador2">Total de <strong id="totalizador" runat="server"> 0 </strong> compras cadastradas na promoção</span></th>
                                            <th colspan="2" style="text-align: right;"><span id="totalizador3">Valor total de <strong id="totalizador4" runat="server"> </strong></span></th>
                                        </tr>
                                        <tr>
                                            <%--<th>#</th>--%>
                                            <th>Nome</th>
                                            <th>Valor</th>
                                            <th>Data da Compra</th>
                                            <%--<th style="width: 150px;text-align: center;">Ações</th>--%>
                                        </tr>
                                    </thead>
                                    <tbody id="usuariosCadastrados" runat="server"></tbody>
                                </table>
                                <%--<span id="totalizador" runat="server"></span>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-sm-12">
                    <div class="dataTables_paginate paging_simple_numbers" id="dataTables-example_paginate">
                        <ul class="pagination" id="paginacao" runat="server" >
                            
                        </ul>
                    </div>
                </div>
            
            </div>

        </div>
    </div>


    <div id="dadosUsuario" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Usuário</h4>
                </div>
                <div class="modal-body">
                    <div>
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="text-uppercase vermelho">Dados pessoais</h4>
                                <br>
                            </div>
                        </div>
                        <div>

                            <section id="divUsuario" runat="server">
                            </section>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL CUPOM-->
    <div id="dadosCupom" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Usuário</h4>
                </div>
                <div class="modal-body" style="overflow: hidden;">
                    <div>
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="text-uppercase vermelho">Cupons Enviados</h4>
                                <br>
                            </div>
                        </div>
                        <div>

                            <section id="divCupom" runat="server">
                            </section>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="cuponsUSuario" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Núemro Cupom</th>
                            <th>Ver Cupom</th>
                        </tr>
                    </thead>
                    <tbody id="listaCupons"></tbody>
                </table>
            </div>
        </div>
    </div>

    <script>
        function carregaDtFim(dtInicio) {
            if (dtInicio == 0) {
                $("#imgPlanilha").hide();
                $('#dtFim option[value=0]').attr('selected','selected');
                $("#dtFim").prop("disabled", true);
                return false;
            }
            else {
              //  $('#mask').show();
                ajax2 = ajaxInit();
                ajax2.open("GET", "/ajax/acoes.aspx?acao=carregaDtFim&dtInicio=" + dtInicio + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                          //  $('#mask').hide();
                            $("#dtFim").prop("disabled", false);
                            $('#dtFim').html(ajax2.responseText);
                        }
                    }
                }
                ajax2.send(null);
            }            
        }

        function carregaDatas(dtInicio, dtFim, pagina)
        {
            $('#mask').show();
            $("#dtInicio").prop("disabled", true);
            $("#dtFim").prop("disabled", true);

            ajax2 = ajaxInit();
            ajax2.open("GET", "/ajax/acoes.aspx?acao=carregaComprasFiltrada&dtInicio=" + dtInicio + "&dtFim=" + dtFim + "&pagina=" + pagina + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        
                        MyArray = ajax2.responseText.split("Ø");
                        
                        jQuery("#usuariosCadastrados").html(MyArray[0]);
                        jQuery("#totalizador").html(MyArray[1])
                        jQuery("#paginacao").html(MyArray[2])
                        jQuery("#totalizador4").html(MyArray[3])
                        $("#dtInicio").prop("disabled", false);
                        $("#dtFim").prop("disabled", false);
                        $("#imgPlanilha").show();
                        //$('#dtFim').html(ajax2.responseText);
                        $('#mask').hide();
                    }
                }
            }
            ajax2.send(null);
        }      

        function pagina(pagina) {
            carregaDatas($('#dtInicio').val(), $('#dtFim').val(), pagina);
        }

        function exportarCompras(dtInicio, dtFim) {
            window.location.href = "/ajax/acoes.aspx?acao=exportarCompras&dtInicio=" + dtInicio + "&dtFim=" + dtFim;
        }
    </script>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />
</body>
</html>