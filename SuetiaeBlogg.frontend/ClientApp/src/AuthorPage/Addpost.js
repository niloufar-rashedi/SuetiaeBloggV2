import React, { useState } from "react";
import axios from 'axios';

const AddPost = () => {
    const initialPostState = {
        id: null,
        title: "",
        category: "",
        summary: "",
        body: "",
        lastModified: "",
    };
    const [post, setPost] = useState(initialPostState);
    const [submitted, setSubmitted] = useState(false);

    const handleInputChange = event => {
        const { name, value } = event.target;
        setPost({ ...post, [name]: value });
    };
    const apiURL = 'https://localhost:44351/api/BlogPosts/InsertNewPost';

    const savePost = () => {
        var data = {
            title: post.title,
            category: post.category
        };

        axios.post(apiURL, data)
            .then(response => {
                setPost({
                    id: response.data.id,
                    title: response.data.title,
                    category: response.data.category,
                    summary: response.data.summary,
                    lastModified: response.data.lastModified

                });
                setSubmitted(true);
                console.log(response.data);
            })
            .catch(e => {
                console.log(e);
            });
    };

    const newPost = () => {
        setPost(initialPostState);
        setSubmitted(false);
    };
    return (
        <div className="submit-form">
            {submitted ? (
                <div>
                    <h4>You submitted successfully!</h4>
                    <button className="btn btn-success" onClick={newPost}>
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
                                value={post.title}
                                onChange={handleInputChange}
                                name="title"
                            />
                        </div>

                        <div className="form-group">
                            <label htmlFor="category">Category</label>
                            <input
                                type="text"
                                className="form-control"
                                id="category"
                                required
                                value={post.category}
                                onChange={handleInputChange}
                                name="category"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="title">Summary</label>
                            <input
                                type="text"
                                className="form-control"
                                id="summary"
                                required
                                value={post.summary}
                                onChange={handleInputChange}
                                name="summary"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="title">Body</label>
                            <input
                                type="text"
                                className="form-control"
                                id="body"
                                required
                                value={post.body}
                                onChange={handleInputChange}
                                name="body"
                            />
                        </div>

                        <div className="form-group">
                            <label htmlFor="title">Last modfied</label>
                            <input
                                type="text"
                                className="form-control"
                                id="lastModified"
                                required
                                value={post.lastModified}
                                onChange={handleInputChange}
                                name="lastModified"
                            />
                        </div>

                        <button onClick={savePost} className="btn btn-success">
                            Submit
          </button>
                    </div>
                )}
        </div>
    );
};

export default AddPost;