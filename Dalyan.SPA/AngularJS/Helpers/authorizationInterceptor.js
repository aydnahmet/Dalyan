publication.factory('authorizationInterceptor', ['$rootScope', '$q', '$location', 'localStorageService', '$window', function ($rootScope, $q, $location, localStorageService, $window) {
    return {
        request: function (config) {
            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        },

        responseError: function (rejection) {
            switch (rejection.status) {
                case 401: {
                    console.log($location);
                    $window.location.href = 'Login/Auth';
                    break;
                }
                default: {
                    break;
                }
            }

            return $q.reject(rejection);
        }
    };
}]);