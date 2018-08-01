var timeRotate;

jQuery(document).ready(function ($) {

    var SPMaskBehavior = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
    spOptions = {
        onKeyPress: function (val, e, field, options) {
            field.mask(SPMaskBehavior.apply({}, arguments), options);
        }
    };
    $('.telefone').mask(SPMaskBehavior, spOptions);
    $(".cpf").mask("999.999.999-99");
    $(".cep").mask("99999-999");
    $('.nascimento').mask('99/99/9999');
    var regexDate = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/i;
    $(".nascimento").blur(function () {
        var data = $(this).val();
        if (regexDate.test(data) == true) {
            $(".nascimento").removeClass("error");
            console.log("no err");
        } else {
            $(".nascimento").addClass("error");
            console.log("err");
        }
    });
    

    //INSTA
    if ($('#divInstagram').length > 0 && $(window).width() < 481) {
        timeRotate = setInterval(rotacao, 30);
    }
    $(window).resize(function () {
        if ($("#divInstagram").length > 0 && $(window).width() < 481) {
            timeRotate = setInterval(rotacao, 30);
            insta();
        } else {
            $("#divInstagram ul").removeAttr('style');
            setTimeout(function () {

                timeRotate = clearInterval(timeRotate);
            }, 500);
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


    /* ANIMATION */
    $("*[data-animation]").each(function () {
        var delay = $(this).data("time");
        delay = delay / 1000;
        var style = $(this).attr("style");
        if (style == undefined) { style = ""; } else {style = style + ";";}
        style = style + "-webkit-transition: all " + delay + "s ease;- moz - transition: all " + delay + "s ease;-o - transition: all " + delay + "s ease;transition: all " + delay + "s ease;";
        $(this).attr("style", style);
    });
    check_if_in_view();
    window.onload = function () {
        check_if_in_view();
        $(window).scroll(function () {
            check_if_in_view();
        });
    }


    /* MAPA ONDE ESTAMOS */
    if (jQuery("#onde-estamos").length) {
        var map;
        var image_empreendimento = 'assets/images/marker-besni.png';
        map = new GMaps({
            div: '#map',
            zoom: 12,
            scrollwheel: true,
            lat: -23.5500722,
            lng: -46.6353697
        });

        map.addMarker({
            lat: -23.6713737,
            lng: -46.74125389999995,
            icon: image_empreendimento,
            title: 'BESNI - Estrada do Mboi Mirim, 830/840',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Estrada do Mboi Mirim, 830/840</p > '
            }
        });

        map.addMarker({
            lat: -22.9251553,
            lng: -47.12635,
            icon: image_empreendimento,
            title: 'BESNI - Av. John Boyd Dunlop, 3900  lj 2054/2055',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av.John Boyd Dunlop, 3900  lj 2054/2055</p > '
            }
        });

        map.addMarker({
            lat: -23.9673408,
            lng: -46.33393299999999,
            icon: image_empreendimento,
            title: 'BESNI - Rua Marcílio Dias, 02/06',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Marcílio Dias, 02/06</p>'
            }
        });

        map.addMarker({
            lat: -23.9672716,
            lng: -46.38595489999999,
            icon: image_empreendimento,
            title: 'BESNI - Rua Martim Afonso, 410/420',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Martim Afonso, 410/420</p>'
            }
        });

        map.addMarker({
            lat: -23.5932345,
            lng: -46.5851935,
            icon: image_empreendimento,
            title: 'BESNI - Av. Dr. Francisco de Mesquita, 1000 &#8211; Arco M',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Dr. Francisco de Mesquita, 1000 &#8211; Arco M</p>'
            }
        });

        map.addMarker({
            lat: -23.691524,
            lng: -46.6232392,
            icon: image_empreendimento,
            title: 'BESNI - Rua Manoel da Nobrega, 712 &#8211; Loja 318 &#8211; Piso Paineiras',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Manoel da Nobrega, 712 &#8211; Loja 318 &#8211; Piso Paineiras</p>'
            }
        });

        map.addMarker({
            lat: -23.71022,
            lng: -46.5506997,
            icon: image_empreendimento,
            title: 'BESNI - Rua Marechal Deodoro, 1356/1360',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Marechal Deodoro, 1356/1360</p>'
            }
        });

        map.addMarker({
            lat: -23.6680472,
            lng: -46.4604136,
            icon: image_empreendimento,
            title: 'BESNI - Av. Barão de Maúa, 313',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Barão de Maúa, 313</p>'
            }
        });

        map.addMarker({
            lat: -23.6670621,
            lng: -46.4597801,
            icon: image_empreendimento,
            title: 'BESNI - Av. Governador Mario Covas Junior, 1 &#8211;  Loja 220',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Governador Mario Covas Junior, 1 &#8211;  Loja 220</p>'
            }
        });

        map.addMarker({
            lat: -23.6644134,
            lng: -46.5078915,
            icon: image_empreendimento,
            title: 'BESNI - Av. Geovanni Batistta Pirelli, 155  &#8211; terreo luc 148/345',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Geovanni Batistta Pirelli, 155  &#8211; terreo luc 148/345</p>'
            }
        });

        map.addMarker({
            lat: -23.6575223,
            lng: -46.52713240000003,
            icon: image_empreendimento,
            title: 'BESNI - Av. Industrial, 600 Arco 52/53/54',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Industrial, 600 Arco 52/53/54</p>'
            }
        });

        map.addMarker({
            lat: -23.657548,
            lng: -46.5271245,
            icon: image_empreendimento,
            title: 'BESNI - Rua Coronel Oliveira Lima, 383',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Coronel Oliveira Lima, 383</p>'
            }
        });

        map.addMarker({
            lat: -23.6701797,
            lng: -46.7730498,
            icon: image_empreendimento,
            title: 'BESNI - Av. Comendador Santana, 360',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Comendador Santana, 360</p>'
            }
        });

        map.addMarker({
            lat: -23.6544675,
            lng: -46.70747129999999,
            icon: image_empreendimento,
            title: 'BESNI - Rua Paulo Eiró, 80',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Paulo Eiró, 80</p>'
            }
        });

        map.addMarker({
            lat: -23.6523081,
            lng: -46.705689,
            icon: image_empreendimento,
            title: 'BESNI - Av. Adolfo Pinheiro, 10',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Adolfo Pinheiro, 10</p>'
            }
        });

        map.addMarker({
            lat: -23.6506613,
            lng: -46.70759700000001,
            icon: image_empreendimento,
            title: 'BESNI - Praça Floriano Peixoto, 02',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Praça Floriano Peixoto, 02</p>'
            }
        });

        map.addMarker({
            lat: -23.6085435,
            lng: -46.7541021,
            icon: image_empreendimento,
            title: 'BESNI - Rod. Régis Bittencourt &#8211; Br 116, Km 271,5 Loja 43 a 46',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rod. Régis Bittencourt &#8211; Br 116, Km 271,5 Loja 43 a 46</p>'
            }
        });

        map.addMarker({
            lat: -23.5401594,
            lng: -46.7657347,
            icon: image_empreendimento,
            title: 'BESNI - Av. dos Autonomistas, 1400 Ancora L',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. dos Autonomistas, 1400 Ancora L</p>'
            }
        });

        map.addMarker({
            lat: -23.5334486,
            lng: -46.77546289999998,
            icon: image_empreendimento,
            title: 'BESNI - Rua Antonio Agú, 369',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Antonio Agú, 369</p>'
            }
        });

        map.addMarker({
            lat: -23.5420947,
            lng: -46.76608139999996,
            icon: image_empreendimento,
            title: 'BESNI - Rua Dona Primitiva Vianco, , 561',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Dona Primitiva Vianco, , 561</p>'
            }
        });

        map.addMarker({
            lat: -23.4701218,
            lng: -46.52982189999999,
            icon: image_empreendimento,
            title: 'BESNI - Rua Dom Pedro II, 103/107',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Dom Pedro II, 103/107</p>'
            }
        });

        map.addMarker({
            lat: -23.443959,
            lng: -46.44767179999999,
            icon: image_empreendimento,
            title: 'BESNI - Rod. Presidente Dutra, Km 230  &#8211; Loja K 01',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rod. Presidente Dutra, Km 230  &#8211; Loja K 01</p>'
            }
        });

        map.addMarker({
            lat: -23.6750376,
            lng: -46.6775792,
            icon: image_empreendimento,
            title: 'BESNI - Av. Interlagos, 2255  Âncora 06',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Interlagos, 2255  Âncora 06</p>'
            }
        });

        map.addMarker({
            lat: -23.6174376,
            lng: -46.6388869,
            icon: image_empreendimento,
            title: 'BESNI - Av. Jabaquara, 1495',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Jabaquara, 1495</p>'
            }
        });

        map.addMarker({
            lat: -23.4703942,
            lng: -46.6655224,
            icon: image_empreendimento,
            title: 'BESNI - Av. Parada Pinto, 417',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Parada Pinto, 417</p>'
            }
        });

        map.addMarker({
            lat: -23.5202377,
            lng: -46.7042186,
            icon: image_empreendimento,
            title: 'BESNI - Rua 12 de Outubro, 232/238',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua 12 de Outubro, 232/238</p>'
            }
        });

        map.addMarker({
            lat: -23.4757129,
            lng: -46.35253230000001,
            icon: image_empreendimento,
            title: 'BESNI - Rua Capitão José Leite, 70',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Capitão José Leite, 70</p>'
            }
        });

        map.addMarker({
            lat: -23.5254224,
            lng: -46.1942183,
            icon: image_empreendimento,
            title: 'BESNI - Rua Dr. Deodato Wertheimer, 1437',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Dr. Deodato Wertheimer, 1437</p>'
            }
        });

        map.addMarker({
            lat: -23.5399167,
            lng: -46.3101096,
            icon: image_empreendimento,
            title: 'BESNI - Rua General Francisco Glicério, 623',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua General Francisco Glicério, 623</p>'
            }
        });

        map.addMarker({
            lat: -23.493826,
            lng: -46.43976199999999,
            icon: image_empreendimento,
            title: 'BESNI - Av. Marechal Tito, 655',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av. Marechal Tito, 655</p>'
            }
        });

        map.addMarker({
            lat: -23.5397557,
            lng: -46.4619639,
            icon: image_empreendimento,
            title: 'BESNI - Av.  Contorno,  Ljs. 239/240',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Av.  Contorno,  Ljs. 239/240</p>'
            }
        });

        map.addMarker({
            lat: -23.565637,
            lng: -46.50706599999999,
            icon: image_empreendimento,
            title: 'BESNI - Avenida Aricanduva, 5555 Arco 102',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Avenida Aricanduva, 5555 Arco 102</p>'
            }
        });

        map.addMarker({
            lat: -23.5241351,
            lng: -46.5472066,
            icon: image_empreendimento,
            title: 'BESNI - Rua Dr. João Ribeiro, 428 /452',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Dr. João Ribeiro, 428 /452</p>'
            }
        });

        map.addMarker({
            lat: -23.5386663,
            lng: -46.5749392,
            icon: image_empreendimento,
            title: 'BESNI - Rua Gonçalves Crespo,  Lojas 224B/22B e 32/322',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Gonçalves Crespo,  Lojas 224B/22B e 32/322</p>'
            }
        });

        map.addMarker({
            lat: -23.5437787,
            lng: -46.6402302,
            icon: image_empreendimento,
            title: 'BESNI - Rua Vinte E Quatro De Maio, 185/189',
            infoWindow: {
                content: '<p><strong>Endereço:</strong><br>Rua Vinte E Quatro De Maio, 185/189</p>'
            }
        });


        jQuery(".cep").keydown(function (e) {
            if (e.which == 13) {
                $('.btn-buscar').click();
            }
        });

        $('.btn-buscar').click(function (e) {
            GMaps.geocode({
                address: $('.cep').val(),
                callback: function (results, status) {
                    if (status == 'OK') {

                        var latlng = results[0].geometry.location;
                        var latNext = 0;
                        var longNext = 0;

                        find_closest_marker(latlng.lat(), latlng.lng())

                        function find_closest_marker(lat, lng) {
                            var R = 6371; // radius of earth in km
                            var distances = [];
                            var closest = -1;
                            for (i = 0; i < map.markers.length; i++) {
                                var mlat = map.markers[i].position.lat();
                                var mlng = map.markers[i].position.lng();
                                var dLat = rad(mlat - lat);
                                var dLong = rad(mlng - lng);
                                var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                                    Math.cos(rad(lat)) * Math.cos(rad(lat)) * Math.sin(dLong / 2) * Math.sin(dLong / 2);
                                var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                                var d = R * c;
                                distances[i] = d;
                                if (closest == -1 || d < distances[closest]) {
                                    closest = i;
                                }
                            }
                            latNext = map.markers[closest].position.lat();
                            longNext = map.markers[closest].position.lng();

                        }
                        function rad(x) { return x * Math.PI / 180; }

                        map.setCenter(latNext, longNext);
                        map.setZoom(14);

                    }
                    else {
                        alert("CEP não localizado")
                    }
                }
            });

        });

    }

});



function getVal(array, val, dir) {
    for (var i = 0; i < array.length; i++) {
        if (dir == true) {
            if (array[i] > val) {
                return array[i - 1] || 0;
            }
        } else {
            if (array[i] >= val) {
                return array[i];
            }
        }
    }
}

function check_if_in_view() {
    var $animation_elements = $('.animation');
    var $window = $(window);

    var window_height = $window.height();
    var window_top_position = $window.scrollTop();
    var window_bottom_position = (window_top_position + window_height);

    $.each($animation_elements, function () {
        var $element = $(this);
        var element_height = $element.outerHeight();
        var element_top_position = $element.offset().top - 110;
        var element_bottom_position = (element_top_position + element_height);

        //check to see if this current container is within viewport
        if ((element_bottom_position >= window_top_position) &&
            (element_top_position <= window_bottom_position)) {

            if ($element.data("delay") != undefined) {
                setTimeout(function () {
                    $element.addClass('ready-animation');
                }, $element.data("delay"))
            }
            else {
                $element.addClass('ready-animation');
            }

            
        }
    });
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