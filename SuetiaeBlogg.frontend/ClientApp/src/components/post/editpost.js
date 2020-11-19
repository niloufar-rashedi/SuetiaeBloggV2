import React, { useContext } from 'react';
import ReturnCategories from './return-categories-addpost';
import axios from 'axios';
import ReactQuill from 'react-quill';


class EditPost extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            post: [],
            newPost: {

                postId: '',
                title: '',
                body: '',
                summary: '',
                category:
                {
                    categoryname: '',
                }
                //,
                //authorId: ''
                //snackbaropen: false,
                //snackbarmsg: ''
            }
        };
    }
    snackbarClose = e => {
        this.setState({ snackbaropen: false })
    };
    changeHandler = event => {
        const { target } = event;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const { name } = target;

        this.setState({ [event.target.name]: event.target.value })
        console.log('Value from the addpost', event.target.value)
    }
    onContentChange = (content) => {
        this.setState({ body: content });
    };
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
            });
    }
    editHandler = e => {
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
                <form onSubmit={this.editHandler}>



                    <div class="row form-group">
                        <label for="Title">Title</label>
                        <input type="text" name="title" defaultValue={this.state.post.title} onChange={this.changeHandler} />
                    </div>


                    <div>
                        <p>
                            Available categories
                        </p>
                        <ReturnCategories />
                    </div>
                    <div class="row form-group">
                        <label for="Category">Category</label>
                        <input type="text" name="category" defaultValue={this.state.post.category} onChange={this.changeHandler} />
                    </div>

                    <div class="row form-group">
                        <label for="Summary">Summary</label>
                        <input type="text" name="summary" defaultValue={this.state.post.summary} onChange={this.changeHandler} />
                    </div>



                    <div class="row form-group">
                        <label for="Body">Body</label>
                        <ReactQuill
                            modules={{ toolbar: toolbarOptions }}
                            theme="snow"
                            name="body"
                            defaultValue={body}
                            onChange={this.onContentChange}
                            placeholder="Content"
                        />
                    </div>



                    <button class="btn btn-primary mt-5" type="submit">Edit</button>



                </form>
            </div>
        )
    }


}
export default EditPost;