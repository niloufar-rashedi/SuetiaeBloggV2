import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { faHome } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true, 
            userId: ''
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }
           // this.state.authorId = 
    logout() {
        //this.setState({
        //    userId: localStorage.removeItem('userId')
        return localStorage.clear();
        }
        
    


    render() {
        const userId = localStorage.getItem('userId');
        return (


            <div className="sticky-top bg-light">
                <header className="text-center">
                    <section className="text-center text-md-right">
                        <h1 className="text-center font-weight-bold">S   u   e   t   i   a   e</h1>
                        <h5 className="text-center">A latin word for Sweden. Sounds strange? Let's discover it together</h5>
                    </section>
                    <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                        <Container>
                            <NavbarBrand tag={Link} to="/"><FontAwesomeIcon icon={faHome} /></NavbarBrand>
                            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                                <ul className="navbar-nav flex-grow">
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/about">About Us</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/counter">Activities</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/contact">Contact Us</NavLink>
                                    </NavItem>

                                    {userId ? (
                                        <div>
                                            <NavItem>
                                                <NavLink tag={Link} className="text-dark" to="/" onClick={this.logout}>Sign Out</NavLink>
                                            </NavItem>
                                            <NavItem>
                                                <NavLink tag={Link} className="text-dark" to="/authorsdashboarad">Dashboard</NavLink>
                                            </NavItem>
                                        </div>
                                    ) : (
                                            <div>
                                        <NavItem>
                                           
                                        <NavLink tag={Link} className="text-dark" to="/register">Sign Up</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/login">Sign In</NavLink>
                                                </NavItem>
                                            </div>
                                    )}
                                    
                                </ul>
                            </Collapse>
                        </Container>
                    </Navbar>
                </header>
            </div>
        );
    }
}
