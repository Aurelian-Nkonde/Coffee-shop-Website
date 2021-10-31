// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const btn = document.getElementById("btn")
const curten = document.getElementById("curten")
btn.addEventListener("click", () => {
    curten.classList.toggle("hidden")
})