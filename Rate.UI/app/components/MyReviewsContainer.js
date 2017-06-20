import React, { Component } from 'react';
import {Container} from 'flux/utils';
import ReviewActions from '../actions/ReviewActions';
import ReviewStore from '../stores/ReviewStore';
import MyReviews from './MyReviews';
import AddReviewContainer from './AddReviewContainer';

export default class MyReviewsContainer extends Component {

   constructor() {
        super();
        this.getReviews = this.getReviews.bind(this);
        this.state = {
            reviews: ReviewStore.getAll()
        };
    }

    componentWillMount () {
        ReviewStore.addChangeListener(this.getReviews);
        ReviewActions.fetchReviews();
    }

    componentWillUnmount(){
        ReviewStore.removeChangeListener(this.getReviews);
    }

    getReviews(){
        this.setState({
            reviews : ReviewStore.getAll()
        })
    }

    render() {
        const {reviews} = this.state;
        return (
            <div class="container">
                <div class="col-md-12">
                    <AddReviewContainer/>
                </div>
                <MyReviews reviews = {reviews}/>
            </div>           
        )
    }
};
