
    // api url
    const api_url =
    " https://localhost:44393/api/Product/Index";
    // Defining async function
    async function getapi(url) {

        // Storing response
        const response = await fetch(url);

        // Storing data in form of JSON
        var data = await response.json();
        console.log(data);
        if (response) {
        hideloader();
        }
        show(data);
    }
    // Calling that async function
    getapi(api_url);

    // Function to hide the loader
    function hideloader() {
        document.getElementById('loading').style.display = 'none';
    }
    // Function to define innerHTML for HTML table
    function show(data) {
        let tab =
            ``;

        // Loop to access all rows
        for (let r of data) {
        tab += ` <div class="col-lg-3 col-md-4 col-sm-6 mix">
            <div class="car__item">
                <div class="car__item__pic__slider owl-carousel">
                    <img src="img/cars/car-1.jpg" alt="">
                    <img src="img/cars/car-8.jpg" alt="">
                    <img src="img/cars/car-6.jpg" alt="">
                    <img src="img/cars/car-3.jpg" alt="">
                </div>
            
            <div class="car__item__text">
                    <div class="car__item__text__inner">
                        <div class="label-date">${r.id}</div>
                        <h5><a href="#">${r.name}</a></h5>
                        <ul>
                            <li><span>${r.quantity}</span> mi</li>
                            <li>Auto</li>
                            <li><span>${r.created_Date}</span> hp</li>
                        </ul>
                    </div>
                    <div class="car__item__price">
                        <span class="car-option">For Rent</span>
                        <h6>${r.price}<span>/Month</span></h6>
                    </div>
            </div>
             </div>
                    </div>`;
        }
        // Setting innerHTML as tab variable
        document.getElementById("myData").innerHTML = tab;
    }
