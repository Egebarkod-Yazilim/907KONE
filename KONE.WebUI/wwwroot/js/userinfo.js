$(document).ready(function () {
    var back = ["#ff0000", "blue", "gray"];
    //var rand = back[Math.floor(Math.random() * back.length)];
    
    //$('div').css('background', rand);

    c = document.querySelectorAll("div#role-badges-div a span");

    Array.from(c).forEach(function (itm) {
        var rand = '#' + ('000000' + Math.floor(Math.random() * 16777215).toString(16)).slice(-6);
        console.log(rand);
        itm.style.backgroundColor = rand;
    });
});