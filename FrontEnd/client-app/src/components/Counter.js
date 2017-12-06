import * as React from 'react'; 

class Counter extends React.Component {
    constructor() {
        super();
        this.state = {  
            character: [], 
            location: [],
            link: "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com",
            getRequest: "/api/dbaccess"
        };

    }
    
    render() {
        return <div>
            <h1>Counter</h1>

            <p> {this.state.location.name} </p>

            <button onClick={() => { this.postData('CHARDESC', '1')}}>Post Call</button>

            <button onClick={() => { this.getData("location", 1, "/initialiselocations") }}>Get Data</button>

        </div>;
    }

    handleSetState(_propertyName, _data) {
        if (_propertyName === "location") {
            this.setState({location: _data}); 
        } else if (_propertyName === "character"){
            this.setState({character: _data}); 
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
            this.handleSetState(_propertyName, data[_id - 1]); 
            console.log("fetch complete"); 
        });

        return dataRequestReturn; 

    }

    postData(_action, _parameter) {

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
