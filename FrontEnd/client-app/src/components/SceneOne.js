import React, { Component } from "react";
import { Helper } from "../functions/fetchRequests";

class SceneOne extends React.Component {

    constructor() {
        super();
        this.state = {
            data: ""
        }
        this.handleClickOne = this.handleClickOne.bind(this);
        this.handleClickTwo = this.handleClickTwo.bind(this);
        this.handleClickThree = this.handleClickThree.bind(this);
    }

    componentDidMount() {
        this.setData();
    }

    async setData() {
        var result = await Helper.postData('CHARDESC', '1');
        this.setState({ charone: result.Message });
        var result = await Helper.postData('CHARDESC', '2');
        this.setState({ chartwo: result.Message });
        var result = await Helper.postData('CHARDESC', '3');
        this.setState({ charthree: result.Message });
    }

    render() {
        return(
        <div>
            <h1>Scene One</h1>
            <p>You wake up at desk after long and restless night. It is 2nd November, the Day of the Dead. It is also the anniversary of your partner’s death - former Sheriff Theodore.</p>
            <p>In the town gaol is the town drunk, <a href="" onClick={this.handleClickOne}>Clayton</a>. He was locked up for disturbing the peace.  He has been yelling, “I have seen the ghost of the Cowboy Killer!”
            You answer, “That’s impossible, she’s been dead for a year! Killed by my father!”</p>

            <p>You then ignore the drunk and gets on with some work.</p>

            <p>Suddenly,  <a href="" onClick={this.handleClickTwo}>Cowboy Johnny</a> bursts into the room.
                    He says he has heard screaming by the Spooky House, the
                    home of <a href="" onClick={this.handleClickThree}>Old Lady Dolores</a>. </p>
            <p>You leave the office to the Spooky House, with the keys to the gaol cell still in your hand...</p>
        </div>
        )
    
    }


    handleClickOne() {
        window.alert(this.state.charone);
    }

    handleClickTwo() {
        window.alert(this.state.chartwo);
    }

    handleClickThree() {
        window.alert(this.state.charthree);
    }
}
export default SceneOne;


