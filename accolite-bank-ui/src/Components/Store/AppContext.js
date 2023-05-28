import React from "react";
import APIHelper from "../utility/ApiHelper";
export const AppContext = React.createContext({
  UserId: "",
  User: {},
  AccountId: "Test",
  AccountList: [],
  Account: {},

  createUser: async function(user){
    var res = await APIHelper.createUser(user);
    if(res.status == 200){
      this.User = res.data;
      return true;
    }
    else{
      alert(`Error While Creating User ${res.statusText}`);
      return false;
    }
  },

  loginUser: async function(email, password){
    var res = await APIHelper.loginUser(email, password);
    if(res.status == 200 && res.data.userId){
        this.User = res.data;
        var res = await this.getAccountByUserId();
        return true;
    }
    else{
      return false;
    }
  },

  addAccount: async function(balance, type, setNewAccountBalance){
    var res = await APIHelper.addAccount(this.User.userId, balance, type);
    if(res.status == 200){
      await this.getAccountByUserId();
      setNewAccountBalance(0);
      return true;
    }
    else{
      return false;
    }
  },

  deleteAccount: async function(accountId, set){
    var res = await APIHelper.deleteAccount(accountId); 
    if(res.status == 200){
      await this.getAccountByUserId();
      set(0);
      return true;
    }
    else{
      return false;
    }
  },

  addTransaction: async function(amount, type, setNewTransactionsBalance){
    
    var res = await APIHelper.addTransaction(this.Account.accountId, type, amount);
    debugger;
    if(res?.status == 200){
      var transactions = await this.getTransactions();
      var account = await APIHelper.getAccount(this.Account);
      this.Account.availableBalance = account.availableBalance;
      setNewTransactionsBalance(0);
    }
    else{
      return false;
    }
  },

  getAccountByUserId: async function () {
    await APIHelper.getAccountList(this.User.userId, this.User);
  },

  getTransactions: async function () {
    return await APIHelper.getTransactionsList(this.Account.accountId, this.Account);
  },
});
