// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function(e) {
        e.preventDefault();
        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});

document.querySelectorAll('.delete-run').forEach(button => {
    button.addEventListener('click', function(event) {
        const confirmed = confirm("Are you sure you want to delete this run?");
        if (!confirmed) {
            event.preventDefault();
        }
    });
});

$(window).scroll(function() {
    if ($(this).scrollTop() > 50) {
        $('.navbar').addClass('navbar-scrolled');
    } else {
        $('.navbar').removeClass('navbar-scrolled');
    }
});

$(document).ready(function(){
    let tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    let tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })
});

window.onscroll = function() {scrollProgress()};

function scrollProgress() {
    let scrollPosition = document.body.scrollTop || document.documentElement.scrollTop;
    let pageHeight = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    let scrollPercentage = (scrollPosition / pageHeight) * 100;
    document.getElementById("scrollIndicator").style.width = scrollPercentage + "%";
}