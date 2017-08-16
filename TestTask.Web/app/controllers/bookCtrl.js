app.controller('bookCtrl', ['$scope', 'bookSrv', function ($scope, bookSrv) {
    $scope.bookCreateModel = {};
    let get = function get() {
        bookSrv.get().then((data) => {
            $scope.books = data.map(function (item) { item.editionDate = new Date(item.editionDate); return item });
        });
    };
    get();

    $scope.searchByAuthorTitle = function (pattern) {
        bookSrv.searchByAuthorTitle(pattern).then((data) => {
            $scope.books = data.map(function (item)
            { item.editionDate = new Date(item.editionDate); return item });
        });
    };

    $scope.update = function (book) {
        bookSrv.update(book).then((data) => { },
            (data) => { alert('error: ' + data.data.modelState.exception); });
    };

    $scope.delete = function (bookId) {
        bookSrv.delete(bookId).then((data) => {
            get();
        });
    };

    $scope.create = function (book) {
        bookSrv.create(book).then((data) => { get(); },
            (data) => { alert('error: ' + data.data.modelState.exception); });
    };
    
}]);