<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CPFsBloqueados.aspx.cs" Inherits="cartaoPremiado.admin.CPFsBloqueados" %>

<%@ Register Src="~/admin/inc/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/admin/inc/menu-topo.ascx" TagPrefix="besni" TagName="menuTopo" %>
<%@ Register Src="~/admin/inc/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/admin/inc/footer.ascx" TagPrefix="besni" TagName="footer" %>

<!DOCTYPE html>
<html lang="pt">

<head>
    <besni:head runat="server" ID="head" />
</head>

<body id="bodyInterna">
    <div id="wrapper">

        <!--menu-->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <besni:menuTopo runat="server" ID="menuTopo" />
            <besni:menu runat="server" ID="menu" />
        </nav>

        <div id="page-wrapper">
            <div class="row displayFlex">
                <div class="col-lg-11">
                    <h1 class="page-header">CPFs bloqueados</h1>
                </div>
                <div class="col-lg-1">
                    <a href="javascript:void(0)" data-toggle="modal" data-target="#insertCpf">
                        <i class="fa fa-plus" style="font-size:25px;color:green" aria-hidden="true"></i>
                    </a>
                </div>
            </div>
            
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>CPF</th>
                                            <th style="width: 150px;text-align: center;">Ações</th>
                                        </tr>
                                    </thead>
                                    <tbody id="cpfsBloqueados" runat="server"></tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="insertCpf" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Inserir novo CPF para bloqueio</h4>
                </div>
                <div class="modal-body">
                    <form action="CPFsBloqueados.aspx" method="post" class="form" style="text-align:right">
                        <input type="hidden" name="acao" value="novoCPF" />
                        <input type="text" name="cpf" class="cpf form-control" value="" />
                        <button type="submit" class="btn btn-default" style="margin-top:15px;">Enviar</button>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />
    <script src="js/instagram.js"></script>

    <script type="text/javascript">

        function removerCPF(CAD_CPF) {
            ajax2 = ajaxInit();
            ajax2.open("GET", "/ajax/acoes.aspx?acao=removerCPF&cpf=" + CAD_CPF, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        jQuery("#" + CAD_CPF).remove();  
                    }
                }
            }
            ajax2.send(null);
        }
    </script>


</body>

</html>

