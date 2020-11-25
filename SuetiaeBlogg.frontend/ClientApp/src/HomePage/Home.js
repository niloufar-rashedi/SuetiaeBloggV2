import React, { Component} from 'react';
import { Posts } from '../components/post/posts';
import Carousel from 'react-bootstrap/Carousel'
import Card from 'react-bootstrap/Card'
import { ShowCategories } from '../components/categories/showcategories';

import { Button } from 'reactstrap';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <div className="Container">
                <div className="row">
                <Carousel>
                    <Carousel.Item interval={1000}>
                        <img
                            className="d-block w-100"
                            src="https://images.unsplash.com/photo-1527156737205-c93d3dc84e87?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80"
                            alt="First slide"
                        />
                        <Carousel.Caption>
                            <h3>How do you experience Suetiae?</h3>
                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item interval={500}>
                        <img
                            className="d-block w-100"
                            src="https://images.unsplash.com/photo-1593642533144-3d62aa4783ec?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80"
                            alt="Third slide"
                        />
                        <Carousel.Caption>
                            <h3>Getout of your comfort zone</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://images.unsplash.com/photo-1551730708-87acf0563a4d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1950&q=80"
                            alt="Third slide"
                        />
                        <Carousel.Caption>
                            <h3>Housing can be a problem sometimes</h3>
                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://images.unsplash.com/photo-1580677881307-5852a81368ef?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80"
                            alt="Third slide"
                        />
                        <Carousel.Caption>
                            <h3>Celebrate Kanelbulle day with us!</h3>
                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                        </Carousel.Caption>
                    </Carousel.Item>

                </Carousel>                    
                </div>

                
                
                <div className="input-group mb-3 mt-5">
                    <div className="input-group-prepend">
                        <button type="button" className="btn btn-danger">Search among posts</button>
                    </div>
                    <input type="text" className="form-control" aria-label="Text input with segmented dropdown button" placeholder="Author, Subject, Publication date, ..." />
                </div>
                <div className="row">
                    <div>
                        <Posts />
                        </div>
                    
                    <div className="col">
                        <div className="row">
                            <div className="col">
                                <ul className="list-group list-group-flush">
                                    <li className="list-group-item font-weight-bold">Archive</li>
                                    <li className="list-group-item">Cras justo odio</li>
                                    <li className="list-group-item">Dapibus ac</li>
                                    <li className="list-group-item">Morbi leo risus</li>
                                    <li className="list-group-item">Consectetur ac</li>
                                    <li className="list-group-item">Vestibulum at</li>
                                </ul>
                            </div>
                            <div className="col">
                            <ul class="list-group list-group-flush">
                                    <li class="list-group-item font-weight-bold">Categories</li>
                                    <div>
                        <ShowCategories />
                        </div>
                    
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                {/* </Container>*/}



            <div className="row">
                <Card className="text-dark d-flex justify-content-center">
                    <Card.Img src="https://images.unsplash.com/photo-1483288578299-bdb6421dee2e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1310&q=80" alt="Card image" />
                    <Card.ImgOverlay>
                        <Card.Title>Celebrate "kanelbullens dag" with a fantastic recipe</Card.Title>
                        <Card.Text>
                            Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi.
                    </Card.Text>
                        <Card.Text><a href="#" />click to learn more</Card.Text>
                    </Card.ImgOverlay>
                </Card>

            </div>
            <div className="row d-flex justify-content-center">
                <h1>Our Background</h1>
                <p className="text-justify">Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.
                magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.
                            magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit,<a href="#" className="text-info"> read more </a>

                </p>
            </div>


            <div className="row d-flex justify-content-center">
                <Card className="text-center">
                    <Card.Header>subscription</Card.Header>
                    <Card.Body>
                        <Card.Title>Join our mailing list to read the latest on Suetiae</Card.Title>
                        <Card.Text>

                        </Card.Text>
                        <Button variant="warning">Subscribe</Button>
                    </Card.Body>
                    <Card.Footer className="text-muted"></Card.Footer>
                </Card>
            </div>
            </div>
    );
  }
}
