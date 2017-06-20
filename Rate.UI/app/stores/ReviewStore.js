import { EventEmitter } from "events";

import AppDispatcher from "../AppDispatcher";
import constants from '../actionConstants';
import RateFlixAPI from '../api/RateFlixAPI';

import update from 'react-addons-update';

const CHANGE_EVENT = 'change';

class ReviewStore extends EventEmitter {
    constructor(){
        super()
        this.reviews = [
        ];
    }

    getAll =  () => this.reviews;


    setReviews (reviews) {
        const self = this;
        this.reviews = reviews; 
    }

    emitChange() { 
        this.emit(CHANGE_EVENT);
    }

    addChangeListener(callback) {
        this.on(CHANGE_EVENT, callback)
    }

    removeChangeListener(callback) {
        this.removeListener(CHANGE_EVENT, callback)
    }

    handleActions(action){
        const self = this;
        switch(action.type){
            case constants.CREATE_REVIEW_SUCCESS:
                console.log("entro");
                ReviewActions.fetchReviews();
                self.emitChange();
                break;
            case constants.CREATE_REVIEW_ERROR:
                alert(action.message);
                break;
            case constants.FETCH_REVIEWS_SUCCESS:
                self.setReviews(action.payload.response);
                self.emitChange();
                break;
            case constants.FETCH_REVIEWS_ERROR:
                alert(action.message);
                break;
            default: 
        }
    }

}
const reviewStore = new ReviewStore;
AppDispatcher.register(reviewStore.handleActions.bind(reviewStore));
export default reviewStore;
