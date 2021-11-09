function solve() {
let sendButton=document.getElementById('send');
let input=document.getElementById('chat_input');
let messageField=document.getElementById('chat_messages');

sendButton.addEventListener('click', (e)=>{

   console.log(input.value);
   let neElement=document.createElement('div');
   neElement.innerHTML=input.value;
   neElement.classList.add('message', 'my-message');
   messageField.appendChild(neElement);
   input.value='';
})

}


