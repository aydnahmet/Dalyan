window.publication = angular.module('dalyan', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'DalyanControllers']);   

publication.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
    $routeProvider
        
        .when('/user/list', { templateUrl: 'AngularJS/App/User/List/UserList.view.html', controller: 'UserListController' })
        .when('/user/add', { templateUrl: 'AngularJS/App/User/Add/UserAdd.view.html', controller: 'UserAddController' })
        .when('/user/edit', { templateUrl: 'AngularJS/App/User/Edit/UserEdit.view.html', controller: 'UserEditController' })
        .when('/user/edit/:Id', { templateUrl: 'AngularJS/App/User/Edit/UserEdit.view.html', controller: 'UserEditController' })
        .when('/user/changepassword', { templateUrl: 'AngularJS/App/User/ChangePassword/ChangePassword.view.html', controller: 'ChangePasswordController' })
        .when('/user/logout', { templateUrl: 'AngularJS/App/User/Logout/Logout.view.html', controller: 'LogoutController' })

        .when('/company/add', { templateUrl: 'AngularJS/App/Company/Add/CompanyAdd.view.html', controller: 'CompanyAddController' })
        .when('/company/edit/:Id', { templateUrl: 'AngularJS/App/Company/Edit/CompanyEdit.view.html', controller: 'CompanyEditController' })
        .when('/company/list', { templateUrl: 'AngularJS/App/Company/List/CompanyList.view.html', controller: 'CompanyListController' })

        .when('/dashboard/default', { templateUrl: 'AngularJS/App/Dashboard/Default/DashboardDefault.view.html', controller: 'DashboardDefaultController' })

    $httpProvider.interceptors.push('authorizationInterceptor');
}]);


window.DalyanControllers = angular.module('DalyanControllers', ['ui.bootstrap', 'ngReallyClickModule', 'ui.select', 'ngSanitize', 'checklist-model']);
