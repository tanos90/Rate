import React from 'react';
import { Link } from 'react-router';
import styled from 'styled-components';


const StyledLink = styled(Link)`
        color: tomato;
        display: block;
        margin: 0.5em 0;
        font-family: Helvetica, Arial, sans-serif;

        &:hover {
            text-decoration: underline;
        }
        `;

export default class Categories extends React.Component {
    constructor() {
        super();
        this.state = {
            categories: [
                {
                    name: "Test"
                }, {
                    name: "Test2"
                }
            ]
        };
    }

    onSelect = (e) => { console.log(e);} 

    
    render() {
        const {categories} = this.state;

        let listCategories = categories.map(category => 
                                    <li className={category.name === this.selection ? 'selected' : ''}
                                        key={category.name}
                                        onClick={() => this.onSelect(category.name)}>
                                        <StyledLink>{category.name}</StyledLink>
                                    </li>)
        return (
            <div class="well">
                <h4>Categories</h4>
                <div class="row">
                    <div class="col-lg-6">
                        <ul class="list-unstyled">
                            {listCategories}
                        </ul>
                    </div>
                    <div class="col-lg-6"></div>
                </div>
            </div>
        );
    }
}