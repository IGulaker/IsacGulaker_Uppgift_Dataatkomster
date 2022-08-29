function submitNewUser(e){
    e.preventDefault()

    let SignUpFormJson = JSON.stringify(
        {
            newUserFirstName: e.target['firstName'].value,
            newUserLastname: e.target['lastName'].value,
            newUserEmailAddress: e.target['emailAddress'].value,
            newUserPhoneNumber: e.target['phoneNumber'].value,
            newUserAlternativePhoneNumber: e.target['alternativePhoneNumber'].value,
            newUserAddress: {
                newAddressCity: e.target['city'].value,
                newAddressPostalCode: e.target['postalCode'].value,
                newAddressStreetName: e.target['streetName'].value,
                newAddressResidenceNumber: e.target['residenceNumber'].value
            },
            newUserPassword: e.target['password'].value
    });

    fetch('https://localhost:7285/api/Authentication/SignUp?keY=e2a228d1-95a9-4ade-8eab-5c14f5a24573',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: SignUpFormJson
    });
}

function attemptLogin(e){
    e.preventDefault();

    let signInFormJson = JSON.stringify(
        {
            email: e.target['emailAddress'].value,
            password: e.target['password'].value
    });

    fetch('https://localhost:7285/api/Authentication/SignIn?keY=e2a228d1-95a9-4ade-8eab-5c14f5a24573',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },

        body: signInFormJson
    });
}

function optionalInputChange(e){

    if(e.target.value == ""){
        e.target.style.fontStyle = "italic";
    }
    else{
        e.target.style.fontStyle = "normal";
    }
}