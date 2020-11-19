import React from 'react';
import  ReturnCategories   from './return-categories-addpost';
import axios from 'axios';
import ReactQuill from 'react-quill';



class AddPost extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            postId: '',
            title: '',
            body: '',
            summary: '',
            category:
            {
                categoryname: '',
            }
            ,
            authorId: '',
            snackbaropen: false,
            snackbarmsg:''
        }
    }

    snackbarClose = e => {
        this.setState({ snackbaropen:false })
    };
    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
        console.log('Value from the addpost', e.target.value)
    }
    onContentChange = (content) => {
        this.setState({ body: content });
    };

    apiURL = 'https://localhost:44351/api/BlogPosts/InsertNewPost';
         token = localStorage.getItem('signin');
        
    submitHandler = e => {
        e.preventDefault()
        this.state.authorId = localStorage.getItem('userId');
        console.log(this.state)
        axios.post(this.apiURL, this.state, {
            headers: {
                'Authorization': `Bearer `+ this.token,
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
        const { title, body, summary, category, authorId } = this.state
        const toolbarOptions = [
            [{ 'header': [1, 2, false] }],
            ['bold', 'italic', 'underline', 'strike', 'blockquote'],       
            [{ 'list': 'ordered' }, { 'list': 'bullet' }, { 'indent': '-1' }, { 'indent': '+1' }],
            ['link', 'image', 'video'],
            ['clean']
        ];
        return (
            <div>
                { /* <Snackbar
                    anchorOrigin={{ vertical: 'center', horizontal: 'center' }}
                    open={this.state.snackbaropen}
                    autoHideDuration={3000}
                    //onClose={this.state.snackbarClose}
                    message={<span id="message-id">{this.state.snackbarmsg}</span>}
                    action={[<IconButton
                        key="close"
                        aria-label="close"
                        color="inherit"
                        onClick={this.state.snackbarClose}
                    >

                    </IconButton>]}
                />*/}
                <form onSubmit={this.submitHandler}>
                    { /*<div>
                        <label for="Title">Title</label>
                        <input type="text" name="postId" value={postId} onChange={ this.changeHandler} />
                    </div>*/}
                    <div class="row form-group">
                        <label for="Title">Title</label>
                        <input type="text" name="title" value={title} onChange={this.changeHandler} />
                    </div>
                    <div>
                        <p>
                            Available categories
                        </p>
                        <ReturnCategories/>
                    </div>
                    <div class="row form-group">
                        <label for="Category">Category</label>
                        <input type="text" name="category" value={category} onChange={this.changeHandler} />
                        
                        </div>

                    <div class="row form-group">
                        <label for="Summary">Summary</label>
                        <input type="text" name="summary" value={summary} onChange={this.changeHandler} />
                    </div>

                    <div class="row form-group">
                        <label for="Body">Body</label>
                        { /*<input type="text" name="body" value={body} onChange={this.changeHandler} />*/}
                        <ReactQuill
                            modules={{ toolbar: toolbarOptions }}
                            theme="snow"
                            name="body"
                            value={body}
                            onChange={this.onContentChange}
                            placeholder="Content"
                        />
                    </div>
                    <button class="btn btn-primary mt-5" type="submit">Submit</button>
                </form>
            </div>
            )
    }
}
export default AddPost;

