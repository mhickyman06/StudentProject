// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var isclick ;

$(".navbar-toggler").on('click',function(){
    isclick = true; 
    console.log(isclick);
    
    $(".custom-nav-div").css("margin-left","0")
});

$(document).ready(function () {
    $(".landing-text").animate({
        right: '20px',
    }, "slow");
});


