import React from 'react';
import axios from 'axios';
import Moment from 'react-moment';
//import AddComment from './addcomment';

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

            <div className="container justify-content-md-center">
                <div className="row d-flex justify-content-center">
                    <div><h1>{this.state.post.title}</h1></div>
                </div>
                <div style={{ display: "flex" }}>
                    <p>Published: <Moment format="MM/DD/YYYY"></Moment> by {this.state.post.firstName}</p>
                </div>

                <div className="row">
                    <p dangerouslySetInnerHTML={{ __html: this.state.post.body }}></p>
                </div>
                <div className="row">
                    <p>Last modified    {this.state.post.lastModified} </p>
                </div>

                <div class="form-group">
                    <div class="ui comments"><h3 class="ui dividing header">Comments</h3><div class="comment">
                        {this.state.post.comments && this.state.post.comments.map(comment => {
                            return (
                                <div class="content"><a class="author">{comment.firstName}</a><div class="metadata"><div>{comment.pubDate}</div></div>
                                <div class="text">{comment.body}</div>
                                <div class="actions"><a class="">Reply</a></div>
                                </div>       
                         );
                         })}
                            
                    </div>
                </div>
                </div>
             </div>
                )
    }
}

export default ShowPost;