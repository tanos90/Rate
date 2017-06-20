import React from 'react';

import Footer from './Footer';
import Navbar from './Navbar';


export default class Layout extends React.Component {

    render() {
        return (
            <div>
                <Navbar history={this.props.router}/>
                {this.props.children}
            </div>
        );
    }
}