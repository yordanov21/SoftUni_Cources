function lockedProfile() {

    const $buttons = document.querySelectorAll('div#container main#main div.profile button');

    [...$buttons].forEach((button) => {
                button.addEventListener('click', (event) => {

                        const divSivling = event.currentTarget.parantNode.children[9];
                        divSivling.style.display = 'block';
                    }
                    // let buttons = document.getElementsByTagName("button");

                    // for (const button of buttons) {
                    //     button.addEventListener("click", handler);
                    // }

                    // function handler() {

                    //     let elements = this.parentNode.children;
                    //     let isLocked = elements[2].checked;
                    //     let hidenInfo = elements[9];
                    //     let button = elements[10];       

                    //     if(!isLocked && button.textContent === "Show more"){
                    //         hidenInfo.style.display = "block";
                    //         button.textContent = "Hide it";
                    //     }
                    //     else if (!isLocked && button.textContent === "Hide it") {
                    //         hidenInfo.style.display = "none";
                    //         button.textContent = "Show more";
                    //     }
                    // }
                }
            }