// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.controllers' is found in controllers.js
angular.module('starter', ['ionic', 'starter.controllers', 'ngOpenFB'])

.run(function($ionicPlatform, ngFB) {
  ngFB.init({appId: '640446396160697'});

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
    templateUrl: 'templates/menu.html',
    controller: "AppCtrl"

  })

  .state('app.menu', {
    url: '/menu',
    views: {
      'menuContent': {
        templateUrl: 'templates/tab-menu.html'
      }
    }
  })

  .state('app.home', {
      url: '/home',
      views: {
        'menuContent': {
          templateUrl: 'templates/tab-home.html'
        }
      }
    })

   .state('app.location', {
      url: '/location',
      views: {
        'menuContent': {
          templateUrl: 'templates/tab-location.html',
          controller: 'Information'

        }
      }
    })

   .state('app.reservation', {
      url: '/reservation',
      views: {
        'menuContent': {
          templateUrl: 'templates/tab-reservation.html'
        }
      }
    })

   .state('app.sessions', {
      url: "/sessions",
      views: {
          'menuContent': {
              templateUrl: "templates/tab-home.html",
              // controller: 'SessionsCtrl'
          }
      }
    })



   .state('app.profile', {
      url: "/profile",
      views: {
          'menuContent': {
              templateUrl: "templates/profile.html",
              controller: "ProfileCtrl"
          }
      }
  })


  // .state('app.session', {
  //     url: "/sessions/:sessionId",
  //     views: {
  //         'menuContent': {
  //           templateUrl: "templates/session.html",
  //           controller: 'SessionCtrl'
  //       }
  //     }
  // })

  // .state('app', {
  //     url: "/app",
  //     views: {
  //         'menuContent': {
  //             templateUrl: "templates/menu.html",
  //             controller: "ProfileCtrl"
  //         }
  //     }
  // })

  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/app/sessions');

});
