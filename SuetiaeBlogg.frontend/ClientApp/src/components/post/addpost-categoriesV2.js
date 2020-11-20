import React from 'react';
import {ClassicEditor} from '@ckeditor/ckeditor5-build-classic';
import CKEditor from 'ckeditor4-react';
import ReturnCategories from './return-categories-addpost';
import axios from 'axios';

//https://ckeditor.com/docs/ckeditor4/latest/guide/dev_react.html

class AddPostV2 extends React.Component {
    constructor(props) {
        super(props);
    
    this.state = {
        postId: '',
        title: '',
        body: '',
        summary: '',
        category: {
            name: ''
        },
        authorId: ''
    }
    }

    apiURL = 'https://localhost:44351/api/BlogPosts/InsertNewPost';
    token = localStorage.getItem('signin');


    handleChange = (event) => {
        const target = event.target;
        const { name, value } = target;
        //By setting state we access the elements of our form
        this.setState({
            [name]: value
        });

    }
    onEditorChange = (event) => {
        this.setState({
            body: event.editor.getData()
        })
        //console.log(data);
    }

    handleSubmit = e => {
        e.preventDefault()
        this.state.authorId = localStorage.getItem('userId');
        console.log(this.state)
        axios.post(this.apiURL, this.state, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                console.log("Response from server: ", response);
                alert('Post was sent successfully!');
            })
            .catch(error => {
                console.log(error);
            })
    }

    render() {
        console.log('STATE_', this.state)
        return (
            <div className="AddPost">
                <div className="container">
                    <div className="wrapper">
                        <form className="form-group" onSubmit={this.handleSubmit}>
                            <h1>Contact Us</h1>
                            <div className="form-group">
                                <label>Title</label>
                                <input type="text" name="title" value={this.state.title} onChange={this.handleChange} placeholder="Title of your post" className="form-control" />
                            </div>
                            <div className="form-group">
                                <label>Category</label>
                                <input type="text" name="category" defaultValue={this.state.category.name} onChange={this.handleChange} placeholder="pick a category" className="form-control" />
                            </div>
                            <div className="form-group">
                                <label>Summary</label>
                                <input type="text" name="summary" value={this.state.summary} onChange={this.handleChange} placeholder="140 character..." className="form-control" />
                            </div>

                            <div className="form-group">
                                <label>Your inspiring blog post</label>
                                {/*<textarea type="text" name="content" cols="25" rows="14" value={this.state.content} onChange={this.handleChange} className="form-control" placeholder="Enter Message" />*/}
                                <CKEditor
                                    body={this.state.body}
                                    onChange={this.onEditorChange}
                                    //editor={ClassicEditor}
                                    onInit={editor => {
                                        editor.getData();
                                    }} />
                                <label>
                                    Change value:
                                    <textarea defaultValue={this.state.body} onChange={this.handleChange} />
                                </label>
                                    
                                

                            </div>

                            <button type="submit" name="submit" placeholder="Enter Message" className="btn btn-secondary">Submit</button>
                        </form>
                    </div>

                </div>


            </div>
        );
}
}
export default AddPostV2;
