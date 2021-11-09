export default {
    succsessNotification: function(message) {
        let notification = document.createElement('div');
        notification.setAttribute('id', 'notifications')

        notification.innerHTML = `<div style="display: block;" id="successBox" class="alert alert-success" role="alert">${message}</div>`;
        console.log(notification);

        document.querySelector('body').appendChild(notification);

        setTimeout(() => {
            notification.remove();
        }, 5000);
    },
    loading: function() {
        let notification = document.createElement('div');
        notification.setAttribute('id', 'notifications')

        notification.innerHTML = `<div style="display: block;" id="loadingBox" class="alert alert-info" role="alert">Loading...</div>`;

        console.log(notification);

        document.querySelector('body').appendChild(notification);

        setTimeout(() => {
            notification.remove();
        }, 500);
    },
    errorNotification: function(message) {
        let notification = document.createElement('div');
        notification.setAttribute('id', 'notifications');

        notification.innerHTML = `<div style="display: block;" id="errorBox" class="alert alert-danger" role="alert">${message}</div>`;
        console.log(notification);

        document.querySelector('body').appendChild(notification);

        setTimeout(() => {
            notification.remove();
        }, 5000);
    }
}