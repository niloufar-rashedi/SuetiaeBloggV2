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
    
    postId = this.props.match.params.postId;
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
            
            <div>
            <p>Title     {this.state.post.title}</p>
                <p>Summary   {this.state.post.summary}</p>
                <h3>Body </h3>
                <p dangerouslySetInnerHTML={{ __html: this.state.post.body }}></p>
            <p>Last modified    {this.state.post.lastModified} </p>
            <p>Author       {this.state.post.firstName}</p>
            <p>Comments</p>
                {this.state.post.comments && this.state.post.comments.map(comment => {
                    return (
                        <div>
                    <p>{comment.pubDate} by {comment.firstName}</p>
                    <p>{comment.body}</p>
                     </div>

                    );

                })};
                < AddComment />
            
        </div>);
    }
}

export default ShowPost;