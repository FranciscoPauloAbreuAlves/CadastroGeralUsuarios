﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Chamar datatable JQuery
$(document).ready(function (){
    getDatatable('#table-contatos');
    getDatatable('#table-usuarios');
    getDatatable('#table-membros');
    getDatatable('#table-tarefas');

    // Open modal in AJAX callback
    $('.btn-total-contatos').click(function () {
        var usuarioId = $(this).attr('usuario-id');

        $.ajax({
            type: 'GET',
            url: '/Usuario/ListarConstatosPorUsuarioId/' + usuarioId,
            success: function (result) {
                $('#listaContatosUsuario').html(result);
                $('#modalContatosUsuario').modal();
                getDatatable("#table-contatos-usuario");
            }
        });
    });
})



function getDatatable(id) {
    $(id).DataTable({
            "ordenando": false,
            "paginação": true,
            "buscando": true,
            "oLanguage":
            {
                "sEmptyTable": "Nenhum registro encontrado na tabela",
                "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
                "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
                "sInfoFiltered": "(Filtrar de _MAX_ total de registros)",
                "sInfoPostFix": "",
                "sInfoMilhares": ".",
                "sLengthMenu": "Mostrar _MENU_ registros por pagina",
                "sLoadingRecords": "Carregando...",
                "sProcessando": "Processando...",
                "sZeroRecords": "Nenhum registro encontrado",
                "sSearch": "Pesquisar",
                "oPaginar":
                {
                    "sNext": "Próximo",
                    "sAnterior": "Anterior",
                    "sFirst": "Primeiro",
                    "sLast": "Ultimo"
                },
                "oAria":
                {
                    "sSortAscending": ": Ordenar colunas de forma ascendente",
                    "sSortDescending": ": Ordenar colunas de forma descendente"
                }
            }
        });
};


$(document).ready(function (id) {
    $(id).DataTable();
});

//Evento click nos botões de mensagens(sucesso e erro):
$('.close-alert').click(function() {
    $('.alert').hide('hide');
});
