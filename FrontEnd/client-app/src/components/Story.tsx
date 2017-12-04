import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Story extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return (
        <div>
            <h1>Where the story displays</h1>
        </div>
        );
    }
}

// A '.tsx' file enables JSX support in the TypeScript compiler,
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
