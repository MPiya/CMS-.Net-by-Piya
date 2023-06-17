﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
}); 

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                  // data is a place holder for json object from GetALL Product, in this case its id,  
                "data": "id",
                "render": function (data) {
                    return `   
                    <div class="w-75  btn-group" role = "group">
                            <a href="/Admin/Product/Upsert?id=${data}"
                           class="btn btn-primary mx-2" > <i class="bi bi-pen"></i>  Edit </a>
<a onClick=Delete('/Admin/Product/DeletePost/+${data}')
                              class="btn btn-primary mx-2"> <i class="bi bi-pen"></i>  Delete </a>
                    </div > `
                      
                    
                },
            }

        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
                })
            
        }
    })
}