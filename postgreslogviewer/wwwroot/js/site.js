// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
document.querySelector('.custom-file-input').addEventListener('change', function (e) {
    var fileName = document.getElementById("file-input").files[0].name;
    var nextSibling = e.target.nextElementSibling
    nextSibling.innerText = fileName
})