angular.module('starter.services', ['ngResource'])
.factory('Session', function ($resource) {
    return $resource('http://localhost:8100/#/app/sessions');
});
