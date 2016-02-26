(function (app) {
    'use strict';


    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function indexCtrl($scope, apiService, notificationService) {

        $scope.pageClass = "page-home";

        $scope.projects = [];
        $scope.loadData;

        function loadData()
        {
            apiService.get("/api/projects", null,
               projectsLoadCompleted,
               projectsLoadFailed);
        }

        

        function projectsLoadCompleted(result)
        {
            $scope.projects = result.data;
        }

        function projectsLoadFailed(response)
        {
            notificationService.displayError(response.data);
        }

        loadData();
        
    }
})(angular.module('malkosContacts'));
