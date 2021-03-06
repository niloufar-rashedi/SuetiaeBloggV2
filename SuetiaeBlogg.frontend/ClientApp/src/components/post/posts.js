﻿import React from 'react';
import axios from 'axios';
import {Link} from 'react-router-dom';
import { Button } from 'react-bootstrap';
import styled from 'styled-components';
import Moment from 'react-moment';
import Card from 'react-bootstrap/Card'
import posts from './posts';
import showpost from './posts';
import history from './../../history';
import { faComments } from '@fortawesome/free-solid-svg-icons';

//const Block = styled.div`
//        cursor: pointer;
//        background: transparent;
//        font-size:16px;
//        border-radius: 3px;
//        border: 2px solid darkgray;
//        margin: 0 1em;
//        padding: 0.25em 1em;
//        margin-bottom: 3vh;
//        margin-top: 1vh;
//        transition: 0.5s all ease-out;
//     &: hover {
//        background-color: darkgray;
//        color: white;
//        }
//    `;
export class Posts extends React.Component {
    state = {
        posts: [],
        }
    apiURL = 'https://localhost:44351/api/BlogPosts';

    

    async componentDidMount() {
        await axios.get(this.apiURL)
            .then(response => {
            console.log('Response from main Api:', response);
                this.setState({ posts: response.data.data});
        });
    }

    
    
    render() {
        return (
            <div>
               
               {this.state.posts && this.state.posts
               .sort((a,b) => {
                return new Date(a.lastModified).getTime() - 
                    new Date(b.lastModified).getTime()
                })
                .reverse()
               .map(post => (
                //<Block>
                    <div className="card" key={post.lastModified}>
                        <Card style={{ width: '50rem' }}>
                <Card.Header>Last modified: <Moment format="YYYY/MM/DD">{post.lastModified}</Moment> by {post.firstName}</Card.Header>
                             <Card.Body>
                                <Card.Title>{post.title}</Card.Title>
                                <Card.Subtitle className="mb-2 text-muted">{post.summary}</Card.Subtitle>
                                    <Card.Text>Comments:  {post.comments.length}</Card.Text>
                                <Card.Link href="#">
                                <Link to={{pathname: `/showpost/${post.postId}`, query: { id: post.postId }}}><Button variant="btn btn-success" >Read more</Button></Link>
                                </Card.Link>
                            </Card.Body>
                        </Card>
                    </div>
                    //</Block>
                ))
                }             
               
            </div>
        );
    }
}

export default posts;