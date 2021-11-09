let someWorker = ((worker) => {

    if (worker.dizziness) {
        worker.levelOfHydrated += (0.1 * worker.weight * worker.experience)
        worker.dizziness = !worker.dizziness; //сетваме обратната страна, ако е true=>false, ako e false=>true
    }

    return worker;
})({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
});

//решение с функция
// function solve(worker) {
//     if (worker.dizziness) {
//         worker.levelOfHydrated += (0.1 * worker.weight * worker.experience)
//         worker.dizziness = !worker.dizziness; //сетваме обратната страна, ако е true=>false, ako e false=>true
//     }

//     return worker;
// }
// console.log(solve({
//     weight: 80,
//     experience: 1,
//     levelOfHydrated: 0,
//     dizziness: true
// }));