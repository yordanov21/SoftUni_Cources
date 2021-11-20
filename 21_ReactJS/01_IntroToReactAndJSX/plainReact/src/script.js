let rootElement = document.getElementById('root');

let reactElement = React.createElement(
    'header',
    { className: 'side-header' },
    React.createElement('h1', { id: 'main-heading' }, 'Hello react!'),
    React.createElement('h2', {}, 'The best framework it the world'),
);

ReactDOM.render(reactElement, rootElement);