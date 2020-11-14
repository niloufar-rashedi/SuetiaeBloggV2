import React, { useContext} from 'react'
import { Badge, Card, CardBody, CardHeader, Col, Pagination, PaginationItem, PaginationLink, Row, Table } from 'reactstrap';
import axios from 'axios';
import { useState, useEffect } from 'react'
import { UserContext } from '../components/UserContext';

function PostsList(props) {
    const [data, setData] = useState([]);
    const [user, setUser] = useState(null);

    useEffect(() => {
        const GetPosts = async () => {
            const result = await axios('https://localhost:44351/api/BlogPosts');
            setData(result.data);
        };

        GetPosts();
    }, []);

    const deletePosts = (id) => {
        debugger;
        axios.delete('https://localhost:44351/api/BlogPosts' + id)
            .then((result) => {
                props.history.push('/authorsdahboard')
            });
    };
    const editPosts = (id) => {
        props.history.push({
            pathname: '/edit/' + id
        });
    };
   // const msg = useContext(UserContext);

    return (
        <div className="Container animated fadeIn">
        

            <Row>
                <Col>
                    <Card>
                        <CardHeader>
                            <i className="fa fa-align-justify"></i> Your recent posts
              </CardHeader>
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
                                        [data].map((item, idx) => {
                                            return <tr>
                                                <td>{item.Title}</td>
                                                <td>{item.Category}</td>
                                                <td>{item.summary}</td>

                                                <td>
                                                    <div class="btn-group">
                                                        <button className="btn btn-warning" onClick={() => { editPosts(item.Id) }}>Edit</button>
                                                        <button className="btn btn-warning" onClick={() => { deletePosts(item.Id) }}>Delete</button>
                                                    </div>
                                                </td>
                                            </tr>
                                        })}
                                </tbody>
                                <br>
                                </br>
                            </Table>
                        </CardBody>
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
export default PostsList;