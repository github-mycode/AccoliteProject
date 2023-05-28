import axios from "axios";

const domain = "https://localhost:7293";
export default class APIHelper {

  static async createUser(user){
    const requestData = {
      name: user.name,
      password: user.password,
      dateOfBirth: user.dob,
      gender: parseInt(user.gender),
      email: user.email,
      contactNumber: user.contactNumber
    };
    //const requestJson = JSON.stringify(requestData);
    

    const options = {
      //headers: {'X-Custom-Header': 'value'}
      headers: {'accept': 'text/plain', 'Content-Type': 'application/json'}
     };
     try{
      var x = await axios.post(`${domain}/api/Users/register`, requestData, options);
      return x;
     }
     catch(err){
        
    }
  }

  static async loginUser(email, password){
    const requestData = {
      password: password,
      emailId: email
    };
    

    const options = {
      //headers: {'X-Custom-Header': 'value'}
      headers: {'accept': 'text/plain', 'Content-Type': 'application/json'}
     };
     try{
      var x = await axios.post(`${domain}/api/Users/login`, requestData, options);
      return x;
     }
     catch(err){
        
    }
  }

  static async addAccount(userId, balance, type){
    const requestData = {
      userId: userId,
      availableBalance: parseInt(balance),
      accountType: parseInt(type)
    };
    

    const options = {
      //headers: {'X-Custom-Header': 'value'}
      headers: {'accept': 'text/plain', 'Content-Type': 'application/json'}
     };
     try{
      var x = await axios.post(`${domain}/api/Accounts/create-account`, requestData, options);
      return x;
     }
     catch(err){
        
    }
  }

  static async deleteAccount(accountId){
    const requestData = accountId;
    
    const options = {
      //headers: {'X-Custom-Header': 'value'}
      headers: {'accept': 'text/plain', 'Content-Type': 'application/json'}
     };
     try{
      var x = await axios.delete(`${domain}/api/Accounts/delete-account?accountId=${accountId}`);
      return x;
     }
     catch(err){
        
    }
  }


  static async addTransaction(accountId, depositType, amount){
    const requestData = {
      accountId: accountId,
      depositType: parseInt(depositType),
      amount: parseInt(amount),
      accountType: 1
    };
    

    const options = {
      //headers: {'X-Custom-Header': 'value'}
      headers: {'accept': 'text/plain', 'Content-Type': 'application/json'}
     };
     try{
      var x = await axios.post(`${domain}/api/Transactions/add-transaction`, requestData, options);
      return x;
     }
     catch(err){
        
    }
  }
  // static getAccountList(userId) {
  //   return axios
  //     .get(`${domain}/api/Accounts/get-all-account-by-userid?userId=${userId}`)
  //     .then((response) => {
  //       return response.data;
  //     })
  //     .catch((err) => {
  //       return [];
  //     });
  // }

  static async getAccountList(userId, user){
    
     try{
      var x = await axios.get(`${domain}/api/Accounts/get-all-account-by-userid?userId=${userId}`);
      user.accounts = x.data;
      return x.data;
     }
     catch(err){
        
    }
  }

  static async getAccount(account){
    
    try{
     var x = await axios.get(`${domain}/api/Accounts/get-account-detail-by-accountid?accountId=${account.accountId}`);
     return x.data;
    }
    catch(err){
       
   }
 }

  static async getTransactionsList(accountId, account){
    
     try{
      var x = await axios.get(`${domain}/api/Transactions/get-all-transaction?AccountId=${accountId}`);
      account.transactions = x.data;
      return x.data;
     }
     catch(err){
        
    }
  }

}
