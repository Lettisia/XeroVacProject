import * as React from 'react'; 

class Counter extends React.Component {
    constructor() {
        super();
        this.state = { 
            showText: true, 
            character: [], 
            location: [],
            link: "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com",
            getRequest: "/api/dbaccess"
        };

    }
    
    render() {
        return <div>
            <h1>Counter</h1>

            <p> {this.state.location[0]} </p>

            <button onClick={() => { this.postData('LOCVERB', '1')}}>Post Call</button>

            <button onClick={() => { this.getData("character", 1, "/initialiselocations") }}>Get Data</button>

            <button onClick={() => { this.callDb("/Home/DbAccessRow/") }}>Grab Row</button>
            
            <button onClick={() => { this.displayText()}}>display</button>

            <p id="story" hidden={this.state.showText}>
                {this.testData}
            </p>
        </div>;
    }
    
    displayText() {
        if (this.testData != null) {
            this.setState({ showText: false });
        }
    }
    
    //https://stackoverflow.com/questions/29775797/fetch-post-json-data

    getData(_propertyName, _id, _apiLink) {

        var dataRequestReturn = null; 

        fetch(this.state.link + this.state.getRequest + _apiLink, {
            method: 'GET', 
        }
        ).then(results => {
            return results.json(); 
        }).then(data =>{ 
            this.setState({_propertyName: data[_id - 1]}); 
            console.log(this.state._propertyName); 
            console.log("fetch complete"); 
        })
        return dataRequestReturn; 

    }

    async postData(_action, _parameter) {

        // var fetchResponse = null; 
        var postQuery = JSON.stringify({Action: _action, Parameter: _parameter});  
        fetch(this.state.link + "/command?jsonStr=" + postQuery, {
            method: 'GET'
        }).then(response => {
            return response.text(); 
        }).then(data => {
            //fetchResponse = data; 
            console.log(data); 
        }); 
    }
}

export default Counter; 
