import React, { Fragment, Button } from 'react';
import BlogDataService from "../services/blog.service";
//import { EditorState, convertToRaw, convertFromRaw } from 'draft-js';
//import { Editor } from 'react-draft-wysiwyg';
import ReactQuill from 'react-quill';


export default class AddPost extends React.Component {

    constructor(props) {
        super(props);
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.state = { body: '' }
        this.onChangeBody = this.onChangeBody.bind(this);
        this.onChangeSummary = this.onChangeSummary.bind(this);
        this.saveData = this.saveData.bind(this);
        this.newData = this.newData.bind(this);

        this.state = {
            id: null,
            title: "",
            body: "",
            summary: "",

            published: false,

            submitted: false
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
    onChangeBody(value) {
        this.setState({
            body: value
        });
    }
    onChangeSummary(e) {
        this.setState({
            summary: e.target.value
        });
    }
    saveData() {
        var data = {
            id: this.state.id,
            title: this.state.title,
            summary: this.state.summary,
            body: this.state.body
        };

        BlogDataService.create(data)
            .then(response => {
                this.setState({
                    id: response.data.id,
                    title: response.data.title,
                    body: response.data.body,
                    summary: response.data.summary,

                    published: response.data.published,

                    submitted: true
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
            body: "",
            //body: JSON.stringify(convertToRaw(editorState.editorState.getCurrentContent())),
            summary: "",
            published: false,
            submitted: false

        })
    }

    handleChange = (value) => {
        this.setState({ body: value })
    }

    //handleSubmit = event => {
    //    event.preventDefault();

    //    const post = {
    //        title: this.state.title,
    //        summary: this.state.summary,
    //        body: this.state.body
    //        //category: {
    //        //name: this.state.category.name

    //        // }
    //    };

    //    axios.post('/api/BlogPosts', this.state)
    //        .then(res => {
    //            console.log(res);
    //            console.log(res.data);
    //        })

    //}

            //    <div>
            //        <form onSubmit={this.handleSubmit}>
            //            <label>
            //                Title:
            //    <input type="text" name="title" onChange={this.handleChange} />
            //            </label>
            //            <label>
            //                Summary:
            //    <input type="text" name="summary" onChange={this.handleChange} />
            //            </label>
            //            <label>
            //                Body:
            //    <input type="text" name="body" onChange={this.handleChange} />
            //            </label>

            //            <button type="submit">Add</button>
            //        </form>
            //    </div>
            //)
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
                                <label htmlFor="description">Description</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="description"
                                    required
                                    value={this.state.summary}
                                    onChange={this.onChangeSummary}
                                    name="description"
                                />
                            </div>
                            <div>
                                <ReactQuill
                                    id="body"
                                    required
                                    value={this.state.body}
                                    onChange={this.onChangeBody}
                                name="body"/>

                            </div>
                            <button onClick={this.saveData} className="btn btn-success">
                                Submit
                            </button>
                        </div>
                    )}
            </div>
        );
    }
}

                {/*<PreviewModal output={getHtml(editorState)} />*/}