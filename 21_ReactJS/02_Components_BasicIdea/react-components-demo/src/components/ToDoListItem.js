const ToDoListItem = (props) => {
    return <li style={{ color: props.color }}>{props.children}-{props.person?.name}</li>
};

export default ToDoListItem;