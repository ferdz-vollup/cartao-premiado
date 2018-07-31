<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="cartaoPremiado.faq" %>

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

<body id="faq">

     <!--menu-->
    <besni:menu runat="server" ID="menu" />

    <section id="banner">
        <div class="conteudo">
            <div class="cartao-vitrine">
                <img class="animation" data-animation="left" data-time="1200" src="assets/images/mao-cartao-vitrine.png" alt="">
            </div>
            <div class="moedas moedas-vitrine-direita">
                <img class="animation" data-animation="width" data-time="1800" data-delay="500" src="assets/images/moedas-direita-vitrine.png" alt="">
            </div>
        </div>
    </section>
    
    <section>
        <div class="container">
            <h2 class="basenine degrade-vermelho text-uppercase">
                perguntas frequentes
            </h2>
            <hr />
            <button class="button-normal text-uppercase">
                <a href="#">Clique aqui e veja o regulamento</a>
            </button>
            <hr />
            <h3 class="basenine">Proin gravida nibh vel velit auctor aliquet. Aenean souam?</h3>
            <p>Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit. </p>
            <hr />
            <h3 class="basenine">Proin gravida nibh vel velit auctor aliquet. Aenean souam?</h3>
            <p>Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit. </p>
            <hr />
            <h3 class="basenine">Proin gravida nibh vel velit auctor aliquet. Aenean souam?</h3>
            <p>Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit. </p>
            <hr />
            <h3 class="basenine">Proin gravida nibh vel velit auctor aliquet. Aenean souam?</h3>
            <p>Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit. </p>
        </div>
    </section>

    <!--footer-->
    <besni:footer runat="server" ID="footer" />

    <!--scripts-->
    <besni:scripts runat="server" ID="scripts" />

</body>
</html>
