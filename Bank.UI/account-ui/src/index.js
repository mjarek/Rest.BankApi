import React from 'react';
import ReactDOM from 'react-dom';
import AppContainer from './components/AppContainer'

import './index.css';
import * as serviceWorker from './serviceWorker';



ReactDOM.render(
  <React.StrictMode>
    
        <AppContainer />
       ,
  </React.StrictMode>,
  document.getElementById('root')
);


serviceWorker.unregister();

