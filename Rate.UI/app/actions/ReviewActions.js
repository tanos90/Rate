import AppDispatcher  from "../AppDispatcher";
import constants from '../actionConstants';
import RateFlixAPI from '../api/RateFlixAPI';

let ReviewActions = {
    createReview(review) {
        console.log(constants);
        AppDispatcher.dispatchAsync(RateFlixAPI.createReview(review), {
            request: constants.CREATE_REVIEW,
            success: constants.CREATE_REVIEW_SUCCESS,
            failure: constants.CREATE_REVIEW_ERROR
        });
    },

    fetchReviews() {
        AppDispatcher.dispatchAsync(RateFlixAPI.fetchReviews(), {
            request: constants.FETCH_REVIEWS,
            success: constants.FETCH_REVIEWS_SUCCESS,
            failure: constants.FETCH_REVIEWS_ERROR
        }, {});
    }
};

export default ReviewActions;
