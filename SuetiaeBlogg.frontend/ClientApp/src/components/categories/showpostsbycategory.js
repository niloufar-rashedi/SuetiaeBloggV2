import React from 'react';
import axios from 'axios';
import Moment from 'react-moment';
import Card from 'react-bootstrap/Card'
import {Link} from 'react-router-dom';
import { Button } from 'react-bootstrap';


class ShowPostsByCategory extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            posts: []
        };
        
    }
    
    
    apiURL = `https://localhost:44351/api/BlogPosts/categories`;
 
    async componentDidMount() {
        await axios.get(`${this.apiURL}/${this.props.location.myCustomProps.categoryId}/posts`)
            .then(response => {
            console.log('Response from postByCategoryId', response)
            console.log('Props content', this.props.match.params.categoryId)
                this.setState({ posts: response.data.data});

        });
    }

    

    render() {
        return (
            <div>
                <h2>All post in category:    {this.props.location.myCustomProps.name} </h2>
                <h2>with Id:    {this.props.location.myCustomProps.categoryId} </h2>
                {this.state.posts && this.state.posts.sort((a,b) => {
                return new Date(a.lastModified).getTime() - 
                    new Date(b.lastModified).getTime()
                })
                .reverse()
                .map((post) => (
                    <div className="card" key={post.id}>

                        <Card style={{ width: '50rem' }}>
                            
                <Card.Header>Last modified: <Moment format="YYYY/MM/DD">{post.lastModified}</Moment> by {post.firstName}</Card.Header>
                             <Card.Body>
                                <Card.Title>{post.title}</Card.Title>
                                <Card.Subtitle className="mb-2 text-muted">{post.summary}</Card.Subtitle>
                                <Card.Text>Comments: {post.comments.length}</Card.Text>
                                <Card.Link href="#">
                                <Link to={{pathname: `/showpost/${post.postId}`, query: { id: post.postId }}}><Button variant="btn btn-success" >Read more</Button></Link>
                                </Card.Link>
                            </Card.Body>
                        </Card>
                    </div>
                    //</Block>
                ))}             
               
            </div>
            
        );
    }
}

export default ShowPostsByCategory;