function submitNewUser(e){
    e.preventDefault()

    let json = JSON.stringify(
        {
            firstName: e.target['firstName'].value,
            lastname: e.target['emailAddress'].value,
            phoneNumber: e.target['phoneNumber'].value,
            alternativePhoneNumber: e.target['alternativePhoneNumber'].value,
            address: {
                city: e.target['city'],
                postalCode: e.target['postalCode'],
                streetName: e.target['streetName'],
                residenceNumber: e.target['citresidenceNumbery']
            },
            password: e.target['password']
    })

    fetch('https://localhost:7285/api/Authentication/SignUp?keY=e2a228d1-95a9-4ade-8eab-5c14f5a24573',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })

    console.log(e.target['firstName'].value)
    e.target['firstName'].value = ''
}