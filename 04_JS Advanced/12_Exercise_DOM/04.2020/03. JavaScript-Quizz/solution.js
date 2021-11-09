function solve() {
    let quizzie = document.getElementById('quizzie');
    let sections = document.getElementsByTagName('section');
    let result = document.querySelector('.results-inner h1')
        //ride anwers
    let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents']
    let userAnswers = 0;
    let currentStep = 0;

    quizzie.addEventListener('click', (e) => {
        //е.target реферира към елемента, на който сме кликнали 
        if (e.target.className === 'answer-text') {
            //set current step to none(hide it)
            sections[currentStep].style.display = "none";
            //check ride answer
            let isAnswerCorrect = correctAnswers.includes(e.target.innerHTML);
            if (isAnswerCorrect) {
                userAnswers++;
            }
            currentStep++;
            //show next section
            if (currentStep < correctAnswers.length) {
                sections[currentStep].style.display = "block"
            }
            //if current step=3 =>show the result
            if (currentStep === 3) {

                document.querySelector('#results').style.display = 'block';
                //може и директно 3 да напишем
                result.innerHTML = correctAnswers.length === userAnswers ?
                    "You are recognized as top JavaScript fan!" : `You have ${userAnswers} right answers`
            }
        }

    })
}