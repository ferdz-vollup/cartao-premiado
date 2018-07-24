var timeRotate;

jQuery(document).ready(function ($) {

    //INSTA
    if ($('#divInstagram').length > 0 && $(window).width() < 481) {
        timeRotate = setInterval(rotacao, 30);

        /*$('#divInstagram').hover(
            function () {
                if ($(window).width() > 768) { clearInterval(timeRotate); }
            },
            function () {
                if ($(window).width() > 768) { timeRotate = setInterval(rotacao, 30); }
            }

        );*/

    }

    $(window).resize(function () {
        if ($("#divInstagram").length > 0 && $(window).width() < 481) {
            // 
            timeRotate = setInterval(rotacao, 30);
            insta();
        } else {
            $("#divInstagram ul").removeAttr('style');
            setTimeout(function () {

                timeRotate = clearInterval(timeRotate);
            }, 500);

            // 
        }

    });

    window.onload = function () {
        if ($("#divInstagram").length > 0 && $(window).width() < 481) {
            insta();
        } else {
            $("#divInstagram ul").removeAttr('style');
            setTimeout(function () {
                clearInterval(timeRotate);
            }, 500);
        }
    }

    // Recuperação de Senha (COMEÇO)

    //$(".novaSenhaClick").click(function () {
    //    var senha1 = $("input[name=senha]").val();
    //    var senha2 = $("input[name=senha2]").val();
    //    if (senha1 == senha2) {
    //        alert("Senha nova salva com sucesso!");
    //    } else {
    //        alert("Erro: você precisa confirmar a nova senha nos dois campos.");
    //    }
    //});

    // Recuperação de Senha (FIM)

    var alturaEscrita = jQuery("#banner-escrita img").height();
    jQuery("#banner-escrita img").attr("style", "margin-top:-" + alturaEscrita / 2 + "px");
    jQuery(".banner img").fadeIn(1000);

    var SPMaskBehavior = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
        spOptions = {
            onKeyPress: function (val, e, field, options) {
                field.mask(SPMaskBehavior.apply({}, arguments), options);
            }
        };
    // $('.telefone').mask(SPMaskBehavior, spOptions);


    $(function ($) {
        $(".cpf").mask("999.999.999-99");
        $('.rg').mask("**.***.***-*");
        $('.data-nasc').mask("99/99/9999");
        $('.cel').mask("(99) 99999-9999");
        $('.telefone').mask("(99) 99999-9999");
        $('.cep').mask("99999-999");
        $('.cnpj').mask("99.999.999/9999-99");
        // $('.valor-nota').mask("9.999,99", { reverse: true });
        $('.telefone').unbind('focusout').focusout(function () {
            var valor = $(this).val().replace('_', '');
            var len = valor.length;
            if (len >= 14) {
                $(this).unmask();
                if (len == 14) {
                    $(this).mask("(99) 9999-9999?9");
                    $(this).removeClass('error');
                }
                else {
                    $(this).mask("(99) 99999-999?9");
                    $(this).removeClass('error');
                }
            }
        }).trigger('focusout');

        $('.telefone').focusout(function (e) {
            var valor = $(this).val().replace('_', '');
            var len = valor.length;
            if (len >= 14) {
                $(this).unmask();
                if (len == 14) {
                    $(this).mask("(99) 9999-9999?9");
                    $(this).removeClass('error');
                }
                else {
                    $(this).mask("(99) 99999-999?9");
                    $(this).removeClass('error');
                }
            } else {
                $(this).addClass('error')
            }
        });
    });

    jQuery(".btn-limpar").click(function () {
        var formulario = jQuery(this).parent().parent().parent();
        formulario[0].reset();
    });

    // Validação de valor mínimo do Cupom

    jQuery("#cadastrarcupom").submit(function () {
        var valCupom = jQuery("#valor_nota_02").val();
        valCupom = valCupom.replace(".", "").replace(",", "");
        var cupomFile = jQuery("input[name='input-file-preview']").val();
        if (cupomFile == "") {
            jQuery(".input-group.image-preview > input").addClass("error");
        }
        else {
            jQuery(".input-group.image-preview > input").removeClass("error");
        }
        if (valCupom >= 20000) {
            jQuery("#valor_nota_02").removeClass("error");
            console.log("no err");
        } else {
            jQuery("#valor_nota_02").addClass("error");
            console.log("err");
        }
        if (jQuery("#cadastrarcupom").find(".error").length == 0) {
			jQuery(this).find(".btn-enviar").val("Enviando...");
			jQuery(this).find(".btn-enviar").attr("disabled", "disabled");
            return true;
        }
        else {
            return false;
        }
    });

    jQuery(".novaSenhaClick").click(function () {

        if ($("input[name='senha']").val() != $("input[name='senha2']").val()) {
            $("input[name='senha2']").addClass("error");
            console.log("Confirmação da nova senha não corresponde à digitada.");
            return false;

        }
    });

    jQuery(".btn-enviar").click(function () {

        if ($("input[name='senha']").val() != $("input[name='senha2']").val()) {
            $("input[name='senha2']").addClass("error");
            console.log("Confirmação de senha não corresponde à digitada.");
            return;
        }
        if ($("input[name='email']").val() != $("input[name='email2']").val()) {
            $("input[name='email2']").addClass("error");
            $('html, body').animate({
                scrollTop: $("#formCadastrar").offset().top - 180
            }, 1000);
            console.log("Confirmação de email não corresponde ao digitado.");
            return;
        }


        // Campos Obrigatórios

        var idForm = "#" + jQuery(this).data("form");
        var inputs = jQuery(idForm).find(".inputs:not(.no-obg)");
        /*for (i = 0; i < inputs.length; i++) {
            if (inputs[i].value == "") {
                jQuery(inputs[i]).addClass("error");
                
                $('html, body').animate({ 
                    scrollTop: $(inputs[i]).offset().top-180
                }, 1000);
                alert('teste');
                console.log("erro de campos com o valor vazio, campo: " + inputs[i].name);
                return;
            }
            else {
                jQuery(inputs).removeClass("error");
            }
        }*/

        $(idForm + ' .inputs:not(.no-obg)').each(function () {
            if ($(this).val() == "") {
                $(this).addClass('error')
            } else {
                if ($(this).hasClass('email')) {
                    email = $(this).val()
                    var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                    if (filtro.test(email)) {
                        $(this).removeClass('error')
                    } else {
                        $(this).addClass('error')
                    }
                } else if ($(this).hasClass('url')) {
                    urlValida = $(this).val();
                    validaUrl = /[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/ig;
                    if (validaUrl.test(urlValida)) {
                        $(this).removeClass('error')
                    } else {
                        $(this).addClass('error')
                    }
                } else if ($(this).hasClass('data')) {
                    var dataValida = $(this).val();
                    var validaData = /((0[1-9]|[12][0-9]|3[01])\/(0[13578]|1[02])\/[12][0-9]{3})|((0[1-9]|[12][0-9]|30)\/(0[469]|11)\/[12][0-9]{3})|((0[1-9]|1[0-9]|2[0-8])\/02\/[12][0-9]([02468][1235679]|[13579][01345789]))|((0[1-9]|[12][0-9])\/02\/[12][0-9]([02468][048]|[13579][26]))/gi;
                    if (validaData.test(dataValida)) {
                        $(this).removeClass('error')
                    } else {
                        $(this).addClass('error')
                    }
                } else if ($(this).hasClass('nome')) {
                    var validaNome = /[^0-9A-Za-zà-úÀ-Ú]{3}/;
                    nomeValida = $(this).val()
                    if (!validaNome.test(nomeValida.replace(/\s/g, ''))) {
                        $(this).removeClass('error')
                    } else {
                        $(this).addClass('error')
                    }
                } else if ($(this).hasClass('hora')) {
                    var horaValida = $(this).val();
                    var validaHora = /^([0-1][0-9]|2[0-3]):[0-5][0-9]$/gi;
                    if (validaHora.test(horaValida)) {
                        $(this).removeClass('error')
                    } else {
                        $(this).addClass('error')
                    }
                } else {
                    $(this).removeClass('error')
                }
            }
        });
        if ($(idForm + ' .inputs').hasClass('error')) {

            $('html, body').animate({
                scrollTop: $(idForm + ' .inputs.error:first').offset().top - 180
            }, 1000);

            return false
        } else {

        }
        if (jQuery("#termos").length > 0) {
            if (jQuery("#termos").is(':checked')) {
                jQuery("#termos").removeClass("error");
            } else {
                alert("Você deve aceitar nossas condições da campanha");
                jQuery("#termos").addClass("error");
            }
        }




        if (jQuery(idForm).find(".error").length == 0) {

            if (jQuery("input[type='email']").length > 0) {
                var eml = jQuery("input[type='email']").val();
                console.log(eml);
                var filtroregexemail = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                console.log(filtroregexemail.test(eml));
                if (filtroregexemail.test(eml) == true) {
                    if (idForm == "#faleConoscoForm") {
                        enviaFerdz(idForm);
                        jQuery(idForm).submit();
                    }
                    else {
                        console.log();
                        jQuery(".btn-enviar").val("Enviando...");
						jQuery(".btn-enviar").attr("disabled", "disabled");
                        jQuery(idForm).submit();
                    }
                } else {
                    console.log("erro email");
                    jQuery(eml).addClass("error");
                    console.log("err");

                }
            } else {
                jQuery(idForm).submit();
            }


        }
    });
        
    jQuery("input[type='email']").on("blur", function () {
        var eml = jQuery(this).val();
        console.log(eml);
        var filtroregexemail = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
        console.log(filtroregexemail.test(eml));
        if (filtroregexemail.test(eml) == true) {
            jQuery(this).removeClass("error");
            console.log("no err");
        } else {
            jQuery(this).addClass("error");
            console.log("err");
        }
    });

    jQuery(".sorteios .botao").click(function () {
        if (jQuery(window).width() < 768) {
            jQuery(this).parent().addClass("ativo");
        }
        else {
            jQuery(".sorteios").addClass("ativo");
        }
    });


    // Exibir campos para cartão Besni


    $(".card-hide").click(function () {
        $(".cardBesni input").val("");
        $(".cardBesni input").addClass("no-obg");
        $(".cardBesni").hide();
    });
    $(".card-show").click(function () {
        $(".cardBesni").show();
    });




    jQuery(".numero-cartao .inputs").keyup(function () {
        var digitados = jQuery(this).val().length;
        jQuery(this).attr("maxlength", "4");
        var maxLenght = jQuery(this).attr("maxlength");
        if (digitados == maxLenght) {
            jQuery(this).addClass("esse");
            jQuery(".esse").parent("div").next("div").children("input").focus();
            jQuery(".esse").removeClass("esse");
        }
    });

    jQuery(".metodo-compras button").click(function () {
        jQuery(".metodo-compras").addClass("fechado");
        jQuery(".metodo-compras").fadeOut(100);
        jQuery("#formCadastro").addClass("aberto");
        if (jQuery(this).data("cartao") == "Sim") {
            jQuery("#sim").attr("checked", "checked");
            jQuery(".cartao").fadeIn(100);
            jQuery(".numero-cartao input").removeClass("no-obg");
        } else {
            jQuery("#nao").attr("checked", "checked");
            jQuery(".numero-cartao input").addClass("no-obg");
        }
        if ($(window).width() < 600) {
            setTimeout(function () {
                $('html, body').animate({
                    scrollTop: $("#formCadastro").offset().top - 100
                }, 1000);
                jQuery("input#nome").trigger("focus");
                jQuery("input#nome").focus(function () {
               
                });
            }, 300);
            
        }
    })
})




function validarCNPJ(cnpj) {
    
}





function enviaFerdz(idForm) {
    if (document.querySelectorAll(idForm + " .error").length == 0) {
        var form = jQuery(idForm).serialize();
        jQuery.ajax({
            type: "GET",
            url: "http://www.misasi.com.br/form/flagform.asp",
            async: true,
            data: form,
            crossorigin: true,
            success: function (data) {
                if (data == "sucesso") {
                    console.log("sucesso total");
                    jQuery(idForm + " .retorno-mensagem").html("Obrigado por entrar em contato! Em breve daremos um retorno");
                } else {
                    console.log("sucesso, porém erro");
                    jQuery(idForm + " .retorno-mensagem").html("Ops... Erro ao tentar enviar, por favor, tente novamente!");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log("erro total");
                jQuery(idForm + " .retorno-mensagem").html("Ops... Erro ao tentar enviar, por favor, tente novamente!");
            },
            beforeSend: function () {
                jQuery(".retorno-mensagem").html("<span class='loader'></span>Enviando mensagem...");
                jQuery(idForm + " button").attr("disabled", "disabled");
            },
            complete: function () {
                console.log("request completo");
                setTimeout(function () {
                    jQuery(idForm + " button").removeAttr("disabled");
                    jQuery(idForm + " .retorno-mensagem").html("");
                    jQuery(idForm)[0].reset();
                }, 6000);

            }
        });
    } else {
        alert("Preencha todos os campos corretamente.");
    }
}


function MascaraMoeda(objTextBox, SeparadorMilesimo, SeparadorDecimal, e) {
    var sep = 0;
    var key = '';
    var i = j = 0;
    var len = len2 = 0;
    var strCheck = '0123456789';
    var aux = aux2 = '';
    var whichCode = (window.Event) ? e.which : e.keyCode;
    if (whichCode == 13) return true;
    key = String.fromCharCode(whichCode); // Valor para o cÃƒÂ³digo da Chave
    if (strCheck.indexOf(key) == -1) return false; // Chave invÃƒÂ¡lida
    len = objTextBox.value.length;
    for (i = 0; i < len; i++)
        if ((objTextBox.value.charAt(i) != '0') && (objTextBox.value.charAt(i) != SeparadorDecimal)) break;
    aux = '';
    for (; i < len; i++)
        if (strCheck.indexOf(objTextBox.value.charAt(i)) != -1) aux += objTextBox.value.charAt(i);
    aux += key;
    len = aux.length;
    if (len == 0) objTextBox.value = '';
    if (len == 1) objTextBox.value = '0' + SeparadorDecimal + '0' + aux;
    if (len == 2) objTextBox.value = '0' + SeparadorDecimal + aux;
    if (len > 2 && len < 9) {
        aux2 = '';
        for (j = 0, i = len - 3; i >= 0; i--) {
            if (j == 3) {
                aux2 += SeparadorMilesimo;
                j = 0;
            }
            aux2 += aux.charAt(i);
            j++;
        }
        objTextBox.value = '';
        len2 = aux2.length;
        for (i = len2 - 1; i >= 0; i--)
            objTextBox.value += aux2.charAt(i);
        objTextBox.value += SeparadorDecimal + aux.substr(len - 2, len);
    }
    return false;
}

/* MAPA */
var map;
var infowindow;
var request;
var localizacao;

function initMap() {
    if (document.getElementById('map')) {

        localizacao = { lat: -23.5558717, lng: -46.6993749 };

        map = new google.maps.Map(document.getElementById('map'), {
            center: localizacao,
            zoom: 15
        });

        infowindow = new google.maps.InfoWindow();

    }
}

function callback(results, status) {
    if (status == google.maps.places.PlacesServiceStatus.OK) {
        for (var i = 0; i < results.length; i++) {
            var place = results[i];
            createMarker(results[i]);
            map.setCenter(results[0].geometry.location);
        }
    }
}

function createMarker(place) {
    var placeLoc = place.geometry.location;
    var marker = new google.maps.Marker({
        map: map,
        icon: 'http://www.vollup.com/images/marker-besni2.png',
        position: place.geometry.location
    });

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent("<center>Loja Besni<br>" + place.formatted_address + "</center>");
        infowindow.open(map, this);
    });
}

function chama() {
    var cep = jQuery(".cep").val();
    var geocoder = new google.maps.Geocoder();
    var address = 'Loja besni ' + cep;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setZoom(18);
            map.setCenter(results[0].geometry.location);
            createMarker(results[0]);
        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
}

//INSTA
function insta() {
    var w = 180;
    var wul = $('#divInstagram ul li').length;
    $('#divInstagram ul').width(180 * wul);
    var largura = $(window).width(),
        ul = $('#divInstagram ul').width(),
        distancia = ul - largura;
    rotacao()
}

function rotacao() {
    var w = 180;
    var value = document.getElementById('instaFeed').style.marginLeft + 0;
    var margin = parseInt(value) - 1;
    if (margin == -180) {
        margin = 0;
        $('#instaFeed > li:first-child').appendTo('#instaFeed');
    }
    document.getElementById('instaFeed').style.marginLeft = margin + 'px';

}

function addLink(e) {
    var nAgt = navigator.userAgent;
    var nameOffset, verOffset, ix;
    if ((verOffset = nAgt.indexOf("Firefox")) != -1) {
    } else {
        e.preventDefault();
        var url = window.location.href.toString();
        var copyright = ' - Leia mais em ' + window.location.href.toString();
        var novoTexto = copytext = window.getSelection() + copyright;
        (window.clipboardData ? window : event).clipboardData.setData('Text', copytext);
    }
} window.addEventListener('copy', addLink);