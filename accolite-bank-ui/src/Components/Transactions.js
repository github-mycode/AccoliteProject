import React, { useState, useContext, useEffect } from 'react';
import { AppContext } from './Store/AppContext';

const TransactionType = {
  1:'Deposit',
  2:'Withdrawl'
}

export default function Transactions (){
  const context = useContext(AppContext);
  // State for new Transactions input
  const [newTransactions, setNewTransactions] = useState({
    TransactionsType: 1,
    amount: 0
  });
  useEffect(() => {
    
    console.log('from effect', context.Account.transactions);
  }, [context.Account, context.Account.transactions]);


	const setNewTransactionsType = (e) => {
    setNewTransactions({TransactionsType: e,
    amount: newTransactions.amount});
  };
  
  const setNewTransactionsBalance = (e) => {
    setNewTransactions({amount: e,
    TransactionsType: newTransactions.TransactionsType});
  };
  
  const addTransaction = async () => {
    
    if(isValid())
      await context.addTransaction(newTransactions.amount, newTransactions.TransactionsType, setNewTransactionsBalance);
  }

  const isValid = () => {
    if (newTransactions.TransactionsType == 2 && context.Account.availableBalance*.9 <= newTransactions.amount){
      alert('Sorry! you can not withdraw more than 90% of your total balance.')
      return false;
    }
    if (newTransactions.TransactionsType == 2 && context.Account.availableBalance - newTransactions.amount <100){
      alert('Sorry! account can not have less than $100.')
      return false;
    }
    if (newTransactions.TransactionsType == 1 && newTransactions.amount > 10000){
      alert('Sorry! you can not deposit more than $10,000 in a single transaction.')
      return false;
    }
    return true;
  }

  return (
    <div>
      <h2>Account Id: {context.Account?.accountId}</h2>
      <h2>Account Balance: <b>${context.Account.availableBalance}</b></h2>
      <div>
        <span className = "add-data">Add New Transactions:</span>
        <label className ="margin" >Transactions Type:</label>
          <select className= "add-data-input" value={newTransactions.TransactionsType} onChange={(e) => setNewTransactionsType(e.target.value)}>
						<option value="1">Deposit</option>
						<option value="2">Withdrawl</option>
					</select>
        <label className ="margin">Amount:</label>
        <input
          type="number"
          className= "add-data-input"
          value={newTransactions.amount}
          onChange={(e) => setNewTransactionsBalance(e.target.value)}
        />
        <button className="add-data-btn" onClick={addTransaction}>Add Transactions</button>
      </div>
      
      <h2>Your Transactions:</h2>
      <table  className="accounts">
      <tr>
        <th>Transactions Id</th>
        <th>Transactions Type</th>
        <th>Amount</th>
        <th>Date</th>
      </tr>
        {context.Account?.transactions?.map((Transaction) => (
            <TransactionsView data = {Transaction}/>
        ))}
      </table>
    </div>
  );
};

const TransactionsView = (props) => {
  return <tr>
    <td>{props.data.transactionId}</td>
    <td>{TransactionType[props.data.depositType]}</td>
    <td>${props.data.amount}</td>
    <td>{props.data.transactionTime}</td>
  </tr>
};