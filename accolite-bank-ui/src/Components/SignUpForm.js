import { useState, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { AppContext } from './Store/AppContext';
import '../App.css'

export default function () {
	const context = useContext(AppContext);
	// States for registration
	const [name, setName] = useState('');
	const [email, setEmail] = useState('');
	const [password, setPassword] = useState('');
    const [dob, setDob] = useState('');
    const [gender, setGender] = useState('');
    const [contactNumber, setContactNumber] = useState('');
	// States for checking the errors
	const [submitted, setSubmitted] = useState(false);
	const [error, setError] = useState(false);
	const navigate = useNavigate();
	const [newUser, setNewUser] = useState({
		name: name,
		email: email,
		password: password,
		dob: dob,
		gender: gender,
		contactNumber: contactNumber
	})
	// Handling the name change
	const handleName = (e) => {
		setName(e.target.value);
		setNewUser({
			name: e.target.value,
			email: email,
			password: password,
			dob: dob,
			gender: gender,
			contactNumber: contactNumber
		})
		setSubmitted(false);
	};

	// Handling the email change
	const handleEmail = (e) => {
		setEmail(e.target.value);
		setNewUser({
			name: name,
			email: e.target.value,
			password: password,
			dob: dob,
			gender: gender,
			contactNumber: contactNumber
		})
		setSubmitted(false);
	};

	// Handling the password change
	const handlePassword = (e) => {
		setPassword(e.target.value);
		setNewUser({
			name: name,
			email: email,
			password: e.target.value,
			dob: dob,
			gender: gender,
			contactNumber: contactNumber
		})
		setSubmitted(false);
    };
    
    // Handling the date of birth change
	const handleDob = (e) => {
		setDob(e.target.value);
		setNewUser({
			name: name,
			email: email,
			password: password,
			dob: e.target.value,
			gender: gender,
			contactNumber: contactNumber
		})
		setSubmitted(false);
    };
    
    // Handling the Contact number change
	const handleContactNumber = (e) => {
		setContactNumber(e.target.value);
		setNewUser({
			name: name,
			email: email,
			password: password,
			dob: dob,
			gender: gender,
			contactNumber: e.target.value
		})
		setSubmitted(false);
    };
    
    	// Handling the Gender change
	const handleGender = (e) => {
		setGender(e.target.value);
		setNewUser({
			name: name,
			email: email,
			password: password,
			dob: dob,
			gender: e.target.value,
			contactNumber: contactNumber
		})
		setSubmitted(false);
	};

	// Handling the form submission
	const handleSubmit = (e) => {
		e.preventDefault();
		if (name === '' || email === '' || password === '' ||  contactNumber === '' ||  gender === '' ||  dob === '') {
			setError(true);
		} else {
			debugger;
			var x = context.createUser(newUser);
			x.then( r => {
				setSubmitted(true);
				navigate('/account');
			}).catch(e => {
				setError(false);
				alert(e.errorMessage);
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
				<h5>User {name} successfully registered!!</h5>
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
				<h1>User Registration</h1>
			</div>

			{/* Calling to the methods */}
			<div className="messages">
				{errorMessage()}
				{successMessage()}
			</div>

			<form>
				
                <div>
                    <label className="label">Name</label>
                    <input onChange={handleName} className="input"
                        value={name} type="text" />
                </div>

                <div>
                    <label className="label">Email</label>
                    <input onChange={handleEmail} className="input"
                        value={email} type="email" />
                </div>

                <div>
                    <label className="label">Contact Number</label>
                    <input onChange={handleContactNumber} className="input"
                        value={contactNumber} type="tel" />
                </div>

                <div>
                    <label className="label">Gender</label>
					<select className= "select" value={gender} onChange={handleGender}>
						<option value="">-- Select --</option>
						<option value="1">Male</option>
						<option value="3">Female</option>
						<option value="3">Others</option>
					</select>
                </div>

                <div>
                    <label className="label">Date Of Birth</label>
                    <input onChange={handleDob} className="input"
                        value={dob} type="date" />
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
