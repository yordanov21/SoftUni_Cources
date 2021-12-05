import { Routes, Route, Link } from "react-router-dom";
import PetList from '../PetList/PetList';
//import svg file -two ways:
// 1. Directly
//import {logo} from '../../logo.svg';
// 2. With React componet
//import { ReactComponent as Logo } from '../../logo.svg';
//import './Dashboard.css';

const Dashboard = () => {

    return (
        <section id="dashboard-page" className="dashboard">
            <h1>Dashboard</h1>

            <nav>
                <Link to="types">Types</Link>
            </nav>

            <section>
                <Routes>
                    <Route path="/" element={<PetList />} />
                    <Route path="/types" element={<><p>Types ...</p></>} />
                </Routes>
            </section>

            {/* <img src={logo} title="logo" alt="logo" /> */}
            {/* <Logo className="logo" /> */}

        </section>
    );
};

export default Dashboard;