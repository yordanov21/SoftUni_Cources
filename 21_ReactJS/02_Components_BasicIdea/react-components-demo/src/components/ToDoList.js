import ToDoListItem from './ToDoListItem';

function ToDoListFuncComponent() {

    let firstTask = "Clean your room";
    let firstColor = 'blue';
    let person = {
        name: "Pehso",
        age: 20
    };

    return (
        <>
            <h2>Tasks</h2>
            <ul>
                <ToDoListItem color={firstColor}>{firstTask}</ToDoListItem>
                <ToDoListItem color="green"><p>Go Shoping - func</p></ToDoListItem>
                <ToDoListItem color="red" person={person}>Learn React - func</ToDoListItem>
                <ToDoListItem color="purple">Wash the dishes - func</ToDoListItem>
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


