<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="onde-estamos.aspx.cs" Inherits="cartaoPremiado.onde_estamos" %>

<%@ Register Src="~/include/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="besni" TagName="footer" %>
<%@ Register Src="~/include/scripts.ascx" TagPrefix="besni" TagName="scripts" %>


<!doctype html>
<html>

<head runat="server">
    <besni:head runat="server" ID="head" />

    <title>Onde estamos - Cartão Besni</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
</head>

<body id="onde-estamos">
    
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
                Onde estamos
            </h2>
            <hr /><hr />
            <h3 class="basenine text-uppercase">
                encontre uma besni perto de você
            </h3>
            <div class="traco-vermelho center"></div>
            <p>
                São 36 lojas espalhadas pelo Estado de São Paulo. <br />
                Digite seu CEP e veja a(s) unidade(s) mais próxima(s) de você.
            </p>
            <div class="traco-vermelho center"></div>
            <div style="width: 530px;max-width: 100%;margin: auto;">
                <input type="text" name="cep" value="" class="cep" placeholder="DIGITE SEU CEP"/>
            </div>
            <hr />
            <button class="button-normal btn-buscar">Buscar</button>
            <hr /><hr />
        </div>
    </section>

    <div id="map" class="maps"></div>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBSUuzKFf-qvUvfah7ekcUoJPB3V1DUDmw&amp;language=pt_BR&amp;sensor=false&amp;ver=3.8.5&amp;libraries=places&amp;dsa=1532975490"></script>
    <script src="assets/js/gmaps.js"></script>
    <besni:scripts runat="server" ID="scripts" />

</body>
</html>
