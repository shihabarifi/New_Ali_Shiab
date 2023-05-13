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
        buttons: [{
            extend: 'collection',
            text: '<i class="bx bx-printer me-10"></i>Export ',
            className: 'btn btn-label-secondary mx-10',
           
            buttons: [{
                extend: 'copy',
                text: '<i class="bx bx-printer me-1"></i>copy ',
                className: 'btn btn-label-secondary mx-1',
                exportOptions:
                {
                    columns: [1] /// COLUMN INDEX HERE TO EXPORT 
                }
            },

            {
                extend: 'csv',
                text: '<i class="bx bx-printer me-1"></i>csv ',
                className: 'btn btn-label-success  mx-1',
                exportOptions: {
                    columns: [1] /// COLUMN INDEX HERE TO EXPORT 
                }
            },
            {
                extend: 'excel',
                text: '<i class="bx bx-printer me-1"></i>excel ',
                className: 'btn btn-label-secondary mx-1',
                exportOptions: {
                    columns: [1] /// COLUMN INDEX HERE TO EXPORT 
                }
            },
            {
                extend: 'pdf',
                text: '<i class="bx bx-printer me-1"></i>طباعة ',
                className: 'btn btn-label-danger  mx-1',
                exportOptions: {
                    columns: [1] /// COLUMN INDEX HERE TO EXPORT 
                }
            },
            {
                extend: 'print',
                text: '<i class="bx bx-printer me-1"></i>طباعة ',
                className: 'btn btn-label-danger mx-1',
                 customize: function (win) {
                    $(win.document.body)
                        .css('font-size', '10pt')
                        .prepend(
                            '<div><img src="/Images/Users/61505fd4-c198-4093-9eae-636eec267c33.JPG" class="rounded-circle"></div>'
                        );

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                },
                exportOptions: { columns: [3, 2, 1, 0] }
           
            }
            ]
        },
           
                   
            
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