import React from 'react';

export default class LoadMore extends React.Component {
    constructor() {
        super();
        this.state = {};
    }

    handleChange(e) {
        const searchText = e.target.value;
        this.props.SearchFlick(searchText);
    }

    render() {
        return (
            <div>
                <button type="button" class="btn btn-block">Load More</button>
            </div>
        );
    }
}