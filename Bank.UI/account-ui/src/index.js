import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

import * as serviceWorker from './serviceWorker';


class MyButton extends React.Component {
constructor(props){
  super(props)
  this.state = {
    color: 'green'
  };
}
getStatus() {
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
      <button onClick={this.getStatus}>Wpłać 1000 zł</button>
      </div>
    )
  }
}

class WithdrawalButton extends React.Component {
  constructor(props){
    super(props)
    this.state = {
      color: 'green'
    };
  }
  withdrawal() {
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
        <button onClick={this.withdrawal}>Wypłać 250 zł</button>
        </div>
      )
    }
  }



ReactDOM.render(
  <React.StrictMode>
    <MyButton />
    <WithdrawalButton/>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();

