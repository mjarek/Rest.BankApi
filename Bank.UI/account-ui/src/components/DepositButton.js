import React from 'react';
import styles from '../css/button.css'

class DepositButton extends React.Component {
    callDeposit() {
      fetch('http://localhost:52233/api/Accounts/b8bfc789-ad06-4820-9f4a-906e90aa8d49/Deposit', {
        method: 'PUT',
        body: JSON.stringify({
          "amount": 1000
        }),
        headers: {
          "Content-type": "application/json; charset=UTF-8"
        }
      })
    .then(response =>response.json())
    .then(response => {
    
      console.log(response)
    })
      }
      render(){
        return (
          <div>
            <button className="btn green" onClick={this.callDeposit}>Deposit 1000 zł</button>
          </div>

        )
      }
    }

    export default DepositButton;