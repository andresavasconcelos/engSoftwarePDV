// console.log("Olá Mundo");
// console.log($);

/*Declaração de Variáveis */

var enderecoProduto = "https://localhost:5001/Gestao/Produtos/Produto/";

/* */

$("#pesquisar").click(function(){
    var codProduto = $("#codProduto").val(); 
    var enderecoTemporario = enderecoProduto+codProduto;
    $.post(enderecoTemporario, function(dados, status){
        alert("Dados:" + dados + "Status: " + status);
    });
});