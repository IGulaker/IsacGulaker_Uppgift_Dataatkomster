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
    .then(res => {
        if(res.status === 200){
            window.location.replace("index.html");
        };
    });
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
    .then(data => {
        localStorage.setItem('JWT', data);
        console.log(localStorage.getItem("JWT"));
        window.location.replace("ProductsPage.html");
    });
}

function getProducts(e){
    e.preventDefault();

    fetch(`https://localhost:7285/api/Products?key=${localStorage.getItem("apiAccessKey")}`,{
        method: 'get',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(res => res.json())
    .then(data =>{
        listProducts(data)
    })
    
}

function listProducts(data){
    
    data.forEach(element => {
        var li = document.createElement("li");
        li.style.border = "solid 2px"

        var p = document.createElement("p");
        p.style.fontSize = "22px";
        

        p.innerHTML = `<br/><center><strong>${element.name}</strong><br/><br/>
                       ${element.description}<br/><br/>
                       Price: ${element.price}<br/>
                       Article number: ${element.eaN_13}<br/>
                       ${element.subcategory.name} ${element.subcategory.category.name}<br/><br/>
                       Manufacturer: ${element.manufacturer.name}`;

        var btn = document.createElement("button")
        btn.textContent = "Order";
        btn.classList.add("btn")
        btn.classList.add("btn-primary")
        btn.style.marginLeft = "30px";
        btn.style.marginBottom = "10px";
        btn.style.width = "150px"

        li.appendChild(p).appendChild(btn);
        document.querySelector("#listOfProducts").appendChild(li);
    });

    

    //jsonObj = JSON.parse(data);
    
    //var list = document.querySelector("listOfProducts");
    //for (let i of jsonObj) { var item = document.createElement("li"); list.appendChild(item); } 


}

function optionalInputChange(e){

    if(e.target.value == ""){
        e.target.style.fontStyle = "italic";
    }
    else{
        e.target.style.fontStyle = "normal";
    }
}