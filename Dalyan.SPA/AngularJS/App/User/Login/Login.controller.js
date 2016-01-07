DalyanControllers.controller('LoginController',
    ['$scope', '$routeParams', 'AuthenticationService', 'localStorageService',
        function ($scope, $routeParams, authenticationService, localStorageService) {
            $scope.Login = _login;
            
            $scope.loginEmail;
            $scope.loginPassword;
            $scope.loginState = true;

            function _login() {
                var loginUser = {
                    Email: $scope.loginEmail,
                    Password: $scope.loginPassword
                };

                authenticationService.Login(loginUser).then(function () {
                    document.location = "../#/dashboard/default";
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    $scope.loginState = false;
                });
            }

            $scope.errorClass = function () {
                if ($scope.loginState == true)
                    return 'display-hide';
                else
                    return 'display-show';
            };

        }]);