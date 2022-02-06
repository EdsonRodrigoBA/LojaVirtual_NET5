$(document).ready(function () {
    //Dialogo de confirmação eventos excluir listagem
    $(".btn-excluir").click(function (e) {
        var result = confirm("Tem certeza que deseja excluir ?");
        if (result == false) {
            e.preventDefault();

        }
    });

    //Dialogo de confirmação eventos excluir imagem
    $(".btn-imagem-excluir").click(function (e) {
        var result = confirm("Tem certeza que deseja excluir ?");
        if (result == false) {
            e.preventDefault();

        }
    });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });
    $('.cep').mask('00.000-000', { reverse: true });
    $('.creditcard').mask('0000 000 000 000 0000', { reverse: true });



    AjaxUploadImagemProduto();
    mudarquantidadeProdutoCarrinho();
    AcaoBotaoCalcularFrete();
    AjaxCalcularFrete(false);

});


function AcaoBotaoCalcularFrete() {
    $(".btn-calcular-frete").click(function (e) {
        AjaxCalcularFrete(true);
        e.preventDefault();
    });
}

function CalcularFrete_inputCepLeave() {

}

function AjaxCalcularFrete(chamado_no_clique_botao) {
    //salva o cep no cockie via jquery para sempre que o usuario for comprar não precisar informar novamente.
    $(".btnContinuar").addClass("disabled");

    if (chamado_no_clique_botao == false) {
        if ($.cookie('Carrinho.CEP') != undefined) {

            $(".cep").val($.cookie('Carrinho.CEP'));
        }
    }

    var cep = $(".cep").val().replace(".", "").replace("-", "");
    $.removeCookie("Carrinho.TipoFrete");
    if (cep.length == 8) {

        $.cookie('Carrinho.CEP', $(".cep").val(), { expires: 7 });


        $(".container-frete").html("<img src='img/loading-buffering.gif' \> <br \>");
        $(".total_compracarrinho").text("R$ 0,00");
        $(".valor_fretecarrinho").text("R$ 0,00");
        $.ajax({
            type: "GET",
            url: "/Carrinho/CalcularFreteCorreio?cedpdestino=" + cep,
            error: function (data) {
                alert("Erro no envio do arquivo");
            },
            success: function (data) {

                html = "";
                //console.info(data);

                for (var i = 0; i < data.length; i++) {

                    var tipofrete = data[i].tipofrete;
                    var valor = data[i].valor;
                    var prazo = data[i].prazo;

                    html += " <dl class=\"dlist-align\"><dt><input type=\"radio\" name=\"name\" value=\"" + tipofrete + "\"class=\"form-control\" /><input type=\"hidden\" name=\"valor\" value=\"" + valor + "\" /></dt > <dd>" + tipofrete + " - " + numberToReal(valor
                    ) + " (" + prazo + " dias uteis ).</dd></dl> <br/><br/>"
                }

                $(".container-frete").html(html);

                $(".container-frete").find("input[type=radio]").change(function () {

                    var valorfrete = parseFloat($(this).parent().find("input[name=valor]").val());

                    $.cookie("Carrinho.TipoFrete", $(this).val());
                    $(".btnContinuar").removeClass("disabled");

                    $(".valor_fretecarrinho").text(numberToReal(valorfrete));

                    var subtotal = parseFloat($(".subtotalcarrinho").text().replace("R$", "").replace(".", "").replace(",", "."));

                    var totalcompracarinho = valorfrete + subtotal;

                    $(".total_compracarrinho").text(numberToReal(totalcompracarinho));
                });
            }

        });
    }
    else {
        if (chamado_no_clique_botao == true) {
            $(".container-frete").html("");
            MostrarMensagemErroCarrinho("O CEP informado é Inválido.")

        }
    }
}

function numberToReal(numero) {
    var numero = numero.toFixed(2).split('.');
    numero[0] = "R$ " + numero[0].split(/(?=(?:...)*$)/).join('.');
    return numero.join(',');
}

function AjaxUploadImagemProduto() {
    $(".img-updload").click(function () {
        $(this).parent().parent().find(".input-file").click();
    });
    $(".btn-imagem-excluir").click(function () {
        var campoHidemImagem = $(this).parent().find("input[name=imagem]");
        var imagem = $(this).parent().find(".img-updload");
        var btnExcluir = $(this).parent().find(".btn-imagem-excluir");
        var inputfile = $(this).parent().find(".input-file");

        $.ajax({
            type: "GET",
            url: "/Colaboradores/Imagens/Deletar?path=" + campoHidemImagem.val(),
            error: function () {
                alert("Erro no envio do arquivo");
            },
            success: function (data) {

                imagem.attr("src", "/img/image_padrao.png");
                btnExcluir.addClass("btn-imagem-ocutar");
                campoHidemImagem.val("");
                inputfile.val("");

            }

        });
    });


    $(".input-file").change(function () {


        var campoHidemImagem = $(this).parent().find("input[name=imagem]");
        var imagem = $(this).parent().find(".img-updload");
        var btnExcluir = $(this).parent().find(".btn-imagem-ocutar");

        //montando formulario pra pegar imagens via JS
        var binario = $(this)[0].files[0];
        var formulario = new FormData();
        formulario.append("file", binario);
        //exibir imagem.
        imagem.attr("src", "/img/loading-buffering.gif");
        imagem.addClass("thumb-loading");

        $.ajax({

            type: "POST",
            url: "/Colaboradores/Imagens/CadastrarImagem",
            data: formulario,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro no envio do arquivo");
                imagem.attr("src", "img/image_padrao.png");
                imagem.removeClass("thumb-loading");


            },
            success: function (data) {
                imagem.removeClass("thumb-loading");

                var caminho = data.caminho;
                imagem.attr("src", caminho);
                campoHidemImagem.val(caminho);
                btnExcluir.removeClass("btn-imagem-ocutar");

            }

        });

    });
}



function mudarquantidadeProdutoCarrinho() {



    $("#order .btn-primary").click(function (e) {
        OcutarMensagemErroCarrinho();
        if ($(this).hasClass("diminuir")) {
            Logica_MudarQuantidadeProdutoCarrinho("diminuir", $(this));
            e.preventDefault();

        }

        if ($(this).hasClass("aumentar")) {

            Logica_MudarQuantidadeProdutoCarrinho("aumentar", $(this));
            e.preventDefault();


        }

    });
}


function Logica_MudarQuantidadeProdutoCarrinho(operacao, botao) {

    var pai = botao.parent().parent();
    var produtoId = parseInt(pai.find(".input_produto_id").val());
    var quantidadeEstoque = parseInt(pai.find(".inputQuantidadeEstoque").val());
    var valorunitario = parseFloat(pai.find(".inputValorUnitario").val().replace(",", "."));
    var campoQuantidadeProdutoCarrinho = pai.find(".inputQuantidadeProdutoCarrinho");
    var quantidadeCarrinhoAntiga = parseInt(campoQuantidadeProdutoCarrinho.val());

    var valortotal = botao.parent().parent().parent().parent().parent().find(".price")

    var produtocarrinho = new ProdutoQuantidadeValor(produtoId, quantidadeEstoque, valorunitario, 0, quantidadeCarrinhoAntiga, campoQuantidadeProdutoCarrinho, valortotal);
    AlteracoesVisuais_Carrinho(produtocarrinho, operacao)
}



function AlteracoesVisuais_Carrinho(produtocarrinho, operacao) {

    if (operacao == "aumentar") {


        produtocarrinho.quantidadeprodutoCarrinhoAtual = produtocarrinho.quantidadeprodutoCarrinhoAntiga + 1;

        AtualizarQuantidade_Valor(produtocarrinho);
        AjaxAtualizarCarrinhoServer(produtocarrinho);
    }

    if (operacao == "diminuir") {

        if (produtocarrinho.quantidadeprodutoCarrinhoAntiga == 1) {
            produtocarrinho.quantidadeprodutoCarrinhoAntiga = 1;
        }
        else {
            produtocarrinho.quantidadeprodutoCarrinhoAtual = produtocarrinho.quantidadeprodutoCarrinhoAntiga - 1;

            AtualizarQuantidade_Valor(produtocarrinho);
            AjaxAtualizarCarrinhoServer(produtocarrinho);

        }

    }
}

function AtualizarQuantidade_Valor(produtocarrinho) {

    produtocarrinho.campoQuantidadeProdutoCarrinho.val(produtocarrinho.quantidadeprodutoCarrinhoAtual);

    var resultado = numberToReal(produtocarrinho.valorunitario * produtocarrinho.quantidadeprodutoCarrinhoAtual);
    produtocarrinho.campovalor.text(resultado);
    AtualizarSubtotalCarrinho();
}

function AjaxAtualizarCarrinhoServer(produtocarrinho) {
    $.ajax({

        type: "GET",
        url: "/Carrinho/AlterarQuantidade?id=" + parseInt(produtocarrinho.ProdutoId) + "&quantidade=" + produtocarrinho.quantidadeprodutoCarrinhoAtual,

        error: function (data) {
            MostrarMensagemErroCarrinho(data.responseJSON.mensagem);
            produtocarrinho.quantidadeprodutoCarrinhoAtual = produtocarrinho.quantidadeprodutoCarrinhoAntiga;
            AtualizarQuantidade_Valor(produtocarrinho);

        },
        success: function (data) {

            AjaxCalcularFrete(false);
        }

    });
}

function MostrarMensagemErroCarrinho(mensagem) {
    $(".altert-carrinhocompras").css("display", "block");
    $(".altert-carrinhocompras").text(mensagem);

}
function OcutarMensagemErroCarrinho() {
    $(".altert-carrinhocompras").css("display", "none");


}

function AtualizarSubtotalCarrinho() {

    var tagsPrice = $(".price");
    var subtotal = 0;
    tagsPrice.each(function () {
        var valorReais = parseFloat($(this).text().replace("R$", "").replace(".", "").replace(",", ".").replace("Total: ", ""));
        subtotal += valorReais;
    });
    $(".subtotalcarrinho").text(numberToReal(subtotal));

}

/*classes*/
class ProdutoQuantidadeValor {


    constructor(ProdutoId, quantidadeestoque, valorunitario, quantidadeprodutoCarrinhoAtual, quantidadeprodutoCarrinhoAntiga, campoQuantidadeProdutoCarrinho, campovalor) {

        this.ProdutoId = ProdutoId;
        this.quantidadeestoque = quantidadeestoque;
        this.valorunitario = valorunitario;
        this.quantidadeprodutoCarrinhoAtual = quantidadeprodutoCarrinhoAtual;
        this.quantidadeprodutoCarrinhoAntiga = quantidadeprodutoCarrinhoAntiga;
        this.campoQuantidadeProdutoCarrinho = campoQuantidadeProdutoCarrinho;
        this.campovalor = campovalor;
    }
}