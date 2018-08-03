<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="cartaoPremiado.faq" %>

<%@ Register Src="~/include/head.ascx" TagPrefix="besni" TagName="head" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="besni" TagName="menu" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="besni" TagName="footer" %>
<%@ Register Src="~/include/scripts.ascx" TagPrefix="besni" TagName="scripts" %>


<!doctype html>
<html>

<head runat="server">
    <besni:head runat="server" ID="head" />

    <title>Perguntas Frequentes - Cartão Besni</title>
</head>

<body id="faq">

    <!--menu-->
    <besni:menu runat="server" ID="menu" />

    <section id="banner">
        <div class="conteudo">
            <div class="cartao-vitrine">
                <img class="animation" data-animation="left" data-time="1200" src="assets/images/mao-cartao-vitrine.png" alt="">
            </div>
            <div class="estrela-vitrine visible-xs">
                <img class="animation" data-animation="scale" data-time="1200" src="assets/images/estrela-vitrine-home.png" alt="">
            </div>
            <div class="moedas moedas-vitrine-direita">
                <img class="animation" data-animation="width" data-time="1800" data-delay="500" src="assets/images/moedas-direita-vitrine.png" alt="">
            </div>
        </div>
    </section>

    <section>
        <div class="container">
            <h2 class="basenine degrade-vermelho text-uppercase">perguntas frequentes
            </h2>
            <hr />
            <button class="button-normal text-uppercase">
                <a href="regulamento-cartao-da-sorte.pdf" target="_blank">Clique aqui e veja o regulamento</a>
            </button>
            <hr />
            <h3 class="basenine">Qual o período da promoção?</h3>
            <p>01/08/2018 a 04/01/2019</p>
            <hr />
            <h3 class="basenine">Qual o período válido de compras para participar da promoção?</h3>
            <div style="max-width:100%;overflow-x:auto">
            <p>
                <table width="600" margin="2" cellspacing="1" cellpadding="1" border="1">
                    <tr>
                        <th><center>Período da Compra</center></th>
                        <th><center>Sorteio</center></th>
                    </tr>
                    <tr>
                        <td>01/08 até 23h59min do dia 31/08/2018</td>
                        <td>01/09/18</td>
                    </tr>
                     <tr>
                        <td>01/09 até 23h59min do dia 05/10/2018</td>
                        <td>06/10/18</td>
                    </tr>
                     <tr>
                        <td>06/10 até 23h59min do dia 02/11/2018</td>
                        <td>03/11/18</td>
                    </tr>
                     <tr>
                        <td>03/11 até 23h59min do dia 30/11/2018</td>
                        <td>01/12/18</td>
                    </tr>
                     <tr>
                        <td>01/12 até 23h59min do dia 04/01/2019</td>
                        <td>05/01/19</td>
                    </tr>
                </table>
            </p>
            </div>
            <hr />
            <h3 class="basenine">Quem pode participar da promoção?</h3>
            <p>Qualquer pessoa física, residente e domiciliada no Brasil e portadora de CPF/MP poderá participar desta promoção.  EXCLUSIVO PARA PORTADORES DO CARTÃO BESNI.</p>
            <hr />
            <h3 class="basenine">Quem não pode participar?</h3>
            <p>Excluem-se de participação na presente promoção as pessoas jurídicas, os acionistas, diretores, empregados, representantes comerciais (e seus sócios) das Lojas Belian Moda Ltda., da Adcard – Administradora de Cartões de Crédito Ltda., da Bluebox Design e Comunicação Ltda e do escritório de advocacia M. Godoy Consultoria Jurídica em Comunicação Publicitária, sendo a identificação de tais condições efetuada, no momento da apuração, por meio de listagem de RH.</p>
            <hr />
            <h3 class="basenine">Qual a premiação da promoção?</h3>
            <p>Sorteios mensais de 500 (quinhentos) vales-presente no valor de R$100,00 (cem reais) e 03 (três) de R$1.000,00 (mil reais), entregues em um cartão Besni válidos para utilização em qualquer uma de nossas lojas.</p>
            <hr />
            <h3 class="basenine">Como posso participar?</h3>
            <p>Para participar, basta efetuar compras de, no mínimo, R$250,00 (duzentos e cinquenta reais) com cartão de crédito Besni em qualquer loja Besni durante o período de participação da promoção. O cadastro é realizado automaticamente, podendo ser consultado no hotsite da promoção no endereço www.promocaobesnicartaodasorte.com.br</p>
            <hr />
            <h3 class="basenine">Posso editar ou atualizar os meus dados pessoais do cadastro realizado no site da promoção?</h3>
            <p>Não todos. Após a confirmação do cadastro, NÃO será possível alterar as seguintes informações: nome completo, sexo, data de nascimento e número do CPF/MF. É de total responsabilidade do participante a veracidade dos dados cadastrais.</p>
            <hr />
            <h3 class="basenine">Quando receberei o(s) número(s) da sorte?</h3>
            <p>Os números da sorte serão disponibilizados no site da promoção, em até 72 horas (setenta e duas horas) a partir da data de compra. É só efetuar o login (CPF) e a senha criada no momento do cadastro (primeiro acesso) no site da promoção.</p>
            <hr />
            <h3 class="basenine">Quantos números da sorte posso receber?</h3>
            <p>Cada cupom fiscal cadastrado, referente a compras de valor mínimo de R$250,00 (duzentos e cinquenta reais) dará ao participante o direito a 01 (um) número da sorte para concorrer na apuração correspondente à data do registro. A cada R$250 em compras, o participante ganhará um novo número da sorte.</p>
            <hr />
            <h3 class="basenine">Como faço para consultar meu(s) número(s) da sorte?</h3>
            <p>Para consultar os números da sorte, com os quais estará concorrendo aos prêmios, o participante deverá acessar o site da promoção www.promocaobesnicartaodasorte.com.br com os dados de login e senha previamente cadastrados.</p>
            <hr />
            <h3 class="basenine">Como será realizado o sorteio?</h3>
            <p>O sorteio ocorrerá vinculado à extração da Loteria Federal, de acordo com a data, série e período de participação.</p>
            <hr />
            <h3 class="basenine">Como os ganhadores serão notificados?</h3>
            <p>Os ganhadores contemplados, titulares do número de ordem de cada uma das séries, serão localizados por meio dos dados constantes no cadastro DO SEU CARTÃO BESNI e serão comunicados sobre a sua contemplação no prazo de 07 (sete) dias úteis, contados da data de sua identificação.</p>
            <hr />
            <h3 class="basenine">Como os prêmios serão entregues?</h3>
            <p>Os prêmios serão entregues aos ganhadores, livres de quaisquer ônus, em até 30 (trinta) dias da data da respectiva apuração, no endereço de residência dos ganhadores (conforme dados informados no cadastro), sendo certo que no momento da entrega, deverão estar munidos dos documentos pessoais (CPF e RG) e, ainda, assinar o respectivo Termo de Quitação e Entrega de Prêmio.</p>
            <hr />
            <h3 class="basenine">Preciso guardar todas as notas ou cupons fiscais cadastrados nesta promoção?</h3>
            <p>Sim. O participante deverá guardar as Notas Fiscais cadastradas na promoção, a fim de validar as informações cadastradas. Caso isso não aconteça o participante poderá perder a oportunidade de ser o ganhador. </p>
            <hr />
        </div>
    </section>
    <style>
        table {
            border-spacing: 1px;
            padding: 10px;
        }

            table td {
                border: 1px solid black;
                text-align: center;
                padding: 5px;
            }
    </style>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />

</body>
</html>
