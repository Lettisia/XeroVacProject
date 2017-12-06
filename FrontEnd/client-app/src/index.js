import React from 'react'; 
import ReactDOM from 'react-dom'; 
import logo from './images/DeathLogo.jpg';
import './css/index.css';
import Counter from './components/Counter';


class Home extends React.Component {
    render() {
        return (
            <div class = "box">
                <img src ={logo} class= 'logo' alt='logo' />
                <p>By the Xero Vacation Team</p>
                <form action = "pageOne.js">
                    <input type = "submit" value="Start Game!" />
                </form>
                <div class="container">
                    <Counter />
                </div>
            </div>
        ); 
    }
}

ReactDOM.render(
    <Home />, 
    document.getElementById('root')
);