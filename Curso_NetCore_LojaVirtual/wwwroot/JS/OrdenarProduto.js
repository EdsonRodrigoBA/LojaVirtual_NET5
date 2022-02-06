$(document).ready(function () {
    OrdenarListagemProduto();
    MoverScrolOrdenacaoProduto();

});

function OrdenarListagemProduto() {

    $("#ordenacao").change(function () {
        var pagina = 1;
        var pesquisa = "";
        var fragmento = "#myCarousel";
        var ordenacao = $(this).val();

        var queryString = new URLSearchParams(window.location.search);
        if (queryString.has("pagina")) {
            pagina = queryString.get("pagina");
        }
        if (queryString.has("pesquisa")) {
            pesquisa = queryString.get("pesquisa");
        }

        if ($("#breadcrumb").length > 0) {
            fragmento = "";
        }
        var url = window.location.protocol + "//" + window.location.host + window.location.pathname;
        var urlComparametros = url + "?pagina=" + pagina + "&pesquisa=" + pesquisa + "&ordenacao=" + ordenacao + fragmento;
        window.location.href = urlComparametros;
    });
}

//posociona o scrol na listagem do produto quando pesquisa ou ordena
function MoverScrolOrdenacaoProduto() {
    if (window.location.hash.length > 0) {
        var hashFragamento = window.location.hash;
        if (hashFragamento == "#myCarousel") {
            window.scrollBy(0, 460);
        }
    }
}