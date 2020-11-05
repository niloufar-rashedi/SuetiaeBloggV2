import React, { useState } from 'react'
import axios from 'axios';

function Regster(props) {
    const [data, setdata] =
        useState({ FirstName: '', LastName: '', UserName: '', Password: '' })
    const apiUrl = "https://localhost:44351/api/Authors/register";

    const Registration = (e) => {
        e.preventDefault();
        // debugger;
        const data1 = {
            FirstName: data.FirstName,
            LastName: data.LastName,
            UserName: data.UserName,
            Password: data.Password
        };
        axios.post(apiUrl, data1)
            .then((result) => {
                //debugger;
                console.log(result.data);
                if (result.data.Status == 'Invalid')
                    alert('Invalid User');
                else
                    props.history.push('/authorsdashboarad')
            }).catch(e => {
                console.log(e.result);
            }); }
        const onChange = (e) => {
            e.persist();
            //debugger;
            setdata({ ...data, [e.target.name]: e.target.value });
        }
   
        return (
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 btn btn-primary" style={{ "margin": "6px" }}>
                        Add New Contact
       </div>
                </div>
                <div class="card o-hidden border-0 shadow-lg my-5" style={{ "marginTop": "5rem!important;" }}>
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Create a New User</h1>
                                    </div>
                                    <form onSubmit={Registration} class="user">
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                <input type="text" name="FirstName" onChange={onChange} value={data.FirstName} class="form-control" id="exampleFirstName" placeholder="FirstName" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <input type="text" name="LastName" onChange={onChange} value={data.LastName} class="form-control" id="exampleInputEmail" placeholder="LastName" />
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                <input type="email" name="UserName" onChange={onChange} value={data.UserName} class="form-control" id="exampleInputPassword" placeholder="UserName" />
                                            </div>
                                            <div class="col-sm-6">
                                                <input type="Password" name="Password" onChange={onChange} value={data.Password} class="form-control" id="exampleLastName" placeholder="Password" />
                                            </div>

                                        </div>
                                        <button type="submit" class="btn btn-primary  btn-block">
                                            Create User
                </button>
                                        <hr />
                                    </form>
                                    <hr />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
export default Regster;