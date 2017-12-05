import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Counter extends React.Component {
    constructor() {
        super();
        this.state = { 
            showText: true, 
            testData: 'hello'
        };

    }
    
    render() {
        return <div>
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <button onClick={() => { this.incrementCounter() }}>Increment</button>

            <button onClick={() => { this.callDb("/Home/TestDbCallDelete/") }}>TestDbCall</button>

            <button onClick={() => { this.callDbPost("/Home/DbAccessRow/") }}>TestDbPostCall</button>

            <button onClick={() => { this.callDb("/Home/DbAccessRow/") }}>Grab Row</button>
            
            <button onClick={() => { this.displayText()}}>display</button>


            <p id="story" hidden={this.state.showText}>
                {this.testData}
            </p>
        </div>;
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }
    
    displayText() {
        if (this.testData != null) {
            this.setState({ showText: false });
        }
    }
    
    //https://stackoverflow.com/questions/29775797/fetch-post-json-data
    async callDbPost(url)
    {
        var testQuery = JSON.stringify({ Action: 'PICKUP', Parameter: '4' });
        url += "?jsonStr=" + testQuery;

        var response = await fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        });

        var json = await response.json();
        console.log(json);
        
        this.testData = json;
 
    }

    async callDb(url) {

        var response = await fetch(url, {
            method: 'GET'
        });
        
        var json = await response.json();
        console.log(json);

        /*
        console.log(fetch("/Home/TestDbCallDelete", {
            method: 'GET'
        }).then(function (resp) {
            return resp.json();
        }).then(function (data) {
            console.log(data);
            //can call set state
            })
        );
        */
    }
}
