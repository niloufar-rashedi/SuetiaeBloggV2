import React from 'react';
import axios from 'axios';
import Moment from 'react-moment';
import Card from 'react-bootstrap/Card'
import AddComment from './addcomment';

class ShowPost extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            post: []
        };
        
    }
    
    
    apiURL = `https://localhost:44351/api/BlogPosts`;

    async componentDidMount() {
        await axios.get(`${this.apiURL}/${this.props.match.params.id}`)
            .then(response => {
            console.log('Rasponse from postById', response)
            
                this.setState({ post: response.data.data});
        });
    }

    

    render() {
        return (

            <div className="container justify-content-md-center">
                <div className="row">
                    <label>Title </label>
                    <div>{this.state.post.title}</div>
                </div>
                <div className="row">
                    <p>Summary   {this.state.post.summary}</p>
                </div>
                <div className="row">
                    <h3>Body </h3>
                    <p dangerouslySetInnerHTML={{ __html: this.state.post.body }}></p>
                </div>
                <div className="row">
                    <p>Last modified    {this.state.post.lastModified} </p>
                </div>
                <div className="row">
                    <p>Author       {this.state.post.firstName}</p>
                </div>
                <div className="row">
                    <p>Comments</p>
                        {this.state.post.comments && this.state.post.comments.map(comment => {
                            return (
                                <div>
                            <p>{comment.pubDate} by {comment.firstName}</p>
                            <p>{comment.body}</p>
                             </div>

                            );

                        })};

                </div>
                <div className="row">
                    < AddComment />
                </div>


                
            
        </div>);
    }
}

export default ShowPost;