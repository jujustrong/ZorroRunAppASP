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
    let scrollPercentage = (scrollPosition / pageHeight) * 50;
    document.getElementById("scrollIndicator").style.width = scrollPercentage + "%";
}

document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: "smooth"
        });
    });
});

document.addEventListener('DOMContentLoaded', function () {
    let notesTextarea = document.getElementById('notes');
    let autosaveMessage = document.getElementById('autosave-message');
    let saveButton = document.getElementById('save-notes-btn');
    
    notesTextarea.addEventListener('input', function () {
        autosaveMessage.style.display = 'block';
        autosaveMessage.textContent = 'Typing...';
        autosaveMessage.classList.add('text-warning');
    });
    
    saveButton.addEventListener('click', function () {
        autosaveMessage.textContent = 'Saving...';
        autosaveMessage.classList.remove('text-warning');
        autosaveMessage.classList.add('text-success');
    });
    
document.querySelector('form').addEventListener('submit', function(e) {
    e.preventDefault(); // Prevent default form submission
    let formData = new FormData(this);
    
    fetch(this.action, {
        method: 'POST',
        body: formData
    }).then(function(response) {
        return response.json();  // Or handle accordingly
    }).then(function(data) {
        autosaveMessage.textContent = 'Notes saved successfully!';
    }).catch(function(error) {
        autosaveMessage.textContent = 'Failed to save notes.';
    });
});

});
