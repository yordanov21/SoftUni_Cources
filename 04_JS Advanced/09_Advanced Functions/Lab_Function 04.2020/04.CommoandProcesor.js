function solution(){

    let text='';
   function append(str){
       text+=str;
   }

   function removeStart(n){
       text=text.substring(n);
   }

   function removeEnd(n){
       text=text.substring(0,text.length-n);
   }

   let print=()=>console.log(text);
   return{
       append: append,
       removeEnd: removeEnd,
       removeStart: removeStart,
       print: print
   }
}
let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
