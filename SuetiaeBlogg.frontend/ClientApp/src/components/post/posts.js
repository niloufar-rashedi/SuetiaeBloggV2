import React from 'react';
import axios from 'axios';

import Card from 'react-bootstrap/Card'

export default class Posts extends React.Component {
    state = {
        posts: [],
    };

    componentDidMount() {
        axios.get('https://localhost:5001/api/Posts').then(response => {
            console.log(response);
            this.setState({ posts: response.data });
        });
    }

    render() {
        return (
            <div>
                {this.state.posts.map(post => (
                    <div className="card" key={post.id}>

                        <Card style={{ width: '50rem' }}>
                            <Card.Body>
                                <Card.Title>{post.title}</Card.Title>
                                <Card.Subtitle className="mb-2 text-muted">{post.summary}</Card.Subtitle>
                                <Card.Text>{post.body}
                                </Card.Text>
                                <Card.Link href="#">Card Link</Card.Link>
                                <Card.Link href="#">Another Link</Card.Link>
                            </Card.Body>
                        </Card>




                    </div>
                ))}
            </div>
        );
    }







}