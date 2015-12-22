var MessageViewModel = function() {
    var self = this;
    self.messages = ko.observableArray([]);

    self.toRelativeTime = function(dateObj) {
        return moment(dateObj).fromNow();
    };
}

var vm = new MessageViewModel();

$(function() {
    ko.applyBindings(vm);

    $.getJSON("/Api/Messages/", function (data) {
        vm.messages(data);
    });
});
