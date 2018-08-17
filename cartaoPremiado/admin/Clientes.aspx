<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="cartaoPremiado.admin.Clientes" %>
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
                    <h1 class="page-header">Clientes Ativos</h1>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default" id="todosUsuarios">
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i>Usuários cadastrados
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                               <%-- <label>
                                    Filtrar:
                                    <select onchange="filtrarUsuario(this.value, $('#cpf').val());" name="filtro" id="fitro" aria-controls="dataTables-example" class="form-control input-sm input-fitro">
                                        <option value="null"></option>
                                        <option value="1">Com produtos</option>
                                        <option value="0">Sem produtos</option>
                                    </select>
                                </label>--%>
                                <label>
                                    Filtrar por CPF:
                                    <input type="text" id="cpf" name="cpf" onblur="filtrarUsuario(this.value);" />
                                    <input type="button" value="Filtrar" onclick="filtrarUsuario($('#cpf').val())" /> | <input type="button" value="limpar" onclick="limparFiltro();" />
                                </label>
                              <!-- <label style="float: right;" runat="server" id="imgPlanilha">
                                    <img src="../assets/imagens/ico-excel.png" class="imagemExcel" onclick="exportarUsuarios(this.id)" id="2"  alt="Fazer Download" style="margin-right:10px;cursor: pointer;"  width="34px">
                                </label>-->
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th colspan="4" style="text-align: right;"><span id="totalizador2">Total de <strong id="totalizador" runat="server"> 0 </strong> clientes ativos na promoção</span></th>
                                        </tr>
                                        <tr>
                                            <%--<th>#</th>--%>
                                            <th>Nome</th>
                                            <th>N.º Cartão</th>
                                            <th>CPF</th>
                                            <th style="width: 150px;text-align: center;">Ações</th>
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
        function verUser(CAD_CPF) {
            ajax2 = ajaxInit();
            ajax2.open("GET", "/admin/Clientes.aspx?acao=verUser&CAD_CPF=" + CAD_CPF, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        jQuery("#divUsuario").html(ajax2.responseText);

                    }
                }
            }
            ajax2.send(null);
        }

        function verCupons(CAD_CPF) {
            ajax2 = ajaxInit();
            ajax2.open("GET", "/ajax/acoes.aspx?acao=verCupons&CAD_CPF=" + CAD_CPF, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        //jQuery("#listaCupons").html(ajax2.responseText);
                        jQuery("#divCupom").html(ajax2.responseText);
                       // console.log(ajax2.responseText)
                    }
                }
            }
            ajax2.send(null);
        }

        function limparFiltro()
        {
            //filtrarUsuario('');
            window.location.replace("clientes.aspx")
        }

        function filtrarUsuario(cpf) {
            
            $('#mask').show();
            if (cpf != "")
            ajax2 = ajaxInit();
            ajax2.open("GET", "/ajax/acoes.aspx?acao=filtrarClientes&cpf=" + cpf, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        
                        if (ajax2.responseText == "limpar") {
                            pagina(1);
                        }
                        MyArray = ajax2.responseText.split("Ø");
                        jQuery("#usuariosCadastrados").html(MyArray[0]); 
                        jQuery("#totalizador").html(MyArray[1])
                        jQuery("#paginacao").html("");
                        
                        //Ajustar execel
                        // jQuery(".imagemExcel").attr("id", id);

                        $('#mask').hide();
                    }
                }
            }
            ajax2.send(null);
        }

        function pagina(pagina) {
            $('#mask').show();
            ajax2 = ajaxInit();
            ajax2.open("GET", "/ajax/acoes.aspx?acao=paginarUsuario&pagina=" + pagina, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        MyArray = ajax2.responseText.split("Ø");
                        jQuery("#usuariosCadastrados").html(MyArray[0]);
                        jQuery("#paginacao").html(MyArray[1]);
                        jQuery("#totalizador").html(MyArray[2])
                        jQuery(".imagemExcel").attr("id", 2);
                        $('#mask').hide();
                    }
                }
            }
            ajax2.send(null);
        }

        function exportarUsuarios(id)
        {
            window.location.href = "/ajax/acoes.aspx?acao=exportarUsuarios&tipo=" +id;
        }
    </script>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />
</body>

</html>