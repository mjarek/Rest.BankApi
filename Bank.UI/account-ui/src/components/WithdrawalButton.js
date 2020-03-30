import React from 'react';
import styles from '../css/button.css'

class WithdrawalButton extends React.Component {
    
      render(){
        return (
          <div>
          <button className="btn red" onClick={this.props.onClickHandler}>Withdrawal 250 zł</button>
          </div>
        )
      }
    }

    export default WithdrawalButton;