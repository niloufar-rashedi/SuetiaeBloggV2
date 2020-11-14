import React from 'react';
import axios from 'axios';
import Moment from 'react-moment';
import Card from 'react-bootstrap/Card'

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
        return (<div>
            <p>Title {this.state.post.title}</p>
            <p>Summary {this.state.post.summary}</p>
            <p>Body </p>
            <p>Author {this.state.post.firstname}</p>
            <p>Comments </p>
            
        </div>);
    }
}

export default ShowPost;