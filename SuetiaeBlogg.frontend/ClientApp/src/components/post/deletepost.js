import axios from 'axios';
import React from 'react';



class DeletePost extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            post: []
        };
    }
    token = localStorage.getItem('signin');
    authorId = localStorage.getItem('userId');
    apiURL = `https://localhost:44351/api/BlogPosts`;


    async componentDidMount() {
        await axios.get(`${this.apiURL}/${this.props.match.params.id}`, {
            headers: {
                'Authorization': `Bearer ` + this.token,
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                console.log('Rasponse from editById', response)
                this.setState({ post: response.data.data});
                //console.log('Rasponse from server', response)

            });
    }


    deletePosts(id, e) {
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

                    post: result.data.data
                })
                window.location.assign('https://localhost:44301/authorsdashboarad'); 

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


render(){
    return (
        <div>
            <p>Are you sure you want to delete " {this.state.post.title} " permanently? </p>
            <button type="button" class="btn btn-warning" data-toggle="modal" data-target="#staticBackdrop">Delete</button>

            <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="staticBackdropLabel">Warning</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                { /*This accetion is irreversible! are you sure you want to delete " {postbyauthorid.title} " forever?" {this.state.post.title} " forever?*/}
                                                                    This action is irreversible! are you sure you want to delete the post?
                                                                    </div>
                            <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal"> I regret </button>
                            <button type="submit" class="btn btn-light" onClick={(e) => this.deletePosts(this.state.post.postId, e)}>Confirm & delete</button>
                            </div>
                        </div>
                    </div>
                </div>
               
        </div>

            );
        }
}
export default DeletePost;