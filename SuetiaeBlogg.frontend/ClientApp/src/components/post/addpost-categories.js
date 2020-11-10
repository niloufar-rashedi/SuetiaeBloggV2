import React, { Fragment, Button, useState } from 'react';
import axios from 'axios';


class AddPost extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            postId: '',
            title: '',
            body: '',
            summary:''
        }
    }


    changeHandler = e => {
        this.setState({[e.target.name]: e.target.value})
    }

    apiURL = 'https://localhost:44351/api/BlogPosts/InsertNewPost';
         token = localStorage.getItem('signin');
//console.log('Token retrieved', token);

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        axios.post(this.apiURL, this.state, {
            headers: {
                'Authorization': `Bearer `+ this.token,
                'Content-Type': 'application/json'
            }

        })
            .then(response => {
                console.log("Response from server: ", response)
            })
            .catch(error => {
                console.log(error);
                //console.log(this.state.error)
            })
    }



    render() {
        const { postId, title, body, summary } = this.state
        return (
            <div>
                <form onSubmit={this.submitHandler}>
                    <div>
                        <input type="text" name="postId" value={postId} onChange={ this.changeHandler} />
                    </div>
                    <div>
                        <input type="text" name="title" value={title} onChange={this.changeHandler} />
                    </div>
                    <div>
                        <input type="text" name="body" value={body} onChange={this.changeHandler} />
                    </div>
                    <div>
                        <input type="text" name="summary" value={summary} onChange={this.changeHandler} />
                    </div>
                    <button type="submit">Submit</button>



                </form>
            </div>
            )
    }
}
export default AddPost;
{/*<PreviewModal output={getHtml(editorState)} />*/ }