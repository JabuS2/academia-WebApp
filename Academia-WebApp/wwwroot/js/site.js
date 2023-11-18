﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



$('#myTable').DataTable({
    "ordering": true,
    "paging": true,
    "searching": true,
    "oLanguage": {
        "sEmptyTable": "Nenhum registro encontrado na tabela",
        "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
        "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "Mostrar _MENU_ registros por pagina",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Proximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Ultimo"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    }
});

document.addEventListener('DOMContentLoaded', function () {
    var excluirModalBtn = document.getElementById('excluirModalBtn');
    var editModalBtn = document.getElementById('editModalBtn');

    var excluirModal = document.getElementById('excluirModal');
    var editModal = document.getElementById('editModal');

    var closeExcluirModalBtn = document.getElementById('closeExcluirModalBtn');
    var closeEditModalBtn = document.getElementById('closeEditModalBtn');

    var closeExcluirModalBtn2 = document.getElementById('closeExcluirModalBtn2');
    var closeEditModalBtn2 = document.getElementById('closeEditModalBtn2');

    excluirModalBtn.addEventListener('click', function () {
        excluirModal.style.display = 'block';
    });

    editModalBtn.addEventListener('click', function () {
        editModal.style.display = 'block';
    });

    closeExcluirModalBtn.addEventListener('click', function () {
        excluirModal.style.display = 'none';
    });

    closeEditModalBtn.addEventListener('click', function () {
        editModal.style.display = 'none';
    });

    closeExcluirModalBtn2.addEventListener('click', function () {
        excluirModal.style.display = 'none';
    });

    closeEditModalBtn2.addEventListener('click', function () {
        editModal.style.display = 'none';
    });

    window.addEventListener('click', function (event) {
        if (event.target == excluirModal) {
            excluirModal.style.display = 'none';
        } else if (event.target == editModal) {
            editModal.style.display = 'none';
        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var excluirButtons = document.querySelectorAll('.btn-excluir');
    var excluirModal = document.getElementById('excluirModal');
    var closeExcluirModalBtn = document.getElementById('closeExcluirModalBtn');
    var excluirBtn = document.querySelector('.btn-excluir-modal');
    var nomeClienteSpan = document.getElementById('nomeCliente');

    excluirButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            var clienteId = button.getAttribute('data-cliente-id');
            var nomeCliente = button.getAttribute('data-cliente-nome');

            // Atualizar o nome do cliente no modal
            nomeClienteSpan.textContent = nomeCliente;

            // Construir a URL do botão de exclusão no modal
            var urlExclusao = excluirBtn.getAttribute('href').split('?')[0] + '?id=' + clienteId;
            excluirBtn.setAttribute('href', urlExclusao);

            // Abrir o modal
            excluirModal.style.display = 'block';
        });
    });

    closeExcluirModalBtn.addEventListener('click', function () {
        // Fechar o modal
        excluirModal.style.display = 'none';
    });


});






// Write your JavaScript code.