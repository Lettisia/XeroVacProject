import React from 'react'; 
import ReactDOM from 'react-dom'; 
import logo from './images/DeathLogo.jpg'; 

class Home extends React.Component {
    render() {
        return (
            <div>
                <h1>Hi there!</h1>
                <img src ={logo} alt='logo'/>
            </div>
        ); 
    }
}

ReactDOM.render(
    <Home />, 
    document.getElementById('root')
);