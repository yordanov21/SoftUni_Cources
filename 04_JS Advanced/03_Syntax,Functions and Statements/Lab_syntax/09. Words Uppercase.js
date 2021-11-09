function solve(text){

    let regex=/\w+/g;
    let words=text.match(regex);
    let result=[];
    
    for (i=0; i<words.length; i++){
        let word=words[i].toUpperCase();
        result[i]=word;
    }
 
    console.log(result.join(', '));
}

solve('Hi, how are you?');

