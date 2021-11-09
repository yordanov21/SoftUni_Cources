  function attachEvents() {
      const url = "https://phonebook-nakov.firebaseio.com/phonebook.json";
      const phoneBookData = document.getElementById("phonebook");
      let loadButton = document.querySelector('#btnLoad');
      let createButton = document.querySelector('#btnCreate');

      loadButton.addEventListener('click', () => {
          fetch(url)
              .then(resources => resources.json())
              .then(data => {
                  phoneBookData.innerHTML = "";

                  Object.entries(data).forEach(([elementId, { person, phone }]) => {

                      let liElement = document.createElement("li");
                      liElement.textContent = `${person}: ${phone}`;
                      const deleteButton = document.createElement("button");
                      deleteButton.textContent = "Delete";
                      deleteButton.id = elementId;
                      deleteButton.addEventListener("click", deletePhone);
                      liElement.appendChild(deleteButton);
                      phoneBookData.appendChild(liElement);
                  });
              })
              .catch(() => console.log("Error"));
      })

      createButton.addEventListener('click', () => {
          const person = document.getElementById("person").value;
          const phone = document.getElementById("phone").value;
          const headers = {
              method: "POST",
              headers: {
                  "Content-Type": "application/json"
              },
              body: JSON.stringify({
                  person,
                  phone
              })
          };
          fetch(url, headers)
              .then(() => {
                  document.getElementById("person").value = "";
                  document.getElementById("phone").value = "";
                  phoneBookData.innerHTML = "";
                  loadPhoneBook();
              })
              .catch(() => console.log("Error"));
      })

      function deletePhone() {
          const id = this.getAttribute("id");
          const headers = {
              method: "DELETE"
          };

          fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${id}.json`, headers)
              .then(() => {
                  phoneBookData.innerHTML = "";
                  loadPhoneBook();
              })
              .catch(() => console.log("Error"));
      }

      return {
          deletePhone
      };
  }

  attachEvents();