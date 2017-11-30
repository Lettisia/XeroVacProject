import React from 'react'; 
import ReactDOM from 'react-dom'; 
import './index.css'; 
import {Character} from './components/homePage.js'; 

class App extends React.Component {
    render() {
        return(
            //<h1>Howdy Partner!</h1>
            <div>
                <Character/>
            </div>
        );
    }
}

ReactDOM.render(
    <App />, 
    document.getElementById('root')
); 
