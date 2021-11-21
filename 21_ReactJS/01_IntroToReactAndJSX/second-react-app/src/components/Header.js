function Header() {
    return (
        <header>
            <div className="header-top">
                <div className="header">
                    <div className="container">
                        <div className="row">
                            <div className="col-xl-3 col-lg-3 col-md-3 col-sm-3 col logo_section">
                                <div className="full">
                                    <div className="center-desk">
                                        <div className="logo">
                                            <a href="index.html"><img src="images/logo.png" alt="#" /></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-xl-9 col-lg-9 col-md-9 col-sm-9">
                                <div className="menu-area">
                                    <div className="limit-box">
                                        <nav className="main-menu">
                                            <ul className="menu-area-main">
                                                <li className="active"> <a href="index.html">Home</a> </li>
                                                <li> <a href="#about">About</a> </li>
                                                <li> <a href="#games">Games</a> </li>
                                                <li> <a href="#Our_Our">Our News</a> </li>
                                                <li> <a href="#booknow">Contact us</a> </li>
                                            </ul>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <section className="slider_section">
                    <div id="myCarousel" className="carousel slide banner_main" data-ride="carousel">
                        <ol className="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" className="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>
                        </ol>
                        <div className="carousel-inner">
                            <div className="carousel-item active">

                                <div className="container">
                                    <div className="carousel-caption">
                                        <div className="row d_flex">
                                            <div className="col-md-4">
                                                <div className="text-bg">
                                                    <h1>Online casino </h1>
                                                    <a href="#">Play now</a>
                                                </div>
                                            </div>
                                            <div className="col-md-8">
                                                <div className="text-img">
                                                    <figure><img src="images/img.png" /></figure>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="carousel-item">

                                <div className="container">
                                    <div className="carousel-caption">
                                        <div className="row d_flex">
                                            <div className="col-md-4">
                                                <div className="text-bg">
                                                    <h1>Online casino </h1>
                                                    <a href="#">Play now</a>
                                                </div>
                                            </div>
                                            <div className="col-md-8">
                                                <div className="text-img">
                                                    <figure><img src="images/img.png" /></figure>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="carousel-item">

                                <div className="container">
                                    <div className="carousel-caption">
                                        <div className="row d_flex">
                                            <div className="col-md-4">
                                                <div className="text-bg">
                                                    <h1>Online casino </h1>
                                                    <a href="#">Play now</a>
                                                </div>
                                            </div>
                                            <div className="col-md-8">
                                                <div className="text-img">
                                                    <figure><img src="images/img.png" /></figure>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a className="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
                            <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span className="sr-only">Previous</span>
                        </a>
                        <a className="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
                            <span className="carousel-control-next-icon" aria-hidden="true"></span>
                            <span className="sr-only">Next</span>
                        </a>
                    </div>

                </section>
            </div>
        </header>
    );
}

export default Header;