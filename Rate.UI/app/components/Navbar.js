import React from 'react';
import styled from 'styled-components';
import {Link} from 'react-router';
import menus from './config/menu.json';


export default class Navbar extends React.Component {
   
    constructor(props) {
        super(props);
        this.state = {
           collapsed : true
        };

    }

    handleClick() {
        window.location = '/';
    }
    toggleCollapse(){
        const collapsed = !this.state.collapsed;
        this.setState({collapsed});
    }
    
    isActive  = (currentPath, menuPath) => (currentPath.indexOf(menuPath) > -1) ;

    render() {
        const user = "Tanos";
        const {history} = this.props;
        const {location} = history;
        const {collapsed} = this.state;

        const navClass = collapsed ? "collapse" : "";

        const menuOptions = menus.map((menu) => 
            <li className= { this.isActive(location.pathname,menu.route) ? "active" : ""}
                    key={menu.title}>
                <Link to={menu.route}> {menu.title} 
                </Link>
            </li>
        );
        
        return ( 
            <Wrapper>
            <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" onClick = { this.toggleCollapse.bind(this) }>
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <Button class="navbar-brand" onClick = { this.handleClick.bind(this) }> MeinFlix </Button>    
                    </div>
                    <div class={"navbar-collapse " + navClass } id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav">
                            {menuOptions}
                        </ul> 
                        <ul class ="nav navbar-nav navbar-right">
                            <li>
                                <StyledLink>{user}</StyledLink>
                            </li>
                        </ul>
                    </div>
                    <div>
                        
                    </div>
                </div>
            </nav>
            </Wrapper>
        );
    }
}

const Button = styled.button `
  background: red;
  color: white !important;
  font-size: 1.1em;
  margin: 0px;
  padding: 2px 5px;
  border: 2px solid white;
  border-radius: 3px;
  position:relative; 
`;

const Wrapper = styled.header `
  padding: 5px;
`;

const StyledLink = styled(Link)`
        color: tomato;
        display: block;
        margin: 0.25em 0;
        font-family: Helvetica, Arial, sans-serif;

        &:hover {
            text-decoration: underline;
        };
        `;