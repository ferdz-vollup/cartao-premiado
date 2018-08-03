<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="numero-da-sorte.aspx.cs" Inherits="cartaoPremiado.numero_da_sorte" %>

<%@ Register Src="~/include/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="besni" TagName="footer" %>
<%@ Register Src="~/include/scripts.ascx" TagPrefix="besni" TagName="scripts" %>

<!doctype html>
<html>

<head runat="server">
    <besni:head runat="server" ID="head" />

    <title>Número da sorte - Cartão Besni</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
</head>

<body id="numero-da-sorte">

    <!--menu-->
    <besni:menu runat="server" ID="menu" />

    <section id="banner" class="sem-tiras">
        <div class="conteudo">
            <div class="mao-cartao">
                <img class="animation" data-animation="left" data-time="1200" src="assets/images/mao-vitrine-numero-da-sorte.png" alt="">
            </div>
            <div class="estrela-vitrine">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
        </div>
    </section>

    <section>
        <div class="container text-center">
            <h2 class="basenine degrade-vermelho">Número da Sorte
            </h2>
            <hr />
            <hr />
            <p>
                Consulte seus cupons e confira quantas 
                <br />
                chances você tem de ganhar!
            </p>
            <div class="traco-vermelho center"></div>
            <form action="javascript:buscarCupons($('#cpf').val(), $('#nascimento').val());" method="post" id="formNumeroSorte">
                <div style="width: 530px; max-width: 100%; margin: auto;">
                    <input type="text" name="cpf" id="cpf" value="" class="cpf" placeholder="CPF" />
                    <input type="text" name="nascimento" id="nascimento" value="" class="nascimento" placeholder="DATA DE NASCIMENTO" />

                     <p id="msg1"></p>
                </div>
                <hr />
                <button class="button-normal btn-buscar">Buscar</button>
            </form>
            <hr />
            <hr />
            <section id="divGanhadores" runat="server"></section>

            <section id="secEmail" runat="server" style="display: none">

                <div class="traco-vermelho center"></div>
                <form action="javascript:atualizaEmail($('#cpf').val(), $('#email').val());" method="post" id="formEmail">
                    <p style="width: 1000px; margin: auto; max-width: 100%;">
                        Deseja receber os seus cupons por e-mail?
                    </p>
                    <input type="email" name="email" id="email" placeholder="E-MAIL" class="email inputs" /><br />
                    <button class="button-normal btn-buscar">Enviar</button>
                </form>
                <hr />
            
                <p id="msg" style="display:none"></p>
            </section>

            <div class="traco-vermelho center"></div>
            <p style="width: 1000px; margin: auto; max-width: 100%;">
               Os prêmios serão entregues aos ganhadores, livres de quaisquer ônus, em até 30 (trinta) dias da data da respectiva apuração, no endereço de residência dos ganhadores (conforme dados informados no cadastro), sendo certo que no momento da entrega, deverão estar munido dos documentos pessoais (CPF e RG) e, ainda, assinar o respectivo Termo de Quitação e Entrega de Prêmio.
            </p>
        </div>
    </section>


    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />

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

        function buscarCupons(cpf, nascimento) {
            if ($(".nascimento").hasClass("error")) {
                alert("Data de nascimento inválida!");
                return;
            }

            if (cpf != "") {
                ajax2 = ajaxInit();
                ajax2.open("GET", "/ajax/acoes.aspx?acao=buscarCupons&cpf=" + cpf + "&nascimento=" + nascimento + "&email=" + email, true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {

                            if (ajax2.responseText == "vazio")
                            {
                                jQuery("#msg1").html("Dados não localizados no sistema! </br> Por favor, verifique se estão corretos.")
                            }
                            else {
                                jQuery("#divGanhadores").html(ajax2.responseText);
                                $('#secEmail').show();
                                $('html,body').animate({
                                    scrollTop: $("#nascimento").offset().top
                                }, 'slow');
                                $('#cpf').attr("readonly", "readonly");
                                $('#nascimento').attr("readonly", "readonly");
                            }
                        }
                    }
                }
                ajax2.send(null);
            }
        }

        function atualizaEmail(cpf, email) {

            if (email != "")

                ajax2 = ajaxInit();
            ajax2.open("GET", "/ajax/acoes.aspx?acao=atualizaEmail&email=" + email + "&cpf=" + cpf, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {
                        
                        jQuery("#msg").html(ajax2.responseText);
                        $('#msg').show();
                    }
                }
            }
            ajax2.send(null);
        }


    </script>

</body>
</html>