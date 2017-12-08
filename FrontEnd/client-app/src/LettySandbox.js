import React, { Component } from "react";
import { Helper } from "./functions/fetchRequests";

class Letty extends React.Component {
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
                <button class="mdc-button" onClick={this.handleClick}>
                {this.state.data}
            </button>
        </div>
        )
    }

    handleClick() {
        //e.preventDefault();
        console.log('The link was clicked.');
        //console.log(this.state.data);
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
export default Letty;


