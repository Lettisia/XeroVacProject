import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Counter } from './Counter';
 

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Hello, world!</h1>
            <p><script>document.body.innerHTML = (testData);</script></p>
        </div>;
    }
}
