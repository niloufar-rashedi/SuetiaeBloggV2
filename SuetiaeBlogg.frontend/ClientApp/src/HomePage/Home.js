import React, { Component, Link } from 'react';
import { Posts } from '../components/post/posts';
import AddPost from '../components/Addpost'


import { Container, Col, Row, Form, Button } from 'reactstrap';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <div>
                <div class="row">
                    <div class="col">
                        <img src="https://images.unsplash.com/photo-1551730708-87acf0563a4d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1950&q=80"
                            class="img-fluid" alt="Responsive image"
                        />
                    </div>
                    
                </div>

                
                
                <div class="input-group mb-3 mt-5">
                    <div class="input-group-prepend">
                        <button type="button" class="btn btn-danger">Search among posts</button>
                    </div>
                    <input type="text" class="form-control" aria-label="Text input with segmented dropdown button" placeholder="Author, Subject, Publication date, ..." />
                </div>
                <div class="row">
                    <div>
                        <Posts />
                        </div>
                    
                    <div class="col">
                        <div class="row">
                            <div class="col">
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item font-weight-bold">Archive</li>
                                    <li class="list-group-item">Cras justo odio</li>
                                    <li class="list-group-item">Dapibus ac</li>
                                    <li class="list-group-item">Morbi leo risus</li>
                                    <li class="list-group-item">Consectetur ac</li>
                                    <li class="list-group-item">Vestibulum at</li>
                                </ul>
                            </div>
                            <div class="col">
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item font-weight-bold">Categories</li>
                                    <li class="list-group-item">Cras justo odio</li>
                                    <li class="list-group-item">Dapibus ac</li>
                                    <li class="list-group-item">Morbi leo risus</li>
                                    <li class="list-group-item">Consectetur ac</li>
                                    <li class="list-group-item">Vestibulum at</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                {/* </Container>*/}



                <div class="container">
                    <h3>Celebrate "kanelbullens dag" with a fantastic recipe </h3>
                    <img src="https://images.unsplash.com/photo-1580677881307-5852a81368ef?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80"
                        class="img-fluid" alt="Responsive image"
                        href="https://www.ica.se/buffe/artikel/recept-till-kanelbullens-dag/"
                    />
                </div>
                <div class="row mt-3">
                    <div class="col">
                        <img src="https://images.unsplash.com/photo-1526644253653-a411eaafdfe6?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1055&q=80"
                            className="img-fluid rounded"
                            alt="..."
                        />
                    </div>
                    <div class="col">
                        <p class="text-justify">Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.
                        magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam
                            </p>
                    </div>
                    <div class="col">
                        <p class="text-justify">Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.
                            magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit,<a href="#" class="text-info"> read more </a>
                        </p>
                    </div>
                </div>


                <Form>
                    <h3 class="text-center">subscribe to our newsletter</h3>
                    <div class="form-row mx-auto">
                        <div class="col-md-6 mb-3">
                            <label for="validationServer01"></label>
                            <input type="text" class="form-control is-valid" id="validationServer01" placeholder="First name" required />
                            <div class="valid-feedback">
                            </div>
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="validationServerUsername"></label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="inputGroupPrepend3">@</span>
                                </div>
                                <input type="text" class="form-control is-invalid" id="validationServerUsername" placeholder="E-mail" aria-describedby="inputGroupPrepend3" required />
                                <div class="invalid-feedback">
                                </div>
                            </div>
                            <button type="submit" class="btn btn-primary">Submit</button>
                        </div>
                        <div class="col-auto my-1">

                        </div>
                    </div>
                </Form>
            </div>

      </div>
    );
  }
}
