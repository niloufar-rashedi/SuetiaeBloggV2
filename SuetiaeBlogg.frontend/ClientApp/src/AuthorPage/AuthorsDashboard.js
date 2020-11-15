import React, { Component, useContext} from 'react'
import { Badge, Card, CardBody, CardHeader, Col, Pagination, PaginationItem, PaginationLink, Row, Table } from 'reactstrap';
import axios from 'axios';
import { useState, useEffect } from 'react'
import Button from 'react-bootstrap/Button';

import { UserContext } from '../components/UserContext';

class AuthorsDashboard extends Component {
    constructor(props) {
        super(props);
        this.state = {
            post: [],
            authorId:''
        }
    }

            authorId = localStorage.getItem('userId');

    apiURL = `https://localhost:44351/api/BlogPosts/authors`;

    async componentDidMount() {
        //this.state.authorId = localStorage.getItem('userId');
        await axios.get(`${this.apiURL}/${this.authorId}/posts`)
            .then(response => {
                console.log('Rasponse from postByAuthorId', response)

                this.setState({ post: response.data.data });
            });
    }
     deletePosts = (id) => {
        debugger;
        axios.delete('https://localhost:44351/api/BlogPosts' + id)
            .then((result) => {
                //props.history.push('/authorsdahboard')
                console.log('Object deleted', result)

            });
    };
    // editPosts = (id) => {
    //    props.history.push({
    //        pathname: '/edit/' + id
    //    });
    //};
   // const msg = useContext(UserContext);
    render() {
    return (
        <div className="Container animated fadeIn">
            <Row>
                <Col>
                    <Card>
                        <CardHeader>
                            <i className="fa fa-align-justify"></i> Your recent posts
                          </CardHeader>
                        <CardBody>
                            <Table hover bordered striped responsive size="sm">
                                <thead>
                                    <tr>
                                        <th>Title</th>
                                        <th>Summary</th>
                                        <th>Category</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {/**/}
                                    {this.state.post.map(postbyauthorid => (
                                        <tr key={postbyauthorid.id}>
                                            <td>{postbyauthorid.title}</td>
                                            <td>{postbyauthorid.summary}</td>
                                            <td>{postbyauthorid.category}</td>
                                            

                                            <td>
                                                <div class="btn-group">
                                                    {/*<button className="btn btn-warning" onClick={() => { this.editPosts(this.state.post.id) }}>Edit</button>*/}
                                                    <button className="btn btn-warning" onClick={() => { this.deletePosts(this.state.post.id) }}>Delete</button>
                                                </div>
                                            </td>
                                        </tr>
                                    ))}
                                </tbody>
                                <br>
                                </br>
                                <Button href='/addposttrial'> Add new post </Button>
                            </Table>
                        </CardBody>
                        <div>
                        </div>



                    </Card>
                </Col>
            </Row>
            <Row>
                <Col>
                </Col>
            </Row>
        </div> 
        )
    }
}
export default AuthorsDashboard;