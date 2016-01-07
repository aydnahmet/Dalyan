DalyanControllers.controller('CompanyListController',
    ['$scope', '$routeParams', '$modal', 'CompanyService',
        function ($scope, $routeParams, $modal, companyService) {
            $scope.company = [];
            $scope.companyDelete = _companyDelete;

            init();

            function init() {
                companyList();
            }

            function companyList() {

                companyService.companyList().then(function (data) {
                    if (data.State == 0) {
                        $scope.company = data.Result;
                    }
                    else {
                        toastr.error(data.Message, "Error");
                    }
                });
            }

            function _companyDelete(Id) {
                companyService.companyDelete(Id).then(function (data) {
                    if (data.State == 0) {
                        toastr.success(data.Message);
                        companyList();
                    }
                    else {
                        toastr.error(data.Message, "Error");
                    }
                });
            }
        }]);
