// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.btn-edit').on('click', function () {
    console.log($(this).data)
    $('#editModal #firstName').val($(this).data('first'));
    $('#editModal #lastName').val($(this).data('last'));
    $('#editModal #email').val($(this).data('mail'));    
});