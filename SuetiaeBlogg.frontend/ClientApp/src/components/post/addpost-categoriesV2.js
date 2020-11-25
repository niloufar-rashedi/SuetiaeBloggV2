import React from 'react';
import {ClassicEditor} from '@ckeditor/ckeditor5-build-classic';
import CKEditor from 'ckeditor4-react';
import ReturnCategories from './return-categories-addpost';
import axios from 'axios';
import Select from 'react-select';

  

//https://ckeditor.com/docs/ckeditor4/latest/guide/dev_react.html

class AddPostV2 extends React.Component {
    constructor(props) {
        super(props);
    
    this.state = {
        postId: '',
        title: '',
        body: '',
        summary: '',
        category: '',     
        authorId: '',
        status:'',
        categories: []
    }
    }
    apiURLCategories = 'https://localhost:44351/api/BlogPosts/categories';

    async componentDidMount() {
        await axios.get(this.apiURLCategories)
            .then(response => {
                console.log(response);
                this.setState({ 
                    categories: [{name: '', id: ''}].concat(response.data.data )
                
                })
               
            });
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
        console.log('Data from editor', this.state)
        axios.post(this.apiURL, this.state, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        }).catch(function (error) {
            if (error.response) {
              console.log(error.response.data);
              console.log(error.response.status);
              console.log(error.response.headers);
            }
          })
            .then(response => {
                console.log("Response from server: ", response.status);
                if(response.status === 200)
                    alert('Post was sent successfully! Press OK to go back to dashboard');
                else
                    alert('There has been a problem submitting the post. Press OK to go back to dashboard');
                 window.location.assign('https://localhost:44301/authorsdashboarad'); 
            })
            .catch(error => {
                console.log(error);
            })
    }

    render() {
        console.log('STATE_', this.state)
        //const optionItems = this.state.categories.map(categories, index => (
        //    <option key={categories.id}>
        //        {categories.name}
        //    </option> ));
        const { categories } = this.state;

        
        return (
            <div className="AddPost">
                <div className="container">
                    <div className="wrapper">
                        <form className="form-group" onSubmit={this.handleSubmit}>
                            <h1>Write your blog here</h1>
                            <div className="form-group">
                                <label>Title</label>
                                <input type="text" required name="title" value={this.state.title} onChange={this.handleChange} placeholder="Title of your post" className="form-control" />
                            </div>

                            <div className="form-group">
                                
                                <label>Select a category, otherwise it will be post as "General"</label>
                                <div>
                                    <select value={this.state.category}
              onChange={(e) => this.setState({category: e.target.value})}>
                                       {this.state.categories.map((cat) => <option key={cat.value} value={cat.value}>{cat.name}</option>)}
                                    </select>
                                </div>
                                {/*<input type="text" value={this.state.category.name} onChange={this.handleChange} className="form-control" />*/}
                            </div>




                            <div className="form-group">
                                <label>Summary</label>
                                <input type="text" name="summary" value={this.state.summary} onChange={this.handleChange} placeholder="140 character..." className="form-control" />
                            </div>

                            <div className="form-group">
                                <label>Your inspiring blog post</label>
                                {/*<textarea type="text" name="content" cols="25" rows="14" value={this.state.content} onChange={this.handleChange} className="form-control" placeholder="Enter Message" />*/}
                                <CKEditor
                                    required body={this.state.body}
                                    onChange={this.onEditorChange}
                                    //editor={ClassicEditor}
                                    onInit={editor => {
                                        editor.getData();
                                    }} />
                                <label>
                                    Change value:
                                    <textarea required defaultValue={this.state.body} onChange={this.handleChange} />
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
