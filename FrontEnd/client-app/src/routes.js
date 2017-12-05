import React from 'react'; 
import { render } from 'react-dom'; 
import { Router, Route } from 'react-router'; 
import Page from './components/pageOne'; 


export default (
    <Router>
        <Route path='/pageOne' component={Page}/>
    </Router>,
    document.getElementById('container')
); 