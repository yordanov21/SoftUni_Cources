class Forum {

    //Private properties starts with "_"!
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1

    }

    register(username, password, repeatPassword, email) {
        if (username === '' || password === '' || repeatPassword === '' || email === '') {

            throw new Error('Input can not be empty');
        }

        if (password !== repeatPassword) {
            throw new Error('Passwords do not match');
        }

        const index = this._users.findIndex((x) => x.username === username);
        if (index !== -1) {
            throw new Error('This user already exists!');
        }

        let user = {
            username: username,
            password: password,
            email: email,
            isLogin: false
        }
        this._users.push(user);

        return `${username} with ${email} was registered successfully!`;

    }

    login(username, password) {
        const index = this._users.findIndex((x) => x.username === username);
        if (index === -1) {
            throw new Error('There is no such user');
        }

        if (this._users[index].password === password) {
            this._users[index].isLogin = true;
            return "Hello! You have logged in successfully";
        }
    }

    logout(username, password) {
        const index = this._users.findIndex((x) => x.username === username);
        if (index === -1) {
            throw new Error('There is no such user');
        }

        if (this._users[index].password === password) {
            this._users[index].isLogin = false;
            return "You have logged out successfully";
        }
    }

    postQuestion(username, question) {
        const user = this._users.find(u => u.username === username);

        if (!user || user.isLoggedIn === false) {
            throw new Error("You should be logged in to post questions");
        }

        if (!question) {
            throw new Error("Invalid question");
        }

        const targetQuestion = {
            id: this._id++,
            username: username,
            question: question,
            answers: []
        };

        this._questions.push(targetQuestion);
        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        const user = this._users.find(u => u.username === username);

        if (!user || user.isLogin === false) {
            throw new Error("You should be logged in to post answers");
        }

        if (!answer) {
            throw new Error("Invalid answer");
        }

        const question = this._questions.find(q => q.id === questionId);

        if (!question) {
            throw new Error("There is no such question");
        }

        question.answers.push({
            username: username,
            answer: answer
        });

        return "Your answer has been posted successfully";
    }

    showQuestions() {
        let result = "";

        for (const question of this._questions) {
            result += `Question ${question.id} by ${question.username}: ${question.question}\n`;

            for (const answer of question.answers) {
                result += `---${answer.username}: ${answer.answer}\n`;
            }
        }

        return result.trim();
    }
}