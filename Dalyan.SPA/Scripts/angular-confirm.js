angular.module('ngReallyClickModule', ['ui.bootstrap'])
  .directive('ngReallyClick', ['$modal',
    function ($modal) {

        var ModalInstanceCtrl = function ($scope, $modalInstance) {
            $scope.ok = function () {
                $modalInstance.close();
            };

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        };

        return {
            restrict: 'A',
            scope: {
                ngReallyClick: "&",
                item: "="
            },
            link: function (scope, element, attrs) {
                element.bind('click', function () {
                    var message = attrs.ngReallyMessage || "Emin misiniz ?";
                    var title = attrs.ngReallyTitle || "Dalyan";

                    /*
                    //This works
                    if (message && confirm(message)) {
                      scope.$apply(attrs.ngReallyClick);
                    }
                    //*/

                    //*This doesn't works
                    var modalHtml = '<div class="modal-dialog"><div class="modal-content"><div class="modal-header"><h4 class="modal-title">' + title +'</h4></div><div class="modal-body">' + message + '</div>';
                    modalHtml += '<div class="modal-footer"><button class="btn btn-primary" ng-click="ok()">OK</button><button class="btn btn-warning" ng-click="cancel()">Cancel</button></div></div></div>';                                            

                    var modalInstance = $modal.open({
                        template: modalHtml,
                        controller: ModalInstanceCtrl
                    });

                    modalInstance.result.then(function (Id) {
                        scope.ngReallyClick(Id); //raise an error : $digest already in progress
                    }, function () {
                        //Modal dismissed
                    });
                    //*/

                });

            }
        }
    }
  ]);