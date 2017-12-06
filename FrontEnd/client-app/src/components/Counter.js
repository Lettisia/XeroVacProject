import * as React from 'react';

class Counter extends React.Component {
    constructor() {
        super();
        this.state = { 
            showText: true, 
            testData: null,
            link: "http://default-environment.dczmz2y6rg.ap-southeast-2.elasticbeanstalk.com/api/dbaccess/initialisecharacter"
        };

    }
    
    render() {
        return <div>
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <button onClick={() => { this.postData("EXAMINE", 1)}}>Post Call</button>

            <button onClick={() => { this.getData("id", 1) }}>Get Data</button>

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
    // async callDbPost(url)
    // {
    //     var testQuery = JSON.stringify({ Action: 'PICKUP', Parameter: '4' });
    //     url += "?jsonStr=" + testQuery;

    //     var response = fetch(url, {
    //         method: 'POST',
    //         headers: {
    //             'Accept': 'application/json',
    //             'Content-Type': 'application/json'
    //         },
    //     });

    //     var json = response.json();
    //     console.log(json);
        
    //     this.testData = json;
 
    // }

    getData(_propertyName, _id) { //CHANGE ACCORDING TO DATA WANTED

        var dataRequestReturn = null; 

        fetch(this.state.link, {
            method: 'GET', 
            mode: 'cors',
            headers: {
                'Access-Control-Allow-Origin': "*"
            }
        }
        ).then(results => {
            return results.json(); 
        }).then(data =>{
            dataRequestReturn = data._propertyName._id; //CHECK DATA FORMAT
            console.log(dataRequestReturn); 
        })

        return dataRequestReturn; 
    }

    postData(_action, _parameter) {

        var postQuery = JSON.stringify({Action: _action, Parameter: _parameter}); 
        var response = fetch(this.state.link + postQuery, {
            method: 'POST'
        }); 

        return response; 
    }

    // async callDb(url) {

    //     var response = fetch(url, {
    //         method: 'GET'
    //     });
        
    //     var json = response.json();
    //     console.log(json);

    //     /*
    //     console.log(fetch("/Home/TestDbCallDelete", {
    //         method: 'GET'
    //     }).then(function (resp) {
    //         return resp.json();
    //     }).then(function (data) {
    //         console.log(data);
    //         //can call set state
    //         })
    //     );
    //     */
    // }
}

export default Counter; 
