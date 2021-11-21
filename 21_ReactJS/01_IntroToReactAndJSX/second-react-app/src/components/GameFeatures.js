import GameCard1 from "./gameFeaturesCards/GameCard1";
import GameCard2 from "./gameFeaturesCards/GameCard2";
import GameCard3 from "./gameFeaturesCards/GameCard3";
import GameCard4 from "./gameFeaturesCards/GameCard4";

function GameFeatures() {
    return (
        <div id="games" className="Features">
            <div className="container">
                <div className="row d_flex">
                    <div className="col-xl-6 col-lg-6 col-md-12 col-sm-12 ">
                        <div className="titlepage">
                            <h2>Features<br /><strong className="white"> Games</strong></h2>
                            <p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less </p>
                            <a href="#">View All</a>
                        </div>
                    </div>
                    <div className="col-xl-6 col-lg-6 col-md-12 col-sm-12 ">
                        <div className="row">
                            <GameCard1 />
                            <GameCard2 />
                            <GameCard3 />
                            <GameCard4 />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default GameFeatures;