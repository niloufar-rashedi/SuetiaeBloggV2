import React, { useContext } from 'react';
import ReturnCategories from './return-categories-addpost';
import axios from 'axios';
import ReactQuill from 'react-quill';


class EditPost extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            //postId: '',
            //title: '',
            //body: '',
            //summary: '',
            //category:
            //{
            //    categoryname: '',
            //}
            //,
            //authorId: '',
            //snackbaropen: false,
            //snackbarmsg: ''
            post: []
        };
    }
    snackbarClose = e => {
        this.setState({ snackbaropen: false })
    };
    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
        console.log('Value from the addpost', e.target.value)
        //this.setState({ body: e.target.value })
    }
    onContentChange = (content) => {
        this.setState({ body: content });
    };

    //ADD relevant methods to get posts by ID, similar to showpost. Now I am returning all the posts
    apiURL = `https://localhost:44351/api/BlogPosts/authors`;
    token = localStorage.getItem('signin');
    authorId = localStorage.getItem('userId');

    async componentDidMount() {
        await axios.get(`${this.apiURL}/${this.props.match.params.id}/posts`, {
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
                <form>
                   // onSubmit={this.editHandler}
                

                    <div class="row form-group">
                        <label for="Title">Title</label>
                        <input type="text" name="title" value={this.state.post.title} onChange={this.changeHandler}/>
                    </div>


                    <div>
                        <p>
                            Available categories
                        </p>
                        <ReturnCategories />
                    </div>
                    <div class="row form-group">
                        <label for="Category">Category</label>
                        <input type="text" name="category" value={this.state.post.category} onChange={this.changeHandler} />
                    </div>

                    <div class="row form-group">
                        <label for="Summary">Summary</label>
                        <input type="text" name="summary" value={this.state.post.summary} onChange={this.changeHandler} />
                    </div>



                    <div class="row form-group">
                        <label for="Body">Body</label>
                        { /*<input type="text" name="body" value={body} onChange={this.changeHandler} />*/}
                        <ReactQuill
                            modules={{ toolbar: toolbarOptions }}
                            theme="snow"
                            name="body"
                            value={this.state.post.body}
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