import React from 'react'; 
import ReactDOM from 'react-dom'; 
import './index.css';


function GameStart(props) {
    return <h1>Death in Tombstone</h1>;
}



class App extends React.Component {
    constructor(){
        super();
        this.state ={
        }
    }

    handleClick(event) {
        console.log('this is:', this);
        alert('button clicked');
    }

    render() {
        return ( <div>
            <h1>Howdy Partner!</h1>
            <button onClick={this.handleClick}>Please work</button>
            <GameStart /> 
            </div>
        
        );

    }

}




ReactDOM.render(
    <App />,
    document.getElementById('root')
); 