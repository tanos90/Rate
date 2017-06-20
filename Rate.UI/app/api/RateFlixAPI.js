import 'whatwg-fetch';
import axios from 'axios';
import 'babel-polyfill';
import constants from '../constants';
import {buildUrl} from '../Utilities/Utilities';

//const API_URL = 'http://kanbanapi.pro-react.com';     //The API_URL has moved into the constants file 
const API_HEADERS = {
  'Content-Type': 'application/json',
  Authorization: 'any-string-you-like',
  'Access-Control-Allow-Origin': '*',
  'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
  'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token'
}

let RateFlixAPI = {
  fetchReviews() {
    return axios.get(`${constants.API_URL}/reviews`)
    .then((response) => response.data)
  },
  createReview(review) {
    debugger;
    return axios.post(`${constants.API_URL}/review`, review).then(function(){
    });
  },
  getFlickByTitle(title){
    const self = this;
    const url = buildUrl(`${constants.API_URL}/flick`,({ title:title }));
    return axios.get(url)
                .then((response) => response.data);
  }

};

export default RateFlixAPI;
