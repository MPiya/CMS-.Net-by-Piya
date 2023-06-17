var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/company/getall' },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "state", "width": "15%" },

            { "data": "phoneNumber", "width": "15%" },
            { "data": "postalCode", "width": "15%" },


            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a onClick=Delete('/admin/company/deletePost/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}



function Delete(url) {
    swal.fire({
        title: 'are you sure?',
        text: "you won't be able to revert this!",
        icon: 'warning',
        showcancelbutton: true,
        confirmbuttoncolor: '#3085d6',
        cancelbuttoncolor: '#d33',
        confirmbuttontext: 'yes, delete it!'
    }).then((result) => {
        if (result.isconfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}