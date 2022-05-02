const URL = "https://resign.byiconic.at";
const API_URL = URL + "/api";

const LOCALSTORAGE_KEY = "userId";
const PASSWORDS_NOT_EQUAL = "pass_not_equal";

let USER;
let USER_ID;

//Functions from here
function readFromLocalStorage(keyword) {
  try{
    let result = localStorage.getItem(keyword);
    return result;
  }catch(error) {
    console.error(error);
    return undefined;
  }
}
function writeToLocalStorage(keyword, value) {
    if(keyword == undefined || value == undefined) {
        console.error(`(Func: ${arguments.callee.toString()}) Keyword or value cannot be undefined!`);
        //throw `(Func: ${arguments.callee.toString()}) Keyword or value cannot be undefined!`;
    }

    localStorage.setItem(keyword, value);
}

function isLoggedIn() {
  let localUserId = readFromLocalStorage(LOCALSTORAGE_KEY);

  if(localUserId == undefined)
    return false;

  USER_ID = localUserId;
  return true;
}

//[Async] function that returns a Promise of the response
function getResponse(httpverb, urlext, body){
    //check parameters
    const httpMethod = httpverb.toUpperCase();
    if(httpMethod !== 'GET'
      && httpMethod !== 'POST'
      && httpMethod !== 'PUT'
      && httpMethod !== 'DELETE')
        console.error(`HTTP Verb "${httpMethod}" not supported!`);


    //Build the request 🔥
    const reqUrl = API_URL + urlext;
    const request = {
        method: httpMethod, // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
          //'Content-Type': 'application/json'
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        //body: JSON.stringify(body) // body data type must match "Content-Type" header
    };

    //if body is set, add it to the request (as JSON)
    if(body !== undefined) {
      //Add body
      request.body = JSON.stringify(body);
      //Add content-type for body
      request.headers = {
        'Content-Type': 'application/json'
      };
    }

    return fetch(reqUrl, request);
}

async function login(username, password) {
  const res = await getLoginResponse(username, password);

  if (res.ok){
    //Save userId to localstorage
    
    writeToLocalStorage(LOCALSTORAGE_KEY, USER_ID);
    return true;
  }
  else {
    //Show "failed to login" message
    console.error("Failed to login, username or password wrong?");
    return false;
  }
}

async function register(username, firstname, lastname, password, confirmPassword, classId) {
  //Check if passwords are equal
  if(password !== confirmPassword) {
    return PASSWORDS_NOT_EQUAL;
  }

  const res = await getRegisterResponse(username, firstname, lastname, password, classId);

  if(res.ok){
    return true;
  }

  return false;
}

//function that registers a new user
async function getRegisterResponse(username, firstname, lastname, password, classId){
  const reqUrl = API_URL + "/user";
  const reqBody = {
    "username" : username,
    "firstname" : firstname,
    "lastname" : lastname,
    "classId": classId
  }
    const response = await fetch(reqUrl, {
      method: 'POST', // *GET, POST, PUT, DELETE, etc.
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        'Content-Type': 'application/json',
        'password': password
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
      body: JSON.stringify(reqBody) // body data type must match "Content-Type" header
    });

    user = await response.json();
    return response;
}
//function that checks if the given user and password represent an existing user in our system
async function getLoginResponse(username, password) {
    const reqUrl = API_URL + "/user/check";

    const response = await fetch(reqUrl, {
      method: 'GET', // *GET, POST, PUT, DELETE, etc.
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        //'Content-Type': 'application/json',
        'username': username,
        'password': password
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
      //body: JSON.stringify(reqBody) // body data type must match "Content-Type" header
    });

    USER = await response.json();
    USER_ID = USER.id;

    return response;
}

//Gets the current status of the user, if he is checked in or checked out currently (or undefined if not logged in)
async function getCurrentStatus() {
  if(USER_ID == undefined){
    console.error("USER_ID not specified");
    return undefined;
  }

  const response = await getResponse("GET", `/interaction/latest/${USER_ID}`, undefined);

  console.log(response);

  const jsonResponse = await response.json();


  return jsonResponse.type == 0 ? "in" : "out";
}