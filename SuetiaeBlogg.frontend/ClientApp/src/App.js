import React, {useState } from 'react';
import { Route } from 'react-router';
import { Router, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './HomePage/Home';
import { About } from './AboutPage/About';
import { Contact } from './ContactPage/Contact';
import posts from './components/post/posts';
import showpost from './components/post/showpost';
import  AuthorsDashboard  from './AuthorPage/AuthorsDashboard';
import { Counter } from './components/Counter';
import AddPostByCategory from '../src/components/post/addpost-categories';
import AddPostByCategoryV2 from '../src/components/post/addpost-categoriesV2';
import editpost from '../src/components/post/editpost'
import editpostv2 from '../src/components/post/editpostV2'

import Categories from '../src/CategoriesPage/Categories';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import 'react-draft-wysiwyg/dist/react-draft-wysiwyg.css'
import AuthorRegistration from '../src/RegisterPage/author-registration';
import Login from '../src/LoginPage/author-login'
import 'react-draft-wysiwyg/dist/react-draft-wysiwyg.css';
import history from './history';
import Blogs from './BlogPage/Blogs';
import { UserContext } from '../src/components/UserContext'


import './custom.css'
import { useMemo } from 'react';


function App() {
    //displayName = App.name;
    const [user, setUser] = useState(null);
    const providerValue = useMemo(() => ({ user, setUser }), [user, setUser]);

    return (

        <Router history={history}>
              <Switch>
                  <Layout>
                      <Route exact path='/' component={Home} />
                    <Route path='/showpost/:id' component={showpost} />

                      <Route path='/about' component={About} />
                      <Route path='/contact' component={Contact} />
                      <Route path="/blogs" component={Blogs} />
                      <Route path='/counter' component={Counter} />
                      { /*<AuthorizeRoute path='/authosdashboarad' component={AuthorsDashboard} />*/}
                      <Route path='/register' component={AuthorRegistration} />
                      <Route path='/login' component={Login} />
                    <Route path='/selectcategories' component={Categories} />

                    <UserContext.Provider value={providerValue}>
                      <Route path='/authorsdashboarad' component={AuthorsDashboard} />
                        <Route path='/addposttrial' component={AddPostByCategory} />
                        <Route path='/addposttrialV2' component={AddPostByCategoryV2} />
                        { /*<Route path='/editpost/:id' component={editpost} />*/}
                        <Route path='/editpostv2/:id' component={editpostv2} />

                    </UserContext.Provider>
                      <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                  </Layout>
              </Switch>
          </Router>
        );
    
}
export default App;