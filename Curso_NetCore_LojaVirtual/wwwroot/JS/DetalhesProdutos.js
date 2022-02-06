$(document).ready(function () {
    MudarImagemPrincipalProduto();


});

function MudarImagemPrincipalProduto() {
    $(".img-small-wrap img").click(function () {

        var caminho = $(this).attr("src");

        $(".img-big-wrap img").attr("src", caminho);
        $(".img-big-wrap a").attr("href", caminho);
    });
}