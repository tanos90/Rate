import AppDispatcher from "../AppDispatcher";
import RateFlixAPI from '../api/RateFlixAPI';
import constants from '../actionConstants';
import { EventEmitter } from "events";
import ReviewActions from "../actions/ReviewActions";
import update from 'react-addons-update';
import 'babel-polyfill';

const CHANGE_EVENT = 'change_flick';

class FlickStore extends EventEmitter {

    constructor(){
        super()
        this.flick = {};
    }

    getFlick = () => this.flick;
    
    setFlick (flick){
        this.flick = flick;
    }
    
    emitChange() { 
        console.log("entro");
        this.emit(CHANGE_EVENT);
    }

    addChangeListener(callback) {
        console.log("entro");
        this.on(CHANGE_EVENT, callback)
    }

    removeChangeListener(callback) {
        this.removeListener(CHANGE_EVENT, callback)
    }

    handleActions(action){
        const self = this;
        switch(action.type){
            case constants.FETCH_FLICK_SUCCESS: 
                self.setFlick(action.payload.response);
                self.emitChange();
                break;
        }
    }
}

const flickStore = new FlickStore;
AppDispatcher.register(flickStore.handleActions.bind(flickStore));
export default flickStore;