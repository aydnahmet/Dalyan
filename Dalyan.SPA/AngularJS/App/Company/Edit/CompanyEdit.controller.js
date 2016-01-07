DalyanControllers.controller('CompanyEditController',
    ['$scope', '$routeParams', 'CompanyService',
        function ($scope, $routeParams, companyService) {
            $scope.companyEdit = _companyEdit;
            $scope.company;
            $scope.validatePage = _validatePage;
            $scope.allowValidation;

            $scope.clickBack = function () {
                window.history.back();
            };

        	init();

        	function init() {
        	    if ($routeParams.Id != null) {
        	        companyService.companyRetrieve($routeParams.Id).then(function (data) {
        	            $scope.company = data;
        	        });
        	    }

        	    $scope.allowValidation = false;
        	}

        	function _validatePage(flag)
        	{
        	    if (!flag) {
        	        toastr.error("Please fill in the required fields");
        	        $scope.allowValidation = true;
        	    }
        	    
        	    return true;
        	}

        	function _companyEdit() {
        	    
        	    var currentCompany = {
        			Company: $scope.company
        	    };

        	    companyService.companyEdit(currentCompany.Company).then(function (data) {
        	        if (data.State == 0) {
        	            toastr.success(data.Message);
        	        }
        	        else {
        	            toastr.error(data.Message, "Error");
        	        }
        	    });

        	    $scope.allowValidation = false;
        	}
        }]);