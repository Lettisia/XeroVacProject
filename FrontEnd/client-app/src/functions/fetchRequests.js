export class Helper {
    constructor() {
        this.link = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com";
        this.getRequest = "/api/dbaccess"; 
    }

     static async getData(_propertyName, _id, _apiLink) {

        var myLine = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com/api/dbaccess"+ _apiLink; 
        console.log(myLine); 
        var result = await fetch(myLine, {
            method: 'GET', 
        });
        var json =  await result.json();
        console.log(json)
        return json;
        /*
        ).then(results => {
            return results.json(); 
        }).then(data =>{ 
            console.log("fetch complete"); 
            console.log(data[_id - 1]); 
            return data[_id - 1]; 
        });*/
    }

    static postData(_action, _parameter) {
        
        // var fetchResponse = null; 
        var postQuery = JSON.stringify({Action: _action, Parameter: _parameter});  
        fetch(this.state.link + "/command?jsonStr=" + postQuery, {
            method: 'GET'
        }).then(response => {
            return response.text(); 
        }).then(data => {
            return data; 
            console.log(data); 
        });
    }; 
}