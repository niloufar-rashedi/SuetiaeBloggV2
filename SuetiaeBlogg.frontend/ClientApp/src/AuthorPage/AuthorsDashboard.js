//import React, { Component, Link } from 'react';
//import { Row, Form, Col, Button, Card, ListGroup, ListGroupItem } from 'react-bootstrap';
//import BlogDataService from '../services/blog.service';
//import http from '../constants/http-common';


//export class AuthorsDashboard extends Component {

//    //constructor(props) {
//        super(props);
//        this.retrievePosts = this.retrievePosts.bind(this);
//        this.removeAllPosts = this.removeAllPosts.bind(this);
//        this.refreshList = this.refreshList.bind(this);
//        this.setActivePost = this.setActivePost.bind(this);
//        this.state = {
//            posts: [],
//            currentPost: null,
//            currentIndex: -1
//        }
//    }
//    componentDidMount() {
//        this.retrievePosts();
//    }

//    retrievePosts() {
//        BlogDataService.getPostsByAuthors()
//            .then(response => {
//                this.setState({
//                    tutorials: response.data
//                });
//                console.log(response.data);
//            })
//            .catch(e => {
//                console.log(e);
//            });
//    }
//    removeAllPosts() {
//        BlogDataService.deletPostById()
//            .then(response => {
//                console.log(response.data);
//                this.refreshList();
//            })
//            .catch(e => {
//                console.log(e);
//            });
//    }
//    refreshList() {
//        this.retrievePosts();
//        this.setState({
//            currentPost: null,
//            currentIndex: -1
//        });
//    }
//    setActivePost(post, index) {
//        this.setState({
//            currentPost: post,
//            currentIndex: index
//        });
//    }


//    render() {
//        const { posts, currentPost, currentIndex } = this.state;
//        return (
//            //<div class="container">
//            //    <div class="row">
//            //        <h4>Your posts list...</h4>
//            //        <ul className="list-group">
//            //            {posts &&
//            //                posts.map((post, index) => (
//            //                    <li
//            //                        className={
//            //                            "list-group-item " +
//            //                            (index === currentIndex ? "active" : "")
//            //                        }
//            //                        onClick={() => this.setActivePost(post, index)}
//            //                        key={index}
//            //                    >
//            //                        {post.title}
//            //                    </li>
//            //                ))}
//            //            <li>
//            //                Here the GetAllByAuthor() will return all postsrelated to this author
//            //                    </li>
//            //        </ul>
//            //        <button
//            //            className="m-3 btn btn-sm btn-danger"
//            //            onClick={this.removeAllPosts}
//            //        >
//            //            Remove All
//            //                </button>
//            //    </div>

//            //    <div class="row">
//            //        {currentPost ? (
//            //            <div>
//            //                <h4>A Post</h4>
//            //                <div>
//            //                    <label>
//            //                        <strong>Title:</strong>
//            //                    </label>{" "}
//            //                    {currentPost.title}
//            //                </div>
//            //                <div>
//            //                    <label>
//            //                        <strong>Summary:</strong>
//            //                    </label>{" "}
//            //                    {currentPost.summary}
//            //                </div>
//            //                <Link
//            //                    to={http + currentPost.id}
//            //                    className="badge badge-warning"
//            //                >
//            //                    Edit
//            //                            </Link>
//            //            </div>
//            //        ) : (
//            //                <div>
//            //                    <br />
//            //                    <p>Please click on a Post...</p>
//            //                </div>
//            //            )}
//            //    </div>
//            //    <div class="row">
//            //        <Card style={{ width: '18rem' }}>
//            //            {/*<Card.Img variant="top" src="holder.js/100px180?text=Image cap" />*/}
//            //            <Card.Body>
//            //                <Card.Title>Recent post based on LastModified</Card.Title>
//            //                <Card.Text>
//            //                    Summary: "Some quick example text to build on the card title and make up the bulk of
//            //                    the card's content."
//            //            </Card.Text>
//            //            </Card.Body>
//            //            <ListGroup className="list-group-flush">
//            //                <ListGroupItem href="#">Edit the post</ListGroupItem>
//            //            </ListGroup>
//            //            <Card.Body>

//            //                <Card.Link href="#">Go to the post</Card.Link>
//            //            </Card.Body>
//            //        </Card>
//            //    </div>

//            //    <div class="row mt-5">
//            //        <a href='/addpost' class="btn btn-secondary btn-lg active" role="button" aria-pressed="true">Add a new post</a>
//            //    </div>

//            //</div>
//        //);
//    }
//}

import React from 'react'
import { Badge, Card, CardBody, CardHeader, Col, Pagination, PaginationItem, PaginationLink, Row, Table } from 'reactstrap';
import axios from 'axios';
import { useState, useEffect } from 'react'  

function PostsList(props) {
    const [data, setData] = useState([]);

    useEffect(() => {
        const GetPosts = async () => {
            const result = await axios('https://localhost:44351/api/BlogPosts');
            setData(result.data);
        };

        GetPosts();
    }, []);

    const deletePosts = (id) => {
        debugger;
        axios.delete('https://localhost:44351/api/BlogPosts' + id)
            .then((result) => {
                props.history.push('/authorsdahboard')
            });
    };
    const editPosts = (id) => {
        props.history.push({
            pathname: '/edit/' + id
        });
    };
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
                                    {
                                        [data].map((item, idx) => {
                                            return <tr>
                                                <td>{item.Title}</td>
                                                <td>{item.Category}</td>
                                                <td>{item.summary}</td>

                                                <td>
                                                    <div class="btn-group">
                                                        <button className="btn btn-warning" onClick={() => { editPosts(item.Id) }}>Edit</button>
                                                        <button className="btn btn-warning" onClick={() => { deletePosts(item.Id) }}>Delete</button>
                                                    </div>
                                                </td>
                                            </tr>
                                        })}
                                </tbody>
                                <br>

                                </br>
                                <tbody>
                            <a href='/addpost' class="btn btn-primary btn-lg active" role="button" aria-pressed="true">Add a new post</a>

                                </tbody>
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
export default PostsList;