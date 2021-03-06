
(function() {

angular.module('app.controllers', [])


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
  })



.controller('InstaCtrl', function($scope, $http, $window) {
        $scope.instas = [];
        $scope.captions = [];

        $scope.access_token = $window.sessionStorage.getItem("access_token");
        console.log("access_token", $scope.access_token);
    $http.get('https://www.instagram.com/lreztrainingrestaurant/media/?size=t')
    .then(function(response){
      for( i = 0 ; i<response.data.items.length; i++){
        console.log(response.data.items[i]);
        $scope.instas.push(response.data.items[i]);

          if (response.data.items[i].caption == null)
          {
            $scope.captions.push(response.data.items[i]);
          }
          else{
            $scope.captions.push(response.data.items[i].caption.text);
          }

         }
       })
    .catch(function(error) {
        // alert("error: " + JSON.stringify(error));

    });

       $scope.igLike = function(val) {


          $scope.access_token = $window.sessionStorage.getItem("access_token");
        //console.log($scope.instas);
             //$http.post('https://api.instagram.com/v1/media/'  + $scope.instas[key].id +'/likes?access_token=4318921338.d8a48ba.ea5390d0a6ee41458ad1fe9caa946fa6')

             var button = event.target.id;
             // alert(val.id);

             for (key in $scope.instas)
             {

                if (val.id == $scope.instas[key].id) {

                  $http.post('https://api.instagram.com/v1/media/' + $scope.instas[key].id + '/likes?access_token=' + $scope.access_token)

                  alert("Liked");
                  break;
                }
             }

        }
    

  })

  .controller('AppCtrl', function($cordovaOauth, $http, $scope, $window) {
    var appCtrl = this;

    appCtrl.user = '';
     $scope.showsecondCard = true;
      $scope.isDisabled = false;
    
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
              $scope.hidedefaultimg = true;
             $scope.showsecondCard = false;
                $scope.isDisabled = true;
                return false;
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
    
        $cordovaOauth.instagram("d8a48ba89ff14edeb7b621c758de4637", ["basic+likes"])
        .then(function(response) {
          // alert(JSON.stringify(response));

          $window.sessionStorage.setItem("access_token", response.access_token);

          $scope.access_token = $window.sessionStorage.getItem("access_token");

          $http({
            url: 'https://api.instagram.com/v1/users/self/?access_token=' + $scope.access_token
          })
          .then(function(response) {
            // alert(response.access_token);
            alert('instagram login success');
            appCtrl.user = {
              id: response.data.id,
              display: "http://graph.facebook.com/"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     + response.data.id + '/picture?type=large',
              name: response.data.name
            };
            $scope.hidedefaultimg = true;
             $scope.showsecondCard = false;
             $scope.isDisabled = true;
                return false;
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


      $scope.logout = function() {
       $scope.hidedefaultimg = false;
        $scope.isDisabled = false;
      alert("Sign out successfully");
      $scope.showsecondCard = true;
    $cordovaFacebook.logout();

    }, function(error) {
        alert("There was a problem signing in!  See the console for logs");
        console.log(error);
      
    }

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

    .controller('CalendarCtrl', function ($scope, $cordovaCalendar, $http, $ionicPopup, $cordovaClipboard) {

    var today = new Date().toISOString().split('T')[0];
    document.getElementsByName("Date")[0].setAttribute('min', today);

    $scope.rf = {
      name:'',
      number:'',
      email:'',
      date:'',
      vistors:'',
      time:''


    }

    function popup() {
     var confirmPopup = $ionicPopup.confirm({
       title: 'Calendar',
       template: 'Would you like to add your reservation into your calendar?'
     });

     confirmPopup.then(function(res) {
       if(res) {
         try {
           $cordovaCalendar.createEvent({
            title: 'LRez Reservation',
            location: 'Nanyang Polytechnic Block F, Level 3',
            notes: 'Wishing you a pleasant dining experience!',
            startDate: new Date($scope.rf.date.getTime() + $scope.rf.time*60000*60) ,
            endDate: new Date($scope.rf.date.getTime() + $scope.rf.time*60000*60) 
          }).then(function (result) {
      // success
      alert("Event successfully added into calendar!");
      showAlert();
    }, function (err) {
      // error
      alert("Event is not added into calendar");
    });
        }
        catch (error) {
          alert('Event Creation Failure');
          console.log("Error -> " + JSON.stringify(error));
        }
      } else {
       alert("Event is not added into calendar");
       showAlert();
     }
   });
   };

   $scope.display = function(){
    console.log($scope.rf);
    
    var data = {'Name': $scope.rf.name,
    'Contact':$scope.rf.number,
    'Email': $scope.rf.email,
    'ReservationDateTime':new Date($scope.rf.date.getTime() + $scope.rf.time*60000*60),
    'Numvisitors':$scope.rf.visitors,
  };

  /* $scope.copyText = function(value) {
        $cordovaClipboard.copy(value).then(function() {
            console.log("Copied text");
        }, function() {
            console.error("There was an error copying");
        });
    } */

  $http({
    method: 'POST',
    url: 'http://172.20.129.97:8033/api/Reservations', 
    data: data,
    headers: {'Content-Type':'application/json'}
  })
  .then(
   function(response){
           // success callback
           popup();
           console.log(response.data.Tracking);
           $scope.tracking = response.data.Tracking; 
           alert("Your Tracking ID is "+ response.data.Tracking);

         })
  .catch(
    function(error){
     // failure callback
     console.log(error);
     alert(JSON.stringify(error));
   }
   );
}

})

  .controller('ResCtrl', function($scope, $ionicLoading, $state, $stateParams){
    console.log('reservation');

    $scope.formData = {};

    //Go to the guessing page
    $scope.onTouch = function(item,event){
      console.log($scope.formData.email);
    };

  })

  .controller('TrackCtrl', function($scope, $http) {
    //var LoginId = SocialLogin.get();
    $scope.reservations = [];
    $scope.statuscheck= function(id){
      $http.get('http://172.20.129.97:8033/api/Reservations?tracking='+id)
      .then(function(response){
        var intStatus = response.data.Status;
        if( intStatus == 0){
          alert("Rejected Reservation");
          //$scope.reservationStatus = 'Rejected';
        }
        else if(intStatus == 1){
          alert("Approved Reservation");
        // $scope.reservationStatus = 'Approved';
       }
       else if(intStatus == 2){
        alert("Pending Reservation");
        // $scope.reservationStatus = 'Pending';
       }
     })
      .catch(function(error) {
        alert("Your ID is invalid");

      });
    };
    

  });


})();

