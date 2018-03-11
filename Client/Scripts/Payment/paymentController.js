angular.module('NP.controllers').
	controller('paymentController', function ($scope, $rootScope, paymentService) {
		var vm = this;

		vm.PayInfo ={
			BSB : "123456",
			AccountNumber : "12345678",
			AccountName : "AM",
			PaymentAmount : 140,
		};
		

		vm.payClick = function () {
			
			$rootScope.$emit('NP.OnBusy');
			paymentService.savePayment(vm.PayInfo).then(
					function success(data)
					{
						$rootScope.$emit('NP.OnSuccessPay', 'Paid : '+ data.PaymentAmount);
						$rootScope.$emit('NP.OnIdle');
					}
					,
					function error(data)
					{
						$rootScope.$emit('NP.OnError', 'Error in payment');
						$rootScope.$emit('NP.OnIdle');
					}
				)
		};

	});