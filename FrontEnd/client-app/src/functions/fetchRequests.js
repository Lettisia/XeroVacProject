export class Helper {
    constructor() {
        this.link = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com";
        this.getRequest = "/api/dbaccess"; 
    }

<<<<<<< HEAD
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
=======
    static async getData(_propertyName, _id, _apiLink) {

        var myLine = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com/api/dbaccess"+ _apiLink; 
        console.log(myLine); 
        var results = await fetch(myLine, {
            method: 'GET', 
        }); 
        var json = await results.json(); 
        console.log(json); 
        return json[_id - 1]; 
>>>>>>> d58abf8a674753ca3bc8909f1873463eadb1e9a6
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