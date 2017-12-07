import React from 'react'; 
import ReactDOM from 'react-dom'; 
import logo from './images/DeathLogo.jpg';
import './css/index.css';
import Counter from './components/Counter';
import NavBar from './components/navBar'; 
import SceneOne from '../src/components/SceneOne'; 
import SceneTwo from '../src/components/SceneTwo';
import SceneThree from '../src/components/SceneThree'; 
import SceneFour from '../src/components/SceneFour'; 
import SceneFive from '../src/components/SceneFive'; 
import Toolbar from './components/toolbar'; 
import Start from './components/StartScreen'; 

class Home extends React.Component {
	    constructor(props){
        super(props);
        this.closeStart = this.closeStart.bind(this)
        this.state = {
            closeStart: false
        }
    }

    closeStart() {
        this.setState({closeStart: true}); 
    }

    render() {
        return (
            <div className = "app">
                <div className="container">
                    <div className={"app" + (this.state.closeStart ? " no-show":"")}>
                        <Start closeStart={this.closeStart} />
                    </div>                 
                    <NavBar />
                    {/* <div className="content">
                        <img src ={logo} class= 'logo' alt='logo' />
                        <p>By the Xero Vacation Team</p>
                        <form action = "pageOne.js">
                            <input type = "submit" value="Start Game!" />
                        </form> 
                        <SceneOne/>
                        <SceneTwo/>
                        <SceneThree/>
                        <SceneFour/>
                        <SceneFive/>                       
                    </div> */}
                </div>
            </div>
        ); 
    }
}

ReactDOM.render(
    <Home />, 
    document.getElementById('root')
);