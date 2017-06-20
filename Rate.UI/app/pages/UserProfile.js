import React from 'react';
import styled from 'styled-components';


export default class UserProfile extends React.Component {
    constructor() {
        super();
    }

    render() {
        const user = "Tanos";
        return (
            <div class="well">
                <h4>User: {user}</h4>
            </div>
        );
    }
};