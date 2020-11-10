import React, { Fragment, Button } from 'react';
//import { EditorState, convertToRaw, convertFromRaw } from 'draft-js';
//import { Editor } from 'react-draft-wysiwyg';
import ReactQuill from 'react-quill';
import axios from 'axios';
import ReturnCategories from '../post/return-categories'


export default class AddPost extends React.Component {

    constructor(props) {
        super(props);
        //ID?
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeCategory = this.onChangeCategory.bind(this);
        this.onChangeSummary = this.onChangeSummary.bind(this);
        this.state = { body: '' }
        this.onChangeBody = this.onChangeBody.bind(this);
        this.saveData = this.saveData.bind(this);
        this.newData = this.newData.bind(this);

        this.state = {
            id: null,
            title: "",
            category: "",
            summary: "",
            body: "",

            //published: false,

            //submitted: false
        };
    }


    //state = {
    //    posts: [],
    //};
    
    onChangeTitle(e) {
        this.setState({
            title: e.target.value
        });
    }
    onChangeCategory(e) {
        this.setState({
            category: e.target.value
        });
    }

    onChangeSummary(e) {
        this.setState({
            summary: e.target.value
        });
    }
    onChangeBody(value) {
        this.setState({
            body: value
        });
    }

    saveData() {
        var data = {
            id: this.state.id,
            title: this.state.title,
            category: this.state.category,
            summary: this.state.summary,
            body: this.state.body
        };
    const apiURL = 'https://localhost:44351/api/BlogPosts/InserNewPost';

        axios.post(apiURL, data)
            .then(response => {
                this.setState({
                    id: response.data.id,
                    title: response.data.title,
                    body: response.data.body,
                    summary: response.data.summary,

                    //published: response.data.published,

                    //submitted: true
                });
                console.log(response.data);
            })
            .catch(e => {
                console.log(e);
            });
    }
    newData() {
        this.setState({
            id: null,
            title: "",
            category: "",
            summary: "",
            body: "",
            ////body: JSON.stringify(convertToRaw(editorState.editorState.getCurrentContent())),
            //published: false,
            //submitted: false

        })
    }

    handleChange = (value) => {
        this.setState({ body: value })
    }

    render() {
        return (
            <div className="submit-form">
                {this.state.submitted ? (
                    <div>
                        <h4>You submitted successfully!</h4>
                        <button className="btn btn-success" onClick={this.newTutorial}>
                            Add
            </button>
                    </div>
                ) : (
                        <div>
                            <div className="form-group">
                                <label htmlFor="title">Title</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="title"
                                    required
                                    value={this.state.title}
                                    onChange={this.onChangeTitle}
                                    name="title"
                                />
                            </div>

                            <div className="form-group">
                                <label htmlFor="title">Category</label>
                                <ReturnCategories />
                                { /*<input
                                    type="text"
                                    className="form-control"
                                    id="category"
                                    required
                                    value={this.state.category}
                                    onChange={this.onChangeCategory}
                                    name="category"
                                />*/}

                            </div>
                            
                            <div className="form-group">
                                <label htmlFor="description">Summary</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="summary"
                                    required
                                    value={this.state.summary}
                                    onChange={this.onChangeSummary}
                                    name="description"
                                />
                            </div>
                            <div>
                                <label htmlFor="body">Bod</label>
                                <ReactQuill
                                    id="body"
                                    required
                                    value={this.state.body}
                                    onChange={this.onChangeBody}
                                    name="body" />

                                
                                { /* <input
                                    type="text"
                                    className="form-control"
                                    id="body"
                                    required
                                    value={this.state.body}
                                    onChange={this.onChangeBody}
                                    name="body"
                                />*/}


                            </div>
                            <br></br>
                            <button onClick={this.saveData} className="btn btn-success">
                                Submit
                            </button>
                        </div>
                    )}
            </div>
        );
    }
}

{/*<PreviewModal output={getHtml(editorState)} />*/ }