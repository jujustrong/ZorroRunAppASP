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

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
});