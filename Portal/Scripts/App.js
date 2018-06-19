$(document).ready(function () {
    $('.thumbnail').click(function () {
        var name = $(this).find('img').attr('src');
        var mname = $('.carousel-inner').find("img[src='" + $(this).find('img').attr('src') + "']");
        $('.carousel-inner div').removeClass("active");
        $(mname).parent().addClass("active");
        $('#myModal').modal({
            backdrop: 'static',
        }, 'show');
    });
 
 
    $(function () {
        $("#myCarousel").carousel({
            interval: 5000
        });
    });
});