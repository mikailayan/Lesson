////document.getElementById("#link1").addEventListener("click", function (event) {
////	document.querySelector("#link1").classList("kırmızı");
////	event.preventDefault();
////});

$(document).ready(function () {
    $("li a").each(function () {
        if ($(this).attr("href") == window.location.pathname) {
            $(this).addClass("activeLink")
        }
    })
})

let a = $("li a").toArray();
console.log(a);