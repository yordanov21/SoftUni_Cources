let rootElement = document.getElementById('root');

// without JSX syntax
// let reactElement = React.createElement(
//     'header',
//     { className: 'side-header' },
//     React.createElement('h1', { id: 'main-heading' }, 'Hello react!'),
//     React.createElement('h2', {}, 'The best framework it the world'),
// );

// with JSX syntax
let reactElement = (
    <div>
        <header>
            <h1>Hello JSX mod</h1>
            <h2>Something cool here</h2>

            <p>ldsfdsfsdfdsfklsvlk mlsmfdlksmdfmsdlfmlksmdkmlfkm</p>
        </header>
        <footer>All rights reserved &copy;</footer>
    </div>
);

ReactDOM.render(reactElement, rootElement);