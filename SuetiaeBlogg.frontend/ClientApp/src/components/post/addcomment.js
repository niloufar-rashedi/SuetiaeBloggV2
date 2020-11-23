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

    apiURL = 'https://localhost:44351/api/BlogPosts/';
    handleSubmit = e => {
        e.preventDefault()
        this.state.authorId = localStorage.getItem('userId');
        console.log(this.state)
        axios.post(`${this.apiURL}/${this.props.match.params.id}/InsertNewComment`, this.state, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                console.log("Response from server: ", response);
                alert('Comment was added successfully!');

                window.location.assign('https://localhost:44301/showpost/' + this.props.match.params.id);
            })
            .catch(error => {
                console.log(error);
            })
    }


    render() {
        return (
            <div>
                <div className="form-group">
                <div>
                    <label>Please write your comment here: </label>
                        <input type="text" name="body" onChange={this.handleChange} value={this.state.body} />
                </div>
                <button type="submit" name="submit" placeholder="Enter Message" className="btn btn-secondary">Submit</button>
                </div>
            </div>
        )

    }
}

export default AddComment;
