  //слагаме съдържането от script-тага от firebase for  Firebase configuration

  // Your web app's Firebase configuration
  var firebaseConfig = {
      apiKey: "AIzaSyCKmQg6p1UOH9-_L6Vi0vunNqguh8Whsr4",
      authDomain: "jssuperdata.firebaseapp.com",
      databaseURL: "https://jssuperdata.firebaseio.com",
      projectId: "jssuperdata",
      storageBucket: "jssuperdata.appspot.com",
      messagingSenderId: "699788907764",
      appId: "1:699788907764:web:8548646151beb1a7507aa1",
      measurementId: "G-DRBV8CC3TD"
  };
  // Initialize Firebase
  firebase.initializeApp(firebaseConfig);

  //analystics идва от отметката за google analystic.По принцип не ни трябва
  //   firebase.analytics();