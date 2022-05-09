const URL = "https://aduno.byiconic.at";
const API_URL = URL + "/api";

const LOCALSTORAGE_KEY = "userToken";
const PASSWORDS_NOT_EQUAL = "pass_not_equal";

let USER;
let USER_ID;
let USER_JWT_TOKEN;

//Functions from here

function getAllUrlParams() {
  const params = new Proxy(new URLSearchParams(window.location.search), {
    get: (searchParams, prop) => searchParams.get(prop),
  });

  return params;
}

function parseJwt(token) {
  var base64Url = token.split('.')[1];
  var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
  }).join(''));

  return JSON.parse(jsonPayload);
};

function getUserFromJwtToken(token) {
  const jwtData = parseJwt(token);

  console.log("getUserFromJwt(): ");
  console.log(token);

  let result = {
    "id": jwtData.userId,
    "username": jwtData.username,
    "firstname": jwtData.firstname,
    "lastname": jwtData.lastname,
    "classId": jwtData.classId,
    "role": jwtData.role
  };

  return result;
}

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
  let localUserToken = readFromLocalStorage(LOCALSTORAGE_KEY);

  if(localUserToken == undefined)
    return false;

  USER_JWT_TOKEN = localUserToken;
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
          "Authorization": "Bearer " + USER_JWT_TOKEN
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
    //Save jwt token to localstorage
    
    writeToLocalStorage(LOCALSTORAGE_KEY, USER_JWT_TOKEN);
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
    const reqUrl = API_URL + "/user/createjwt";

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

    const data = await response.json();

    USER_JWT_TOKEN = data.token;
    USER = getUserFromJwtToken(USER_JWT_TOKEN);
    USER_ID = USER.id;

    console.log(USER);
    console.log(USER_ID);

    return response;
}

//Gets the current status of the user, if he is checked in or checked out currently (or undefined if not logged in)
async function getCurrentStatus() {
  if(USER_JWT_TOKEN == undefined){
    console.error("USER_JWT_TOKEN not specified");
    return undefined;
  }

  const response = await getResponse("GET", `/interaction/latest/${USER_ID}`, undefined);

  //Check if response is 204 or 200 (204 means there is no interaction for today yet; 200 returns the latest one of today)
  if(response.status == 204)
    return "out";
  
  //else, return type of latest interaction
  let jsonResponse = await response.json();
  return jsonResponse.type == 0 ? "in" : "out";
}