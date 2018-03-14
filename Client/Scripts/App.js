angular.module('NP.controllers', []);
angular.module('NP.services', []);

var NP = angular.module("NP", [
	"ngMaterial",
	"ui.router",
	"ngMessages",
	"NP.controllers",
	"NP.services"
]);

NP.config(function ($stateProvider, $urlRouterProvider) {

	$urlRouterProvider.otherwise("/");

	$stateProvider.state('/', {
		templateUrl: 'Scripts/Main/main.html',
		url: '/'
	})
	
	
	var paymentState = {
		name: 'pay',
		url: '/pay',
		templateUrl: 'Scripts/payment/payment.html'
	}

	$stateProvider.state(paymentState);
});


NP.controller('NPController', ['$scope', '$rootScope', '$state', '$mdToast',
		function ($scope, $rootScope, $state, $mdToast) {

		var vm = this;

    	//Global variables
    	$rootScope.ServerURL = 'http://localhost:51432';


		vm.AppName = 'NP';
		vm.Busy = false;

        $rootScope.$on('NP.OnBusy', function (ev) {
            vm.Busy = true;
        });		

        $rootScope.$on('NP.OnIdle', function (ev) {
            vm.Busy = false;
        });


	}]);
