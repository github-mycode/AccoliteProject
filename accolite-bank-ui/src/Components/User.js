import React, { useState, useContext, useEffect, isValidElement } from 'react';
import { AppContext } from './Store/AppContext';
import { useNavigate } from 'react-router-dom';

const AccountType = {
  1:'Saving',
  2:'Current'
}

export default function User (){
  const context = useContext(AppContext);
  // State for new account input
  const [newAccount, setNewAccount] = useState({
    accountType: 1,
    initialBalance: 0
  });

  useEffect(() => {
    
    console.log('from effect', context.User.accounts);
    setNewAccount({accountType: 1,
      initialBalance: 0})
  }, [context.User, context.User.accounts]);

	const setNewAccountType = (e) => {
    
    setNewAccount({accountType: e,
    initialBalance: newAccount.initialBalance});
  };
  
  const setNewAccountBalance = (e) => {
    setNewAccount({initialBalance: e,
    accountType: newAccount.accountType});
  };
  
  const isValid = () => {
    if(newAccount.initialBalance<=100){
      alert("Minimum initial balance should be greter that 100$.")
      return false
    }
    return true;
  }
  const addAccount = () => {
    console.log('adding accounttt', newAccount);
    if(isValid()){
      context.addAccount(newAccount.initialBalance, newAccount.accountType, setNewAccountBalance);
      alert(`Account successfully Added!!`)
    }
  }

  return (
    <div>
      <h1>Welcome, {context.User.name}!</h1>
      <div>
        <span className = "add-data">Add New Account:</span>
        <label className ="margin" >Account Type:</label>

        <select className= "add-data-input" value={newAccount.accountType} onChange={(e) => setNewAccountType(e.target.value)}>
						<option value="1">Saving</option>
						<option value="2">Current</option>
					</select>
        <label className ="margin">Initial Balance:</label>
        <input
          className= "add-data-input"
          type="number"
          value={newAccount.initialBalance}
          onChange={(e) => setNewAccountBalance(e.target.value)}
        />
        <button className= "add-data-btn" onClick={addAccount}>Add Account</button>
      </div>
      
      <h2>Your Accounts:</h2>
      <table  className="accounts">
      <tr>
        <th>Account Type</th>
        <th>Account No.</th>
        <th>Balance</th>
        <th></th>
      </tr>
        {context.User?.accounts?.map((account) => (
            <AccountView data = {account} func={setNewAccountBalance}/>
        ))}
      </table>
    </div>
  );
};

const AccountView = (props) => {
  const context = useContext(AppContext);
  const navigate = useNavigate();
  const selectAccount = async (account) => {
    
    
    console.log('selecting Account')
    context.Account = account;
    await context.getTransactions();
    navigate('/transactions')
  }
  const deleteAccount = () => {
    var x = context.deleteAccount(props.data.accountId, props.func);
    if(x){
      alert('account deleted successfully!!')
    }
    else{
      alert('Error While deleting the account')
    }
  }
  return <tr>
    <td>{AccountType[props.data.accountType]}</td>
    <td>{props.data.accountId}</td>
    <td>{props.data.availableBalance}</td>
    <button onClick={() => deleteAccount()}>Delete</button>
    <button onClick={() => selectAccount(props.data)}>Show</button>
  </tr>
};