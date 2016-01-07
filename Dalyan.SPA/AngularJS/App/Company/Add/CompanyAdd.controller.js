DalyanControllers.controller('CompanyAddController',
    ['$scope', '$routeParams', 'CompanyService',
        function ($scope, $routeParams, companyService) {
            $scope.companyAdd = _companyAdd;
            $scope.company;
            $scope.validatePage = _validatePage;
            $scope.allowValidation;

            $scope.clickBack = function () {
                window.history.back();
            };

        	init();

        	function init() {
        	    $scope.company = {
        	        Name: "",
                    IsDeleted: false
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

        	function _companyAdd() {
        	    
        	    var currentCompany = {
        			Company: $scope.company
        	    };

        	    companyService.companyAdd(currentCompany.Company).then(function (data) {
        	        if (data.State == 0) {
        	            toastr.success(data.Message);
        	            $scope.company = null;
        	        }
        	        else {
        	            toastr.error(data.Message, "Error");
        	        }
        	    });

        	    $scope.allowValidation = false;
        	}
        }]);