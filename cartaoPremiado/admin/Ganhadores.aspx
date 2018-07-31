<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ganhadores.aspx.cs" Inherits="cartaoPremiado.admin.Ganhadores" %>

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
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Ganhadores</h1>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-trophy fa-fw"></i>Aguardando aprovação
                        </div>
                        <div class="panel-body" style="height:410px;overflow-y:scroll">
                            <table width="100%" border="0" style="font-size:12px;width:732px">
                                <tr>
                                    <th>Nome</th>
                                    <th style="text-align:center">CPF</th>
                                    <th style="text-align:center">Número da Sorte</th>
                                    <th style="text-align:center">Ação</th>
                                </tr>
                                <tbody id="idAguardando" runat="server">
                                    
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-trophy fa-fw"></i>Aprovados
                        </div>
                        <div class="panel-body" style="min-height:410px">
                            <table width="100%" border="0" style="font-size:12px">
                                <tr>
                                    <th>Nome</th>
                                    <th style="text-align:center">CPF</th>
                                    <th style="text-align:center">Número da Sorte</th>
                                </tr>
                                <tbody id="idAprovado" runat="server">
                           
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-trophy fa-fw"></i>Publicado no Site
                        </div>
                        <div class="panel-body" style="height:410px">
                            <table width="100%" border="0" style="font-size:12px">
                                <tr>
                                    <th>Nome</th>
                                    <th style="text-align:center">E-mail</th>
                                    <th style="text-align:center">Concurso</th>
                                </tr>
                                <tbody id="idPublicado" runat="server">
                                    
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />
    <script type="text/javascript">
        function aprovar(id, valor)
        {
            ajax2 = ajaxInit();
            ajax2.open("GET", "ganhadores.aspx?acao=aprovar&id=" + id + "&valor=" + valor, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        //alert(ajax2.responseText);
                        if (ajax2.responseText == "LIMITE") {

                            alert("Já foram aprovados os 10 ganhadores.");

                            window.location.href = "ganhadores.aspx";


                            //$("input[type='radio']").each(function () {
                            //    $(this).attr("disabled", "disabled");
                            //});
                            return false;
                        }
                        
                        $('#idAprovado').html(ajax2.responseText);
                    }
                }
            }
            ajax2.send(null);
        }

        function puclicar(CON_ID) {
            ajax2 = ajaxInit();
            ajax2.open("GET", "ganhadores.aspx?acao=publicar&CON_ID=" + CON_ID, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        window.location.href = "ganhadores.aspx";
                    }
                }
            }
            ajax2.send(null);
        }

    </script>
</body>

</html>

