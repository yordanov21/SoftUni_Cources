function solve() {
    let tbody = document.querySelector('tbody');
    let generatebtn = document.querySelectorAll('button')[0];
    let checkbox = document.querySelector('input');
    checkbox.disabled = false;

    generatebtn.addEventListener('click', (e) => {
        let textAreaJson = document.getElementsByTagName('textarea')[0].value;
        let obj = JSON.parse(textAreaJson)
        console.log(obj);

        obj.forEach(element => {
            const { img, name, price, decFactor } = element;
            let tr = document.createElement('tr');
            tr.innerHTML = `
      <td>
          <img
             src="${img}">
      </td>
      <td>
          <p>${name}</p>
      <td>
          <p>${price}</p>
      </td>
      <td>
          <p>${decFactor}</p>
      </td>
      <td>
          <input type="checkbox"/>
      </td>
      `;
            tbody.appendChild(tr);
        });


    });

    let buyBtn = document.getElementsByTagName('button')[1];
    buyBtn.addEventListener('click', (e) => {
        let textAreaOutput = document.getElementsByTagName('textarea')[1];


    })
}