app.factory('bookSrv',function ($http,$q) {
        let serverUrl = 'http://localhost:16334/api/';
        return {
            get: function () {
                var deferred = $q.defer();
                $http({ method: 'GET', url: serverUrl+'Book/Get' }).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.reject(response.status);
                    }
                    );
                return deferred.promise;
            },
            searchByAuthorTitle: function (pattern) {
                var deferred = $q.defer();
                $http({ method: 'GET', url: serverUrl + 'Book/SearchByAuthorTitle', params: { searchPattern: pattern } }).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.reject(response.status);
                    }
                    );
                return deferred.promise;
            },
            update: function (book) {
                var deferred = $q.defer();
                $http({
                    method: 'PUT', url: serverUrl + 'Book/Update', params: {
                        id: book.id,
                        author: book.author,
                        title: book.title,
                        editionDate: book.editionDate
                    }
                }).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.reject(response);
                    }
                    );
                return deferred.promise;
            },
            create: function (book) {
                var deferred = $q.defer();
                $http({
                    method: 'POST', url: serverUrl + 'Book/Create', params: {
                        id: book.id,
                        author: book.author,
                        title: book.title,
                        editionDate: book.editionDate
                    }
                }).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.reject(response);
                    });
                return deferred.promise;
            },
            delete: function (bookId) {
                var deferred = $q.defer();
                $http({
                    method: 'DELETE', url: serverUrl + 'Book/Delete', params: {id: bookId}}).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.reject(response.status);
                    }
                    );
                return deferred.promise;
            }
        }
});