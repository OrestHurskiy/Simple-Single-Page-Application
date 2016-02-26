﻿(function(app) {
    'use strict';

    
    app.directive('sideBar', sideBar);
  
    function sideBar () {
        // Usage:
        //     <sideBar></sideBar>
        // Creates:
        // 
        var directive = {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/spa/layout/sideBar.html'
        };

        return directive;

        
    }

})(angular.module('common.ui'));