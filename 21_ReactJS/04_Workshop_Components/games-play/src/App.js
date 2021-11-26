import { useState, createElement } from 'react';

import Header from './components/Header';
import WelcomeWorld from './components/WelcomeWorld';
import Login from './components/Login';
import Register from './components/Register';
import CreateGame from './components/CreateGame';
import EditGame from './components/EditGame';
import GameDetails from './components/GameDetails';
import GameCatalog from './components/GameCatalog';
import ErrorPage from './components/ErrorPage';

function App() {
	const [page, setPage] = useState('/home');

	const routers = {
		'/home': <WelcomeWorld />,
		'/games': <GameCatalog />,
		'/login': <Login />,
		'/register': <Register />,
		'/create-game': <CreateGame />,
	}

	const navigationChangeHandler = (path) => {
		console.log(path);
		setPage(path);
	}

	return (
		<div id="box">
			<Header navigationChangeHandler={navigationChangeHandler} />

			<main id="main-content">
				{routers[page] || <ErrorPage />}
			</main>

		</div>
	);
}

export default App;
