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
                “Cartão Da Sorte Besni” veja como participar!
            </h2>

            <div class="row">
                <div class="col-md-6">
                    <h3 class="basenine text-uppercase cinza">compras acima de r$250,00</h3>
                    <div class="traco-vermelho"></div>
                    <div class="row">
					    <div class="col-md-3 col-xs-12 text-center col-sm-3">
						    <img src="/assets/images/icone-compras-acima.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-12 col-sm-9">
						    <span class="saiba-concorra">
							    Ao efetuar uma compra de, no mínimo, R$ 250,00 (duzentos e cinquenta reais) com seu cartão de crédito Besni em qualquer loja Besni durante o período de participação da promoção, você receberá 01 (um) cupom para concorrer aos prêmios desta promoção. A cada R$250,00 em compras, o participante ganhará 01 (um) número da sorte. Assim, exemplificativamente, uma compra de R$ 600,00 (seiscentos reais) garantirá ao participante 02 (dois) números da sorte, para concorrer.
						    </span>
					    </div>
				    </div>
                </div>
                <div class="col-md-6">
                    <h3 class="basenine text-uppercase cinza">Consulte seus Cupons no Site</h3>
                    <div class="traco-vermelho"></div>
                    <div class="row">
					    <div class="col-md-3 col-xs-12 text-center col-sm-3">
						    <img src="/assets/images/icone-consulte-seus-cupons.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-12 col-sm-9">
						    <span class="saiba-concorra">
							    Os participantes poderão também consultar seus números da sorte no site <a href="javascript:void(0);" title="Promoção Cartão da Sorte">www.promocaobesnicartaodasorte.com.br</a>, por meio do CPF do titular do cartão, no prazo de 72h (setenta e duas horas) após a compra.
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
					    <div class="col-md-3 col-xs-12 text-center col-sm-3">
						    <img src="/assets/images/icone-fique-de-olho.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-12 col-sm-9">
						    <span class="saiba-concorra">
							    Serão 05 (cinco) datas de sorteio ao longo da promoção, de acordo com os resultados da extração da Loteria Federal do Brasil dos dias 01/09/2018; 06/10/2018; 03/11/2018; 01/12/2018; e 05/01/2018.
						    </span>
					    </div>
				    </div>
                </div>
                <div class="col-md-6">
                    <h3 class="basenine text-uppercase cinza">os prêmios</h3>
                    <div class="traco-vermelho"></div>
                    <div class="row">
					    <div class="col-md-3 col-xs-12 text-center col-sm-3">
						    <img src="/assets/images/icone-os-premios.png" alt="Ícone compras">
					    </div>
					    <div class="col-md-9 col-xs-12 col-sm-9">
						    <span class="saiba-concorra">
							    Serão 500 (quinhentos) vales-presente no valor de R$100,00 (cem reais) e 03 (três) vales-presente no valor de R$1.000,00 (mil reais), TODO MÊS, entregues em um cartão Besni válidos para utilização em qualquer uma de nossas lojas.
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