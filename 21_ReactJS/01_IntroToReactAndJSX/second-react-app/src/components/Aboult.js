import AboultFirstCard from "./aboultCards/AboultFirstCard";
import AboultSecondCard from "./aboultCards/AboultSecondCard";

function Aboult() {
    return (
        <div id="about" className="about">
            <div className="container">
                <div className="row">
                    <div className="col-md-12">
                        <div className="titlepage">
                            <h2>About <strong className="white black"> Us</strong></h2>
                            <p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. </p>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <AboultFirstCard />
                    <AboultSecondCard />
                </div>
            </div>
        </div>
    );
}

export default Aboult