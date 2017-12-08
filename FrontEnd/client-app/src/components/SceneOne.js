import React, { Component } from "react";
import { Helper } from "../functions/fetchRequests";

class SceneOne extends React.Component {

    constructor() {
        super();
        this.state = {
            data: ""
        }
        this.handleClick = this.handleClick.bind(this);
    }

    componentDidMount() {
        this.setData();
    }

    async setData() {
        var result = await Helper.postData('CHARDESC', '1');
        this.setState({ data: result.Message });
    }

    render() {
        return(
        <div>
            <h1>Scene One</h1>
            <p>You wake up at desk after long and restless night. It is 2nd November, the Day of the Dead. It is also the anniversary of your partner’s death - former Sheriff Theodore.</p>
            <p>In the town gaol is the town drunk, <a href="" onClick={this.handleClick}>
                Clayton</a>. He was locked up for disturbing the peace.  He has been yelling, “I have seen the ghost of the Cowboy Killer!”
            You answer, “That’s impossible, she’s been dead for a year! Killed by my father!”</p>

            <p>You then ignore the drunk and gets on with some work.</p>

            <p>Suddenly, Cowboy Johnny bursts into the room. He says he has heard screaming by the Spooky House, the home of Old Lady Dolores. </p>
            <p>You leave the office to the Spooky House, with the keys to the gaol cell still in your hand...</p>
        </div>
        )
    
    }


    handleClick() {
        window.alert(this.state.data);
    }


    static async getData(_apilink) {

        var myLine = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com/";
        myLine += "command?jsonStr{\"Action\":\"CHARDESC\",\"Parameter\":\"2\"}";
        console.log(myLine);
        var results = await fetch(myLine, {
            method: 'GET',
        });
        var json = await results.json();
        return json;
    }



}
export default SceneOne;


