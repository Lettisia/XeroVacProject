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

    static getInfo(_scene) {
        switch(_scene) {
            case 1 || 3: //Office
                return this.getData("location", 1, "/initialiselocations");
            case 2: //Spooky House
                return this.getData("location", 2, "/initialiselocations");
            case 4: //Saloon
                return this.getData("location", 4, "/initialiselocations");
            
            case 5: //Cemetery
                return this.getData("location", 3, "/initialiselocations");
            
            case 6: //Main Street
                return this.getData("location", 5, "/initialiselocations");
            
            default:
                return "No scene"; 

        }
    }
}