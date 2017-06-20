import React from 'react';

import Categories from '../components/Categories';
import LoadMore from '../components/LoadMore';
import Posts from '../components/Posts';
import SearchFlick from '../components/SearchFlick';


export default class Home extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <div class="container">
                    <h4>Home</h4>
                    <hr/>
                    <div class="row">
                        <div class="col-md-8">

                            <Posts/>
                            
                            <LoadMore/>

                        </div>

                        <div class="col-md-4">

                            <SearchFlick history={this.props.router}/>

                            <Categories/>


                        </div>
                        
                    </div>
                </div>
            </div>
        );
    }
}