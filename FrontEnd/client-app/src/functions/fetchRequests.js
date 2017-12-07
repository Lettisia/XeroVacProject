export class Helper {
    constructor() {
        this.link = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com";
        this.getRequest = "/api/dbaccess"; 
    }

    static getData(_propertyName, _id, _apiLink) {

        var myLine = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com/api/dbaccess"+ _apiLink; 
        console.log(myLine); 

        var results = fetch(myLine, {
            method: 'GET'
        }).then(result => {
            return result.json();
        }).then(data => {
            return data[_id - 1]; 
        })
        return results; 
    }

    static postData(_action, _parameter) {
        
        var postQuery = JSON.stringify({Action: _action, Parameter: _parameter});  
        fetch(this.state.link + "/command?jsonStr=" + postQuery, {
            method: 'GET'
        }).then(response => {
            return response.text(); 
        }).then(data => {
            return data;  
        });
    }; 
}