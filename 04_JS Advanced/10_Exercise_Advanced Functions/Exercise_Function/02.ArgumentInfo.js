function argumentInfo(...args){
const obj={};
    args.forEach(el=>{
        const argType=typeof el;
        console.log(`${argType}: ${el}`);

        if(!obj.hasOwnProperty(argType)){
            obj[argType]=0;
        }
        obj[argType]++;
    });

    var sortable = [];
    for (var element in obj) {
            sortable.push([element, obj[element]]);
        }
        
        sortable.sort(function(a, b) {
            return b[1] - a[1];
        });

        sortable.forEach((el)=>{
            console.log(`${el[0]} = ${el[1]}`);
            
        });

}

argumentInfo('cat', 42, function () { console.log('Hello world!'); },42);