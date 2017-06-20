import React from 'react';
import styled from 'styled-components';

export default class Movie extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {      
        const {flick} = this.props;
        return (
            <div>
            {
                <div key={flick.title}>
                    <div class="container-fluid">
                        <Image class="col-md-1" src={flick.poster} alt="" />
                        <div class= "col-md-4"><h2>{flick.title}</h2>
                            <h3>{flick.year}</h3> 
                            <h3>{flick.imdbRating}/10 Score</h3>  
                        </div>
                    </div>
                    <div class="container-fluid">
                        <p>
                            <span class="glyphicon glyphicon-calendar" style={{marginRight: .5 + 'em'}}> </span>
                            Release on {flick.released}</p>
                        <p>{flick.plot}</p>
                    </div>
                </div>
            }

                
            </div>
        );
    }
}

const Image = styled.img`
  width : 15%;
  margin: 5px;
`;
