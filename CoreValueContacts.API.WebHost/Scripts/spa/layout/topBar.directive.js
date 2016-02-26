(function (app) {
    'use strict';


    app.directive('topBar', topBar);

    function topBar() {
        // Usage:
        //     <topBar></topBar>
        // Creates:
        // 
        var directive = {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/spa/layout/topBar.html'
        };
        return directive;

        
    }

})(angular.module('common.ui'));