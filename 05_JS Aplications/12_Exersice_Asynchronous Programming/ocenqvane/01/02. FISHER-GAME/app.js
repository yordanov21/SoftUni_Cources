function attachEvents() {
    

    const elements={
        $catch:{
            $angler:()=>document.querySelector('#addForm input.angler'),
            $weight:()=>document.querySelector('#addForm input.weight'),
            $species:()=>document.querySelector('#addForm input.species'),
            $location:()=>document.querySelector('#addForm input.location'),
            $bait:()=>document.querySelector('#addForm input.bait'),
            $captureTime:()=>document.querySelector('#addForm input.captureTime')
        },
        $addBtn:()=>document.querySelector('#addForm button.add'),
        $loadBtn:()=>document.querySelector('aside button.load'),
        $catches:()=>document.getElementById('catches'),
        $exampleCatch:()=>document.querySelector('div.catch')
    }

    elements.$addBtn().addEventListener('click',addCatch);

    elements.$loadBtn().addEventListener('click',loadCatches);


    function addCatch(){
        const angler=elements.$catch.$angler().nodeValue;
        const weight=elements.$catch.$weight().nodeValue;
        const species=elements.$catch.$species().nodeValue;
        const location=elements.$catch.$location().nodeValue;
        const bait=elements.$catch.$bait().nodeValue;
        const captureTime=elements.$catch.$captureTime().nodeValue;

        catches.post({angler,weight,species,location,bait,captureTime})
        .then((data)=>console.log(data)) 
        .catch((err)=>console.log(err));

    }

    function loadCatches(){
        elements.$catches.innerHTML='';
        catches.get()
        .then((allCatches)=>{
           showAllCatches(allCatches)
        })
        .catch((err)=>console.log(err))
    }

    function showAllCatches(allCatches){
          Object.keys(allCatches).forEach((id)=>{
              const copy=elements.$exampleCatch().cloneNode(true);

              copy.setAttribute('data-id',id);

              Object.keys(elements.$catch).map((c)=>c.slice(1)).forEach((key)=>{
                  copy.querySelector(`input.${key}`).value=allCatches[id][key]
              })

              elements.$catches().appendChild(copy);
          });
         [...document.querySelectorAll('button.delete')]
         .forEach((b)=>b.addEventListener('click',removeCatch()));

         [...document.querySelectorAll('button.update')]
         .forEach((b)=>b.addEventListener('click',updateCatch()));

         elements.$exampleCatch().remove();

    }     



    function removeCatch(e){
        const id=e.currentTarget.parendNode.getAttribute('data-id');

        catches.del(id).then(loadCatches());
    }

    function updateCatch(e){
        const id=e.currentTarget.parendNode.getAttribute('data-id');
        catches.put(id).then(loadCatches());
    }
  

}

attachEvents();

