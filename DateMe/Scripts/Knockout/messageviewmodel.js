var MessageViewModel = function() {
    var self = this;
    self.messages = ko.observableArray([]);
    self.toRelativeTime = function(dateObj) {
        return moment(dateObj).fromNow();
    };

    self.sendMessage = function() {
                var message = { Text: $("#message_text").val() };
                var id = $("#toUserId").val();

                $.ajax({
                    type: "POST",
                    data: JSON.stringify(message),
                    url: "../../api/messages/?toUserId=" + id,
                    contentType: "application/json",
                    success: function () {
                        alert("Funka!");
                    },
                    async: true
                });
    }

    self.removeMessage = function(message) {
        $.ajax({
            type: "DELETE",
            url: "../../api/messages/" + message.Id,
            contentType: "application/json",
            success: function () {
                self.messages.remove(message);
            },
            error: function () {
                alert("funkade inte");
            }
        });
    }
}

var vm = new MessageViewModel();

$(function() {
    ko.applyBindings(vm);

    $.getJSON("/Api/Messages/", function(data) {

        vm.messages(data);
        vm.messages.reverse();
    });
});
