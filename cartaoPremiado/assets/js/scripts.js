var timeRotate;

jQuery(document).ready(function ($) {

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
    window.onload = function () {
        check_if_in_view();
        $(window).scroll(function () {
            check_if_in_view();
        });
    }

});



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
            $element.addClass('ready-animation');
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