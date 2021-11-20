var rootElement = document.getElementById('root');

// without JSX syntax
// let reactElement = React.createElement(
//     'header',
//     { className: 'side-header' },
//     React.createElement('h1', { id: 'main-heading' }, 'Hello react!'),
//     React.createElement('h2', {}, 'The best framework it the world'),
// );

// with JSX syntax
var reactElement = React.createElement(
    'div',
    null,
    React.createElement(
        'header',
        null,
        React.createElement(
            'h1',
            null,
            'Hello JSX mod'
        ),
        React.createElement(
            'h2',
            null,
            'Something cool here'
        ),
        React.createElement(
            'p',
            null,
            'ldsfdsfsdfdsfklsvlk mlsmfdlksmdfmsdlfmlksmdkmlfkm'
        )
    ),
    React.createElement(
        'footer',
        null,
        'All rights reserved \xA9'
    )
);

ReactDOM.render(reactElement, rootElement);