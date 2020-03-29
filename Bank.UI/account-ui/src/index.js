import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import DepositButton from './components/DepositButton'
import WithdrawalButton from './components/WithdrawalButton'

import * as serviceWorker from './serviceWorker';


ReactDOM.render(
  <React.StrictMode>
    <DepositButton />
    <WithdrawalButton/>
  </React.StrictMode>,
  document.getElementById('root')
);


serviceWorker.unregister();

