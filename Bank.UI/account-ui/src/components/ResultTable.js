import React from 'react';

class ResultTable extends React.Component {
    constructor(props){
      super(props)
    }
  formatStatus() {
    const result = this.props.status == 1 ? 'Open' : (this.props.status == 2 ? 'Freeze' : (this.props.status == 3 ? 'Close' : 'Undefined'))
    return result
  }
      render(){
        return (
          <div>
          <p><b>Your status account is :</b></p>
            <p>Status : {this.formatStatus()}</p>
            <p>Balance :{this.props.balance}</p>
            <p>Message :{this.props.message}</p>
          </div>
          
        )
      }
    }

    export default ResultTable;