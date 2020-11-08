import React, { useState } from 'react'
import axios from 'axios';

function Login(props){

    const [author, setauthor] =
        useState({ UserName: '', Password: '' });  

    const Signin = (e) => {
        e.preventDefault();
        const data = {
            UserName: author.UserName,
            Password: author.Password
        };
        const apiUrl = "https://localhost:44351/api/Authors/login";

        axios.post(apiUrl, data)
            .then((result) => {
                console.log(result.data);
                const serializedState = JSON.stringify(result.data.UserDetails);
                var a = localStorage.setItem('myData', serializedState);
                console.log("A:", a)
                //const author = result.data.UserDetails;
                console.log(result.data.message);
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
    return (

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-10 col-lg-12 col-md-9">
                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Sign in to your blog dashboard</h1>
                                        </div>
                                        <form onSubmit={Signin} class="user">
                                            <div class="form-group">
                                                <input type="email" class="form-control" value={author.UserName} onChange={onChange} name="UserName" id="UserName" aria-describedby="emailHelp" placeholder="Your username is your Email" />
                                            </div>
                                            <div class="form-group">
                                                <input type="password" class="form-control" value={author.Password} onChange={onChange} name="Password" id="Password" placeholder="Password" />
                                            </div>
                                            {/* <div class="form-group">  
                          <div class="custom-control custom-checkbox small">  
                            <input type="checkbox" class="custom-control-input" id="customCheck"/>  
                            <label class="custom-control-label" for="customCheck">Remember Me</label>  
                          </div>  
                        </div> */}
                                            <button type="submit" className="btn btn-info mb-1" block><span>Login</span></button>
                                            <hr />
                                        </form>
                                        <hr />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )  


}
export default Login;