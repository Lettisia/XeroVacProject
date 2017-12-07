import React from 'react'; 
import ReactDOM from 'react-dom'; 
import logo from './images/DeathLogo.jpg';
import './css/index.css';
import Counter from './components/Counter';
import NavBar from './components/navBar'; 
import Toolbar from './components/toolbar'; 


class Home extends React.Component {
	    constructor(props){
        super(props);
    }
    render() {
        return (
            <div class = "box">
                <div class="container">
                    <Toolbar />
                    <NavBar />
                    <div class="content">
                        <img src ={logo} class= 'logo' alt='logo' />
                        <p>By the Xero Vacation Team</p>
                        <form action = "pageOne.js">
                            <input type = "submit" value="Start Game!" />
                        </form>
                    </div>
                </div>
            </div>
        ); 
    }
}

ReactDOM.render(
    <Home />, 
    document.getElementById('root')
);