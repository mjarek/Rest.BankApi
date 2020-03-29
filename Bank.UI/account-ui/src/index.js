import React from 'react';
import ReactDOM from 'react-dom';
import DepositButton from './components/DepositButton'
import WithdrawalButton from './components/WithdrawalButton'
import ResultTable from './components/ResultTable'
import './index.css';
import * as serviceWorker from './serviceWorker';


ReactDOM.render(
  <React.StrictMode>
     <div
      style={{
          position: 'absolute', left: '50%', top: '50%',
          transform: 'translate(-50%, -50%)'
      }}
    >
        <DepositButton />
        <WithdrawalButton/>
        <ResultTable/>
    </div>,
  </React.StrictMode>,
  document.getElementById('root')
);


serviceWorker.unregister();

