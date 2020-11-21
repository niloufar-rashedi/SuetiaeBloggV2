import React, { useState, useEffect} from 'react';
import axios from 'axios'

export class ReturnCategories extends React.Component {
    state = {
        categories: [],
    }
    apiURL = 'https://localhost:44351/api/BlogPosts/categories';

    onChangeCategories(event) {
        console.log(event.target.value);
    }


    async componentDidMount() {
        await axios.get(this.apiURL)
            .then(response => {
                console.log(response);
                this.setState({ categories: response.data.data });
            });
    }

    render() {
        const { categories } = this.state;

        return (
            <div>

                <span>Select a category</span>
                <div>
                    <select onChange={this.onChangeCategories}>
                {categories.map((category, index) => {
                    return <option>{category.name}</option>

                            

                            })}
                </select>
                    </div>
            </div>
        );
    }
}

export default ReturnCategories;
