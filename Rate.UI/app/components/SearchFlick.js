import React from 'react';
import { Link, browserHistory, Router } from 'react-router';
import FlickActions from "../actions/FlickActions";

export default class SearchFlick extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            searchText: 'search'
        };
    }

    handleChange (e) {
        let {value} = e.target;
        if(value!==null&&value!=="")
         this.setState({ searchText: value });
        event.preventDefault();
    }

    getFlickByTitle() {
        let { searchText } = this.state;
        if(searchText !== "" && searchText !== null)
            FlickActions.getFlickByTitle(searchText);
    }

    render() {
        const style = {
            "max-width":"500px"
        };
        let value = "";
        return (
            <div>
                <h4>Movie or tv show By Title</h4>
                <div class="input-group" style={style}>
                    <input type="text" 
                           class="form-control" 
                           onChange = {this.handleChange.bind(this)}
                           onBlur = {this.getFlickByTitle.bind(this)}/>
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button" onClick = {this.getFlickByTitle.bind(this)}>
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>
        );


    }
}
