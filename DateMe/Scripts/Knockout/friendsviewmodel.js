var ModelView = function () {
    var self = this;

    self.categories = ko.observableArray(["Flirt", "Serious", "Cute", "Freak", "Maniac"]);

    self.changeCategory = function (friend, categoryDom) {
        var selectedCategory = ($(categoryDom).val());
        console.log(friend);
        if (selectedCategory) {
            $.ajax({
                url: "/api/friends/" + friend.Id + "?category=" + selectedCategory,
                type: "PUT",
                success: function () {
                    UpdateFriends();
                    UpdateUnconfirmed();
                    console.log('xx');
                }
            });
        }
    }

    self.unconfirmed = ko.observableArray();
    self.friends = ko.observableArray();
    self.orderBy = "";
    self.confirmFriend = function(id) {
        $.ajax({
            url: "/api/friends/" + id,
            type: "PUT",
            success: function() {
                UpdateFriends();
                UpdateUnconfirmed();
            }
        });
    }
    self.denyFriend = function (id) {
        $.ajax({
            url: "/api/friends/" + id,
            type: "DELETE",
            success: function () {
                UpdateFriends();
                UpdateUnconfirmed();
            }
        });
    }
    self.sortByColumn = function (col) {
        if (self.orderBy == col) {

            self.friends.reverse();

        } else {

            self.friends.sort(function (left, right) {
                return left[col] == right[col] ? 0 : (left[col] < right[col] ? -1 : 1);
            });

            self.orderBy = col;
        }
    };
};

var vm = new ModelView();

$(function() {
    ko.applyBindings(vm);
    UpdateFriends();
    UpdateUnconfirmed();
});

function UpdateFriends() {
    $("#ajax-loader").removeClass("hidden");

    $.getJSON("/Api/Friends/", function (data) {
        vm.friends(data);
        $("#ajax-loader").addClass("hidden");
    });
}

function UpdateUnconfirmed() {
    $("#ajax-loader").removeClass("hidden");

    $.getJSON("/Api/Friends/requests", function (data) {
        vm.unconfirmed(data);
        $("#ajax-loader").addClass("hidden");
    });
}