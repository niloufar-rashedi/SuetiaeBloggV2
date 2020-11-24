import React, { Component } from 'react';
import { MDBCol, MDBContainer, MDBRow, MDBFooter } from "mdbreact";


export class Footer extends Component {

    render() {
        return (
            <footer className="site-footer"> 
                <div className="container">
                    <div className="row">
                        <div className="col-sm-12 col-md-6">
                            <h6>About</h6>
                            <p className="text-justify"><i>Suetiate.se </i> is home for all you expats in Sweden! Uniting expat bloggers with their latest blog posts, blog reviews, expat interviews & contests. Our news team bring you daily news items from Sweden that may help you to enjoy your time here!. Enjoy, share and get involved! </p>
                        </div>

                        <div className="col-xs-6 col-md-3">
                            <h6>Categories</h6>
                            <ul className="footer-links">
                                <li><a href="http://scanfcode.com/category/c-language/">General</a></li>
                                <li><a href="http://scanfcode.com/category/front-end-development/">Holiday</a></li>
                                <li><a href="http://scanfcode.com/category/back-end-development/">Leasure activities</a></li>
                                <li><a href="http://scanfcode.com/category/java-programming-language/">Events</a></li>
                                <li><a href="http://scanfcode.com/category/java-programming-language/">Finding job</a></li>

                            </ul>
                        </div>

                        <div className="col-xs-6 col-md-3">
                            <h6>Quick Links</h6>
                            <ul className="footer-links">
                                <li><a href="/About">About Us</a></li>
                                <li><a href="/Contact">Contact Us</a></li>
                                <li><a href="http://scanfcode.com/contribute-at-scanfcode/">Contribute</a></li>
                                <li><a href="http://scanfcode.com/privacy-policy/">Privacy Policy</a></li>
                                <li><a href="http://scanfcode.com/sitemap/">Sitemap</a></li>
                            </ul>
                        </div>
                    </div>
                </div>

                <div className="container">
                    <div className="row">
                        <div className="col-md-8 col-sm-6 col-xs-12">
                            <p className="copyright-text">Copyright &copy; 2020 All Rights Reserved by
                         <a href="#"> Suetiae</a>.
                            </p>
                        </div>

                        <div className="col-md-4 col-sm-6 col-xs-12">
                            <ul className="social-icons">
                                <li><a className="facebook" href="#"><i className="fa fa-facebook"></i></a></li>
                                <li><a className="twitter" href="#"><i className="fa fa-twitter"></i></a></li>
                                <li><a className="dribbble" href="#"><i className="fa fa-dribbble"></i></a></li>
                                <li><a className="linkedin" href="#"><i className="fa fa-linkedin"></i></a></li>
                            </ul>
                        </div>
                    </div>
                </div>

            </footer>

        );
    }
}