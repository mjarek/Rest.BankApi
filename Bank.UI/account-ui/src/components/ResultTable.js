import React from 'react';

class ResultTable extends React.Component {
    constructor(props){
      super(props)
   
    }
      render(){
        return (
          <div>
          <p><b>Your status account is :</b></p>
            <p>Status : {this.props.status}</p>
            <p>Balance :{this.props.balance}</p>
          </div>
          
        )
      }
    }

    export default ResultTable;