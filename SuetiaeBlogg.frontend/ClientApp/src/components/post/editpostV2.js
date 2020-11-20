import React from 'react';
import { ClassicEditor } from '@ckeditor/ckeditor5-build-classic';
import CKEditor from 'ckeditor4-react';
import ReturnCategories from './return-categories-addpost';
import axios from 'axios';
//https://ckeditor.com/docs/ckeditor5/latest/builds/guides/integration/saving-data.html
//https://ckeditor.com/docs/ckeditor5/latest/builds/guides/integration/frameworks/react.html
//To add image in editor: https://www.youtube.com/watch?v=qjrKVJjTLDc&list=PLC9HTNsJgxkQbbkbF_CX43Qk6tiDRfWL8&index=4

//https://github.com/ckeditor/ckeditor5-react/issues/20#issuecomment-409227841
//https://ckeditor.com/docs/ckeditor4/latest/guide/dev_react.html

class EditPostV2 extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            post: [],
            postId: '',
            title: '',
            body: '',
            summary: '',
            category: '',
            authorId: ''
        }
    }
    apiURL = `https://localhost:44351/api/BlogPosts`;
    token = localStorage.getItem('signin');
    authorId = localStorage.getItem('userId');

    async componentDidMount() {
        await axios.get(`${this.apiURL}/${this.props.match.params.id}`, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        }
        )
            .then(response => {
                console.log('Rasponse from editById', response)

                this.setState({ post: response.data.data });
                console.log('Rasponse from server', response)

            });
    }


    handleChange = (event) => {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const { name} = target;
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

    handleEdit = e => {
        e.preventDefault()
        console.log(this.state)
        axios.put(`${this.apiURL}/${this.props.match.params.id}`, this.state, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                console.log("Response from server: ", response);
                alert('Post was edited successfully!');
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
                        <form onSubmit={this.handleEdit} className="form-group" >
                            <h1>Contact Us</h1>
                            <div className="form-group">
                                <label>Title</label>
                                <input type="text" name="title" defaultValue={this.state.post.title} onChange={this.handleChange} placeholder="Title of your post" className="form-control" />
                            </div>
                            <div className="form-group">
                                <label>Category</label>
                                <input type="text" name="category" defaultValue={this.state.post.category} onChange={this.handleChange} placeholder="pick a category" className="form-control" />
                            </div>
                            <div className="form-group">
                                <label>Summary</label>
                                <input type="text" name="summary" defaultValue={this.state.post.summary} onChange={this.handleChange} placeholder="140 character..." className="form-control" />
                            </div>

                            <div className="form-group">
                                <label>Your inspiring blog post</label>
                                {/*<textarea type="text" name="content" cols="25" rows="14" value={this.state.content} onChange={this.handleChange} className="form-control" placeholder="Enter Message" />*/}
                                <CKEditor
                                    name="body"
                                    data={this.state.post.body}
                                    onChange={this.onEditorChange}
                                    editor={ClassicEditor}
                                    onInit={editor => {
                                        editor.getData();
                                    }}
                                
                                    />
                                <label>
                                    Change value:
                                    <textarea defaultValue={this.state.post.body} onChange={this.handleChange} />
                                    CKEDITOR.
                                </label>

                            </div>

                            <button type="submit" className="btn btn-secondary">Submit</button>
                        </form>
                        <script>
                            ClassicEditor
                        
                            .create( document.querySelector( '#editor' ) );
                        </script>
                    </div>

                </div>


            </div>
        );
    }
}

export default EditPostV2;