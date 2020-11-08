import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './HomePage/Home';
import { About } from './AboutPage/About';
import { Contact } from './ContactPage/Contact';
//import { Posts } from './components/post/posts';
//import { FetchData } from './components/FetchData';
import  AuthorsDashboard  from './AuthorPage/AuthorsDashboard';
import { Counter } from './components/Counter';
import  AddPost from './AuthorPage/Addpost'
import AddPostByCategory from '../src/components/post/addpost-categories';
import Categories from '../src/CategoriesPage/Categories';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import 'react-draft-wysiwyg/dist/react-draft-wysiwyg.css'
import AuthorRegistration from '../src/RegisterPage/author-registration';
import Login from '../src/LoginPage/author-login'


import './custom.css'

export default class App extends Component {
    static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/about' component={About} />
        <Route path='/contact' component={Contact} />
            {/*<Route exact path="/" component={Posts} />*/}
        <Route path='/counter' component={Counter} />
            { /*<AuthorizeRoute path='/authosdashboarad' component={AuthorsDashboard} />*/}
            <Route path='/authorsdashboarad' component={AuthorsDashboard} />
            <Route path='/register' component={AuthorRegistration} />
            <Route path='/login' component={Login} />
            <Route path='/addpost' component={AddPostByCategory} />
            <Route path='/selectcategories' component={Categories} />


            <Route path='/addposttrial' component={AddPost} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
            </Layout>
        );
    }
}