import React, { Component, useState, useEffect} from 'react';
import Select from 'react-select';
import makeAnimated from 'react-select/animated';
import axios from 'axios';
import Card from 'react-bootstrap/Card'



//First Carl Rippon solution: 

//function ReturnCategories() {

//    const animatedComponents = makeAnimated();

//    const [items] = useState([
//        { label: "General", value: "General" },
//        { label: "Historia", value: "Historia" },
//        { label: "Holiday", value: "Holiday" }

//    ]);
//    return (

//        //<select>
//        //    {items.map(item => (
//        //        <option
//        //            key={item.value}
//        //            value={item.value}
//        //        >
//        //            {item.label}
//        //        </option>                
//        //        ))}
//        //</select>

//        <Select
//            closeMenuOnSelect={false}
//            components={animatedComponents}
//            isMulti
//            options={items}
//        />
//        );
//}
//export default ReturnCategories;



//Second solution:



//export default class ReturnCategories extends Component {

//    constructor(props) {
//        super(props)
//        this.state = {
//            selectOptions: [],
//            id: "",
//            name: ''
//        }
//    }
//    async getOptions() {
//        const res = await axios.get(
//            apiUrlCategory
//        );
//        const data = res.json();
//        setItems(
//            data.res.map(({ name }) => ({
//                label: name,
//                value: name
//            })
//            ));
        
//    };
//        const options = data.map(d => ({
//                    label: d.name,
//                    value: d.name

//        }))

//        this.setState({ selectOptions: options })
//    }

//    handleChange(e) {
//        //console.log(e);
//        this.setState({ id: e.value, name: e.label })
//    }

//    componentDidMount() {
//        this.getOptions()
//    }

//    render() {
//        console.log(this.state.selectOptions)
//        return (
//            <div>
//                <Select options={this.state.selectOptions} onChange={this.handleChange.bind(this)} />
//                <p>You have selected <strong>{this.state.name}</strong> whose id is <strong>{this.state.id}</strong></p>
//            </div>
//        )
//    }
//}



//Third solution

//const fetchURL = "https://localhost:44351/api/BlogPosts/categories";
//const getItems = () => fetch(fetchURL).then(res => res.json());

//function ReturnCategories() {
//    const [items, setItems] = useState([]);

//    useEffect(() => {
//        getItems().then(data => setItems(data));
//    }, []);

//    return (
//        <div>
//            {items
//                ? items.map(item => {
//            return <div key={item.id}>{item.title}</div>;
//                })
//                : "Loading..."}
//        </div>
//            );
//}

//export default ReturnCategories;

export class ReturnCategories extends React.Component {
    state = {
        categories: [],
    }
         apiUrl = 'https://localhost:44351/api/BlogPosts/categories';

    async componentDidMount() {
        await axios.get(this.apiUrl)
            .then(response => {
                console.log(response);
                this.setState({ categories: response.data.data });
            });
    }
    render() {
        return (
            <div>
                {this.state.categories.map(category => (
                        <div className="card" key={category.Id}>

                            <Card style={{ width: '50rem' }}>
                                <Card.Body>
                                    <Card.Title>{category.Name}</Card.Title>
                                </Card.Body>
                            </Card>
                        </div>
                ))}
            </div>
        );
    }
} export default ReturnCategories;