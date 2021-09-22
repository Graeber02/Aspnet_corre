/*$(document).ready(function ({
    loadCidades();
}));

function loadCidades() {
    CidadeListaCidades('').then(function (data) {
        data.forEach(obj => {
            $('#cidadeId').append('<option value ="' + obj.id + '">' + obj.nome + '</optin>')
        });
        $('#cidadeId').select2();
    });
}
*/

function salvar() {
    let obj = {

        nome: ($("[name='Nome']").val() || ''),
        datanasc: ($("[name='Data Nasc.']").val() || ''),
        cidade: ($("[name='Cidade']").val() || ''),
        ativo: ($("[name='Ativo']").val() || '')
    };


    CidadeSalvar(obj).then(function () {
        window.location.href = '/pessoa';
    }, function (err) {
        alert(err);
    });
}
