import React from 'react';
import axios from 'axios';

export class AddPost extends React.Component {
    state = {
        posts: [],
    };

    handleChange = event => {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit = event => {
        event.preventDefault();

        const post = {
            title: this.state.title,
            summary: this.state.summary,
            body: this.state.body
            //category: {
            //name: this.state.category.name

            // }
        };

        axios.post('/api/Posts', this.state)
            .then(res => {
                console.log(res);
                console.log(res.data);
            })

    }
    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        Title:
            <input type="text" name="title" onChange={this.handleChange} />
                    </label>
                    <label>
                        Summary:
            <input type="text" name="summary" onChange={this.handleChange} />
                    </label>
                    <label>
                        Body:
            <input type="text" name="body" onChange={this.handleChange} />
                    </label>

                    <button type="submit">Add</button>
                </form>
            </div>
        )
    }
}
