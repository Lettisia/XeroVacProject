import React, {Component} from 'react'; 


export class Character extends Component {
    constructor() {
        super(); 
        this.state = {
            characters: 'Default'
        }; 
    }; 

    componentDidMount() {
        fetch('./jsonExample/example.json'
        ).then(results => {
            return results.json();
        }).then(data => {
            this.setState({character: data.character.name})
            console.log("fetch complete");
        }); 
    }

    render() {
        return (
            <div> 
                <div>
                    {this.state.character}
                </div>
            </div>
        ); 
    }

}