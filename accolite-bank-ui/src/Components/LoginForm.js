import { useState, useContext } from 'react';
import '../App.css'
import { useNavigate } from 'react-router-dom';
import { AppContext } from './Store/AppContext';

export default function () {

	// States for registration
	const navigate = useNavigate();
	const context = useContext(AppContext);
	const [email, setEmail] = useState('');
	const [password, setPassword] = useState('');

	// States for checking the errors
	const [submitted, setSubmitted] = useState(false);
	const [error, setError] = useState(false);


	// Handling the email change
	const handleEmail = (e) => {
		setEmail(e.target.value);
		setSubmitted(false);
	};

	// Handling the password change
	const handlePassword = (e) => {
		setPassword(e.target.value);
		setSubmitted(false);
	};

	// Handling the form submission
	const handleSubmit = (e) => {
		e.preventDefault();
		if (email === '' || password === '') {
			setError(true);
		} else {
			debugger;
			var x = context.loginUser(email, password);
			x.then( r => {
				if(r){
					setSubmitted(true);
					navigate('/account');
				}
				else{
					alert('Please Enter a valid Email and Password');
				}
			}).catch(e => {
				setError(false);
			})		
		}
	};

	// Showing success message
	const successMessage = () => {
		return (
			<div
				className="success"
				style={{
					display: submitted ? '' : 'none',
				}}>
				<h5>User successfully Loggedin!!</h5>
			</div>
		);
	};

	// Showing error message if error is true
	const errorMessage = () => {
		return (
			<div
				className="error"
				style={{
					display: error ? '' : 'none',
				}}>
				<h5>Please enter all the fields</h5>
			</div>
		);
	};

	return (
		<div className="form">
			<div>
				<h1>Login</h1>
			</div>

			{/* Calling to the methods */}
			<div className="messages">
				{errorMessage()}
				{successMessage()}
			</div>

			<form>

                <div>
                    <label className="label">Email</label>
                    <input onChange={handleEmail} className="input"
                        value={email} type="email" />
                </div>

                <div>
                    <label className="label">Password</label>
                    <input onChange={handlePassword} className="input"
                        value={password} type="password" />
                </div>


				<button onClick={handleSubmit} className="btn"
						type="submit">
					Submit
				</button>
			</form>
		</div>
	);
}
