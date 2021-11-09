  function notify(message) {
      const notification = document.getElementById("notification");

      notification.innerHTML = message;
      notification.style.display = "block";
      //show notification for 2sec
      setTimeout(function() {
          notification.style.display = "none";
      }, 2000);
  }