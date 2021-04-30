
(function ($) {
    // 'use strict';

    // Main Navigation
    $('.hamburger-menu').on('click', function () {
        $(this).toggleClass('open');
        $('.site-navigation').toggleClass('show');
    });

    
    $(function () {
        $('.tab-content:first-child').show();

        $('.tab-nav').bind('click', function (e) {
            $this = $(this);
            $tabs = $this.parent().parent().next();
            $target = $($this.data("target"));
            $this.siblings().removeClass('active');
            $target.siblings().css("display", "none");
            $this.addClass('active');
            $target.fadeIn("slow");
        });

        $('.tab-nav:first-child').trigger('click');
    });

})(jQuery);

function DeleteConfirm(uniqueid, isdeleclicked) {
    var deleteconfirmed = $("#Deleteconfirmed_" + uniqueid);
    var deleteid = $("#Delete_" + uniqueid);
    if (isdeleclicked) {
        deleteid.hide();
        deleteconfirmed.show();


    } else {
        deleteid.show();
        deleteconfirmed.hide();
    }
}