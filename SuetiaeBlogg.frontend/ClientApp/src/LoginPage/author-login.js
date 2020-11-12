import React, { useState } from 'react'
import axios from 'axios';
import { isEmail } from "validator";
import { UserContext } from '../components/UserContext'

function Login(props){

    const [author, setauthor] =
        useState({ UserName: '', Password: '' });  

    const [user, setUser] = useState(null);

    const Signin = (e) => {
        e.preventDefault();
        const data = {
            UserName: author.UserName,
            Password: author.Password
        };
        const apiUrl = "https://localhost:44351/api/Authors/login";
        
        axios.post(apiUrl, data, {   
            headers: {
                //'Authorization': token ,
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                console.log('This is the response', response)
                return response;
                debugger;
            })
            .then((result) => {
                console.log('This the result', result)
                localStorage.setItem('signin', result.data.token)
                console.log('Token from localStorage', localStorage.getItem('signin'))
                localStorage.setItem('userId', JSON.stringify(result.data.id))
                console.log('userId from localStorage', localStorage.getItem('userId'))

                //    console.log(result.data);
                //    const serializedState = JSON.stringify(result.data.UserDetails);
                //    var a = localStorage.setItem('myData', serializedState);
                //    console.log("A:", a)
                //    //const author = result.data.UserDetails;
                //    console.log(result.data.message);
                    if (result.data.Status == 'Invalid')
                    alert('Try again!');
                
                    else
                        props.history.push('/authorsdashboarad')
                }).catch(e => {
                    console.log(e.result);
                  
                });           
            }

    const onChange = (e) => {
        e.persist();
        //debugger;
        setauthor({ ...author, [e.target.name]: e.target.value });
    } 
    const required = value => {
        if (!value) {
            return (
                <div className="alert alert-danger" role="alert">
                    This field is required!
                </div>
            );
        }
    };

    const email = value => {
        if (!isEmail(value)) {
            return (
                <div className="alert alert-danger" role="alert">
                    This is not a valid email.
                </div>
            );
        }
    };
    return (

      

            <form onSubmit={Signin} class="user">
                <h3>Log in</h3>
                <div class="form-group">
                    <label>Email</label>
                <input type="email" class="form-control" value={author.UserName} onChange={onChange} name="UserName" id="UserName" aria-describedby="emailHelp" placeholder="Your username is your Email" validations={[required, email]} />
                </div>
                <div class="form-group">
                    <label>Password</label>
                <input type="password" class="form-control" value={author.Password} onChange={onChange} name="Password" id="Password" placeholder="Password" validations={[required]} />
                </div>
                   <button type="submit" className="btn btn-info mb-1" block><span>Login</span></button>
                                           
            </form>                                              
    )  
}
export default Login;