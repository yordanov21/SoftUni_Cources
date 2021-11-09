function solve() {
    let sendBtn = document.getElementById("send");
    let chatInput = document.getElementById("chat_input");
    let messages = document.getElementById("chat_messages");

    sendBtn.addEventListener('click', addMessage);
    //  sendBtn.addEventListener("keyup", function(e) {
    //      if (e.keyCode === 13) {
    //          e.preventDefault();
    //          let currentMessage = document.createElement('div');
    //          currentMessage.className = "message my-message";
    //          currentMessage.textContent = chatInput.value;
    //          messages.appendChild(currentMessage);
    //          chatInput.value = '';
    //      }
    //  });

    function addMessage() {
        let currentMessage = document.createElement('div');
        currentMessage.className = "message my-message";
        currentMessage.textContent = chatInput.value;
        messages.appendChild(currentMessage);
        chatInput.value = '';
    }
}

// document.querySelector('#txtSearch').addEventListener('keypress', function(e) {
//     if (e.key === 'Enter') {
//         // code for enter
//     }
// });