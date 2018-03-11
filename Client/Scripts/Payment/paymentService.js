angular.module('NP.services')
	.service('paymentService', ['$http', '$rootScope', '$q',
		function ($http, $rootScope, $q) {

			var self = this;



			self.savePayment = function (paymentInfo) {
			
				var deferred = $q.defer();
							
	            $http.post($rootScope.ServerURL + "/api/payment"
			                //, JSON.stringify({Email: userName,})
			                , JSON.stringify(paymentInfo)
			                , { headers: { 'Content-Type': 'application/json' } }
	                )
	            	.then(
	                	function (response) {
		                    if (response.status == 200 ) //&& response.data)
		                    {
	                            deferred.resolve(paymentInfo);
		                    }
		                    else
		                    {
		                        deferred.reject("(savePayment): Error in communication with server." + response.statusText);
		                    }

		                }, 
		                function (response) {
		                    return deferred.reject(response.statusText);
		                }
	                );

	            return deferred.promise;



			}

	




		}]
	);
