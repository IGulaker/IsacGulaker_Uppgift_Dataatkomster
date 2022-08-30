localStorage.setItem('apiAccessKey', 'e2a228d1-95a9-4ade-8eab-5c14f5a24573');
localStorage.setItem('apiAdminAccessKey', '76dafbb3-465c-4922-8cf5-19c819362f16');

let products = [];
let placedOrders = [];

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
    .then(res => res.json())
    .then(customerProfile => {
        sessionStorage.setItem("CustomerProfile", JSON.stringify(customerProfile));
        let jsonProfile = JSON.parse(sessionStorage.getItem("CustomerProfile"));
        console.log('Current User: ' + jsonProfile.firstName + ' ' + jsonProfile.lastName);
        window.location.replace("ProductsPage.html");
    });
}

function getProducts(e){

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
        products.push(element);

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
        btn.value = element.eaN_13;
        btn.textContent = "Order";
        btn.classList.add("btn")
        btn.classList.add("btn-primary")
        btn.style.marginLeft = "30px";
        btn.style.marginBottom = "10px";
        btn.style.width = "150px"

        btn.addEventListener("click", (e) =>{
            products.forEach(product =>{
                if(product.eaN_13 == e.target.value){
                    placedOrders.push(product);
                }
            });

            document.querySelector("#checkout").textContent = "Placed Orders: " + placedOrders.length;
        });

        li.appendChild(p).appendChild(btn);
        document.querySelector("#listOfProducts").appendChild(li);
    });
}

function SubmitOrders(e){





    placedOrders.forEach(order => {
        let orderQuantity = 0;
        placedOrders.forEach(x => {
            if(x.eaN_13 == order.eaN_13)
            orderQuantity++;
            return;
        });

        customerProfile = JSON.parse(sessionStorage.getItem("CustomerProfile"));

        let jsonFormatedOrder = JSON.stringify({
            'productName': order.name,
            'productEAN_13': order.eaN_13,
            'productPrice': order.price,
            'productQuantity': orderQuantity,
            'customerFirstName': `${customerProfile.firstName}`,
            'customerLastName': `${customerProfile.lastName}`,
            'city': `${customerProfile.city}`,
            'postalCode': `${customerProfile.postalCode}`,
            'streetName': `${customerProfile.streetName}`,
            'residenceNumber': `${customerProfile.residenceNumber}`
        })

        fetch(`https://localhost:7285/api/Orders?key=${localStorage.getItem("apiAccessKey")}`,{
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${JSON.parse(sessionStorage.getItem("CustomerProfile")).accessToken}`
            },
            body: jsonFormatedOrder
        })
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