
(function() {

  
// var app=  angular.module( 'myMenu', ['ionic']);

//  app.controller('MenuCtrl', function($scope, $http) {

//     $scope.menus = [];
    
//     $http.get('http://localhost:53501/api/Menu')
//     .success(function(response){
//       for( i = 0 ; i<response.length ; i++){
//         console.log(response[i].URL);
//         alert(response[i].URL);
//       $scope.menus.push(response[i].URL);
//       }
       
      
//        });
//   });





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
              display: 'http://graph.facebook.com/'+ response.data.id + '/picture?type=large',
              name: response.data.name
            };
          })
          .catch(function(error) {
            alert('error: ' + JSON.stringify(error));
          });
          
        })
        .catch(function(error) {
          alert(error);
          alert('Facebook login failed');
          console.log("Error -> " + JSON.stringify(error));
        });
      }
      catch (error) {
        alert("1"+ error);
        alert('Facebook login failed');
        console.log("Error -> " + JSON.stringify(error));
      }
    };



    appCtrl.googleLogin = function () { 
      
      try {

        alert('h');
    
         $cordovaOauth.google("369119781656-bgq50ishd1gl820luk81pcdk5k4nihsp.apps.googleusercontent.com", ["email","profile"])
        .then(function(response) {

          $http({
            url: 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + response.access_token
          })
          .then(function(response) {
            alert('Google plus login success');
            appCtrl.user = {
              id: response.data.id,
              display: 'https://www.googleapis.com/plus/v1/people'+ response.data.id + '/picture?type=large',
              name: response.data.name
            };
          })
          .catch(function(error) {
            alert('error: ' + JSON.stringify(error));
          });
          
        })
        .catch(function(error) {
          alert('Google plus login failed4');
          alert(error);
          console.log("Error -> " + JSON.stringify(error));
        });
      }
      catch (error) {
        alert('Google plus login failedf');
        console.log("Error -> " + JSON.stringify(error));
      }
    };


    appCtrl.instaLogin = function () { 

      try {
    
        $cordovaOauth.instagram("dadd1fa8cccb4f388b078935844b032a", ["basic"])
        .then(function(response) {
          alert(JSON.stringify(response));
          $http({
            url: 'https://api.instagram.com/v1/users/self/?access_token=' + response.access_token
          })
          .then(function(response) {
            alert('instagram login success');
            appCtrl.user = {
              id: response.data.id,
              display: "http://graph.facebook.com/"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     + response.data.id + '/picture?type=large',
              name: response.data.name
            };
          })
          .catch(function(error) {
            alert('error: ' + JSON.stringify(error));
          });
          
        })
        .catch(function(error) {
          alert('instagram login failed');
          console.log("Error -> " + JSON.stringify(error));
        });
      }
      catch (error) {
        alert('instagram login failed');
        console.log("Error -> " + JSON.stringify(error));
      }
    };



      appCtrl.twitterLogin = function () { 
      
      try {
    
        $cordovaOauth.twitter("u9H7vtmc68Kr3yGFH7vvTHb82", "vMR2OeQMKcCF9y2NvXSPeLweS66jfx5paxgShwLOfQnKwg8vsi",["id_str"])
        .then(function(response) {
          alert(error)
          $http({
            url: 'https://graph.facebook.com/v2.1/me?access_token=' + response.access_token
          })
          .then(function(response) {
            alert('Facebook login success');
            appCtrl.user = {
              id: response.data.id,
              display: 'http://graph.facebook.com/'+ response.data.id + '/picture?type=large',
              name: response.data.name
            };
          })
          .catch(function(error) {
            alert('error: ' + JSON.stringify(error));
          });
          
        })
        .catch(function(error) {
          alert('Facebook login faileda');
          console.log("Error -> " + JSON.stringify(error));
        });
      }
      catch (error) {
        alert('Facebook login failedb');
        console.log("Error -> " + JSON.stringify(error));
      }
    };



    //   appCtrl.twitterLogin = function () { 
      
    //   try {
    
    //     $cordovaOauth.linkedin("81w533odcvwnow", "43HhB8QPIYLaQ4uL", ["r_basicprofile", "r_emailaddress"])
    //     .then(function(response) {
    //       alert(error)
    //       $http({
    //         url: 'https://graph.facebook.com/v2.1/me?access_token=' + response.access_token
    //       })
    //       .then(function(response) {
    //         alert('Facebook login success');
    //         appCtrl.user = {
    //           id: response.data.id,
    //           display: 'http://graph.facebook.com/'+ response.data.id + '/picture?type=large',
    //           name: response.data.name
    //         };
    //       })
    //       .catch(function(error) {
    //         alert('error: ' + JSON.stringify(error));
    //       });
          
    //     })
    //     .catch(function(error) {
    //       alert('Facebook login faileda');
    //       console.log("Error -> " + JSON.stringify(error));
    //     });
    //   }
    //   catch (error) {
    //     alert('Facebook login failedb');
    //     console.log("Error -> " + JSON.stringify(error));
    //   }
    // };





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

    
  })

  .controller('MenuCtrl', function($scope, $http) {
        $scope.menus = [];
    
    $http.get('http://172.20.130.159:8080/api/Menu')
    .then(function(response){
      for( i = 0 ; i<response.data.length ; i++){
        console.log(response.data[i].URL);
        $scope.menus.push(response.data[i].URL);

      }
       
      
       })
    .catch(function(error) {
        alert("error: " + JSON.stringify(error));
    });
  });

})();

