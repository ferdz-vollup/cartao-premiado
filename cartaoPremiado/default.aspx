<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="cartaoPremiado.WebForm1" %>

<%@ Register Src="~/include/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="besni" TagName="footer" %>
<%@ Register Src="~/include/scripts.ascx" TagPrefix="besni" TagName="scripts" %>


<!doctype html>
<html>

<head runat="server">
    <besni:head runat="server" ID="head" />

    <title>Cartão Besni</title>

</head>

<body id="home">

    <!--menu-->
    <besni:menu runat="server" ID="menu" />

    <section id="banner">
        <div class="conteudo">
            <div class="estrela-vitrine animation">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
            <div class="escrita-vitrine">
                <img class="animation" data-animation="right" data-time="1200" src="assets/images/escrita-vitrine-home.png" alt="">
            </div>
        </div>
    </section>


    <div class="container">
        <h2 class="basenine text-uppercase degrade-vermelho">
            Suas compras com cartão Besni<br /> podem valer prêmios todo mês!
        </h2>
        <div style="margin: 70px 0px;">
            <h3 class="basenine text-uppercase cinza">Saiba como participar</h3>
            <div class="traco-vermelho"></div>
            Para concorrer, é só ir até qualquer loja Besni durante o período de participação da promoção e efetuar compras no valor mínimo de R$250,00 (duzentos e cinquenta reais) com seu cartão Besni, que automaticamente você estará participando da promoção. 
            <br>
            <br>
            <em><a href="/como-participar.aspx">saiba mais</a></em>
        </div>
    </div>

    <section id="tarja-cartao">
        <div class="conteudo">
            <div class="cartao-besni">
                <img class="animation" data-animation="bottom" data-time="1200" src="assets/images/mao-cartao.png" alt="">
            </div>
            <div class="escrita">
                <h2 class="din text-uppercase font40 animation" style="letter-spacing: 3px;" data-animation="right" data-time="1200">
                    Agora tem mais um motivo para você <br /><strong>amar o seu cartão besni</strong>
                </h2>
            </div>
        </div>
    </section>

    <section id="premiacao" class="text-center">
        <div class="container">
            <h2 class="basenine degrade-vermelho">
                Premiação
            </h2>
            <div class="conteudo">
                <div class="fundo-cinza">
                    <h3 class="text-uppercase basenine">
                        <em class="basenine-bd-italic">500</em> vales-presente de <em class="basenine-bd-italic">R$100,00</em> <br>
                        e <em class="basenine-bd-italic">3</em> vales-presente de <em class="basenine-bd-italic">R$1.000,00</em>
                    </h3>
                    <div class="traco-vermelho"></div>
                    <p class="txt">
                        Todos os vales-presente serão <strong>entregues em um cartão Besni</strong>, válidos para utilização em qualquer uma de nossas lojas.
                    </p>
                    <em><a href="/como-participar.aspx">saiba mais</a></em>
                </div>
            </div>
        </div>
    </section>

    <section id="instagram">
        <div class="container text-center">
            <div class="traco-vermelho" style="margin:auto"></div>
            <h2 class="basenine degrade-vermelho text-uppercase">
                Compartilhe suas fotos de  produtos Besni com a nossa hashtag e apareça em nossas redes sociais!
            </h2>

            <div id="divInstagram" runat="server"></div>
            
            <div id="instafeed"></div>

            <div style="margin: 3rem auto 30px auto;" class="traco-vermelho"></div>
            <h3 class="basenine">#CartaoDaSorteBesni</h3>
            <div class="redes">
                <a href="https://www.facebook.com/LojasBesni/" title="Lojas Besni no Facebook" target="_blank">
                    <img src="assets/images/icone-facebook.png" alt="ícone facebook">
                </a>
                <a href="https://www.instagram.com/lojasbesni/" title="Lojas Besni no Instagram" target="_blank">
                    <img src="assets/images/icone-instagram.png" alt="ícone instagram">
                </a>
                <p>/lojasbesni</p>
            </div>
        </div>
    </section>

	<section id="besni-proxima">
		<div class="container text-center">
			<h2 class="basenine">tem uma <br>Besni perto de você!</h2><br />
			<a href="/onde-estamos.aspx" title="Clique aqui e veja onde estamos">
		        <button class="btn-onde-estamos">
				    clique aqui e veja onde estamos
			    </button>
			</a>
		</div>
	</section>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />


</body>
</html>
