import React, {Component} from 'react'; 
import '../css/start.css'; 
import logo from '../images/DeathLogo.jpg'; 

class StartScreen extends Component {
    render() {
        if (!this.props.closeStart) {
            return null
        }
        return (
            <div className="start_screen" onClick={this.props.closeStart}>
                <div className="screen_container">
                    <img src={logo} />
                </div>
            </div>
        )
    }
}

export default StartScreen; 