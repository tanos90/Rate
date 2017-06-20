import React from 'react';
import ReviewStore from "../stores/ReviewStore";
import styled from 'styled-components';

export default class Posts extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            reviews: ReviewStore.getAll()
        };
    }

    componentWillMount () {  
        ReviewStore.addChangeListener(this.getReviews);
    }

    getReviews(){
        this.setState({
            reviews : ReviewStore.getAll()
        });
    }

    handleChange(e) {
        const searchText = e.target.value;
        this.props.SearchFlick(searchText);
    }

    render() {
        const {reviews} = this.state;
        const posts = reviews.map((review)=> 
            <div key={review.Title}>
                 <Movie movie={review}/> 
            </div>
        );

        return (
            <div class="well">
                {posts}       
            </div>
        );
    }
}

const Image = styled.img`
    transform: scale(0.5);
`;
