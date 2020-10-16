import React, { Component } from 'react';
import { MDBCol, MDBContainer, MDBRow, MDBFooter } from "mdbreact";
export class Footer extends Component {

    render() {
        return (
            <div class="p-3 mb-2 bg-dark text-white">
                <MDBFooter color="blue" className="font-small pt-4 mt-4">
                    <MDBContainer fluid className="text-center text-md-left">
                        <MDBRow>
                            {/*<MDBCol md="6">
                            <h5 className="title">Footer Content</h5>
                        </MDBCol>
                        <MDBCol md="6">
                            <h5 className="title">Links</h5>
                            <ul>
                                <li className="list-unstyled">
                                    <a href="#!">Link 1</a>
                                </li>
                                <li className="list-unstyled">
                                    <a href="#!">Link 2</a>
                                </li>
                                <li className="list-unstyled">
                                    <a href="#!">Link 3</a>
                                </li>
                                <li className="list-unstyled">
                                    <a href="#!">Link 4</a>
                                </li>
                            </ul>
                        </MDBCol>*/}
                        </MDBRow>
                    </MDBContainer>
                    <div className="footer-copyright text-center py-3">
                        <MDBContainer fluid>
                            &copy; {new Date().getFullYear()} Copyright Suetiae Blogg
                        </MDBContainer>
                    </div>
                </MDBFooter>
            </div>

        );
    }
}