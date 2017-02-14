angular.module('starter.services', ['ngResource'])
.factory('Session', function ($resource) {
    return $resource('http://localhost:8100/#/app/sessions');


})


.factory('SocialLogin', function(){

var idObject="";

	var loginId = JSON.parse(window.localStorage.getItem('LoginId'));
  if (typeof(id) !== "undefined") {
    window.localStorage.setItem('LoginId', JSON.stringify(idObject));
  } else {
    var loginId = JSON.parse(window.localStorage.getItem('LoginId'));
  }
  return{
  	get: function(){
  		return loginId;
  	}
  }
})

