import React, { useState, useEffect} from 'react';
import axios from 'axios'

//function ReturnCategories() {
//    const [categories, setCategories] = useState([])

//   const url = 'https://localhost:44351/api/BlogPosts/categories';

//    useEffect(()=> {
//        axios.get(url)
//            .then(response => {
//                console.log(response)
//                setCategories(response.data)
//            })
//            .catch(err => {
//                console.log(err)
//            })
//    }, [])

//    return (
//        <div>
//            <ul>
//                {

//                    [categories].map(category =>
//                        <li key={category.id}>{category.name}</li>)
//                }
//            </ul>
//        </div>
//    )
//}
//export default ReturnCategories;


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
                <ul>
                    {this.state.categories.map(category => (
                        <li key={category.id}>
                            {category.name}
                        </li>
                    ))}
                </ul>
            </div>
        );
    }
}

export default ReturnCategories;
