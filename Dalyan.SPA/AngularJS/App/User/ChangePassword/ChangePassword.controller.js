DalyanControllers.controller('ChangePasswordController',
    ['$scope', '$routeParams', 'UserService','$log',
        function ($scope, $routeParams, userService,$log) {
            $scope.saveUser = _saveUser;

            $scope.user;
            $scope.password;
            
            init();

            function init() {
                userService.getUserInfo().then(function (data) {
                    $scope.user = data;
                });
            }

            function _saveUser() {
                var currentUser = {
                    Password: $scope.password
                };

                userService.changeUserPassword(currentUser).then(function (data) {
                    if (data.State == 0) {
                        toastr.success(data.Message);
                    }
                    else {
                        toastr.error(data.Message, "Error");
                    }
                });
            }

        }]);
