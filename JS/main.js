/**
 * BibliotecaMVC - main.js
 * Interacciones y efectos para la interfaz de usuario
 */
document.addEventListener('DOMContentLoaded', function () {

    /* 
       1. CONFIRMACIÓN DE ELIMINACIÓN
    */
    document.querySelectorAll('.btn-delete').forEach(function (btn) {
        btn.addEventListener('click', function (e) {
            var titulo = btn.getAttribute('data-titulo') || 'este libro';
            var confirmar = confirm(
                '¿Está seguro de que desea eliminar el libro:\n"' + titulo + '"?\n\nEsta acción no se puede deshacer.'
            );
            if (!confirmar) {
                e.preventDefault();
            }
        });
    });

    /* 
       2. AUTO-OCULTAR ALERTAS DESPUÉS DE 5 SEGUNDOS
    */
    var alerts = document.querySelectorAll('.alert');
    if (alerts.length > 0) {
        setTimeout(function () {
            alerts.forEach(function (alert) {
                alert.style.transition = 'opacity 0.8s ease, transform 0.8s ease';
                alert.style.opacity = '0';
                alert.style.transform = 'translateY(-8px)';
                setTimeout(function () {
                    if (alert.parentNode) alert.parentNode.removeChild(alert);
                }, 800);
            });
        }, 5000);
    }

    /* 
       3. RESALTAR FILA DE TABLA AL PASAR EL MOUSE
    */
    document.querySelectorAll('table tbody tr').forEach(function (row) {
        row.addEventListener('mouseenter', function () {
            row.style.transition = 'background-color 0.2s';
        });
    });

    /* 
       4. EFECTO DE FOCO EN INPUT DE FILTRO
    */
    var filtroInput = document.getElementById('filtro');
    if (filtroInput) {
        filtroInput.addEventListener('focus', function () {
            filtroInput.parentElement.style.boxShadow = '0 0 0 3px rgba(59,130,246,0.15)';
            filtroInput.parentElement.style.borderRadius = '6px';
        });
        filtroInput.addEventListener('blur', function () {
            filtroInput.parentElement.style.boxShadow = '';
        });
    }

    /* 
       5. ANIMACIÓN FADE-IN PARA ELEMENTOS DE TABLA
    */
    var rows = document.querySelectorAll('table tbody tr');
    rows.forEach(function (row, index) {
        row.style.opacity = '0';
        row.style.transform = 'translateY(8px)';
        row.style.transition = 'opacity 0.3s ease, transform 0.3s ease';
        setTimeout(function () {
            row.style.opacity = '1';
            row.style.transform = 'translateY(0)';
        }, 60 * index);
    });

});
