import React from 'react';

import ToDoListItem from './ToDoListItem';

function ToDoListFuncComponent() {
    // put always in the begining ot the component
    let todoState = React.useState(['Clean your room 2', 'Go Shoping 2', 'Learn React 2', 'Wash the dishes 2']);
    // array destructuring assignment
    let [todos, setTodos] = todoState;

    let [todos2, setTodos2] = React.useState('initial todo');
    let [count, setCount] = React.useState(1);

    console.log(todos2);
    console.log(setTodos2);


    console.log(todos);
    console.log(setTodos);


    // for func component demo
    // let firstTask = "Clean your room";
    // let firstColor = 'blue';
    // let person = {
    //     name: "Pehso",
    //     age: 20
    // };

    return (
        <>
            <h2>Tasks</h2>
            <ul>
                {/* // demo for state */}
                {todos.map(todo => <ToDoListItem>{todo}</ToDoListItem>)}

                <ToDoListItem>{todos2}</ToDoListItem>

                {/* // demo for function components */}
                {/* <ToDoListItem color={firstColor}>{firstTask}</ToDoListItem>
                <ToDoListItem color="green"><p>Go Shoping - func</p></ToDoListItem>
                <ToDoListItem color="red" person={person}>Learn React - func</ToDoListItem>
                <ToDoListItem color="purple">Wash the dishes - func</ToDoListItem> */}

                <button onClick={() => console.log('click')}>Modify</button>
                <button onClick={() => setCount(++count)}>Rise count</button>
                <p>{count}</p>
            </ul>
        </>
    );
}

export default ToDoListFuncComponent;


//Class component syntax
// import React from "react";

// class ToDoListClassComponent extends React.Component {
//     render() {
//         return (
//             <>
//                 <h2>Tasks</h2>
//                 <ul>
//                     <li>Clean ypur room - func</li>
//                     <li>Go Shoping - func</li>
//                     <li>Learn React - func</li>
//                 </ul>
//             </>
//         );
//     }
// }
// export default ToDoListClassComponent;


