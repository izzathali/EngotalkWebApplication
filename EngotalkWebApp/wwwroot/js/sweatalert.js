$(function () {
    $(".delete").click(function () {
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this record!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {

                    swal("Poof! Your record file has been deleted!", {
                        icon: "success",
                    });
                } else {
                    swal("Your imaginary file is safe!");
                }
            });
    });
});


$(function () {
    $(".delete").click(function open(url) {
        var id = $(this).data('id');
        var action = $(this).data('action');
        var controller = $(this).data('controller');
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this record!" + controller + "/" + action + "/" + id,
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        type: "GET",
                        url: '@Url.Action("' + action + '", "' + controller + '")',
                        contentType: "application/json; charset=utf-8",
                        data: { id: id },
                        dataType: "json",
                        success: function (recData) { alert('Success'); },
                        error: function (ex) { alert('A error' + ex); }
                    });
                    swal("Poof! Your record file has been deleted!", {
                        icon: "success",
                    });
                } else {
                    swal("Your selected record is safe!");
                }
            });
    });
});