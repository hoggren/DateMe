var VisitorViewModel = function() {
    var self = this;
    self.visitors = ko.observableArray([]);

    self.toRelativeTime = function(dateObj) {
        return moment(dateObj).fromNow();
    };
};

var visitorVm = new VisitorViewModel();

$(function() {
    ko.applyBindings(visitorVm, document.getElementById('visitors'));
    $.getJSON("/Api/Visitors/", function(data) {
        console.log(data);
        visitorVm.visitors(data);
    });
})