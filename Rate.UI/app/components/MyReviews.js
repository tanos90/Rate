import React from 'react';
import AddReview from './AddReview';
import Movie from './Movie';
import ReviewStore from "../stores/ReviewStore";
import ReviewActions from "../actions/ReviewActions";
import styled from 'styled-components';

export default class MyReviews extends React.Component {
    constructor() {
        super();
    }

    render() {
        const {reviews} = this.props;
        let posts =reviews.map((review)=> 
            <div  class="col-md-12 well" key={review.flick.title}>
                <Movie flick={review.flick}/> 
                <label for="review">Review:</label>
                <p name="review">{review.reviewText}</p>
            </div>
            );
        return (
            <div>{posts}</div>
        )
    }

}

const Image = styled.img`
  width : 15%;
  margin: 5px;
`;

