import React from 'react';
import DepositButton from './DepositButton'
import WithdrawalButton from './WithdrawalButton'
import ResultTable from './ResultTable'

class AppContainer extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            balance: '',
            status: '',
            message: ''
        }
        this.callWithdrawal = this.callWithdrawal.bind(this)
        this.callDeposit = this.callDeposit.bind(this)
    }
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
            .then(response => response.json())
            .then(response => {
                this.setState({ balance: response.balance, status: response.statusProduct, message: response.message })
            })
    }

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
            .then(response => response.json())
            .then(response => {
                this.setState({ balance: response.balance, status: response.statusProduct, message: response.message })
            })
    }
    render() {
        console.log(this.state)
        return (
            <div
                style={{
                    position: 'absolute', left: '50%', top: '50%',
                    transform: 'translate(-50%, -50%)'
                }}
            >
                <DepositButton onClickHandler={this.callDeposit} />
                <WithdrawalButton onClickHandler={this.callWithdrawal} />
                <ResultTable balance={this.state.balance} status={this.state.status} message={this.state.message} />
            </div>
        )
    }
  }

  export default AppContainer;
