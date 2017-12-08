export class Helper {
    constructor() {
        this.link = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com";
        this.getRequest = "/api/dbaccess"; 
    }

    static async getData(_propertyName, _id, _apiLink) {

        var myLine = "http://deathintombstone.ap-southeast-2.elasticbeanstalk.com/api/dbaccess"+ _apiLink; 
        console.log(myLine); 
        var results = await fetch(myLine, {
            method: 'GET', 
        }); 
        var json = await results.json(); 
        console.log(json); 
        return json[_id - 1]; 
    }

    static async postData(_action, _parameter) {
        
        var postQuery = JSON.stringify({Action: _action, Parameter: _parameter});  
        var result = await fetch("http://deathintombstone.ap-southeast-2.elasticbeanstalk.com" + "/command?jsonStr=" + postQuery, {
            method: 'GET'
        }); 
        var response = await result.json();
        console.log(response); 

        return response; 

    }; 

    static getInfo(_scene) {
        switch(_scene) {
            case 1 || 3: //Office
                return this.getData("location", 1, "/initialiselocations");
                console.log(this.state.scene);
                console.log(this.state.scene.verboseDescription);
            case 2: //Spooky House
            return this.getData("location", 2, "/initialiselocations");
            case 4: //Saloon
            return this.getData("location", 4, "/initialiselocations");
            
            case 5: //Cemetery
            return this.getData("location", 3, "/initialiselocations");
            
            case 6: //Main Street
            return this.getData("location", 5, "/initialiselocations");
            
            default:
            return 

        }
    }
}

