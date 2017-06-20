import React from 'react';
import SearchFlick from './SearchFlick';
import FlickStore from "../stores/FlickStore";
import Movie from './Movie';
import ReviewActions from "../actions/ReviewActions";
import AddReview from "./AddReview";

export default class AddReviewContainer extends React.Component {

    constructor (props) {
        super(props);
        this.getFlick = this.getFlick.bind(this);
        this.state = { 
            flick : { 
                title: ''
            }, 
            showMovie: false, 
            reviewText:"",
            showReviewForm: false,
        }
    }

    componentWillMount () {
        FlickStore.addChangeListener(this.getFlick);
    }

    componentWillUnmount() {       
        FlickStore.removeChangeListener(this.getFlick);
    }

    getFlick(){
        let flick = FlickStore.getFlick();
        this.setState({ 
            flick : flick, 
            showMovie: true
        });
    }

    addReview(){
        let {flick} = this.state;
        let review = {
            reviewText : this.state.reviewText,
            flick_Id : flick.id,
            id : +new Date()
        } 
        ReviewActions.createReview(review);
        resetAddReview(); 
    }

    resetAddReview(){
        this.setState({showMovie: false});
        toggleAddReview();
    }

    handleText(value){  
        this.setState({reviewText:value});
    }

    toggleAddReview() {
        this.setState({showReviewForm: !this.state.showReviewForm});
    }

    render() {
        let {flick, showReviewForm, showMovie} = this.state;

        return (
            <AddReview 
                flick={flick} 
                showReviewForm = {showReviewForm}
                showMovie = {showMovie}
                handleText ={this.handleText.bind(this)} 
                toggleAddReview= {this.toggleAddReview.bind(this)}
                addReview={this.addReview.bind(this)}
                resetAddReview={this.resetAddReview.bind(this)}/>
        )
    }

}
