import React from 'react';
import SearchFlick from './SearchFlick';
import Movie from './Movie';

export default class AddReview extends React.Component {

    constructor (props) {
        super(props);
    }

    handleText(e){
        const {value} = e.target;
        this.props.handleText(value);
    }

    getFlick(){
        let flick = FlickStore.getFlick();
        this.setState({ 
            flick : flick, 
            showMovie: true
        });
    }

    render() {
        let {flick, toggleAddReview, addReview, showMovie, reviewText, showReviewForm} = this.props;
        
        const addReviewStyle = { 
            "margin":"20px"
        };

        let AddReviewForm = <form class="form-horizontal" onSubmit={addReview.bind(this)}>
                <div class="well">
                    <div class="form-group">
                        <SearchFlick class="form-control" />
                    </div>
                    { 
                        showMovie ? 
                        <div class="form-group">
                            <Movie flick={flick}/> 
                            
                            <div class="form-group col-md-12">
                                <label for="review">Review:</label>
                                <textarea value={reviewText} 
                                        onBlur={this.handleText.bind(this)} 
                                        name="review" 
                                        class="form-control" 
                                        rows="5" 
                                        id="review">
                                </textarea>
                                <button type="submit" class="btn btn-primary">Submit</button>   
                            </div>
                        </div>
                        : null    
                    }         
                </div>
            </form>;

        return (
            <div>
            <button class="btn" onClick={toggleAddReview}  style={addReviewStyle} >Add new review</button>
            {showReviewForm ?<div>{AddReviewForm}</div> : null }   
            </div>
        )
    }

}
