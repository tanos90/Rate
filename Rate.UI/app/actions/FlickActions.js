import AppDispatcher  from "../AppDispatcher";
import constants from "../actionConstants";
import RateFlixAPI from '../api/RateFlixAPI';

let FlickActions = {

    getFlickByTitle(title) {
        AppDispatcher.dispatchAsync(RateFlixAPI.getFlickByTitle(title), {
            request: constants.FETCH_FLICK,
            success: constants.FETCH_FLICK_SUCCESS,
            failure: constants.FETCH_FLICK_ERROR
        }, {title});
    }
};

export default FlickActions;

