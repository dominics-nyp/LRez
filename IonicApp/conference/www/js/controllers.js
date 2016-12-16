angular.module('starter.controllers', ['starter.services', 'ngOpenFB'])

.controller('AppCtrl', function($scope, $ionicModal, $timeout, ngFB) {


 // $scope.doRefresh = function() {
 //    $http.get('/new-items')
 //     .success(function(newItems) {
 //       $scope.items = newItems;
 //     })
  // With the new view caching in Ionic, Controllers are only called
  // when they are recreated or on app start, instead of every page change.
  // To listen for when this page is active (for example, to refresh data),
  // listen for the $ionicView.enter event:
  //$scope.$on('$ionicView.enter', function(e) {
  //});

  // Form data for the login modal
  $scope.loginData = {};

  // Create the login modal that we will use later
  $ionicModal.fromTemplateUrl('templates/login.html', {
    scope: $scope
  }).then(function(modal) {
    $scope.modal = modal;
  });

  // Triggered in the login modal to close it
  $scope.closeLogin = function() {
    $scope.modal.hide();
  };

  // Open the login modal
  $scope.login = function() {
    $scope.modal.show();
  };

  // Perform the login action when the user submits the login form
  $scope.doLogin = function() {
    console.log('Doing login', $scope.loginData);

    // Simulate a login delay. Remove this and replace with your login
    // code if using a login system
    $timeout(function() {
      $scope.closeLogin();
    }, 1000);


  };

  // ngFB.api({
  //       path: '/me',
  //       params: {fields: 'id,name'}
  //   }).then(
  //       function (user) {
  //           $scope.user = user;
  //       },
  //       function (error) {
  //           alert('Facebook error: ' + error.error_description);
  //       });

$scope.fbLogin = function () {
    ngFB.login({scope: 'email,publish_actions'}).then(
        function (response) {
            if (response.status === 'connected') {
                console.log('Facebook login succeeded');
                $scope.closeLogin();
            } else {
                alert('Facebook login failed');
            }
        });
};



 ngFB.api({
        path: '/me',
        params: {fields: 'id,name'}
    }).then(
        function (user) {
            $scope.user = user;
        },
        function (error) {
            alert('Facebook error: ' + error.error_description);
        });




})






.controller('SessionsCtrl', function($scope, Session) {
    $scope.sessions = Session.query();
})

.controller('Information', function($scope, $ionicLoading, $compile) {
  function initialize() {
    // set up begining position
    var myLatlng = new google.maps.LatLng(1.382711,103.849527);

    // set option for map
    var mapOptions = {
      center: myLatlng,
      zoom: 16,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    // init map
    var map = new google.maps.Map(document.getElementById("map"),
      mapOptions);

    //the red arrow marker thingy
    var marker = new google.maps.Marker({
      // The below line is equivalent to writing:
      // position: new google.maps.LatLng(-34.397, 150.644)
      position: {lat: 1.382682, lng: 103.849614},
      map: map
    });

    // assign to stop
    $scope.map = map;
  }
  // load map when the ui is loaded
  $scope.init = function() {
    initialize();
  }
  //google.maps.event.addDomListener(window, 'load', initialize);
})



// .controller('SessionCtrl', function($scope, $stateParams, Session) {
//     $scope.session = Session.get({sessionId: $stateParams.sessionId});
// });

.controller('ProfileCtrl', function ($scope, ngFB) {
    ngFB.api({
        path: '/me',
        params: {fields: 'id,name'}
    }).then(
        function (user) {
            $scope.user = user;
        },
        function (error) {
            alert('Facebook error: ' + error.error_description);
        });
});


