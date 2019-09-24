// let getDogImage = () => {
//     const xhr = new XMLHttpRequest();
//     xhr.open("GET", "https://dog.ceo/api/breeds/image/random");

//     let url = "";
//     xhr.onload = function () {
//         // this will return the JSON response
//         url = JSON.parse(this.response).message;
//         document.getElementById("dog-image").setAttribute("src", url);
//         console.log(this.responseText);
//     };

//     xhr.send();
// };

// getDogImage();

//=======================================================================================
    
// let makeRequest = (HTTPVerb, url) => {
//     return new Promise((resolve, reject) => {
//         const xhr = new XMLHttpRequest();
//         xhr.open(HTTPVerb, url);

//         let src = "";
//         xhr.onload = function () {
//             if (this.status === 200 ){
//                 resolve();
//             }
//             else {
//                 //reject(this.error);
//                 throw "Error";
//             }
//             // this will return the JSON response
//             src = JSON.parse(this.response).message;
//             document.getElementById("dog-image").setAttribute("src", src);
//             console.log(this.responseText);
//         };
//         xhr.onerror = () => {
//             reject({
//                 status: this.status,
//                 statusText: xhr.statusText
//             });
//         }
//         xhr.send();
//     })
//     .catch(error => console.log("There was an error!", error.statusText));
// };

// makeRequest("GET", "https://dog.ceo/api/breeds/image/random");

//==========================================================================================

// let fetchDogPicture = function(){
//     fetch("https://dog.ceo/api/breeds/image/random")
//     .then(response => {
//         console.log(response);
//         return response.json();
//     })
//     .then(data => setDogImage(data))
//     .catch(error => console.log(error));
// };
// fetchDogPicture();

let setDogImage = (json) => {
    if (json.status === "error"){
        throw "An Error Occured";
    }
    url = json.message;
    console.log(url);
    document.getElementById("dog-image").setAttribute("src", url);
};


const asyncDogFetch = async () => {
    try{
        const response = await fetch("https://dog.ceo/api/breeds/image/random");
        const json = await response.json();
        console.log(json);
        Promise.resolve(json);
        setDogImage(json);
    } catch (err){
        console.log(err);
    }
    
}; 

//asyncDogFetch();

let fetchAllDogBreeds = async () => {
    try{
        const response = await fetch("https://dog.ceo/api/breeds/list/all");
        const json = await response.json();
        console.log(json);
        Promise.resolve(json);
        createDogList(json);
    } catch (err){
        console.log(err);
    }
};

let createDogList = (json) =>{
    let dogList = document.getElementsByClassName("dogs-list")[0];
    let dogBreeds = Object.keys(json.message);
    console.log(dogBreeds);
    for(let i=0; i < dogBreeds.length; i++){
        let li = document.createElement("li");
        li.innerHTML = dogBreeds[i];
        dogList.appendChild(li);
    }
};

//fetchAllDogBreeds();

let BuildPage = () => {

    Promise.all([asyncDogFetch(), fetchAllDogBreeds()]).then(function (values) {
        console.log(values);
        setDogImage(values[0]);
        createDogList(values[1]);
    });
};

BuildPage();