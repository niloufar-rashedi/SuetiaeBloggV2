import React, { Component } from 'react'

export class About extends Component {
	render() {
        return (
            <div class="container p-4">
                <h3>About Suetiae Blog</h3>
                <div class="col">
                    <p class="text-justify">Suetiae Blog is home for all you expats in Sweden! Uniting expat bloggers with their latest blog posts, blog reviews, expat interviews & contests. Our news team bring you daily news items from Sweden that may help you to enjoy your time here!. Enjoy, share and get involved!</p>
                    <p> Suetiae Blog was created by three amazing women, those description you can find below. </p>
                </div>
                <div class="w-50 h-50">
                    <div class="carousel slide" id="carouselExampleCaptions" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
                            <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="bilder/Person-1.jpg" alt=" First Slide" class="d-block w-100 h-100"/>
                                <div class="carousel-caption d-none d-md-block">
                                    <h5>Manjula</h5>
                                    <p>Living abroad since 2010. Following her professional commitments, she has moved to various countries: Great-Britain, Canada, Australia and Sweden where she currently lives.</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img src="bilder/Person-2.jpg" alt=" Second Slide" class="d-block w-100 h-100"/>
                                <div class="carousel-caption d-none d-md-block">
                                    <h5>Kitty</h5>
                                    <p>Singaporean, living abroad since 2015. Residing in Umeå, and sharing her everyday memories, one Swedish adventure at the time!.</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img src="bilder/Person-3.jpg" alt=" Third Slide" class="d-block w-100 h-100"/>
                                <div class="carousel-caption d-none d-md-block">
                                    <h5>Ramonda</h5>
                                    <p>Writes about life as an expat wife. Countries I live in and travel to. Personal thoughts & reflections on my life in Sweden.</p>
                                </div>
                            </div>
                        </div>
                        <a href="#carouselExample" class="carousel-control-prev" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a href="#carouselExample" class="carousel-control-next" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>
           </div>  
        );
    }
}