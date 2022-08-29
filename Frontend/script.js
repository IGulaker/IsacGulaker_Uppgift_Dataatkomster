function submitNewUser(e){
    e.preventDefault()

    let json = JSON.stringify(
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
    })

    fetch('https://localhost:7285/api/Authentication/SignUp?keY=e2a228d1-95a9-4ade-8eab-5c14f5a24573',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })

    console.log(json)
}