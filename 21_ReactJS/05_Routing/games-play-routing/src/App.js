import { useState, createElement } from 'react';
import { Route, Link, Switch } from 'react-router-dom';


import Header from './components/Header';
import WelcomeWorld from './components/WelcomeWorld';
import Login from './components/Login';
import Register from './components/Register';
import CreateGame from './components/CreateGame';
import EditGame from './components/EditGame';
import GameDetails from './components/GameDetails';
import GameCatalog from './components/GameCatalog/GameCatalog';
import ErrorPage from './components/ErrorPage';

function App() {
	const [page, setPage] = useState('/home');

	const navigationChangeHandler = (path) => {
		setPage(path);
	}

	const routers = {
		'/home': <WelcomeWorld navigationChangeHandler={navigationChangeHandler} />,
		'/games': <GameCatalog navigationChangeHandler={navigationChangeHandler} />,
		'/login': <Login />,
		'/register': <Register />,
		'/create-game': <CreateGame />,
	}

	const router = (path) => {
		let pathNames = path.split('/');

		let rootPath = pathNames[1];
		let argument = pathNames[2];

		const routes = {
			'home': <WelcomeWorld navigationChangeHandler={navigationChangeHandler} />,
			'games': <GameCatalog navigationChangeHandler={navigationChangeHandler} />,
			'login': <Login />,
			'register': <Register />,
			'create-game': <CreateGame />,
			'details': <GameDetails id={argument} />,
		}

		return routes[rootPath];
	}


	return (
		<div id="box">
			<Header navigationChangeHandler={navigationChangeHandler} />

			<main id="main-content">
				<Switch>
					<Route path="/" exact component={WelcomeWorld} />
					<Route path="/games" component={GameCatalog} />
					<Route path="/create-game" component={CreateGame} />
					<Route path="/login" component={Login} />
					<Route path="/register" component={Register} />
				</Switch>
			</main>

		</div>
	);
}

export default App;
