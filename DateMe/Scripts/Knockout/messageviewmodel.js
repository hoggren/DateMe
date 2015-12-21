var MessageViewModel = function() {
    var self = this;
    self.messages = ko.observableArray([]);
}

var vm = new MessageViewModel();

$(function() {
    ko.applyBindings(vm);

    $.getJSON("/Api/Messages/", function (data) {
        vm.messages(data);
    });
});
