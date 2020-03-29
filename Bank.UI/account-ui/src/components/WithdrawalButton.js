import React from 'react';
import styles from '../css/button.css'

class WithdrawalButton extends React.Component {
    callWithdrawal() {
      fetch('http://localhost:52233/api/Accounts/b8bfc789-ad06-4820-9f4a-906e90aa8d49/Withdrawal', {
        method: 'PUT',
        body: JSON.stringify({
          "amount": 250
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
          <button className="btn red" onClick={this.callWithdrawal}>Wypłać 250 zł</button>
          </div>
        )
      }
    }

    export default WithdrawalButton;