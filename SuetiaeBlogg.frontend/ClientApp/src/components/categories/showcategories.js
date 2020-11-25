import React, { useState, useEffect} from 'react';
import axios from 'axios'
import {Link} from 'react-router-dom';

export class ShowCategories extends React.Component{ 
constructor(props) {
    super(props);
    
  }
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
            
                <div class="col">
                <ul className="list-group list-group-flush">
                    {this.state.categories.map(category => (
                        <span>
                        <li className="list-group-item" key={category.categoryId}>
                    <Link to={{pathname: `/showbycategory/${category.name}` , 
                   myCustomProps: category,  
                    query: { name: category.name }, 
                    }}>{category.name}</Link>
                        </li>
                        </span>
                    ))}
                </ul>
            </div>
        );
    }
}

export default ShowCategories;
