import React, { Component } from 'react';
import { EditorState, convertToRaw } from 'draft-js';
import { Editor } from 'react-draft-wysiwyg';
import { PreviewModal } from './previewModal';
import draftToHtml from 'draftjs-to-html';
import authService from './api-authorization/AuthorizeService'

const getHtml = editorState => draftToHtml(convertToRaw(editorState.getCurrentContent()));

export class FetchData extends Component {
    //static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = {
            //forecasts: [], loading: true
            editorState: EditorState.createEmpty()
        };
    }

    onEditorStateChange = editorState => {
        this.setState({ editorState });
    };

    //componentDidMount() {
    //  this.populateWeatherData();
    //}

    //static renderForecastsTable(forecasts) {
    render() {
        const { editorState } = this.state;
        return (
            //<table className='table table-striped' aria-labelledby="tabelLabel">
            //  <thead>
            //    <tr>
            //      <th>Date</th>
            //      <th>Temp. (C)</th>
            //      <th>Temp. (F)</th>
            //      <th>Summary</th>
            //    </tr>
            //  </thead>
            //  <tbody>
            //    {forecasts.map(forecast =>
            //      <tr key={forecast.date}>
            //        <td>{forecast.date}</td>
            //        <td>{forecast.temperatureC}</td>
            //        <td>{forecast.temperatureF}</td>
            //        <td>{forecast.summary}</td>
            //      </tr>
            //    )}
            //  </tbody>
            //</table>
            <div>
                <Editor
                    editorState={editorState}
                    wrapperClassName="rich-editor demo-wrapper"
                    editorClassName="demo-editor"
                    onEditorStateChange={this.onEditorStateChange}
                    placeholder="Write your reflections, feelings, etc..." />
                <h4>Underlying HTML</h4>
                <div className="html-view">
                </div>
                <button className="btn btn-success" data-toggle="modal" data-target="#previewModal">
                    Preview message
                </button>
                <PreviewModal output={getHtml(editorState)} />
            </div>
        );
    }
}

  //render() {
  //  let contents = this.state.loading
  //    ? <p><em>Loading...</em></p>
  //    : FetchData.renderForecastsTable(this.state.forecasts);

  //  return (
  //    <div>
  //      <h1 id="tabelLabel" >Weather forecast</h1>
  //      <p>This component demonstrates fetching data from the server.</p>
  //      {contents}
  //    </div>
  //  );
  //}

  //async populateWeatherData() {
  //  const token = await authService.getAccessToken();
  //  const response = await fetch('weatherforecast', {
  //    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  //  });
  //  const data = await response.json();
  //  this.setState({ forecasts: data, loading: false });
  //}
//}
