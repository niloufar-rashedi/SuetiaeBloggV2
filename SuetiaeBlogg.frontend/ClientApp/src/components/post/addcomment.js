import React from 'react';
import axios from 'axios';

class AddComment extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            authorId: '',
            body: ''
        }
    }
    handleChange = (event) => {
        const target = event.target;
        const { name, value } = target;
        this.setState({
            [name]: value
        });
    }
    onSubmitHandler = (e) => {
        e.preventDefault();
       this.props.history.push(`/showpost/${this.props.postId}`)
      }

    apiURL = 'https://localhost:44351/api/BlogPosts';
    token = localStorage.getItem('signin');

    handleSubmit = e => {
        e.preventDefault()
        this.state.authorId = localStorage.getItem('userId');
        console.log('Current logged user:', this.state)
        console.log('POstId', this.props.postId)
        console.log('Current state:', this.state)
        console.log('Current token:', this.token)
        axios.put(`${this.apiURL}/${this.props.postId}/InsertNewComment`, this.state, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                console.log("Response from server: ", response);
                alert('Comment was added successfully!');

               
            })
            .catch(error => {
                console.log(error);
            })
    }


    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                        <label>Please write your comment here: 
                        <input type="text" name="body"  value={this.state.value} onChange={this.handleChange} />
                        </label>
                        <input type="submit" value="Submit" />
                </form>
            </div>   
            



  

        )

    }
}

export default AddComment;
