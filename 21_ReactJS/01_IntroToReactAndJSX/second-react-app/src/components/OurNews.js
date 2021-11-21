function OurNews() {
    return (
        <div id="Our_Our" className="Our">
            <div className="container">
                <div className="row">
                    <div className="col-md-2">
                        <div className="titlepage">
                            <h2>Our <br /><strong className="white black"> news</strong></h2>
                        </div>
                    </div>
                    <div className="col-md-10">
                        <div className="titlepage">
                            <span>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less </span>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <div id="main_slider" className="carousel slide banner-main2" data-ride="carousel">
                            <div className="carousel-inner">
                                <div className="carousel-item active">
                                    <img className="first-slide" src="images/banner.png" alt="First slide" />
                                </div>
                                <div className="carousel-item">
                                    <img className="second-slide" src="images/banner.png" alt="Second slide" />
                                </div>
                                <div className="carousel-item">
                                    <img className="third-slide" src="images/banner.png" alt="Third slide" />
                                </div>
                            </div>
                            <a className="carousel-control-prev" href="#main_slider" role="button" data-slide="prev"> <i className='fa fa-angle-left'></i></a>
                            <a className="carousel-control-next" href="#main_slider" role="button" data-slide="next"> <i className='fa fa-angle-right'></i></a>
                        </div>
                        <p className="new_s">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less </p>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default OurNews;