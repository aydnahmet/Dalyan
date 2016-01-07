publication.factory('CompanyService', ['$http', '$q', function ($http, $q) {
    return {
        companyAdd: _companyAdd,
        companyEdit: _companyEdit,
        companyRetrieve: _companyRetrieve,
        companyList: _companyList,
        companyDelete: _companyDelete,
    };

    function _companyRetrieve(Id) {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('Company/Retrieve'), params: { "Id": Id } }).
            success(function (data, status, headers, config) {
                deferred.resolve(data.Result);
            });

        return deferred.promise;
    }

    function _companyList() {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('Company/GetAll') }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _companyEdit(obj) {
        var deferred = $q.defer();

        var httpMethod = "POST";
        
        $http({ method: httpMethod, url: config.generateApiUrl('Company/Edit'), data: JSON.stringify(obj) }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _companyDelete(Id) {
        var deferred = $q.defer();

        var httpMethod = "POST";

        $http({ method: httpMethod, url: config.generateApiUrl('Company/Delete'), params: { "Id": Id } }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _companyAdd(obj) {
        var deferred = $q.defer();

        var httpMethod = "POST";

        $http({ method: httpMethod, url: config.generateApiUrl('Company/Add'), data: JSON.stringify(obj) }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

           return deferred.promise;
    }
}]);