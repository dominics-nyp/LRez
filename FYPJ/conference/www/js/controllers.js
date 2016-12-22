
(function() {

  angular.module('app.controllers', [])

  .controller('AppCtrl', function($cordovaOauth, $http) {
    var appCtrl = this;

    appCtrl.user = '';
    
    appCtrl.fbLogin = function () { 
      
      try {
    
        $cordovaOauth.facebook("1799825963610262", ["public_profile", "email"])
        .then(function(response) {

          $http({
            url: 'https://graph.facebook.com/v2.1/me?access_token=' + response.access_token
          })
          .then(function(response) {
            alert('Facebook login success');
            appCtrl.user = {
              id: response.data.id,
              display: 'http://graph.facebook.com/'+ response.data.id + '/picture?',
              name: response.data.name
            };
          })
          .catch(function(error) {
            alert('error: ' + JSON.stringify(error));
          });
          
        })
        .catch(function(error) {
          alert('Facebook login failed');
          console.log("Error -> " + JSON.stringify(error));
        });
      }
      catch (error) {
        alert('Facebook login failed');
        console.log("Error -> " + JSON.stringify(error));
      }
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
    
    if (document.getElementById("map") == null)
      alert('oh no');
    
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

