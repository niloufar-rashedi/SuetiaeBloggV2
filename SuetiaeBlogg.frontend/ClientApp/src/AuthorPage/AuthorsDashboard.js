import React, { Component} from 'react'
import {Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import axios from 'axios';
import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';
import history from '../../src/history'

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
        await axios.get(`${this.apiURL}/${this.authorId}/posts`)
            .then(response => {
                console.log('Rasponse from postByAuthorId', response)

                this.setState({ post: response.data.data });
            });
    }
    token = localStorage.getItem('signin');
    authorId = localStorage.getItem('userId');
    apiURLDelete = `https://localhost:44351/api/BlogPosts`;

    deletePosts = (id) => {
        axios.delete(`${this.apiURLDelete}/${id}`, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        })
            .then((result) => {
                console.log('Object deleted', result);
                window.location.reload();
                history.push('/authorsdashboarad');
            });
    };
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
                                    {this.state.post.map(postbyauthorid => (
                                        <tr key={postbyauthorid.id}>
                                            <td>{postbyauthorid.title}</td>
                                            <td>{postbyauthorid.summary}</td>
                                            <td>{postbyauthorid.category}</td>
                                            

                                            <td>
                                                <div class="btn-group">
                                                    <Link to={{ pathname: `/editpost/${postbyauthorid.postId}`, query: { id: postbyauthorid.postId } }}><Button variant="btn btn-success" >Edit</Button></Link>
                                                    <button type="button" class="btn btn-warning" data-toggle="modal" data-target="#staticBackdrop">
                                                        Delete</button>
                                                    <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title" id="staticBackdropLabel">Warning</h5>
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                        <span aria-hidden="true">&times;</span>
                                                                    </button>
                                                                </div>
                                                                <div class="modal-body">
                                                                    This accetion is irreversible! are you sure you want to delete " {postbyauthorid.title} " forever?
                                                                  </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-primary" data-dismiss="modal"> I regret </button>
                                                                    <button type="button" class="btn btn-light" onClick={() => this.deletePosts(postbyauthorid.postId)}>Confirm & delete</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
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