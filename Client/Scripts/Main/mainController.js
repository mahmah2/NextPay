angular.module('NP.controllers').
	controller('mainController', ['$scope', '$rootScope', '$state', '$mdToast',
		function ($scope, $rootScope, $state, $mdToast) {

		var vm = this;

    	//Global variables
    	$rootScope.ServerURL = 'http://localhost:51432';

        $rootScope.$on('NP.OnSuccessPay', function (ev, msg) {
                $mdToast.show($mdToast.simple().textContent(msg));
        });	
       
         $rootScope.$on('NP.OnError', function (ev, msg) {
                $mdToast.show($mdToast.simple().textContent(msg));
        });	    



	}]);

