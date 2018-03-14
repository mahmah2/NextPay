angular.module('NP.controllers').
	controller('mainController', ['$scope', '$rootScope', '$state', '$mdToast',
		function ($scope, $rootScope, $state, $mdToast) {

		var vm = this;

        $rootScope.$on('NP.OnSuccessPay', function (ev, msg) {
                $mdToast.show($mdToast.simple().textContent(msg).theme("success-toast"));
        });	
       
         $rootScope.$on('NP.OnError', function (ev, msg) {
                $mdToast.show($mdToast.simple().textContent(msg).theme("error-toast"));
        });	    



	}]);

