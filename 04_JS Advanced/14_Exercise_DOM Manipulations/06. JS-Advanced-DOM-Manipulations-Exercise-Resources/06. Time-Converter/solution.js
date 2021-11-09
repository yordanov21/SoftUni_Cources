function attachEventsListeners() {

   let daysButon=document.getElementById("daysBtn");
   let hoursButon=document.getElementById("hoursBtn");
   let minutesButon=document.getElementById("minutesBtn");
   let secondsButon=document.getElementById("secondsBtn");

   let daysInput=document.getElementById("days");   
   let hoursInput=document.getElementById("hours");
   let minutesInput=document.getElementById("minutes");
   let secondsInput=document.getElementById("seconds");

   daysButon.addEventListener('click', ()=>{
    hoursInput.value=daysInput.value*24;
    minutesInput.value=hoursInput.value*60;
    secondsInput.value=minutesInput.value*60;
   })

   hoursButon.addEventListener('click', ()=>{
    daysInput.value=hoursInput.value/24;
    minutesInput.value=hoursInput.value*60;
    secondsInput.value=minutesInput.value*60;
   })

   minutesButon.addEventListener('click', ()=>{
    daysInput.value=minutesInput.value/60/24;
    hoursInput.value=daysInput.value*24;
    secondsInput.value=minutesInput.value*60;
   })

   secondsButon.addEventListener('click', ()=>{
    daysInput.value=secondsInput.value/60/60/24;
    hoursInput.value=daysInput.value*24;
    minutesInput.value=hoursInput.value*60;
  
   })
}