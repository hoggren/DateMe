function modalConfirm(callback) {
    var modal = $(
        '<div class="modal fade" id="confirmModal">' +
            '<div class="modal-dialog">' +
                '<div class="modal-content">' +
                    '<div class="modal-body">Are you sure?</div>' +
                    '<div class="modal-footer">' +
                        '<button class="btn btn-default" type="button" data-dismiss="modal">No!</button>' +
                        '<button class="btn btn-danger" type="button" id="confirm-modal-btn">Yes...</button>' +
                    '</div>' +
                '</div>' +
            '</div>' +
        '</div>');

    $("body").prepend(modal);

    $("#confirm-modal-btn").click(function () {
        $("#confirmModal").modal("hide");
        callback();
    });

    $("#confirmModal").modal("show");
}