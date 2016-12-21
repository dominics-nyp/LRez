
(function() {

  angular.module('app.controllers', [])

  .controller('AppCtrl', function($cordovaOauth) {
    var appCtrl = this;

    appCtrl.fbLogin = function () {
      $cordovaOauth.facebook("640446396160697", ["email", "read_stream", "user_website", "user_location", "user_relationships"])
      .then(function(response) {
        alert('hello');
        if (response.status === 'connected') {
            console.log('Facebook login succeeded');
            $scope.closeLogin();
        } else {
            alert('Facebook login failed');
        }
      })
      .catch(function(error) {
        alert('eror here');
        console.log("Error -> " + error);
      });
    };

  })

  .controller('InfoCtrl', function() {
    var infoCtrl = this;
    
    var myLatlng = new google.maps.LatLng(1.382711,103.849527);

    // set option for map
    var mapOptions = {
      center: myLatlng,
      zoom: 16,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    // init map
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);

    //the red arrow marker thingy
    var marker = new google.maps.Marker({
      // The below line is equivalent to writing:
      // position: new google.maps.LatLng(-34.397, 150.644)
      position: {lat: 1.382682, lng: 103.849614},
      map: map
    });

  });

})();

