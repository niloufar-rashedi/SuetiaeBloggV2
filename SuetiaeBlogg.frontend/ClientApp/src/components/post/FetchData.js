import React, { Component } from 'react';
import { EditorState, convertToRaw, convertFromRaw } from 'draft-js';
import { Editor } from 'react-draft-wysiwyg';
//import { PreviewModal } from './previewModal';
import { Row, Form, Col, Button } from 'react-bootstrap';  
import axios from 'axios';
import draftToHtml from 'draftjs-to-html';
import debounce from 'lodash/debounce';
import authService from '../api-authorization/AuthorizeService'

//const getHtml = editorState => draftToHtml(convertToRaw(editorState.getCurrentContent()));

export class FetchData extends Component {
    //static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = {
            firstInput: "Title",
            secondInput: "Summary",
            thirdInput: "Body"
            //postData: [
            //    title = '',
            //    summary = '',
            //    body = '',
            //    //lastModified = '',
            //]
        };
        this.initialState = {
        }
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this); 
        //if(props.)
        //forecasts: [], loading: true
        //A trial to see if local storage works> Data persistence
        //////const content = window.localStorage.getItem('content');
        //////if(content) {
        //////    this.state.editorState = EditorState.createWithContent(convertFromRaw(JSON.parse(content)));
        //////} else {
        //////    this.state.editorState = EditorState.createEmpty();
        //////}
    };

    //TODO:
    //Draft.js 
    //To save the content to a localStorage; 
    //Debounce saves the changes inside editor every 1000 ms
    //saveContent = debounce(
    //    (content) => {
    //        //window.localStorage.setItem('content', JSON.stringify(convertToRaw(content)));
    //        fetch('...',
    //        {
    //            method: 'Post',
    //                body: JSON.stringify({
    //                    content: convertToRaw(content),
    //                }),
    //                    headers: new Headers({
    //                        'content-Type': 'application/json'
    //                    })
    //            })

    //    }, 1000);

    onEditorStateChange = (editorState) => {
        const contentState = editorState.getCurrentContent();
        //console.log('content state', convertToRaw(contentState));
       //this.saveContent(contentState);
        this.setState({ editorState });
    };

    handleChange(event) {
        //const name = event.target.name;
        //const value = event.target.value;
        //this.setState({
        //    [name]: value
        //}) 
        //this.setState({
        //    postData: event.target.value
        //})
        console.log(event.target.value);
    }

    async handleSubmit(event) {
       // apiURL = '...';

        event.preventDefault();
        //this.props.onFormSubmit(this.state);
        //TODO:
        //separate post from its content; then divide this part, so the second part becomes (this.inistailState)
        //this.setState(this.state);
        //const post = {
        //    postData: this.state.postData
        //};

        let result = await axios.post(
            //this.apiURL
            'https://localhost:5001/api/BlogPosts/InsertNewPost'
            , {
            title: this.title,
            summary: this.summary,
            body: this.body,
        })
        //.then(result => {
        console.log(result.data);
        window.location = "/retrieve"
                //result.json()
            
               // console.log(result.data);       
}


    //async componentDidMount() {
    //    // this.populateWeatherData();
    //    await axios.post(this.apiURL, post)
    //        .then(result => {
    //            alert(result.post);
    //            this.setState({ response: result });
    //            //fetch('....')
    //            //    .then(val =>
    //            //        this.setState({ val })
    //            //            //val.json())
    //            //            //.then(rawContent => {
    //            //            //    if (rawContent) {
    //            //            //        this.setState({ editorState: EditorState.createWithContent(convertFromRaw(rawContent)) })
    //            //            //    } else {
    //            //            //        this.setState({ editorState: EditorState.createEmpty() });
    //            //            //    }
    //            //            //})
    //            //            );
    //        });

    //static renderForecastsTable(forecasts) {
    render() {
        //const { editorState } = this.state;
        //if (!this.state.editorState) {
        //    return (
        //        <h3 className="loading">Loading...</h3>
        //    );
        //}
        return (
            <div>
                <Row>
                    <Col sm={7}>
                        <Form onSubmit={this.handleSubmit}>
                            <Form.Group controlId={this.title}>
                                <Form.Label>Enter the post title</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="firstInput"
                                    value={this.state.title}
                                    onChange={this.handleChange}
                                    placeholder="a nice title for a nice post..." />
                            </Form.Group>
                            <Form.Group controlId={this.summary}>
                                <Form.Label>Summary</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="secondInput"
                                    value={this.state.summary}
                                    onChange={this.handleChange}
                                    placeholder="enter a 140 char summary" />
                            </Form.Group>

                            <Editor
                                editorState={this.state.editorState}
                                wrapperClassName="rich-editor demo-wrapper"
                                editorClassName="demo-editor"
                                onEditorStateChange={this.onEditorStateChange}
                                controlId={this.body}
                                name="thirdInput"
                                value={this.state.body}
                                onChange={this.handleChange}
                                placeholder="Write your reflections, feelings, etc..." />
                            <h4>Underlying HTML</h4>
                            <div className="html-view">
                            </div>

                            <Form.Group onSubmit={this.handleSubmit}>
                                <Form.Control type="hidden" name="UserId" value={this.state.UserId} />
                                <Button variant="success" type="submit" >Post</Button>

                            </Form.Group>
                        </Form>
                    </Col>
                </Row>
                {/*<button className="btn btn-success" data-toggle="modal" data-target="#previewModal">
                    Preview message
                </button>
                <PreviewModal output={getHtml(editorState)} />*/}
            </div>
        );
    }
}

  //async populateWeatherData() {
  //  const token = await authService.getAccessToken();
  //  const response = await fetch('weatherforecast', {
  //    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  //  });
  //  const data = await response.json();
  //  this.setState({ forecasts: data, loading: false });
  //}
//}
