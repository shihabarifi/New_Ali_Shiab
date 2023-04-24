/**
 * Seasons (jquery)
 */

'use strict';

$(function () {
    var dataTablePermissions = $('.datatables-basic'),
        dt_permission;

    // Users List datatable
    if (dataTablePermissions.length) {
        dt_permission = dataTablePermissions.DataTable({
            order: [[1, 'asc']],
            scrollY: 400,
            ordering: false,
            dom:

                '<"row mx-1"' +
                '<"col-sm-12 col-md-11"<"dt-action-buttons text-xl-end  text-md-end text-start d-flex align-items-center justify-content-md-between justify-content-center flex-wrap me-1"<"me-6">>>' +
                '>t' +
                '<"row"' +
                '<"col-sm-12 col-md-6 position-absolute bottom-0 start-50 my-2"B>' + '>',
            language: {
                sLengthMenu: '_MENU_',
            },
            // Buttons with Dropdown
            buttons: [
                {
                    extend: 'print',
                    text: '<i class="bx bx-printer me-2 "></i>طباعة ',
                    className: 'btn btn-primary mx-auto w-50 ',
                    exportOptions: { columns: [4, 3, 2, 1, 0] }
                }
            ],
        });
    }

    // Delete Record
    $('.datatables-permissions tbody').on('click', '.delete-record', function () {
        dt_permission.row($(this).parents('tr')).remove().draw();
    });

    // Filter form control to default size
    // ? setTimeout used for multilingual table initialization
    setTimeout(() => {
        $('.dataTables_filter .form-control').removeClass('form-control-sm');
        $('.dataTables_length .form-select').removeClass('form-select-sm');

    }, 300);
});

var sectionSelectInput = document.getElementById("section-select-input");
document.getElementById("person").addEventListener('click', ev => {
    sectionSelectInput.hidden = false;
});
document.getElementById("third-party").addEventListener('click', ev => {
    sectionSelectInput.hidden = true;
});