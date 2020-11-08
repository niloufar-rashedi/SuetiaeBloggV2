import React from 'react';
import axios from 'axios';

import Moment from 'react-moment';


import Card from 'react-bootstrap/Card'
import { faComments } from '@fortawesome/free-solid-svg-icons';

export class Posts extends React.Component {
    state = {
        posts: [],
    }
    apiURL = 'https://localhost:44351/api/BlogPosts';

    

    async componentDidMount() {
        await axios.get(this.apiURL)
            .then(response => {
            console.log(response);
            this.setState({ posts: response.data.data});
        });
    }
    render() {
        return (
            <div>
                {this.state.posts.map(post => (
                    <div className="card" key={post.id}>

                        <Card style={{ width: '50rem' }}>
                            
                            <Card.Header>Last modified: <Moment format="YYYY/MM/DD">{post.lastModified}</Moment></Card.Header>
                            


                            <Card.Body>
                                <Card.Title>{post.title}</Card.Title>
                                <Card.Subtitle className="mb-2 text-muted">{post.summary}</Card.Subtitle>
                                <Card.Text>{post.body}
                                </Card.Text>
                                <Card.Link href="#">
                                    <div class="button read-more absolute-bottom">Read more</div>
                                    
                                    
                                    </Card.Link>
                               
                            </Card.Body>
                        </Card>




                    </div>
                ))}
            </div>
        );
    }
}