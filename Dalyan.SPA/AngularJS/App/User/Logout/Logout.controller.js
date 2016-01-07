DalyanControllers.controller('LogoutController',
    ['$scope', '$routeParams', 'AuthenticationService', 'localStorageService',
        function ($scope, $routeParams, authenticationService, localStorageService) {
            
            init();

            function init() {
                _logout();
            }

            function _logout() {
                localStorageService.clearAll();
                document.location = "Login/Auth";
            }

        }]);