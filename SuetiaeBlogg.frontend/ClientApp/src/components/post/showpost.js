import React from 'react';
import axios from 'axios';
import Moment from 'react-moment';
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
            console.log('Response from postById', response)
                    this.setState({ post: response.data.data});
        });
    }

    

    render() {
        return (
            <div className="container justify-content-md-center">
            <div className="row d-flex justify-content-center">
                <div><h1>{this.state.post.title}</h1></div>
            </div>
            <div style={{ display: "flex" }}>
                    <p>Published: <Moment format="MM/DD/YYYY">{this.state.post.pubDate}</Moment> by {this.state.post.firstName}</p>
            </div>
            <div className="row">
                <p dangerouslySetInnerHTML={{ __html: this.state.post.body }}></p>
            </div>
            <div className="row">
                    <p>Last modified: <Moment format="MM/DD/YYYY">{this.state.post.lastModified}</Moment></p>
            </div>
            <div class="form-group">
                <div class="ui comments"><h3 class="ui dividing header">Comments</h3><div class="comment">
                    {this.state.post.comments && this.state.post.comments.map(comment => {
                        return (
                            <div class="content"><a class="author">{comment.firstName}</a><div class="metadata"><div><Moment format="MM/DD/YYYY">{comment.pubDate}</Moment></div></div>
                            <div class="text">{comment.body}</div>
                            </div>
                     );
                     })}
                </div>
            </div>
            </div>
                <div className="row">
                    < AddComment postId = {this.state.post.postId}/>
                </div>


                
            
        </div>);
    }
}

export default ShowPost;