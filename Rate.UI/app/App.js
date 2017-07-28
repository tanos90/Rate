import React from "react";
import ReactDOM from "react-dom";
import { Router, Route, IndexRoute, hashHistory} from "react-router";

//Components
import About from './Pages/About';
import Home from './Pages/Home';
import Layout from './components/Layout';
import MyReviewsContainer from './components/MyReviewsContainer';
import Movie from './components/Movie';
import UserProfile from './Pages/UserProfile';
import menu from './components/config/menu.json';

const app = document.getElementById('app');

const componentRegistry = {
    "Movie": Movie,
    "MyReviewsContainer": MyReviewsContainer
}

const routesFromConfig = menu.map( (menu) => 
        <Route key={menu.route} path={menu.path} name={menu.routeName} components={componentRegistry[menu.component]}/>
);

const routes = (  
    <Router history={hashHistory}>
        <Route path="/" component={Layout}>
            <IndexRoute component={Home}></IndexRoute>
            <Route path="about" name="about" component={About}/>
            <Route path="MyReviews" name="reviews" component={MyReviewsContainer}/>
            <Route path="userprofile" name="userprofile" component={UserProfile}/>
            {routesFromConfig}
        </Route>
    </Router>
);

ReactDOM.render(routes,app);