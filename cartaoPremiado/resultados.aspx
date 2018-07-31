<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resultados.aspx.cs" Inherits="cartaoPremiado.assets.resultados" %>

<%@ Register Src="~/include/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="besni" TagName="footer" %>
<%@ Register Src="~/include/scripts.ascx" TagPrefix="besni" TagName="scripts" %>


<!doctype html>
<html>

<head runat="server">
    <besni:head runat="server" ID="head" />

    <title>Resultados - Cartão Besni</title>
</head>

<body id="resultados">
    
    <!--menu-->
    <besni:menu runat="server" ID="menu" />

    <section id="banner" class="sem-tiras">
        <div class="container">
            <div class="mulher-vitrine">
                <img class="animation" data-animation="bottom" data-time="1200" src="assets/images/mulher-cartao.png" alt="">
            </div>
            <div class="estrela-vitrine animation">
                <img class="animation" data-animation="right" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
        </div>
    </section>

    <section id="ganhadores">
        <div class="container text-center">
            <h2 class="basenine degrade-vermelho">
                Resultados
            </h2>
            <p style="margin: auto;margin-top: 30px;width: 500px;max-width: 100%;line-height: 35px;">
                Confira os nomes e os códigos dos grandes ganhadores da promoção Cartão da Sorte Besni.
            </p>
            <div class="traco-vermelho center"></div>

            <div class="ganhadores">
                <h2 class="basenine text-uppercase">Ganhadores</h2>
                <h3 class="basenine">08/2018</h3>
                <div class="traco-branco center"></div>
                <ul>
                    <li>
                        Nome Sobrenome<br />
                        cód. 02689-9
                    </li>
                    <li>
                        Nome Sobrenome<br />
                        cód. 02689-9
                    </li>
                    <li>
                        Nome Sobrenome<br />
                        cód. 02689-9
                    </li>
                    <li>
                        Nome Sobrenome<br />
                        cód. 02689-9
                    </li>
                    <li>
                        Nome Sobrenome<br />
                        cód. 02689-9
                    </li>
                    <li>
                        Nome Sobrenome<br />
                        cód. 02689-9
                    </li>
                </ul>
            </div>
            <div class="traco-vermelho center"></div>
            <p style="width: 1000px;margin: auto;max-width: 100%;">
                Os prêmios serão entregues aos ganhadores, livres de quaisquer ônus, em até 30 (trinta) dias da data da respectiva apuração, no endereço de residência dos ganhadores (conforme dados informados no cadastro), sendo certo que no momento da entrega, deverão estar munido dos documentos pessoais (CPF e RG) e ainda, assinar o respectivo Termo de Quitação e Entrega de Prêmio. Caso qualquer participante contemplado opte pelo recebimento da motocicleta, esta será entregue livre de quaisquer ônus, sendo de responsabilidade das Promotoras o pagamento do licenciamento, emplacamento e IPVA relativos ao ano de entrega do automóvel.
            </p>
        </div>
    </section>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />

</body>
</html>
