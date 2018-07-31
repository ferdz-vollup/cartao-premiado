<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="como-participar.aspx.cs" Inherits="cartaoPremiado.como_participar" %>

<%@ Register Src="~/include/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="besni" TagName="footer" %>
<%@ Register Src="~/include/scripts.ascx" TagPrefix="besni" TagName="scripts" %>


<!doctype html>
<html>

<head runat="server">
    <besni:head runat="server" ID="head" />

    <title>Como Participar - Cartão Besni</title>
</head>

<body id="como-participar">
    
    <!--menu-->
    <besni:menu runat="server" ID="menu" />

    <section id="banner">
        <div class="conteudo">
            <div class="moedas moedas-vitrine-esquerda">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/moedas-esquerda-vitrine.png" alt="">
            </div>
            <div class="estrela-vitrine">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
            <div class="moedas moedas-vitrine-direita">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/moedas-direita-vitrine.png" alt="">
            </div>
        </div>
    </section>

    <section id="topicos">
        <div class="container">
            <h2 class="basenine degrade-vermelho text-center" style="width: 600px;max-width: 100%;margin:auto">
                “Cartão Da Sorte Besni” veja como participar
            </h2>

            <div class="row">
                <div class="col-md-6">
                    <h3 class="basenine text-uppercase cinza">compras acima de r$250</h3>
                    <div class="traco-vermelho"></div>
                    <div class="row">
					    <div class="col-md-3 col-xs-3 text-center">
						    <img src="/assets/images/icone-compras-acima.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-9">
						    <span class="saiba-concorra">
							    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
						    </span>
					    </div>
				    </div>
                </div>
                <div class="col-md-6">
                    <h3 class="basenine text-uppercase cinza">Consulte seus Cupons no Site</h3>
                    <div class="traco-vermelho"></div>
                    <div class="row">
					    <div class="col-md-3 col-xs-3 text-center">
						    <img src="/assets/images/icone-consulte-seus-cupons.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-9">
						    <span class="saiba-concorra">
							    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
						    </span>
					    </div>
				    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <h3 class="basenine text-uppercase cinza">fique de olho no sorteio</h3>
                    <div class="traco-vermelho"></div>
                    <div class="row">
					    <div class="col-md-3 col-xs-3 text-center">
						    <img src="/assets/images/icone-fique-de-olho.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-9">
						    <span class="saiba-concorra">
							    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
						    </span>
					    </div>
				    </div>
                </div>
                <div class="col-md-6">
                    <h3 class="basenine text-uppercase cinza">os prêmios</h3>
                    <div class="traco-vermelho"></div>
                    <div class="row">
					    <div class="col-md-3 col-xs-3 text-center">
						    <img src="/assets/images/icone-os-premios.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-9">
						    <span class="saiba-concorra">
							    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
						    </span>
					    </div>
				    </div>
                </div>
            </div>

        </div>
    </section>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />

</body>
</html>