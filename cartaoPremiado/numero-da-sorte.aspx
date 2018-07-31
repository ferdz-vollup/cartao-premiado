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
            <h2 class="basenine degrade-vermelho">
                Número da Sorte
            </h2>
            <hr /><hr />
            <p>                Visualize seus Cupons aqui e confira se você <br />
                não é um dos premiados Besni
            </p>
            <div class="traco-vermelho center"></div>
            <div style="width: 530px;max-width: 100%;margin: auto;">
                <input type="text" name="cpf" value="" class="cpf" placeholder="CPF"/>
            </div>
            <hr />
            <button class="button-normal btn-buscar">Buscar</button>
            <hr /><hr />
            <div class="ganhadores">
                <h2 class="basenine text-uppercase">Cupons</h2>
                <div class="traco-branco center"></div>
                <ul>
                    <li>
                        cód. 02689-9
                    </li>
                    <li>
                        cód. 02689-9
                    </li>
                    <li>
                        cód. 02689-9
                    </li>
                    <li>
                        cód. 02689-9
                    </li>
                    <li>
                        cód. 02689-9
                    </li>
                    <li>
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
