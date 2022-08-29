function onSubmit(e){
    e.preventDefault()

    let json = JSON.stringify({categoryName : e.target['categoryName'].value})

    fetch('https://localhost:7020/api/Categories', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })

    console.log(e.target['categoryName'].value)

    e.target['categoryName'].value = ''
}