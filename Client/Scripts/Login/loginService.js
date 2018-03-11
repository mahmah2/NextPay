angular.module('BM.services')
	.service('loginService', ['$http', '$rootScope', '$q',
		function ($http, $rootScope, $q) {

			var self = this;

			self.loggedIn = false;
			self.user = {};

			self.getUserName = function () {
				return self.user.email;
			}

		}]
	);
