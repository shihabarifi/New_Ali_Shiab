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
                text: '<i class="bx bx-printer me-10"></i>تصدير ',
                className: 'btn btn-label-secondary mx-10',

                buttons: [{
                    extend: 'copy',
                    text: '<i class="bx bx-printer me-1"></i>نسخ ',
                    className: 'btn btn-label-secondary mx-1',
                    exportOptions:
                    {
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
                                '<div><img src="/Images/Users/‏‫‏‏لقطة شاشة‬ (2).png" ></div>'
                            );

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    },
                    exportOptions: { columns: [5,4,3, 2, 1, 0] }

                }
                ]
            },



            ],
        });

        $('#AccTypeDropdown, #currDropdown, #KindDropdown, #amountInput,#AccName').on('change', function () {
            var AccType = $('#AccTypeDropdown').val();
            var cur = $('#currDropdown').val();
            var Kind = $('#KindDropdown').val();
            var amount = $('#amountInput').val();
            var AccNa = $('#AccName').val();
            
            dt_permission.columns(3).search(AccType).draw(); // Replace '1' with the index of the column for role
            dt_permission.columns(2).search(cur).draw(); // Replace '2' with the index of the column for status
            dt_permission.columns(4).search(Kind).draw(); // Replace '3' with the index of the column for type
            dt_permission.columns(5).search(amount).draw();
            dt_permission.columns(1).search(AccNa).draw();
            dt_permission.draw();
        });

    }

    //// Delete Record
    //$('.datatables-permissions tbody').on('click', '.delete-record', function () {
    //    dt_permission.row($(this).parents('tr')).remove().draw();
    //});

    // Filter form control to default size
    // ? setTimeout used for multilingual table initialization
    setTimeout(() => {
        $('.dataTables_filter .form-control').removeClass('form-control-sm');
        $('.dataTables_length .form-select').removeClass('form-select-sm');

    }, 300);
});

//var sectionSelectInput = document.getElementById("section-select-input");
//document.getElementById("person").addEventListener('click', ev => {
//    sectionSelectInput.hidden = false;
//});
//document.getElementById("third-party").addEventListener('click', ev => {
//    sectionSelectInput.hidden = true;
//});

// Handle dropdown list change events
