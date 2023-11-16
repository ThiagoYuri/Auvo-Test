// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function handleFileSelection() {
    var input = document.getElementById('ctrl');
    var files = input.files;

    for (var i = 0; i < files.length; i++) {
        var file = files[i];
        var fileName = file.name;
        var fileType = fileName.slice(((fileName.lastIndexOf(".") - 1) >>> 0) + 2);

        // Verificar se a extensão do arquivo é .csv
        if (fileType.toLowerCase() !== 'csv') {
            alert('Por favor, selecione pastas que contenham somente arquivos .csv.');
            // Limpar o campo de entrada para que o usuário possa selecionar novamente
            input.value = '';
            return;
        }
    }

    console.log('Arquivos .csv selecionados:', files);
}

function activateFileInput() {
    document.getElementById('ctrl').click();
}

