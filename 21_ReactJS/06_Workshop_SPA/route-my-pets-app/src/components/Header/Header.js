import { Link, NavLink } from 'react-router-dom';

const Header = () => {

    return (
        <header id="site-header">
            <nav className="navbar">
                <section className="navbar-dashboard">
                    <Link to="/">Dashboard</Link>

                    <div id="guest">
                        <Link to="/login" className="button" >Login</Link>
                        <Link to="/register" className="button" >Register</Link>
                    </div>

                    <div id="user">
                        <span>Welcome, email</span>
                        <Link to="/my-pets" className="button">My Pets</Link>
                        <Link to="/create" className="button">Add Pet</Link>
                        <Link to="/logout" className="button">Logout</Link>
                    </div>
                </section>
            </nav>
        </header>
    );
};

export default Header;