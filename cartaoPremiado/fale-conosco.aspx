<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fale-conosco.aspx.cs" Inherits="cartaoPremiado.fale_conosco" %>

<%@ Register Src="~/include/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="besni" TagName="footer" %>
<%@ Register Src="~/include/scripts.ascx" TagPrefix="besni" TagName="scripts" %>


<!doctype html>
<html>

<head runat="server">
    <besni:head runat="server" ID="head" />

    <title>Fale Conosco - Cartão Besni</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
</head>

<body id="fale-conosco">
    
    <!--menu-->
    <besni:menu runat="server" ID="menu" />

    <section id="banner" class="banner-estrela">
        <div class="conteudo">
            <div class="estrela-vitrine">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
        </div>
    </section>

    <section>
        <div class="container text-center">
            <h2 class="basenine degrade-vermelho text-uppercase">
                Fale conosco
            </h2>
            <hr />
            <form action="/" method="post" id="formFaleConosco">

                <input type="hidden" name="Destinatario" value="|vitor.emanuel@vollup.com">
				<input type="hidden" name="Obrigatorios" value="|nome|email|mensagem">
				<input type="hidden" name="autoresposta" value="teste">
				<input type="hidden" name="idioma" value="pt">
				<input type="hidden" name="metodo" value="ajax">
				<input type="hidden" name="Assunto" id="assunto" value="Contato Fale Conosco - Promoção Cartão Besni">

                <input type="text" name="nome" placeholder="NOME" class="nome inputs"/>
                <input type="text" name="telefone" class="telefone inputs" />
                <input type="text" name="cpf" placeholder="CPF" class="cpf inputs" />
                <input type="email" name="email" placeholder="E-MAIL" class="email inputs"/>
                <textarea name="mensagem" placeholder="DIGITE SUA MENSAGEM" class="inputs"></textarea>
                <button type="button" class="btn-enviar button-normal">Enviar</button>
                <button type="button" class="btn-limpar button-normal">Limpar</button>
                <div class="retorno-mensagem"></div>
            </form>
        </div>
    </section>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />

    <script>
        jQuery(".btn-enviar").click(function () {
           

            var idForm = "#formFaleConosco";
            var inputs = jQuery(idForm).find(".inputs:not(.no-obg)");
            for (i = 0; i < inputs.length; i++) {
                if (inputs[i].value == "") {
                    jQuery(inputs[i]).addClass("error");

                    $('html, body').animate({
                        scrollTop: $(inputs[i]).offset().top - 180
                    }, 1000);

                    console.log("erro de campos com o valor vazio, campo: " + inputs[i].name);
                    return;

                }
                else {
                    jQuery(inputs).removeClass("error");
                }
            }
            
            if (jQuery(idForm).find(".error").length == 0) {
                var eml = jQuery("input[type='email']");
                console.log(eml);
                var filtroregexemail = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                console.log(filtroregexemail.test(eml));
                if (filtroregexemail.test(eml.val()) == true) {
                    enviaFerdz(idForm);
                 } else {
                    console.log("erro email");
                    jQuery(eml).addClass("error");
                    console.log("err");
                }
            }
        });
    </script>

</body>
</html>

