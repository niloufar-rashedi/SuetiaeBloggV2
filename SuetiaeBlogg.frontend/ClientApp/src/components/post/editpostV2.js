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
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeSummary = this.onChangeSummary.bind(this);
        this.onChangeBody = this.onChangeBody.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.state = {
            post: [],
            postId: '',
            title: '',
            body: '',
            summary: '',
            category: {
                name: ''
            },
            authorId: '',
            categories: []
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
                })
                .then(response => {
                console.log('AuthorId from local storage', this.authorId)
                console.log('Title from server', response.data.data.title)
                console.log('Summary from server', response.data.data.summary)
                console.log('Body from server', response.data.data.body)
                    this.setState({
                        title: response.data.data.title,
                        summary: response.data.data.summary,
                        body: response.data.data.body,
                    })
                })
                    .catch((error) =>{
                        console.log(error);
                    })
                }
    onChangeTitle(e) {
        this.setState({
          title: e.target.value
        })
      }
      onChangeSummary(e) {
        this.setState({
          summary: e.target.value
        })
      }
      onChangeBody(e) {
        this.setState({
          body: e.target.value
        })
      }
      onChangeCategory(e) {
        this.setState({
          category: e.target.value
        })
      }
    onEditorChange = (event) => {
        this.setState({
            body: event.editor.getData()
        })
    }
    onSubmit(e) {
        e.preventDefault()
        const data = {
            authorId: this.authorId,
            title: this.state.title,
            body: this.state.body,
            summary: this.state.summary
            }
            console.log('what we send', data)
            console.log('PostId for put request', this.props.match.params.id)
            console.log('Token', this.token)
        axios.put(`${this.apiURL}/${this.props.match.params.id}`, data,
            {
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
        return (
            <div className="AddPost">
                <div className="container">
                    <div className="wrapper">
                        <form onSubmit={this.onSubmit} className="form-group" >
                            <h1>Edit your post here</h1>
                            <div className="form-group">
                                <label>Title</label>
                                <input type="text" name="title" value={this.state.title} onChange={this.onChangeTitle} placeholder="Title of your post" className="form-control" />
                            </div>
                            <div className="form-group">
                                <label>Summary</label>
                                <input type="text" name="summary" value={this.state.summary} onChange={this.onChangeSummary} placeholder="140 character..." className="form-control" />
                            </div>
                            <div className="form-group">
                                <label>Your inspiring blog post</label>
                                {/*<textarea type="text" name="content" cols="25" rows="14" value={this.state.content} onChange={this.handleChange} className="form-control" placeholder="Enter Message" />*/}
                                <CKEditor
                                    name="body"
                                    data={this.state.body}
                                    onChange={this.onEditorChange}
                                    editor={ClassicEditor}
                                    onInit={editor => {
                                        editor.getData();
                                    }}
                                    />
                                <label>
                                    Change value:
                                    <textarea value={this.state.body} onChange={this.onChangeBody} />
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