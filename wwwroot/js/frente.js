/*Declaração de Variáveis */

var enderecoProduto = "https://localhost:5001/Produtos/Retornar/";
var produto;
var compra = [];

/* Funções */
function preencherFormulario(dadosProdutos){

    $("#campoNome").val(dadosProdutos.name);
    $("#campoCategoria").val(dadosProdutos.categoria.name);
    $("#campoForncedor").val(dadosProdutos.fornecedor.name);
    $("#campoPreco").val(dadosProdutos.precodeVenda);
}

function ZerarFormulario(){

    $("#campoNome").val("");
    $("#campoCategoria").val("");
    $("#campoForncedor").val("");
    $("#campoPreco").val("");
    $("#campoQuantidade").val("");
}

function adicionandoNaTabela(prod, quant){
    var produtoTemp = {};

    Object.assign(produtoTemp, produto);
    compra.push(produtoTemp);
    $("#compras").append(`<tr>
        <td>${prod.id}</td>
        <td>${prod.name}</td>
        <td>${quant}</td>
        <td>${prod.precodeVenda} R$</td>
        <td>${prod.medicao}</td>
        <td>${prod.precodeVenda * quant} R$</td>
        <td><button class="btn btn-danger">Remover</button></td>
    </tr>`);
}

$("#produtoForm").on("submit", function(event){
    event.preventDefault(); // impede que o formulario carreque a pagina
    var produtoParaTabela = produto;
    var qtd = $("#campoQuantidade").val(); 
    console.log(produtoParaTabela);
    console.log(qtd);
    adicionandoNaTabela(produtoParaTabela, qtd);

    // var produto = undefined; // limpa a tabela
    ZerarFormulario();
});

/* Ajax */

$("#pesquisar").click(function(){
    var codProduto = $("#codProduto").val();
    var enderecoTemporario = enderecoProduto+codProduto;
    $.post(enderecoTemporario, function(dados, status){
        console.log(dados);
        produto = dados;

        var med = "";

        switch(produto.medicao){
            case 0:
                med = "L"
                break;
            case 1:
                med = "K"
                break;
            case 2:
                med = "U"                
                break;

            default:
                med = "U"
                break;
        }
        preencherFormulario(produto);
    }).fail(function(){
        alert("Produto inválido!")
    });
});