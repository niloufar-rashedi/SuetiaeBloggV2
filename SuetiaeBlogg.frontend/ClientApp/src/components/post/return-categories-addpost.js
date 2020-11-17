import React, { useState, useEffect} from 'react';
import axios from 'axios'

export class ReturnCategories extends React.Component {
    state = {
        categories: [],
    }
    apiURL = 'https://localhost:44351/api/BlogPosts/categories';



    async componentDidMount() {
        await axios.get(this.apiURL)
            .then(response => {
                console.log(response);
                this.setState({ categories: response.data.data });
            });
    }

    render() {
        return (
            <div>
                <ul class="no-bullets-categories">
                    {this.state.categories.map(category => (
                        <span>
                        <li class="add-space-categories-list" key={category.id}>
                            {category.name}
                            </li>
                        </span>
                    ))}
                </ul>
            </div>
        );
    }
}

export default ReturnCategories;
