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
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
            <div class="estrela-vitrine">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
        </div>
    </section>

    
     <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />

</body>
</html>
