import React, { Component} from 'react'
import {Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import axios from 'axios';
import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';
import history from '../../src/history'
import { post } from 'jquery';


//last try: https://codesource.io/build-simple-blog-using-axios-with-react/
//https://stackoverflow.com/questions/52694011/how-to-delete-a-single-item-using-axios-in-react 
//https://stackoverflow.com/questions/42079896/update-a-component-list-after-deleting-record
//USe later for snackbar:
        //https://www.youtube.com/watch?v=UAJpKl5gg6A

class AuthorsDashboard extends Component {
    constructor(props) {
        super(props);
        this.state = {
            //postId: '',
            //title: '',
            //summary: '',
            //categories: [],
            //body: '',
            post: [],
            authorId: '',
            isLoaded: false
        }
        this.deletePosts = this.deletePosts.bind(this);
    }


    deletePosts (id) {
        const apiURLDelete = `https://localhost:44351/api/BlogPosts`;
        const token = localStorage.getItem('signin');
        const authorId = localStorage.getItem('userId');

        axios.delete(`${apiURLDelete}/${id}`, {
            headers: {
                'Authorization': `Bearer ` + token,
                'Content-Type': 'application/json'
            },
            data: id
        })
            .then((result) => {
                //let newPost = [...this.state.post];
                //console.log('id is: ', id);
                console.log('Object deleted', result);
                this.setState({

                    post: this.state.post.filter(postbyauthorid => postbyauthorid.postId !== id)
                })
                this.setState({ post: this.state.post });
                //this.setState({ post: result.data.data });
                //this.setState({
                //    postId: newPost.length + 1,
                //    title: '',
                //    summary: '',
                //    categories: [],
                //    body: '',
                //    post: newPost
                //})

                // this.componentDidMount();
                //window.location.reload();
                //history.push('/authorsdashboarad');
            });
    };

    authorId = localStorage.getItem('userId');
    apiURL = `https://localhost:44351/api/BlogPosts/authors`;

    async componentDidMount() {
        await axios.get(`${this.apiURL}/${this.authorId}/posts`)
            .then(response => {
                console.log('Rasponse from postByAuthorId', response)

                this.setState({ post: response.data.data, isLoaded: true });

            });
    }
    

    render() {
    return (
        <div className="Container animated fadeIn">
            <Row>
                <Col>
                    <Card>
                        <CardHeader>
                            <i className="fa fa-align-justify"></i> Your recent posts
                          </CardHeader>
                        {this.state.post? (
                        <CardBody>
                            <Table hover bordered striped responsive size="sm">
                                <thead>
                                    <tr>
                                        <th>Title</th>
                                        <th>Summary</th>
                                        <th>Category</th>
                                    </tr>
                                </thead>
                                    <tbody>
                                        
                                            {
                                                this.state.post.map((postbyauthorid, i) =>
                                                    
                                                        <tr key={postbyauthorid.id}>

                                                            {<td>{postbyauthorid.title}</td>}
                                                            {<td>{postbyauthorid.summary}</td>}
                                                            {
                                                                (typeof (postbyauthorid.categories) == 'object') ?
                                                                    <td>

                                                                        {postbyauthorid.categories.map((catNames, k) =>
                                                                            <td>
                                                                                {catNames.name}
                                                                            </td>
                                                                        )
                                                                        }
                                                                        

                                                                    </td> : null}

                                                            <td>

                                                                <div class="btn-group">
                                                                <Link to={{ pathname: `/editpostv2/${postbyauthorid.postId}`, query: { id: postbyauthorid.postId } }}><Button variant="btn btn-success" >Edit</Button></Link>
                                                                <button type="submit" class="btn btn-danger" onClick={this.deletePosts.bind(this, postbyauthorid.postId)}>delete directly</button>

                                                                <Link to={{ pathname: `/deletepost/${postbyauthorid.postId}`, query: { id: postbyauthorid.postId } }}><Button variant="btn btn-warning" >Delete in the next page</Button></Link>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                    
                                         )}
                                        
                                        
                                    )
                                </tbody>
                                <br>
                                </br>
                                { /* <Button href='/addposttrial'> Add new post </Button>
                                <Button href='/addposttrialV2'> Add new post by CKeditor </Button>*/}

                            </Table>
                        </CardBody>
                        ): (
                                <CardBody>
                            <i className="fa fa-align-justify"></i> No post to show 
                                </CardBody>
                                

                            )} 
                                
                            <Button href='/addposttrialV2'> Add new blog post  </Button>
                        <div>
                        </div>
                    </Card>
                </Col>
            </Row>
            <Row>
                <Col>
                </Col>
            </Row>
        </div> 
        )
    }
}
export default AuthorsDashboard;