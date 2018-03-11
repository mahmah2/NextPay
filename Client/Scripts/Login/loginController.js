angular.module('BM.controllers').
	controller('loginController', function ($scope, $rootScope) {
		var vm = this;

		vm.username = "";

		vm.password = "";

		vm.loginClick = function () {
			//alert('Logged in!');
			$rootScope.$emit('BM.OnSuccessLogin');
		};

	});