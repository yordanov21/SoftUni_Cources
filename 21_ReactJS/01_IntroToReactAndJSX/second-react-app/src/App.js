import Footer from "./components/Footer";
import Header from "./components/Header";
import Aboult from "./components/Aboult";
import GameFeatures from "./components/GameFeatures";
import OurNews from "./components/OurNews";
import Contacts from "./components/Contacts";

function App() {
  return (
    <div className="App">

      <div className="loader_bg">
        <div className="loader"><img src="images/loading.gif" alt="#" /></div>
      </div>
      <Header />
      <Aboult />
      <GameFeatures />
      <OurNews />
      <Contacts />
      <div className="map">
        <figure><img src="images/map.jpg" alt="#" /></figure>
      </div>

      <Footer />
    </div>
  );
}

export default App;
