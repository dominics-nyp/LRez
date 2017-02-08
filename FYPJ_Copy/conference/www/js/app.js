
(function() {
  
  angular.module('app', ['ionic', 'app.controllers', 'ngCordovaOauth', 'ngCordova'])
  
  .run(function($ionicPlatform) {//, ngFB) {
    // ngFB.init({appId: '640446396160697'});

    $ionicPlatform.ready(function() {
      // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
      // for form inputs)
      if (window.cordova && window.cordova.plugins.Keyboard) {
        cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        cordova.plugins.Keyboard.disableScroll(true);
      }
      if (window.StatusBar) {
        // org.apache.cordova.statusbar required
        StatusBar.styleDefault();
      }
    });
  })

  .config(function($stateProvider, $urlRouterProvider, $ionicConfigProvider) {
    
    $ionicConfigProvider.tabs.position('top');

    $stateProvider

    .state('app', {
      url: '/app',
      abstract: true,
      templateUrl: 'templates/sidemenu.html',
      controller: "AppCtrl as appCtrl"
    })

    .state('app.menu', {
      url: '/menu',
      views: {
        'menuContent': {
          templateUrl: 'templates/tab-menu.html',
           controller:"MenuCtrl"
        }
      }
    })

    .state('app.home', {
      url: '/home',
      views: {
        'homeContent': {
          templateUrl: 'templates/tab-home.html',
           controller:"InstaCtrl"
        }
      }
    })


    .state('app.lrezfb', {
      url: '/lrezfb',
      templateUrl: 'templates/tab-lrezfb.html',
      views: {
        'homeContent': {
          templateUrl: 'templates/tab-lrezfb.html',
        }
      }
    })

    .state('app.information', {
      url: '/information',
      views: {
        'informationContent': {
          templateUrl: 'templates/tab-information.html',
          controller: "InfoCtrl as infoCtrl"

        }
      }
    })

   .state('app.reservation', {
      url: '/reservation',
      views: {
        'reservationContent': {
          templateUrl: 'templates/tab-reservation.html',
          controller: "CalendarCtrl"
        }
      }
    });

    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/app/home');

  });
  
})();
