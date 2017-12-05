import React from 'react'; 
import ReactDOM from 'react-dom'; 
import logo from './images/DeathLogo.jpg';
import './css/index.css';
import {Router, Route} from 'react-router'; 
import routes from './routes'; 


class Home extends React.Component {
    constructor(props){
        super(props); 

    }

    render() {
        return (
            <div class = "box">
                <img src ={logo} class= 'logo' alt='logo' />
                <p>By the Xero Vacation Team</p>
                <form action = "pageOne.js">
                    <input type = "submit" value="Start Game!" />
                </form>
                <div class="container">
                    <Router routes={routes}/>
                </div>
            </div>
        ); 
    }
}

ReactDOM.render(
    <Home />, 
    document.getElementById('root')
);