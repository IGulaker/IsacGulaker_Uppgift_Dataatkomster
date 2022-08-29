localStorage.setItem('apiAccessKey', 'e2a228d1-95a9-4ade-8eab-5c14f5a24573');
localStorage.setItem('apiAdminAccessKey', '76dafbb3-465c-4922-8cf5-19c819362f16');

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

    fetch('https://localhost:7285/api/Authentication/SignUp',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: SignUpFormJson
    })
    .then((data) => console.log(data));
}

function attemptLogin(e){
    e.preventDefault();

    let signInFormJson = JSON.stringify(
        {
            email: e.target['emailAddress'].value,
            password: e.target['password'].value
    });

    fetch('https://localhost:7285/api/Authentication/SignIn',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: signInFormJson
    })
    .then(res => res.text())
    .then(data => localStorage.setItem('JWT', data))
    .finally(window.location.replace("ProductsPage.html"));
}

function optionalInputChange(e){

    if(e.target.value == ""){
        e.target.style.fontStyle = "italic";
    }
    else{
        e.target.style.fontStyle = "normal";
    }
}