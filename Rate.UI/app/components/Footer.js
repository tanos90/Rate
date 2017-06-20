import React from 'react';

export default class Footer extends React.Component {

    getYear = () => new Date().getFullYear();

    render() {

        return (
            <footer>
                <div class="row">
                    <div class="col-lg-12">
                        <p>Copyright &copy; Your Website {this.getYear()}</p>
                    </div>
                </div>
            </footer>
        );
    }
}
