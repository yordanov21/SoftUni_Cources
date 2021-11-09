           //IIFE
const add=(function solve(){
    //Closure in add function, който го дефинираме във функция add(функция която извиква себе си)
   let sum=0;

   function add(number){
       sum+=number;

       return add;
   }
   add.toString=function(){
       return sum;
   }

   return add;
})();

//Currying
console.log(add(1)(2)(3)(4)(5).toString());
