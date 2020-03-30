import React from 'react';
import styles from '../css/button.css'

class DepositButton extends React.Component {

  render() {
    return (
      <div>
        <button className="btn green" onClick={this.props.onClickHandler}>Deposit 1000 zł</button>
      </div>

    )
  }
}

export default DepositButton;