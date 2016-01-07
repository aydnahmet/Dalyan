publication.factory('UserService', ['$http', '$q', function ($http, $q) {
    return {
        userAdd: _userAdd,
        userEdit: _userEdit,
        getUserInfo: _getUserInfo,
        getAllUsers: _getAllUsers,
        getUser: _getUser,
        saveUser: _saveUser,
        userList: _userList,
        userDelete:_userDelete,
        changeUserPassword: _changeUserPassword,
        userRetrieve: _userRetrieve,
    };

    function _userRetrieve(Id) {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('User/Retrieve'), params: { "Id": Id } }).
            success(function (data, status, headers, config) {
                deferred.resolve(data.Result);
            });

        return deferred.promise;
    }

    function _userAdd(obj) {
        var deferred = $q.defer();

        var httpMethod = "POST";

        $http({ method: httpMethod, url: config.generateApiUrl('User/Add'), data: JSON.stringify(obj) }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _userEdit(obj) {
        var deferred = $q.defer();

        var httpMethod = "POST";

        $http({ method: httpMethod, url: config.generateApiUrl('User/Edit'), data: JSON.stringify(obj) }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _getUserInfo() {
        var deferred = $q.defer();

        $http({ method: 'GET', url: config.generateApiUrl('Authenticate/Get') }).
            success(function (data, status, headers, config) {
                deferred.resolve(data);
            });

        return deferred.promise;
    }

    function _userList() {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('User/GetAll') }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _userDelete(Id) {
        var deferred = $q.defer();

        var httpMethod = "POST";

        $http({ method: httpMethod, url: config.generateApiUrl('User/Delete'), params: { "Id": Id } }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _getAllUsers() {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('User/GetAll') }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

           return deferred.promise;
    }

    function _getUser(userID) {
        var deferred = $q.defer();

        $http({ method: 'GET', url: config.generateApiUrl('User/UserEdit'), params: { "userID": userID == null ? "" : userID } }).
            success(function (data, status, headers, config) {
                deferred.resolve(data);
            });

            return deferred.promise;
    }

    function _saveUser(user) {
        var deferred = $q.defer();

        var httpMethod = "POST";
        if (!user.UserData.UserID || user.UserData.UserID == 0) {
            httpMethod = "PUT";
        }

        $http({ method: httpMethod, url: config.generateApiUrl('User/UserEdit'), data: JSON.stringify(user) }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

           return deferred.promise;
    }

    function _changeUserPassword(user) {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('User/ChangePassword'), params: { "Password": user.Password } }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

           return deferred.promise;
    }
}]);