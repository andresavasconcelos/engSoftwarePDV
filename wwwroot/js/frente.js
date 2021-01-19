/*Declaração de Variáveis */

var enderecoProduto = "https://localhost:5001/Produtos/Retornar/";
var produto;
var compra = [];
var __totalVenda__ = 0.0;

/*Inicio*/ 


function atualizarTotal(){
    $("#totalVenda").html(__totalVenda__);
}

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

    var venda = {produto: produtoTemp, quantidade: quant, subtotal: produtoTemp.precodeVenda * quant};

    __totalVenda__ += venda.subtotal;
    atualizarTotal();
    
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

    /*Finalização de venda */

    $("#FinalizarVendaBTN").click(function (){
        if(__totalVenda__ <= 0)
        {
            alert("Compra inválida, nenhuma produto adicionado");
            return;
        }

        var _valorPago = $("#valorPago").val();
    console.log(typeof _valorPago);
    if(!isNaN(_valorPago)){

        _valorPago = parseFloat(_valorPago);

        if(_valorPago >= __totalVenda__){

            $("#posvenda").show();
            $("#prevenda").hide(); 
            $("#valorPago").prop("disabled",true);
            
            var _troco = _valorPago - __totalVenda__;
            $("#troco").val(_troco);   
        
        }else{
            alert("Valor pago é muito baixo!");
            return;
        }
    }else{
        alert("Valor pago, inválido!");
        return;
    }
});

function restaurarModal(){
    $("#posvenda").hide();
    $("#prevenda").show(); 
    $("#valorPago").prop("disabled",false);
    $("#troco").val("");
    $("#valorPago").val(""); 
}

$("#fecharModal").click(function(){
    restaurarModal();
})