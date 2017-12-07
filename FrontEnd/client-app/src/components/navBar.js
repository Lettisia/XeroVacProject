import React from 'react';
import '../css/navBar.css'; 
import {Helper} from '../functions/fetchRequests'; 

class NavBar extends React.Component {
    constructor() {
        super(); 
        this.state = {
            inventory: [],
            environment: [], 
            player: [], 
            link: "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com",
            getRequest: "/api/dbaccess"
        };

        this.setLocation(1); 
    }

    handleSetState(_propertyName, _data) {
        if (_propertyName === "location") {
            this.setState({player: _data}); 
        } else if (_propertyName === "character"){
            this.setState({character: _data}); 
        }; 
    }; 

    async setLocation(_id) {
        var _propertyName = "location"; 
        var result = await Helper.getData(_propertyName, 1, "/initialiselocations"); 
        console.log(result);
        this.handleSetState(_propertyName, result); 
        console.log(this.state.player); 
    }

    render() {
        return (
            <nav>
                <div class="inventory_section">
                    <h1 id="inventory_header">Inventory</h1>
                </div>
                <div class="environment_section">
                    <h1 id="environment_header">Environment</h1>
                </div>
                <div class="player_section">
                    <h1 id="player_header">William Wyatt</h1>
                    <ul>
                        <li>{this.state.player}</li>
                    </ul>
                </div>
            </nav>

        )
    }
}

export default NavBar; 