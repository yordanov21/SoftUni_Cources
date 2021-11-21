function Contacts() {
    return (
        <div id="booknow" className="contact">
            <div className="container-fluid">
                <div className="row">
                    <div className="col-xl-6 col-lg-6 col-md-6 col-sm-12 padding-right1">
                        <div className="rable-box">
                            <figure />
                            <img src="images/cac.png" alt="#" />
                        </div>
                    </div>
                    <div className="col-xl-6 col-lg-6 col-md-6 col-sm-12 padding-left1">
                        <div className="contact">
                            <div className="titlepage">
                                <h2>Book <br /><strong className="white "> Now</strong></h2>
                            </div>
                            <form className="book_now">
                                <div className="row">
                                    <div className="col-sm-12">
                                        <input className="contactus" placeholder="Name" type="text" name="Name" />
                                    </div>
                                    <div className="col-sm-12">
                                        <input className="contactus" placeholder="Phone Number" type="text" name="Phone Number" />
                                    </div>
                                    <div className="col-sm-12">
                                        <input className="contactus" placeholder="Email" type="text" name="Email" />
                                    </div>
                                    <div className="col-sm-12">
                                        <select name="cars">
                                            <option value="volvo" selected> Select Game</option>
                                            <option value="saab">1</option>
                                            <option value="fiat" >2</option>
                                            <option value="audi">3</option>
                                        </select>
                                    </div>
                                    <div className="col-sm-12">
                                        <textarea className="textarea" placeholder="Message" type="text" name="Message"></textarea>
                                    </div>
                                    <div className="col-sm-12">
                                        <button className="send">Send</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Contacts