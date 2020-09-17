/*Declaração de Variáveis */
var enderecoProduto = "https://localhost:5001/Gestao/Produtos/Retornar/1";
/* */

$("#pesquisar").click(function(){
    $.post(enderecoProduto, function(dados, status){
        alert("Dados: " + dados + "Status: " + status);
    });
});


