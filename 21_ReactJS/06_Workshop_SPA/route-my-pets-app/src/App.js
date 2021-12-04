import { useState, useEffect } from 'react';
import { Routes, Route } from 'react-router-dom';

import * as authService from "./services/authService";
import Header from "./components/Header";
import Dashboard from "./components/Dashboard/Dashboard";
import Login from "./components/Login/Login";
import Register from "./components/Register/Register";
import MyPets from "./components/MyPets/MyPets";
import Create from "./components/Create/Create";

function App() {

	const [userInfo, setUserInfo] = useState({ isAuthenticated: false, email: '' });

	useEffect(() => {
		let user = authService.getUser();

		setUserInfo({
			isAuthenticated: Boolean(user),
			user
		})

	}, []);


	const onLogin = (email) => {
		setUserInfo({
			isAuthenticated: true,
			user: email
		})
	}


	return (
		<div id="container">

			<Header {...userInfo} />

			<main id="site-content">
				<Routes>
					<Route path="/" element={<Dashboard />} />
					<Route path="/login" element={<Login onLogin={onLogin} />} />
					<Route path="/register" element={<Register />} />
					<Route path="/my-pets" element={<MyPets />} />
					<Route path="/create" element={<Create />} />
				</Routes>
			</main>

			<footer id="site-footer">
				<p>@PetMyPet</p>
			</footer>

		</div>
	);
}

export default App;
