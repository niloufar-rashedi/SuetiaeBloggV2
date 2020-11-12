import React, { useContext } from 'react';
import  ReturnCategories   from '../../components/post/return-categories';
import axios from 'axios';
import { UserContext } from '../UserContext'
import ReactQuill from 'react-quill'; 

class AddPost extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            postId: '',
            title: '',
            body: '',
            summary: '',
            category: '',
            author: ''
        }
        //this.changeHandler = this.changeHandler.bind(this)
    }
    //use = useContext(UserContext)

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
        //this.setState({ body: e.target.value })
    }
    onContentChange = (content) => {
        this.setState({ body: content });
    };

    apiURL = 'https://localhost:44351/api/BlogPosts/InsertNewPost';
         token = localStorage.getItem('signin');
         //userId = localStorage.getItem('userId');
        

    submitHandler = e => {
        e.preventDefault()
        this.state.author = localStorage.getItem('userId');
        
        //var form = document.querySelector('form');
        //var body = document.querySelector('input[name=body]');
        //body.value = JSON.stringify(quill.getContents());
        //console.log("Submitted", $(form).serialize(), $(form).serializeArray());


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


    //form = document.querySelector('form');
    //form. = function () {
        // Populate hidden form on submit
        //var about = document.querySelector('input[name=about]');
        //about.value = JSON.stringify(quill.getContents());
        //console.log("Submitted", $(form).serialize(), $(form).serializeArray());

        // No back end to actually submit to!
    //    alert('Open the console to see the submit data!')
    //    return false;
    //};




    render() {
        const { postId, title, body, summary, category } = this.state
        const toolbarOptions = [
            ['bold', 'italic', 'underline'],       
            [{ 'list': 'ordered' }, { 'list': 'bullet' }, { 'indent': '-1' }, { 'indent': '+1' }],
            ['link', 'image', 'video'],
            ['clean']
        ];
        return (
            <div>
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
                        <h3>
                            Category tests
                        </h3>
                        <ReturnCategories/>
                    </div>
                    <div class="row form-group">
                        <label for="Category">Category</label>
                        <input type="text" name="category" value={category} onChange={this.changeHandler} />
                    </div>


                    <div class="row form-group">
                        <label for="Body">Body</label>
                        { /*<input type="text" name="body" value={body} onChange={this.changeHandler} />*/}
                        <ReactQuill
                            modules={{ toolbar: toolbarOptions }}
                            name="body"
                            value={body}
                            onChange={this.onContentChange}
                            placeholder="Content"
                        />
                    </div>



                    <div class="row form-group">
                        <label for="Summary">Summary</label>
                        <input type="text" name="summary" value={summary} onChange={this.changeHandler} />
                    </div>

                    <button class="btn btn-primary" type="submit">Submit</button>
                    


                </form>
            </div>
            )
    }
}
export default AddPost;

