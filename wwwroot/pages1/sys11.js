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

            lengthMenu: [5, 10, 25, 50, 100],
            dom:
                '<"row mx-1"' +
                '<"col-sm-12 col-md-1" l>' +
                '<"col-sm-12 col-md-11"<"dt-action-buttons text-xl-end text-lg-start text-md-end text-start d-flex align-items-center justify-content-md-between justify-content-center flex-wrap me-1"<"me-3"f>B>>' +
                '>t' +
                '<"row mx-2"' +
                '<"col-sm-12 col-md-6"i>' +
                '<"col-sm-12 col-md-6"p>' +
                '>',
            language: {
                sLengthMenu: '_MENU_',
                search: '',
                searchPlaceholder: 'بحث..',
                paginate: {
                    first: 'الأول',
                    last: 'الأخير',
                    next: 'التالي',
                    previous: 'السابق'
                }
            },
            // Buttons with Dropdown
            buttons: [
                {
                    extend: 'print',
                    text: '<i class="bx bx-printer me-2"></i>إصدار تقرير',
                    className: 'btn btn-label-secondary mx-3',
                    exportOptions: { columns: [3, 2, 1, 0] }
                },
                {
                    text: '<i class="icon-plus"></i>إضافة عملية',
                    className: 'add-new btn btn-primary mb-3 mb-md-0',
                    attr: {
                        'data-bs-toggle': 'offcanvas',
                        'data-bs-target': '#offcanvas'
                    },
                    init: function (api, node, config) {
                        $(node).removeClass('btn-secondary');
                    }
                },
                
          
        
      ],
    });
  }


  // Delete Record
  //$('.datatables-permissions tbody').on('click', '.delete-record', function () {
  //  dt_permission.row($(this).parents('tr')).remove().draw();
  //});

  // Filter form control to default size
  // ? setTimeout used for multilingual table initialization
  setTimeout(() => {
    $('.dataTables_filter .form-control').removeClass('form-control-sm');
    $('.dataTables_length .form-select').removeClass('form-select-sm');

  }, 300);
});


document.getElementById("third-party").addEventListener('click', ev => {
  sectionSelectInput.hidden = true;
});